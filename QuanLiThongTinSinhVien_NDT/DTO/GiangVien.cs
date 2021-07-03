using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GiangVien
    {
        private string maGV;
        private string tenGV;
        private string gioiTinh;
        private string maKhoa;

        public string MaGV { get => maGV; set => maGV = value; }
        public string TenGV { get => tenGV; set => tenGV = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string MaKhoa { get => maKhoa; set => maKhoa = value; }

        public GiangVien()
        {

        }
        public GiangVien(string maGV,string tenGV,string gioiTinh,string maKhoa)
        {
            this.maGV = maGV;
            this.tenGV = tenGV;
            this.gioiTinh = gioiTinh;
            this.maKhoa = maKhoa;
        }
    }
}
