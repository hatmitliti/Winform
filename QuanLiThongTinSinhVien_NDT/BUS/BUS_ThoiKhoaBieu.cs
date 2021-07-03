using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_ThoiKhoaBieu
    {
        DAL_ThoiKhoaBieu dalmh = new DAL_ThoiKhoaBieu();

        public DataTable getDataFromTKB(string maSV)
        {
            if (dalmh.getDataTKB(maSV) != null)
            {
                DataTable dt = new DataTable();
                dt = dalmh.getDataTKB(maSV);
                return dt;
            }
            else
            {
                return null;
            }
        }
        public int insertDataFrommTKB(ThoiKhoaBieu tkb)
        {
            Database.conn.Open();
            if (dalmh.insertDataTKB(tkb) == 1)
            {
                Database.conn.Close();
                return 1;
            }
            else if (dalmh.insertDataTKB(tkb) == 0)
            {
                Database.conn.Close();
                return 0;
            }
            else
            {
                Database.conn.Close();
                return -1;
            }
        }
        public int updateDataFrommTKB(ThoiKhoaBieu tkb)
        {
            Database.conn.Open();
            if (dalmh.updateDataTKB(tkb) == 1)
            {
                Database.conn.Close();
                return 1;
            }
            else if (dalmh.updateDataTKB(tkb) == 0)
            {
                Database.conn.Close();
                return 0;
            }
            else
            {
                Database.conn.Close();
                return -1;
            }
        }
        public int removeDataFrommTKB(string maLop)
        {
            Database.conn.Open();
            if (dalmh.removeDataTKB(maLop) == 1)
            {
                Database.conn.Close();
                return 1;
            }
            else if (dalmh.removeDataTKB(maLop) == 0)
            {
                Database.conn.Close();
                return 0;
            }
            else
            {
                Database.conn.Close();
                return -1;
            }
        }
        public DataTable getMaMHFormSQL(string tenMH)
        {

            return dalmh.getMaMHFormSQL(tenMH);
        }
        public DataTable getMaGVFormSQL(string makhoa)
        {

            return dalmh.getMaGVFormSQL(makhoa);
        }
    }
}
