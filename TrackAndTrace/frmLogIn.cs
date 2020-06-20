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
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;
            this.CancelButton = btnCancel;

            string usernameTemp = ConfigurationManager.AppSettings["usernameTemp"].ToString();
            string passwordTemp = ConfigurationManager.AppSettings["passwordTemp"].ToString();

            txtAccount.Text = usernameTemp;
            txtPassword.Text = passwordTemp;

            //string query2 = "select count(*) as count from temporaryAccount";
            //DataTable dt2 = DataProvider.GetList(query2, null, false);
            //int count = int.Parse(dt2.Rows[0]["count"].ToString());

            //if(count!=0)
            //{
            //    string query = "select top 1 username from temporaryAccount";
            //    DataTable dt = DataProvider.GetList(query, null, false);
            //    string username = dt.Rows[0]["username"].ToString();

            //    string query1 = "select top 1 password from temporaryAccount";
            //    DataTable dt1 = DataProvider.GetList(query1, null, false);
            //    string password = dt1.Rows[0]["password"].ToString();

            //    if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            //    {
            //        txtAccount.Text = username;
            //        txtPassword.Text = password;
            //    }
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtAccount.Text;
                string password = txtPassword.Text;
                if (Login(username, password))
                {
                    AccountBusiness accountBusiness = new AccountBusiness();
                    Account logInAccount = accountBusiness.GetAccountByUsername(username);
                    frmChooseDocument f = new frmChooseDocument(username);
                    f.Show();
                    this.Hide();
                    //Luu password va username tam thoi vao app.Config
                    //ConfigurationManager.AppSettings.Set("usernameTemp", txtAccount.Text);
                    //ConfigurationManager.AppSettings.Set("passwordTemp", txtPassword.Text);
                    Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    configuration.AppSettings.Settings["usernameTemp"].Value = txtAccount.Text;
                    configuration.AppSettings.Settings["passwordTemp"].Value = txtPassword.Text;
                    configuration.Save();
                    ConfigurationManager.RefreshSection("appSettings");
                }
                else
                {
                    MessageBox.Show("Sai ten tai khoan hoac mat khau!", "Thong bao!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo!");
            }
        }

        private bool Login(string username, string password)
        {
            return AccountBusiness.Login(username, password);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            frmChangeConnection f = new frmChangeConnection();
            this.Hide();
            f.Show();
        }

        private void FrmLogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }
    }
}
