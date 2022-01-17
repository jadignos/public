using ApoTracking.Properties;
using System;
using System.Windows.Forms;

namespace ApoTracking
{
    public partial class Credential : Form
    {
        public Credential()
        {
            InitializeComponent();
            txtUsername.Text = Settings.Default.Username;
            txtPassword.Text = Settings.Default.Password;
            txtAccountNo.Text = Settings.Default.AccountNumber;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.Default.Username = txtUsername.Text;
                Settings.Default.Password = txtPassword.Text;
                Settings.Default.AccountNumber = txtAccountNo.Text;
                Settings.Default.Save();
                MessageBox.Show("Saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unknown Error!\n\n{ex.Message}");
            }
        }
    }
}
