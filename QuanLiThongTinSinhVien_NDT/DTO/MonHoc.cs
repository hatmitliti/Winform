using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MonHoc
    {
        private string maMH;
        private string tenMH;
        private int soTiet;
        private string maKhoa;
        private string maGV;

        public string MaMH { get => maMH; set => maMH = value; }
        public string TenMH { get => tenMH; set => tenMH = value; }
        public int SoTiet { get => soTiet; set => soTiet = value; }
        public string MaKhoa { get => maKhoa; set => maKhoa = value; }
        public string MaGV { get => maGV; set => maGV = value; }

        public MonHoc()
        {

        }
        public MonHoc(string maMH,string tenMH, int soTiet, string maKhoa,string maGV)
        {
            this.maMH = maMH;
            this.tenMH = tenMH;
            this.soTiet = soTiet;
            this.maKhoa = maKhoa;
            this.maGV = maGV;
        }
    }
}
