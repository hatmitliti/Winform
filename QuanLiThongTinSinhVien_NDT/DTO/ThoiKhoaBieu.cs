using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThoiKhoaBieu
    {
        private string maLop;
        private string maSV;
        private string thu;
        private string buoi;
        private string thoiGian;
        private string phong;
        private string maMH;
        private string maGV;

        public string MaSV { get => maSV; set => maSV = value; }
        public string Thu { get => thu; set => thu = value; }
        public string Buoi { get => buoi; set => buoi = value; }
        public string  ThoiGian { get => thoiGian; set => thoiGian = value; }
        public string Phong { get => phong; set => phong = value; }
        public string MaMH { get => maMH; set => maMH = value; }
        public string MaGV { get => maGV; set => maGV = value; }
        public string MaLop { get => maLop; set => maLop = value; }

        public ThoiKhoaBieu()
        {

        }
        public ThoiKhoaBieu(string malop, string maSV,string thu, string buoi, string  thoigian, string phong,string maMH,string maGV)
        {
            this.maLop = malop;
            this.maSV = maSV;
            this.thu = thu;
            this.buoi = buoi;
            this.thoiGian = thoigian;
            this.phong = phong;
            this.MaMH = maMH;
            this.maGV = maGV;
        }
    }
}
