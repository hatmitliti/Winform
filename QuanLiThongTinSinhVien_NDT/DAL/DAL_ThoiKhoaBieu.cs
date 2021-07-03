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
    public class DAL_ThoiKhoaBieu
    {
        Database dtb = new Database();
        public DataTable getDataTKB(string s)
        {
            try
            {
                DataTable dt = new DataTable();
                string sqlcommamd = "sp_getDataTKB";
                SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
                sqlcm.CommandType = CommandType.StoredProcedure;
                sqlcm.Parameters.Add(new SqlParameter("@MaSVID", s));
                SqlDataAdapter ad = new SqlDataAdapter(sqlcm);
                ad.Fill(dt);
                Database.conn.Close();
                return dt;
            }catch(Exception e)
            {
                return null;
            }
        }
        public int insertDataTKB(ThoiKhoaBieu tkb)
        {
            try
            {
                string sqlcommamd = "sp_insertDataTKB";
                SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
                sqlcm.CommandType = CommandType.StoredProcedure;
                sqlcm.Parameters.Add(new SqlParameter("@MaLopID", tkb.MaLop));
                sqlcm.Parameters.Add(new SqlParameter("@MaSVID", tkb.MaSV));
                sqlcm.Parameters.Add(new SqlParameter("@Thu", tkb.Thu));
                sqlcm.Parameters.Add(new SqlParameter("@buoi", tkb.Buoi));
                sqlcm.Parameters.Add(new SqlParameter("@ThoiGian", tkb.ThoiGian));
                sqlcm.Parameters.Add(new SqlParameter("@Phong", tkb.Phong));
                sqlcm.Parameters.Add(new SqlParameter("@MaMH", tkb.MaMH));
                sqlcm.Parameters.Add(new SqlParameter("@MaGV", tkb.MaGV));
                if (sqlcm.ExecuteNonQuery() >= 0)
                {
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
        public int updateDataTKB(ThoiKhoaBieu tkb)
        {
            try
            {
                string sqlcommamd = "sp_updateDataTKB";
                SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
                sqlcm.CommandType = CommandType.StoredProcedure;
                sqlcm.Parameters.Add(new SqlParameter("@MaLopID", tkb.MaLop));
                sqlcm.Parameters.Add(new SqlParameter("@MaSVID", tkb.MaSV));
                sqlcm.Parameters.Add(new SqlParameter("@Thu", tkb.Thu));
                sqlcm.Parameters.Add(new SqlParameter("@buoi", tkb.Buoi));
                sqlcm.Parameters.Add(new SqlParameter("@ThoiGian", tkb.ThoiGian));
                sqlcm.Parameters.Add(new SqlParameter("@Phong", tkb.Phong));
                sqlcm.Parameters.Add(new SqlParameter("@MaMH", tkb.MaMH));
                sqlcm.Parameters.Add(new SqlParameter("@MaGV", tkb.MaGV));
                if (sqlcm.ExecuteNonQuery() >= 0)
                {
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
        public int removeDataTKB(string maLop)
        {
            try
            {
                string sqlcommamd = "sp_removeDataTKB";
                SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
                sqlcm.CommandType = CommandType.StoredProcedure;
                sqlcm.Parameters.Add(new SqlParameter("@MaLopID", maLop));
                if (sqlcm.ExecuteNonQuery() >= 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }catch (Exception i)
            {
                return -1;
            }
           
        }
        public DataTable getMaMHFormSQL(string tenMH)
        {
            DataTable dt = new DataTable();
            string sqlcommamd = "sp_GetDataFromTableMH";
            SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
            sqlcm.CommandType = CommandType.StoredProcedure;
            sqlcm.Parameters.Add(new SqlParameter("@TenMH", tenMH));
            SqlDataAdapter ad = new SqlDataAdapter(sqlcm);
            ad.Fill(dt);
            return dt;
        }
        public DataTable getMaGVFormSQL(string maKhoa)
        {
            DataTable dt = new DataTable();
            string sqlcommamd = "sp_getDataGiangVien1";
            SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
            sqlcm.CommandType = CommandType.StoredProcedure;
            sqlcm.Parameters.Add(new SqlParameter("@MaKhoa", maKhoa));
            SqlDataAdapter ad = new SqlDataAdapter(sqlcm);
            ad.Fill(dt);
            return dt;
        }
    }
}
