using FastwayApiManager.Manager;
using FastwayApiManager.Model;
using FastwayTrackAndTrace;
using FastwayTrackAndTrace.Factory;
using FastwayTrackAndTrace.Manager;
using FastwayTrackAndTrace.Model;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace FastwayApiManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            cboCountryCode.DataSource = Enum.GetValues(typeof(CountryCode));
            ConfigurationManager.Initialize();
        }

        private async void btnTrackLabels_Click(object sender, EventArgs e)
        {
            txtStatus.Clear();

            tsProgressBar.Visible = true;
            tsStatusLabel.Visible = true;
            btnTrackLabels.Enabled = false;

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var process = new ProcessFactory(
                new ClientManager
                {
                    BaseUrl = ConfigurationManager.BaseUrl,
                    InvocationUrl = ConfigurationManager.InvocationUrl,
                    ApiKey = ConfigurationManager.ApiKey,
                    CountryCode = (int)(CountryCode)cboCountryCode.SelectedValue
                },
                new ExcelManager
                {
                    BaseDirectory = ConfigurationManager.DefaultSaveLocation
                });
            process.ReportStatus = (status) => txtStatus.AppendText(status);
            process.ReportProgress = (progress) =>
            {
                tsProgressBar.Value = progress;
                tsStatusLabel.Text = $"Processing {progress}%";
            };
            process.TrackingLabels = txtTrackingLabels.Lines.ToList();
            await process.Process();

            stopWatch.Stop();
            txtStatus.AppendText($"Time Elapse: {stopWatch.ElapsedMilliseconds} milliseconds");

            btnTrackLabels.Enabled = true;
            tsProgressBar.Visible = false;
            tsStatusLabel.Visible = false;
        }

        private void txtTrackingLabels_TextChanged(object sender, EventArgs e)
        {
            if (txtTrackingLabels.Lines.Length > Default.Input.MAX_LINES)
            {
                txtTrackingLabels.Undo();
                txtTrackingLabels.ClearUndo();
                MessageBox.Show($"Only {Default.Input.MAX_LINES} lines are allowed");
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var optionForm = new ConfigurationForm();
            optionForm.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, $@"{Application.StartupPath}\Help\index.html");
        }
    }
}
