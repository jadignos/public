using CourierPleaseScraper.Properties;
using System;
using System.Windows.Forms;

namespace CourierPleaseScraper
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
            txtKey.Text = Settings.Default.KEY;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Settings.Default.KEY = txtKey.Text;
            MessageBox.Show("SAVED!");
            Dispose();
        }
    }
}
