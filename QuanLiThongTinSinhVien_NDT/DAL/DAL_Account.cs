using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAL
{
    public class DAL_Account
    {
        Database dtb = new Database();
        public DataTable getDataACC()
        {
            DataTable dt = new DataTable();
            string sqlcommamd = "sp_getDataFromTableAccount";
            SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
            sqlcm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlad = new SqlDataAdapter(sqlcm);
            sqlad.Fill(dt);
            return dt;
        }
        public int insertDataACC(Account acc)
        {
            try
            {
                string sqlcommamd = "sp_insertDataFromAccount";
                SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
                sqlcm.CommandType = CommandType.StoredProcedure;
                sqlcm.Parameters.Add(new SqlParameter("@TaiKhoan", acc.TaiKhoan));
                sqlcm.Parameters.Add(new SqlParameter("@MatKhau", acc.MatKhau));
                sqlcm.Parameters.Add(new SqlParameter("@PhanQuyen", acc.PhanQuyen));
                if (sqlcm.ExecuteNonQuery() >= 0)
                {
                    getDataACC();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }catch(Exception e)
            {
                return -1;
            }
            
        }
        public int updateACC(Account acc)
        {
            string sqlcommamd = "sp_upadateDataFromAccount";
            SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
            sqlcm.CommandType = CommandType.StoredProcedure;
            sqlcm.Parameters.Add(new SqlParameter("@TaiKhoan", acc.TaiKhoan));
            sqlcm.Parameters.Add(new SqlParameter("@MatKhau", acc.MatKhau));
            sqlcm.Parameters.Add(new SqlParameter("@PhanQuyen", acc.PhanQuyen));
            if (sqlcm.ExecuteNonQuery() >= 0)
            {
                getDataACC();
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int removeACC(string taiKhoan)
        { 
            try
            {
                string sqlcommamd = "sp_removeDataFromAccount";
                SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
                sqlcm.CommandType = CommandType.StoredProcedure;
                sqlcm.Parameters.Add(new SqlParameter("@TaiKhoan", taiKhoan));
                if (sqlcm.ExecuteNonQuery() >= 0)
                {
                    getDataACC();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }catch(Exception e)
            {
                return -1;
            }
          
        }
        public DataTable getDataACC1(string tk, string mk)
        {
            DataTable dt = new DataTable();
            string sqlcommamd = "sp_getDataFromTableAccount1";
            SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
            sqlcm.CommandType = CommandType.StoredProcedure;
            sqlcm.Parameters.Add(new SqlParameter("@TaiKhoan", tk));
            sqlcm.Parameters.Add(new SqlParameter("@MatKhau", mk));
            SqlDataAdapter sqlad = new SqlDataAdapter(sqlcm);
            sqlad.Fill(dt);
            return dt;
        }
    }
}
