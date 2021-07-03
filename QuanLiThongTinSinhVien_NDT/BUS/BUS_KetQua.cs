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
    public class BUS_KetQua
    {
        DAL_KetQua dalkq = new DAL_KetQua();
        public DataTable getDataFromKQ(string s)
        {
            if (dalkq.getDataKQ(s) != null)
            {
                DataTable dt = new DataTable();
                dt = dalkq.getDataKQ(s);
                return dt;
            }
           else
            {
                return null;
            }
        }
        public int insertDataKQ(KetQua kq)
        {
            Database.conn.Open();
            if (dalkq.insertKQ(kq) == 1)
            {
                Database.conn.Close();
                return 1;
            }
           else  if (dalkq.insertKQ(kq) == 0)
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
        public int updateDataKQ(KetQua kq)
        {
            Database.conn.Open();
            if (dalkq.updateKQ(kq) == 1)
            {
                Database.conn.Close();
                return 1;
            }
            else if (dalkq.updateKQ(kq) == 0)
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
        public int removeDataKQ(string maSV,string maMH)
        {
            Database.conn.Open();
            if (dalkq.removeKQ(maSV,maMH) == 1)
            {
                Database.conn.Close();
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
