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
    public class DAL_Khoa
    {
        Database dtb = new Database();
        public DataTable getDataKhoa()
        {
            try
            {
                DataTable dt = new DataTable();
                string sqlcommamd = "sp_getDataKhoa";
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
        public int insertKhoa(Khoa k)
        {
            try
            {
                string sqlcommamd = "sp_insertKhoa";
                SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
                sqlcm.CommandType = CommandType.StoredProcedure;
                sqlcm.Parameters.Add(new SqlParameter("@MaKhoaID", k.MaKhoa));
                sqlcm.Parameters.Add(new SqlParameter("@TenKhoa", k.TenKhoa));
                if (sqlcm.ExecuteNonQuery() >= 0)
                {
                    getDataKhoa();
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
        public int updateKhoa(Khoa k)
        {
            try
            {
                string sqlcommamd = "sp_updateKhoa";
                SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
                sqlcm.CommandType = CommandType.StoredProcedure;
                sqlcm.Parameters.Add(new SqlParameter("@MaKhoaID", k.MaKhoa));
                sqlcm.Parameters.Add(new SqlParameter("@TenKhoa", k.TenKhoa));
                if (sqlcm.ExecuteNonQuery() >= 0)
                {
                    getDataKhoa();
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
        public int removeKhoa(string maKhoa)
        {
            try
            {
                string sqlcommamd = "sp_removeKhoa";
                SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
                sqlcm.CommandType = CommandType.StoredProcedure;
                sqlcm.Parameters.Add(new SqlParameter("@MaKhoaID", maKhoa));
                if (sqlcm.ExecuteNonQuery() >= 0)
                {
                    getDataKhoa();
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
