using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KOMIKA.DAL
{
    public class Shared
    {
        public string ConnStr
        {
            get
            {
                return "Data Source=.;Initial Catalog=KOMIKA;Integrated Security=True;";
                return "Server=tcp:mariasherly.database.windows.net,1433;Initial Catalog=AKPSI;Persist Security Info=False;User ID=mariasherly;Password=terserah123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            }
        }

        public string getstring(string SQL)
        {
            string result = "";
            using (SqlConnection con = new SqlConnection(ConnStr))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(SQL, con))
                {
                    result = com.ExecuteScalar().ToString();
                }
            }
            return result;
        }

        public int getint(string SQL)
        {
            return Convert.ToInt32(getstring(SQL));
        }

        protected DataTable getdt(string SQL)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnStr))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(SQL, conn))
                    {
                        conn.Open();
                        da.Fill(dt);
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return dt;
        }


        protected bool excutenonquery(string SQL)
        {
            bool outs = false;
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand(SQL, conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    outs = true;
                }
                catch (Exception ex)
                {
                    outs = false;
                }
            }
            return outs;
        }
    }
}