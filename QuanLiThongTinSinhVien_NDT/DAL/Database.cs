using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class Database
    {
        private static string connectString = @"Data Source=LAPTOP-DGOD7QP8\SQLEXPRESS;Initial Catalog=QuanLiSinhVien;Integrated Security=True";
        public static SqlConnection conn = new SqlConnection();
        public Database()
        {
            try
            {
                conn.ConnectionString = connectString;
                conn.Open();
                conn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
