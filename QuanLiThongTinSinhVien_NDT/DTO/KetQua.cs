using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class KetQua
    {
        private string maSV;
        private string maMH;
        private string tenMH;
        private double diemSV;

        public string MaSV { get => maSV; set => maSV = value; }
        public string MaMH { get => maMH; set => maMH = value; }
        public string TenMH { get => tenMH; set => tenMH = value; }
        public double DiemSV { get => diemSV; set => diemSV = value; }

        public KetQua()
        {

        }
        public KetQua(string maSV, string maMH, string tenMH,double diemSV)
        {
            this.maSV = maSV;
            this.maMH = maMH;
            this.tenMH = tenMH;
            this.diemSV = diemSV;
        }
    }
}
