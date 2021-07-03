using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;
using DAL;

namespace BUS
{
    public class BUS_MonHoc
    {
        DAL_MonHoc dalmh = new DAL_MonHoc();

  
        public DataTable getDataFromMH(string maKhoa)
        {
            DataTable dt = new DataTable();
            dt = dalmh.getDataMH(maKhoa);
            return dt;
        }
        public int insertDataFrommMH(MonHoc mh)
        {
            Database.conn.Open();
            if (dalmh.insertDataMH(mh) == 1)
            {
                Database.conn.Close();
                return 1; 
            }
            if (dalmh.insertDataMH(mh) == 0)
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
        public int updateDataFrommMH(MonHoc mh)
        {
            Database.conn.Open();
            if (dalmh.updateDataMH(mh) == 1)
            {
                Database.conn.Close();
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int removeDataFrommMH(string maMH)
        {
            Database.conn.Open();
            if (dalmh.removeDataMH(maMH) == 1)
            {
                Database.conn.Close();
                return 1;
            }
            if (dalmh.removeDataMH(maMH) == 0)
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
    }
}
