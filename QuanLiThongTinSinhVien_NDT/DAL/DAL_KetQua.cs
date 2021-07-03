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
    public class DAL_KetQua
    {
        Database dtb = new Database();
        public DataTable getDataKQ(String s)
        {
            try
            {
                DataTable dt = new DataTable();
                string sqlcommamd = "sp_GetDataFromTableKetQuaByID";
                SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
                sqlcm.CommandType = CommandType.StoredProcedure;
                sqlcm.Parameters.Add(new SqlParameter("@MaSVID", s));
                SqlDataAdapter sqlad = new SqlDataAdapter(sqlcm);
                sqlad.Fill(dt);
                return dt;
            }
            catch(Exception e)
            {
                return null;
            }
           
        }
        public int insertKQ(KetQua kq)
        {
            try
            {
                string sqlcommamd = "sp_insertKQ";
                SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
                sqlcm.CommandType = CommandType.StoredProcedure;
                sqlcm.Parameters.Add(new SqlParameter("@MaSVID", kq.MaSV));
                sqlcm.Parameters.Add(new SqlParameter("@MaMHID", kq.MaMH));
                sqlcm.Parameters.Add(new SqlParameter("@TenMH", kq.TenMH));
                sqlcm.Parameters.Add(new SqlParameter("@DiemThi", kq.DiemSV));
                if (sqlcm.ExecuteNonQuery() >= 0)
                {
                    getDataKQ(kq.MaSV);
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
        public int updateKQ(KetQua kq)
        {
            string sqlcommamd = "sp_updateKQ";
            SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
            sqlcm.CommandType = CommandType.StoredProcedure;
            sqlcm.Parameters.Add(new SqlParameter("@MaSVID", kq.MaSV));
            sqlcm.Parameters.Add(new SqlParameter("@MaMHID", kq.MaMH));
            sqlcm.Parameters.Add(new SqlParameter("@TenMH", kq.TenMH));
            sqlcm.Parameters.Add(new SqlParameter("@DiemThi", kq.DiemSV));
            if (sqlcm.ExecuteNonQuery() >= 0)
            {
                getDataKQ(kq.MaSV);
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int removeKQ(string maSV ,string maMH)
        {
            string sqlcommamd = "sp_removeDataKQ";
            SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
            sqlcm.CommandType = CommandType.StoredProcedure;
            sqlcm.Parameters.Add(new SqlParameter("@MaSVID",maSV));
            sqlcm.Parameters.Add(new SqlParameter("@MaMHID", maMH));
            if (sqlcm.ExecuteNonQuery() >= 0)
            {
                getDataKQ(maSV);
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
