using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace.Model
{
    public class Account
    {
        private string username;
        private string password;
        private int type;

        public Account() { }

        public Account(string username, int type, string password = null)
        {
            this.Username = username;
            this.Type = type;
            this.Password = password;
        }

        public Account(DataRow row)
        {
            this.Username = row["Username"].ToString();
            this.Type = (int)row["Type"];
            this.Password = row["Password"].ToString();
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int Type { get => type; set => type = value; }
    }
}
