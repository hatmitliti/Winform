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

    public class DAL_SinhVien
    {
        Database connect = new Database();

        public DataTable getDataFromSQL()
        {
            DataTable dt = new DataTable();
            string sqlcommamd = "sp_getDataFromsSinhVienByID1";
            SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
            sqlcm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlad = new SqlDataAdapter(sqlcm);
            sqlad.Fill(dt);
            return dt;
        }
        public DataTable get1DataFromSQL(string s)
        {
            try
            {
                DataTable dt = new DataTable();
                string sqlcommamd = "sp_getDataFromsSinhVienByID2";
                SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
                sqlcm.CommandType = CommandType.StoredProcedure;
                sqlcm.Parameters.Add(new SqlParameter("@MaSVID", s));
                SqlDataAdapter sqlad = new SqlDataAdapter(sqlcm);
                sqlad.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public int updateSinhVien(SinhVien sv)
        {
            int resuft = 0;
            DataTable dt = new DataTable();
            string sqlcommamd = "sp_updateDataSinhVien";
            SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
            sqlcm.CommandType = CommandType.StoredProcedure;
            sqlcm.Parameters.Add(new SqlParameter("@MaSVID", sv.MaSV));
            sqlcm.Parameters.Add(new SqlParameter("@HoSV", sv.HoSV));
            sqlcm.Parameters.Add(new SqlParameter("@TenSV", sv.TenSV));
            sqlcm.Parameters.Add(new SqlParameter("@GioiTinh", sv.GioiTinh));
            sqlcm.Parameters.Add(new SqlParameter("@NgaySinh", sv.NgaySinh));
            sqlcm.Parameters.Add(new SqlParameter("@NoiSinh", sv.NoiSinh));
            sqlcm.Parameters.Add(new SqlParameter("@DiaChi", sv.DiaChi));
            sqlcm.Parameters.Add(new SqlParameter("@MaKhoa", sv.MaKhoa));
            try
            {
                if (sqlcm.ExecuteNonQuery() >= 0)
                {
                    Database.conn.Close();
                    return resuft = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                resuft = 0;
            }
            return resuft;
        }
        public int insertSinhVien(SinhVien sv)
        {
            int resuft = 0;
            DataTable dt = new DataTable();
            string sqlcommamd = "sp_insertDataSinhVien";
            SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
            sqlcm.CommandType = CommandType.StoredProcedure;
            sqlcm.Parameters.Add(new SqlParameter("@MaSVID", sv.MaSV));
            sqlcm.Parameters.Add(new SqlParameter("@HoSV", sv.HoSV));
            sqlcm.Parameters.Add(new SqlParameter("@TenSV", sv.TenSV));
            sqlcm.Parameters.Add(new SqlParameter("@GioiTinh", sv.GioiTinh));
            sqlcm.Parameters.Add(new SqlParameter("@NgaySinh", sv.NgaySinh));
            sqlcm.Parameters.Add(new SqlParameter("@NoiSinh", sv.NoiSinh));
            sqlcm.Parameters.Add(new SqlParameter("@DiaChi", sv.DiaChi));
            sqlcm.Parameters.Add(new SqlParameter("@MaKhoa", sv.MaKhoa));
            try
            {
                if (sqlcm.ExecuteNonQuery() >= 0)
                {
                    resuft = 1;
                    Database.conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
                resuft = 0;
            }
            return resuft;
        }
        public int removeDataSV(string s)
        {
            int resuft = 0;
            try
            {
                DataTable dt = new DataTable();
                string sqlcommamd = "sp_removeDataSV";
                SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
                sqlcm.CommandType = CommandType.StoredProcedure;
                sqlcm.Parameters.Add(new SqlParameter("@MaSVID", s));

                if (sqlcm.ExecuteNonQuery() >= 0)
                {
                    resuft = 1;
                    Database.conn.Close();
                }
                else
                {
                    resuft = 0;
                    Database.conn.Close();
                }
            }
            catch (Exception ex)
            {
                resuft = -1;
            }
            return resuft;
        }
        public DataTable getDataTableTKB(string s)
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
        }
    }
}
