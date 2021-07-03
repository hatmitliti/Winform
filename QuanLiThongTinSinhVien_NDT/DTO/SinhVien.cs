using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SinhVien
    {
        private string maSV;
        private string hoSV;
        private string tenSV;
        private string gioiTinh;
        private DateTime ngaySinh;
        private string noiSinh;
        private string diaChi;
        private string maKhoa;

        public string MaSV { get => maSV; set => maSV = value; }
        public string HoSV { get => hoSV; set => hoSV = value; }
        public string TenSV { get => tenSV; set => tenSV = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string NoiSinh { get => noiSinh; set => noiSinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string MaKhoa { get => maKhoa; set => maKhoa = value; }

        public SinhVien()
        {

        }
        public SinhVien(string maSV,string hoSV,string tenSV,string gioiTinh,DateTime ngaySinh,string noiSinh,string diaChi,string maKhoa)
        {
            this.maSV = maSV;
            this.hoSV = hoSV;
            this.tenSV = tenSV;
            this.gioiTinh = gioiTinh;
            this.ngaySinh = ngaySinh;
            this.noiSinh = noiSinh;
            this.diaChi = diaChi;
            this.maKhoa = maKhoa;
        }
    }
}
