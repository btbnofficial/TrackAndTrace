using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace.Model
{
    public class DataProvider
    {
        public const string connectionString = @"Data Source=DESKTOP-014K6AU\SQL2012;Initial Catalog=TracknTrace;Integrated Security=True;";

        public static DataTable GetList(string query, SqlParameter[] pars = null, bool isProcedure = false)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            DataTable dt = new DataTable();

            try
            {
                conn.Open();

                SqlCommand comm = new SqlCommand();

                comm.Connection = conn;
                comm.CommandText = query;

                if(isProcedure)
                {
                    comm.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    comm.CommandType = CommandType.Text;
                }

                if(pars!=null && pars.Length > 0)
                {
                    comm.Parameters.AddRange(pars);
                }

                SqlDataAdapter dataAdapter = new SqlDataAdapter(comm);

                dataAdapter.Fill(dt);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        
        public static bool Execute(string query, SqlParameter[] pars = null, bool isProcedure = false)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            bool isThucHien = false;

            try
            {
                conn.Open();

                SqlCommand comm = new SqlCommand();
                
                comm.Connection = conn;
                comm.CommandText = query;

                if (isProcedure)
                {
                    comm.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    comm.CommandType = CommandType.Text;
                }

                if (pars != null && pars.Length > 0)
                {
                    comm.Parameters.AddRange(pars);
                }

                isThucHien = (comm.ExecuteNonQuery() > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return isThucHien;
        }
        
    }
}
