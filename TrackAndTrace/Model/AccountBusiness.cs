using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAndTrace.Model;

namespace TrackAndTrace.Model
{
    public class AccountBusiness
    {
        public static List<Account> LayDanhSachAccount()
        {
            List<Account> lstAccount = new List<Account>();

            SqlConnection conn = new SqlConnection(DataProvider.connectionString);

            try
            {
                conn.Open();

                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "usp_GetListAccount";

                SqlDataReader reader = comm.ExecuteReader();

                Account objAccount;
                while (reader.Read())
                {
                    objAccount = new Account();
                    objAccount.Username = reader.GetString(reader.GetOrdinal("Username"));
                    objAccount.Type = reader.GetInt32(reader.GetOrdinal("Type"));
                    lstAccount.Add(objAccount);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return lstAccount;
        }

        public static bool Login(string username, string password)
        {
            List<Account> lstAccout = new List<Account>();
            SqlParameter[] pars = new SqlParameter[2];
            pars[0] = new SqlParameter("@Username", SqlDbType.VarChar, 100);
            pars[0].Value = username;

            pars[1] = new SqlParameter("@Password", SqlDbType.VarChar, 100);
            pars[1].Value = password;

            SqlConnection conn = new SqlConnection(DataProvider.connectionString);

            try
            {
                conn.Open();

                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "usp_AccountLogin";
                comm.Parameters.AddRange(pars);

                Account objAccount;
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    objAccount = new Account();
                    objAccount.Username = reader.GetString(reader.GetOrdinal("Username"));
                    objAccount.Password = reader.GetString(reader.GetOrdinal("Password"));
                    objAccount.Type = reader.GetInt32(reader.GetOrdinal("Type"));
                    lstAccout.Add(objAccount);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            if (lstAccout.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Account GetAccountByUsername(string username)
        {
            DataTable dt = DataProvider.GetList("select * from Account where Username = '" + username + "'");

            foreach (DataRow row in dt.Rows)
            {
                return new Account(row);
            }
            return null;
        }

        public static void ChangeAccountPassword(string username, string password)
        {
            SqlParameter[] pars = new SqlParameter[2];

            pars[0] = new SqlParameter("@Username", SqlDbType.VarChar, 100);
            pars[0].Value = username;

            pars[1] = new SqlParameter("@NewPassword", SqlDbType.VarChar, 100);
            pars[1].Value = password;

            DataProvider.Execute("usp_ChangeAccountPassWord", pars, true);
        }
    }
}
