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
    public class BUS_Account
    {
        DAL_Account dalacc = new DAL_Account();
        public DataTable getDataFromACC()
        {
            DataTable dt = new DataTable();
            dt = dalacc.getDataACC();
            return dt;
        }
        public int insertDataACC(Account acc)
        {
            Database.conn.Open();
            if (dalacc.insertDataACC(acc) == 1)
            {
                Database.conn.Close();
                return 1;
            }
            else if (dalacc.insertDataACC(acc) == 1)
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
        public int updateDataACC(Account acc)
        {
            Database.conn.Open();
            if (dalacc.updateACC(acc) == 1)
            {
                Database.conn.Close();
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int removeDataACC(string taiKhoan)
        {
            Database.conn.Open();
            if (dalacc.removeACC(taiKhoan) == 1)
            {
                Database.conn.Close();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public DataTable getDataFromACC1(string tk, string mk)
        {
            DataTable dt = new DataTable();
            dt = dalacc.getDataACC1(tk, mk);
            return dt;
        }
    }
}
