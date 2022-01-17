using CourierPleaseScraper.Manager;
using CourierPleaseScraper.Model;
using CourierPleaseScraper.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace CourierPleaseScraper
{
    public partial class MainForm : Form
    {
        private readonly Stopwatch stopwatch;
        private readonly Timer timer;
        private readonly List<ConsignmentCouponReport> reports;
        private readonly ProcessManager process;

        public MainForm()
        {
            InitializeComponent();

            stopwatch = new Stopwatch();

            timer = new Timer { Interval = 100, Enabled = true };
            timer.Tick += (sender, e) => lblTimeElapse.Text = $"Time Elapse {stopwatch.Elapsed:hh\\:mm\\:ss\\.f}";

            reports = new List<ConsignmentCouponReport>();

            process = new ProcessManager();
            process.UpdatePercentage = percent => progressbar.Value = percent;
            process.UpdateStatus = status =>
            {
                txtStatus.AppendText(status);
                txtStatus.AppendText(Environment.NewLine);
            };
            process.UpdateData = data =>
            {
                reports.Add(data); // csv export
                AddToDataGrid(data);
                groupData.Text = $"DATA ({dataGrid.Rows.Count})";
                dataGrid.CurrentCell = dataGrid.Rows[dataGrid.Rows.Count - 1].Cells[0];
            };
        }

        private async void btnProcessNow_ClickAsync(object sender, EventArgs e)
        {
            StartedState();

            var lines = txtTrackingNumbers.Text.Split(
                new string[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);

            process.TrackingNumbers = lines.ToList();
            await process.RunAsync();

            CompletedState();
        }

        private void AddToDataGrid(ConsignmentCouponReport data)
        {
            string[] row = {
                    data.ConsignmentNo,
                    data.Date,
                    data.DeliveryETA,
                    data.POPShopDropOff,
                    data.Details,
                    data.Remarks,
                    data.DeadWeight,
                    data.Volume,
                    data.Service,
                    data.Status,
                    data.DeliveredAt,
                    data.POD,
                    data.References,
                    data.ItemsCoupons,
                    data.Date,
                    data.Time,
                    data.Contractor,
                    data.ContId,
                    data.Detail,
                    data.Grouping
                };
            dataGrid.Rows.Add(row);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "CSV FILES (*.csv)|*.csv";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                new CsvWriter<ConsignmentCouponReport>(dialog.FileName, reports);
                txtStatus.AppendText(Environment.NewLine);
                txtStatus.AppendText(Environment.NewLine);
                txtStatus.AppendText($"File saved in {dialog.FileName}");
            }
        }

        private void StartedState()
        {
            reports.Clear();
            stopwatch.Restart();
            timer.Start();
            txtStatus.Clear();
            dataGrid.Rows.Clear();
            btnProcessNow.Enabled = false;
            progressbar.Visible = true;
        }

        private void CompletedState()
        {
            stopwatch.Stop();
            timer.Stop();
            lblTimeElapse.Text += " DONE!";
            btnProcessNow.Enabled = true;
            progressbar.Visible = false;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) => new About().ShowDialog();

        private void configToolStripMenuItem_Click(object sender, EventArgs e) => new Config().ShowDialog();
    }
}
