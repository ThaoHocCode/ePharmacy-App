using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ePharmacy
{
    public class Khach_hang
    {
        public string tenNhanVien(string sdt)
        {
            string query = "select FullName from [User] where TelephoneNumber=@sdt";
            using (SqlConnection doi_tuong = new SqlConnection(Database.GetConnectionString()))
            {
                doi_tuong.Open();
                SqlCommand yeu_cau = new SqlCommand(query, doi_tuong);
                yeu_cau.Parameters.AddWithValue("@sdt", sdt);
                string tenNV = (string)yeu_cau.ExecuteScalar();
                return tenNV;
            }
        }

       // public 
    }
}
