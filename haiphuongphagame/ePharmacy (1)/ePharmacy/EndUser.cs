using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePharmacy
{
    public class EndUser
    {
        public string strCnn = "Data Source=LEVUHAI; Database=ePharmacy; " +
                                "user id=sa;password=123;MultipleActiveResultSets=True;";


        //Enroll in
        public int kiem_tra_tai_khoan(string sdt, string mk)
        {
            string query = "select count(*) from [User] where TelephoneNumber=@sdt and Password=@mk";
            using (SqlConnection doi_tuong = new SqlConnection(strCnn))
            {
                doi_tuong.Open();
                SqlCommand yeu_cau = new SqlCommand(query, doi_tuong);
                yeu_cau.Parameters.AddWithValue("@sdt", sdt);
                yeu_cau.Parameters.AddWithValue("@mk", mk);
                int count = (int)yeu_cau.ExecuteScalar();
                return count;
            }
        }

        public string kiem_tra_vi_tri(string sdt, string mk)
        {
            string query = "select position from [User] where TelephoneNumber=@sdt and Password=@mk"; ;
            using (SqlConnection doi_tuong = new SqlConnection(strCnn))
            {
                doi_tuong.Open();
                SqlCommand yeu_cau = new SqlCommand(query, doi_tuong);
                yeu_cau.Parameters.AddWithValue("@sdt", sdt);
                yeu_cau.Parameters.AddWithValue("@mk", mk);
                string position = (string)yeu_cau.ExecuteScalar();
                return position;
            }
        }

        public string kiem_tra_ten_khach_hang(string sdt, string mk)
        {
            string query = "select FullName from [User] where TelephoneNumber=@sdt and Password=@mk";
            using (SqlConnection doi_tuong = new SqlConnection(strCnn))
            {
                doi_tuong.Open();
                SqlCommand yeu_cau = new SqlCommand(query, doi_tuong);
                yeu_cau.Parameters.AddWithValue("@sdt", sdt);
                yeu_cau.Parameters.AddWithValue("@mk", mk);
                string tenKhachHang = (string)yeu_cau.ExecuteScalar();
                return tenKhachHang;
            }
        }

        //Register
        public bool updateData(string fullname, string date, string sdt, string position, string mk)
        {
            int count1 = 0;
            string query = "insert into [User] (FullName, Date,TelephoneNumber,Position,Password) values (@fullname,@date,@sdt,@position,@mk)";
            string query_db = "insert into Information_User (SoDienThoai,GioiTinh,DiemTichLuy) values (@sdt,@gt,@dtl)";
            using (SqlConnection doi_tuong = new SqlConnection(strCnn))
            {
                doi_tuong.Open();
                SqlCommand yeu_cau = new SqlCommand(query, doi_tuong);
                yeu_cau.Parameters.AddWithValue("@fullname", fullname);
                yeu_cau.Parameters.AddWithValue("@date", date);
                yeu_cau.Parameters.AddWithValue("@sdt", sdt);
                yeu_cau.Parameters.AddWithValue("@position", position);
                yeu_cau.Parameters.AddWithValue("@mk", mk);
                count1 = yeu_cau.ExecuteNonQuery();

            }
            using (SqlConnection doi_tuong = new SqlConnection(strCnn))
            {
                doi_tuong.Open();
                SqlCommand yeu_cau = new SqlCommand(query_db, doi_tuong);
                yeu_cau.Parameters.AddWithValue("@sdt", sdt);
                yeu_cau.Parameters.AddWithValue("@gt", "null");
                yeu_cau.Parameters.AddWithValue("@dtl", 0);
                int count2 = yeu_cau.ExecuteNonQuery();
                if (count2 > 0 & count1 > 0)
                    return true;
                else
                {
                    return false;
                }
            }
        }

    }
}
