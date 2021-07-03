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
    public class BUS_GiangVien
    {
        DAL_GiangVien dalgv = new DAL_GiangVien();
        public DataTable getDataFromGV()
        {
            if (dalgv.getDataGV() != null)
            {
                DataTable dt = new DataTable();
                dt = dalgv.getDataGV();
                return dt;
            }
            else
            {
                return null;
            }
        }
        public DataTable getDataFromGV1(string makhoa)
        {
            if (dalgv.getDataGV1(makhoa) != null)
            {
                DataTable dt = new DataTable();
                dt = dalgv.getDataGV1(makhoa);
                return dt;
            }
            else
            {
                return null;
            }
        }
        public DataTable getDataFromGV2(string maKhoa)
        {
            if (dalgv.getDataGV2(maKhoa) != null)
            {
                DataTable dt = new DataTable();
                dt = dalgv.getDataGV2(maKhoa);
                return dt;
            }
            else
            {
                return null;
            }
        }
        public int insertDataGV(GiangVien gv)
        {
            Database.conn.Open();
            if (dalgv.insertGV(gv) == 1)
            {
                Database.conn.Close();
                return 1;
            }
            else if (dalgv.insertGV(gv) == 0)
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
        public int updateDataGV(GiangVien gv)
        {
            Database.conn.Open();
            if (dalgv.updateGV(gv) == 1)
            {
                Database.conn.Close();
                return 1;
            }
            else if (dalgv.updateGV(gv) == 0)
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
        public int removeDataGV(string maGV)
        {
            Database.conn.Open();
            if (dalgv.removeGV(maGV) == 1)
            {
                Database.conn.Close();
                return 1;
            }
            if (dalgv.removeGV(maGV) == 0)
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
