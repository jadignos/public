using FastwayTrackAndTrace.Manager;
using FastwayTrackAndTrace.Model;
using FastwayTrackAndTrace.Properties;
using System;
using System.Windows.Forms;

namespace FastwayTrackAndTrace
{
    public partial class ConfigurationForm : Form
    {
        public ConfigurationForm()
        {
            InitializeComponent();

            ConfigurationManager.Initialize();       
            txtBaseUrl.Text = ConfigurationManager.BaseUrl;
            txtInvocationUrl.Text = ConfigurationManager.InvocationUrl;
            txtApiKey.Text = ConfigurationManager.ApiKey;
            txtBrowse.Text = ConfigurationManager.DefaultSaveLocation;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ConfigurationManager.BaseUrl = txtBaseUrl.Text;
            ConfigurationManager.InvocationUrl = txtInvocationUrl.Text;
            ConfigurationManager.ApiKey = txtApiKey.Text;
            ConfigurationManager.DefaultSaveLocation = txtBrowse.Text;
            ConfigurationManager.Save();
            MessageBox.Show("Changes has been saved!");
        }
        
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                var result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                    txtBrowse.Text = dialog.SelectedPath;
            }
        }
    }
}
