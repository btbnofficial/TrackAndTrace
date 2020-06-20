using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackAndTrace.Model;

namespace TrackAndTrace
{
    public partial class frmChangeConnection : Form
    {
        public frmChangeConnection()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmChangeConnection_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmLogIn f = new frmLogIn();
            f.Show();
        }

        private void BtnChangeConnection_Click(object sender, EventArgs e)
        {
            string dataSource = txtDataSource.Text;
            string initialCatalog = txtInitialCatalog.Text;
            string userId = txtUserId.Text;
            string password = txtPassword.Text;

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["DataSource"].Value = dataSource;
            config.AppSettings.Settings["InitialCatalog"].Value = initialCatalog;
            config.AppSettings.Settings["UserID"].Value = userId;
            config.AppSettings.Settings["Password"].Value = password;
            string connectionString = @"Data Source=" + dataSource + ";Initial Catalog=" + initialCatalog + ";Integrated Security=True;User ID=" + userId + ";Password=" + password + "";
            config.AppSettings.Settings["ConnectionString"].Value = connectionString;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");


            this.Close();
            //DataProvider.connectionString = connectionString;

            //var configFile = ConfigurationManager.OpenExeConfiguration(@"D:\Work\TrackAndTrace\TrackAndTrace\TrackAndTrace\TrackAndTrace\App.config");
            //configFile.AppSettings.Settings[1].Value = connectionString;
            //configFile.Save();
            //ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString = connectionString;
        }
    }
}
