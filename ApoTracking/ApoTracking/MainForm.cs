using ApoTracking.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ApoTracking
{
    public partial class MainForm : Form
    {
        private readonly string url = "https://digitalapi.auspost.com.au/shipping/v1/track?tracking_ids=";
        private string username;
        private string password;
        private string accountNo;

        public MainForm()
        {
            InitializeComponent();
            username = Settings.Default.Username;
            password = Settings.Default.Password;
            accountNo = Settings.Default.AccountNumber;
        }

        private async void GoButton_Click(object sender, EventArgs e)
        {
            Clear();
            btnGo.Enabled = false;

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            txtStatus.AppendText($"STARTED: {DateTime.Now.ToLongTimeString()}{Environment.NewLine}{Environment.NewLine}");

            var process = new ProcessFactory(
                new Client
                {
                    UserName = username,
                    Password = password,
                    Url = url,
                    AccountNumber = accountNo
                },
                txtInput.Lines.ToList());
            process.ReportStatus = (status) =>
            {
                txtStatus.AppendText(status);
                txtStatus.AppendText(Environment.NewLine);
                txtStatus.AppendText(Environment.NewLine);
            };
            process.ReportResult = (results) =>
            {
                if (results.Count != 0)
                {
                    foreach (var result in results)
                    {
                        string[] dataRow =
                        {
                            result.tracking_id,
                            result.status,
                            result.article_id,
                            result.product_type,
                            result.location,
                            result.description,
                            result.date,
                            result.time
                         };
                        gridview.Rows.Add(dataRow);
                    }
                    gridview.FirstDisplayedCell = gridview.Rows[gridview.Rows.Count - 1].Cells[0];
                }
            };
            await process.Process();

            stopWatch.Stop();
            txtStatus.AppendText($"COMPLETED: {DateTime.Now.ToLongTimeString()}");
            txtStatus.AppendText(Environment.NewLine);
            txtStatus.AppendText($"TIME ELAPSE: {stopWatch.ElapsedMilliseconds} milliseconds");

            btnGo.Enabled = true;
        }

        private string dataTableToCsv(DataTable dt)
        {
            var stringBuilder = new StringBuilder();
            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
            stringBuilder.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                stringBuilder.AppendLine(string.Join(",", fields));
            }
            return stringBuilder.ToString();
        }

        private void nothingToSeeHereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var dataTable = GetDataTable(gridview);
                File.WriteAllText(dialog.FileName, dataTableToCsv(dataTable));

                txtStatus.AppendText(Environment.NewLine);
                txtStatus.AppendText(Environment.NewLine);
                txtStatus.AppendText($"File saved in {dialog.FileName}");
            }
        }

        private DataTable GetDataTable(DataGridView gridView)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn col in gridView.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in gridView.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }
            return dt;
        }

        private void Clear()
        {
            gridview.Rows.Clear();
            txtStatus.Text = "";
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AboutBox();
            form.ShowDialog();
        }

        private void credentialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Credential();
            form.ShowDialog();
        }
    }
}
