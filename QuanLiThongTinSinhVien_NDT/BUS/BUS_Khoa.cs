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
    public class BUS_Khoa
    {
        DAL_Khoa dalkhoa = new DAL_Khoa();
        public DataTable getDataFromKhoa()
        {
            if (dalkhoa.getDataKhoa() != null)
            {
                DataTable dt = new DataTable();
                dt = dalkhoa.getDataKhoa();
                return dt;
            }
            else
            {
                return null;
            }
        }
        public int insertDataKhoa(Khoa k)
        {
            Database.conn.Open();
            if (dalkhoa.insertKhoa(k) == 1)
            {
                Database.conn.Close();
                return 1;
            }
            else if (dalkhoa.insertKhoa(k) == 0)
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
        public int updateDataKhoa(Khoa k)
        {
            Database.conn.Open();
            if (dalkhoa.updateKhoa(k) == 1)
            {
                Database.conn.Close();
                return 1;
            }
            else if (dalkhoa.updateKhoa(k) == 0)
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
        public int removeDataKhoa(string maKhoa)
        {
            Database.conn.Open();
            if (dalkhoa.removeKhoa(maKhoa) == 1)
            {
                Database.conn.Close();
                return 1;
            }
            if (dalkhoa.removeKhoa(maKhoa) == 0)
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
