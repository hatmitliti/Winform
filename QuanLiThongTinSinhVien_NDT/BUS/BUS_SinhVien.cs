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
    public class BUS_SinhVien
    {
        DAL_SinhVien dalsv = new DAL_SinhVien();
        public DataTable getDataFromSinhVien()
        {
            DataTable at = new DataTable();
            at = dalsv.getDataFromSQL();
            return at;

        }
        public DataTable getDataFromSinhVien1(string s)
        {
            if (dalsv.get1DataFromSQL(s) != null)
            {
                DataTable at = new DataTable();
                at = dalsv.get1DataFromSQL(s);
                return at;
            }
            return null;
        }
        public int updateSinhVien(SinhVien sv)
        {
            Database.conn.Open();
            if (dalsv.updateSinhVien(sv) == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int insertSinhVien(SinhVien sv)
        {
            Database.conn.Open();
            return dalsv.insertSinhVien(sv);
        }
        public int removeSinhVien(string maSV)
        {
            Database.conn.Open();
            if (dalsv.removeDataSV(maSV) == 1)
            {
                Database.conn.Close();
                return 1;
            }
            else if (dalsv.removeDataSV(maSV) == 0)
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
        public DataTable getDataFromTKB(string s)
        {
            DataTable at = new DataTable();
            at = dalsv.getDataTableTKB(s);
            return at;
        }
    }
}
