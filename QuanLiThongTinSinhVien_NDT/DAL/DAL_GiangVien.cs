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
    public class DAL_GiangVien
    {
        Database dtb = new Database();
        public DataTable getDataGV()
        {
            try
            {
                DataTable dt = new DataTable();
                string sqlcommamd = "sp_getDataGiangVien";
                SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
                sqlcm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlad = new SqlDataAdapter(sqlcm);
                sqlad.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public DataTable getDataGV1(string maKhoa)
        {
            try
            {
                DataTable dt = new DataTable();
                string sqlcommamd = "sp_getDataGiangVien1";
                SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
                sqlcm.Parameters.Add(new SqlParameter("@MaKhoa", maKhoa));
                sqlcm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlad = new SqlDataAdapter(sqlcm);
                sqlad.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public DataTable getDataGV2( string maKhoa)
        {
            try
            {
                DataTable dt = new DataTable();
                string sqlcommamd = "sp_getDataGiangVien2";
                SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
                sqlcm.CommandType = CommandType.StoredProcedure;
                sqlcm.Parameters.Add(new SqlParameter("@MaKhoa", maKhoa));
                SqlDataAdapter sqlad = new SqlDataAdapter(sqlcm);
                sqlad.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public int insertGV(GiangVien gv)
        {
            try
            {
                string sqlcommamd = "sp_insertGiangVien";
                SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
                sqlcm.CommandType = CommandType.StoredProcedure;
                sqlcm.Parameters.Add(new SqlParameter("@MaGVID", gv.MaGV));
                sqlcm.Parameters.Add(new SqlParameter("@TenGV", gv.TenGV));
                sqlcm.Parameters.Add(new SqlParameter("@GioiTinh", gv.GioiTinh));
                sqlcm.Parameters.Add(new SqlParameter("@MaKhoa", gv.MaKhoa));
                if (sqlcm.ExecuteNonQuery() >= 0)
                {
                    getDataGV();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                return -1;
            }

        }
        public int updateGV(GiangVien gv)
        {
            try
            {
                string sqlcommamd = "sp_updateGiangVien";
                SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
                sqlcm.CommandType = CommandType.StoredProcedure;
                sqlcm.Parameters.Add(new SqlParameter("@MaGVID", gv.MaGV));
                sqlcm.Parameters.Add(new SqlParameter("@TenGV", gv.TenGV));
                sqlcm.Parameters.Add(new SqlParameter("@GioiTinh", gv.GioiTinh));
                sqlcm.Parameters.Add(new SqlParameter("@MaKhoa", gv.MaKhoa));
                if (sqlcm.ExecuteNonQuery() >= 0)
                {
                    getDataGV();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                return -1;
            }

        }
        public int removeGV(string maGV)
        {
            try
            {
                string sqlcommamd = "sp_removeGiangVien";
                SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
                sqlcm.CommandType = CommandType.StoredProcedure;
                sqlcm.Parameters.Add(new SqlParameter("@MaGVID", maGV));
                if (sqlcm.ExecuteNonQuery() >= 0)
                {
                    getDataGV();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                return -1;
            }

        }
    }
}
