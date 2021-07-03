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
    public class DAL_MonHoc
    {
        Database dtb = new Database();
        public DataTable getDataMH(string s)
        {
            DataTable dt = new DataTable();
            string sqlcommamd = "sp_GetDataFromTable2";
            SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
            sqlcm.CommandType = CommandType.StoredProcedure;
            sqlcm.Parameters.Add(new SqlParameter("@maKhoa", s));
            SqlDataAdapter sqlad = new SqlDataAdapter(sqlcm);
            sqlad.Fill(dt);
            return dt;
        }
        public int insertDataMH(MonHoc mh)
        {
            try
            {
                string sqlcommamd = "sp_insertMH";
                SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
                sqlcm.CommandType = CommandType.StoredProcedure;
                sqlcm.Parameters.Add(new SqlParameter("@MaMHID", mh.MaMH));
                sqlcm.Parameters.Add(new SqlParameter("@TenMH", mh.TenMH));
                sqlcm.Parameters.Add(new SqlParameter("@SoTiet", mh.SoTiet));
                sqlcm.Parameters.Add(new SqlParameter("@MaKhoa", mh.MaKhoa));
                sqlcm.Parameters.Add(new SqlParameter("@MaGV", mh.MaGV));
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
        public int updateDataMH(MonHoc mh)
        {
            string sqlcommamd = "sp_updateMH";
            SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
            sqlcm.CommandType = CommandType.StoredProcedure;
            sqlcm.Parameters.Add(new SqlParameter("@MaMHID", mh.MaMH));
            sqlcm.Parameters.Add(new SqlParameter("@TenMH", mh.TenMH));
            sqlcm.Parameters.Add(new SqlParameter("@SoTiet", mh.SoTiet));
            sqlcm.Parameters.Add(new SqlParameter("@MaKhoa", mh.MaKhoa));
            sqlcm.Parameters.Add(new SqlParameter("@MaGV", mh.MaGV));
            if (sqlcm.ExecuteNonQuery() >= 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int removeDataMH(string mamh)
        {
            try
            {
                string sqlcommamd = "sp_removeDataMH";
                SqlCommand sqlcm = new SqlCommand(sqlcommamd, Database.conn);
                sqlcm.CommandType = CommandType.StoredProcedure;
                sqlcm.Parameters.Add(new SqlParameter("@MaMHID", mamh));
                if (sqlcm.ExecuteNonQuery() >= 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch(Exception e)
            {
                return -1;
            }
          
        }
    }
}
