using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Khoa
    {
        private string maKhoa;
        private string tenKhoa;

        public string MaKhoa { get => maKhoa; set => maKhoa = value; }
        public string TenKhoa { get => tenKhoa; set => tenKhoa = value; }

        public Khoa()
        {

        }   
        public Khoa(string maKhoa,string tenKhoa)
        {
            this.maKhoa = maKhoa;
            this.tenKhoa = tenKhoa;
        }
    }
}
