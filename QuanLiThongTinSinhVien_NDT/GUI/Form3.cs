using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace QuanLiThongTinSinhVien_NDT
{
    public partial class frmthemsv : Form
    {
        public  static int a;
        public frmthemsv()
        {
            InitializeComponent();
        }
        BUS_SinhVien bussv = new BUS_SinhVien();


        private void btnthem_Click(object sender, EventArgs e)
        {
            
            try
            {
                string sMaNV = txtmasv.Text;
                string sHoNV = txthosv.Text;
                string sTenNV = txttensv.Text;
                string sGioiTinh = "";
                if (rdbnam.Checked == true)
                {
                    sGioiTinh = "Nam";
                }
                else
                {
                    sGioiTinh = "Nữ";
                }
                DateTime sNgaySinh = DateTime.Parse(txtngaysinh.Text);
                string sNoiSinh = txtnoisinh.Text;
                string sDiachi = txtdiachi.Text;
                string sKhoa = "";
                switch (cbokhoa.Text)
                {
                    case ("Công NGhệ Thông Tin"):
                        {
                            sKhoa = "TT";
                            break;
                        }
                    case ("Công Nghệ Kĩ Thuật ÔTô"):
                        {
                            sKhoa = "OTO";
                            break;
                        }
                    case ("Kỹ Thuật Cơ Khí"):
                        {
                            sKhoa = "CNC";
                            break;
                        }
                    case ("Tiếng Anh"):
                        {
                            sKhoa = "TA";
                            break;
                        }
                    case ("Du Lịch"):
                        {
                            sKhoa = "DL";
                            break;
                        }
                    case ("Nhà Hàng"):
                        {
                            sKhoa = "NH";
                            break;
                        }
                    case ("Điện Công Nghiệp"):
                        {
                            sKhoa = "DCN";
                            break;
                        }
                }

                SinhVien sv = new SinhVien(sMaNV, sHoNV, sTenNV, sGioiTinh, sNgaySinh, sNoiSinh, sDiachi, sKhoa);
                if (bussv.insertSinhVien(sv) == 1)
                {
                    MessageBox.Show("Thêm Thành Công");
                    a = 1;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm Thất Bại");
                }
            }
            catch(Exception i)
            {
                MessageBox.Show("Bạn Chưa Nhập đầy Đủ Dữ Liệu Hoặc Lỗi Dữ Liệu Vui Lòng Kiểm Tra Lại !!");
            }
           
           
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtmasv_TextChanged(object sender, EventArgs e)
        { 
           
        }

        private void txthosv_TextChanged(object sender, EventArgs e)
        {
        }

        private void txttensv_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtngaysinh_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void txtnoisinh_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtdiachi_TextChanged(object sender, EventArgs e)
        {
        }

        private void cbokhoa_TextChanged(object sender, EventArgs e)
        {
        }
    }
    
}
