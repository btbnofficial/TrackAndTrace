using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using static System.Net.WebRequestMethods;

namespace TrackAndTrace.Model
{
    public class DataProvider
    {
        //public static string connectionString = @"Data Source=DESKTOP-014K6AU\SQL2012;Initial Catalog=TracknTrace;Integrated Security=True;User ID=;Password=";
        //public const string connectionString = @"Data Source=DESKTOP-014K6AU\SQL2012;Initial Catalog=TracknTrace;Integrated Security=True;";
        //public static string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public static string connectionString = ConfigurationManager.AppSettings["ConnectionString"].ToString();

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

        //Trả về 1 chuỗi json string với dữ liệu được get từ api
        public static string GetRESTDats(string uri, string token)
        {
            var webRequest__1 = (HttpWebRequest)WebRequest.Create(uri);
            webRequest__1.Method = "GET";
            webRequest__1.Headers["authorization"] = "Bearer " + token;
            // webRequest__1.IfModifiedSince = Date.Parse(("Mon, 01 Aug 2016 18:42:32 PDT").Replace("PDT", "-0700"))
            webRequest__1.ContentType = "application/json";
            var webResponse = (HttpWebResponse)webRequest__1.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string content = reader.ReadToEnd();
            return content;
        }

        public static string GetRESTDats2(string uri, string token)
        {
            var webRequest__1 = (HttpWebRequest)WebRequest.Create(uri);
            webRequest__1.Method = "POST";
            webRequest__1.Headers["authorization"] = "Bearer " + token;
            // webRequest__1.IfModifiedSince = Date.Parse(("Mon, 01 Aug 2016 18:42:32 PDT").Replace("PDT", "-0700"))
            webRequest__1.ContentType = "application/json";
            webRequest__1.ContentLength = 0;
            var webResponse = (HttpWebResponse)webRequest__1.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string content = reader.ReadToEnd();
            return content;
        }

        public static string GetRESTDats3(string uri, string token, List<Pnl> plan)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json; charset=utf-8";
            httpWebRequest.Headers["authorization"] = "Bearer " + token;
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                
                var loginjson = new JavaScriptSerializer().Serialize(plan);

                streamWriter.Write(loginjson);
                streamWriter.Flush();
                streamWriter.Close();

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return result;
                }
            }

        }

        //trả về 1 đối tượng ở lớp TestAccessToken 
        public static AccessToken GetTokenDictionary(string userName, string password, string url)
        {
            //Dim content = New Http.FormUrlEncodedContent(pairs)
            //string data = "grant_type=password&username=dms_admin@unza.com&password=Wuvl@1234";
            StringContent content = new StringContent("grant_type=password&username="+userName+"&password="+password+""
                , UnicodeEncoding.UTF8, "application/x-www-form-urlencoded");
            using (var client = new HttpClient())
            {
                var response = client.PostAsync(url, content).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                var arr = JsonConvert.DeserializeObject<AccessToken>(result);
                // Deserialize the JSON into a Dictionary<string, string>
                // Dim tokenDictionary As Dictionary(Of String, String) = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(result)
                return arr;
            }
        }
    }
}
