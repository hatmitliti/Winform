using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Account
    {
        private string taiKhoan;
        private string matKhau;
        private string phanQuyen;

        public string TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string PhanQuyen { get => phanQuyen; set => phanQuyen = value; }

        public Account()
        {

        }

        public Account(string taiKhoan, string matKhau, string phanQuyen)
        {
            this.taiKhoan = taiKhoan;
            this.matKhau = matKhau;
            this.phanQuyen = phanQuyen;
        }
    }
}
