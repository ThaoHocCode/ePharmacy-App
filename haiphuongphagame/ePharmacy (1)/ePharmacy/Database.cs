using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePharmacy
{
    class Database
    {
        private static readonly string connectionString = "Data Source=LEVUHAI; Database=ePharmacy; " +
                                "user id=sa;password=123;MultipleActiveResultSets=True;";
        private SqlConnection sqlConn;

        public Database()
        {
            sqlConn = new SqlConnection(connectionString);
        }

        public DataTable Execute(string sqlStr)
        {
            using (SqlDataAdapter da = new SqlDataAdapter(sqlStr, sqlConn))
            {
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
        }

        public DataTable ExecuteWithParameters(string sqlStr, SqlParameter[] parameters)
        {
            using (SqlCommand cmd = new SqlCommand(sqlStr, sqlConn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }

        public int ExecuteNonQuery(string sqlStr, SqlParameter[] parameters)
        {
            try
            {
                if (sqlConn.State != ConnectionState.Open)
                    sqlConn.Open();

                using (SqlCommand cmd = new SqlCommand(sqlStr, sqlConn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
            }
        }

        public static string GetConnectionString()
        {
            return connectionString;
        }
    }
}
