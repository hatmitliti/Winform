using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QuanLiThongTinSinhVien_NDT
{
    public partial class frmttsv : Form
    {
        public static string maSV;
        public static string hoSV;
        public static string tenSV;
        public static int a;
        public frmttsv()
        {
            InitializeComponent();
        }
        BUS_SinhVien bussv = new BUS_SinhVien();
        BUS_KetQua buskq = new BUS_KetQua();
        BUS_ThoiKhoaBieu bustkb = new BUS_ThoiKhoaBieu();
        BUS_Khoa buskhoa = new BUS_Khoa();
        BUS_GiangVien busgiangvien = new BUS_GiangVien();
        BUS_MonHoc busmonhoc = new BUS_MonHoc();
        public static string MaSV { get => maSV; }
        public static string TenSV { get => tenSV; }
        public static string HoSV { get => hoSV; }

        private void Form2_Load(object sender, EventArgs e)
        {
            string s = frmadmin._message;
            DataTable dt = new DataTable();
            dt = bussv.getDataFromSinhVien1(s);
            foreach (DataRow row in dt.Rows)
            {
                txtmasv.Text = row["MaSVID"].ToString();
                txthosv.Text = row["HoSV"].ToString();
                txttensv.Text = row["TenSV"].ToString();
                txtgioitinh.Text = row["GioiTinh"].ToString();
                txtngaysinh.Text = row["NgaySinh"].ToString();
                txtnoisinh.Text = row["NoiSinh"].ToString();
                txtdiachi.Text = row["DiaChi"].ToString();
                cbokhoa.Text = row["TenKhoa"].ToString();
                maSV = txtmasv.Text;
                tenSV = txttensv.Text;
                hoSV = txthosv.Text;
            }
            dataGridView1.DataSource = bustkb.getDataFromTKB(frmttsv.maSV);
            lblmasv2.Text = frmttsv.maSV.ToString();
            lbltensv2.Text = frmttsv.HoSV.ToString() + frmttsv.tenSV.ToString();
            //////////////////////////////////////////////////////////////////
            DataTable dt1 = new DataTable();
            dataGridView2.DataSource = buskq.getDataFromKQ(lblmasv2.Text);
            textBoxtensv.Text = lbltensv2.Text;
            textBoxmasv.Text = lblmasv2.Text;

            DataTable dt2 = bustkb.getMaGVFormSQL(exchangeMaKhoa(cbokhoa.Text));
            for (int i = 0; i <= dt2.Rows.Count - 1; i++)
            {
                cbomagv.Items.Add(dt2.Rows[i][1]);
            }

            DataTable dt3 = buskhoa.getDataFromKhoa();
            for (int i = 0; i <= dt3.Rows.Count - 1; i++)
            {
                cbokhoa.Items.Add(dt3.Rows[i][1]);
            }

            DataTable dt4 = busmonhoc.getDataFromMH(exchangeMaKhoa(cbokhoa.Text));
            for(int i = 0;i<dt4.Rows.Count;i++)
            {
                cbomonhoctkb.Items.Add(dt4.Rows[i][1]);
                cbomamonhoc.Items.Add(dt4.Rows[i][0]);
                cbotenmonhoc.Items.Add(dt4.Rows[i][1]);
            }    
        }
        public string exchangeMaKhoa(string s)
        {
            string a = "";
            DataTable dt = new DataTable();
            dt = buskhoa.getDataFromKhoa();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][1].ToString().Trim() == s.Trim().ToString())
                {
                    a = dt.Rows[i][0].ToString().Trim();
                }
            }
            return a;
        }
        private void btnsuathongtin_Click(object sender, EventArgs e)
        {
            string sMaNV = txtmasv.Text;
            string sHoNV = txthosv.Text;
            string sTenNV = txttensv.Text;
            string sGioiTinh = txtgioitinh.Text;
            DateTime sNgaySinh = DateTime.Parse(txtngaysinh.Text);
            string sNoiSinh = txtnoisinh.Text;
            string sDiachi = txtdiachi.Text;
            string sKhoa = exchangeMaKhoa(cbokhoa.Text);

            if (txtmasv.Text == string.Empty)
            {
                MessageBox.Show("Ban Chua Nhap Ma Sinh Vien");
            }
            else if (txthosv.Text == string.Empty)
            {
                MessageBox.Show("Ban Chua Nhap Ho Sinh  Vien");
            }
            else if (txttensv.Text == string.Empty)
            {
                MessageBox.Show("Ban Chua Nhap Ten Sinh Vien");
            }
            else if (txtngaysinh.Text == string.Empty)
            {
                MessageBox.Show("Ban Chua Nhap Ngay Sinh Sinh Vien");
            }
            else if (txtdiachi.Text == string.Empty)
            {
                MessageBox.Show("Ban Chua Nhap Dia Chi Sinh Vien");
            }
            else if (txtnoisinh.Text == string.Empty)
            {
                MessageBox.Show("Ban Chua Nhap Noi Sinh Sinh Vien");
            }
            else if (cbokhoa.Text == string.Empty)
            {
                MessageBox.Show("Ban Chua Nhap Khoa Sinh Vien");
            }
            else if (txtgioitinh.Text == string.Empty)
            {
                MessageBox.Show("Ban Chua Nhap Gioi Tinh Cho Sinh Vien");
            }
            SinhVien sv = new SinhVien(sMaNV, sHoNV, sTenNV, sGioiTinh, sNgaySinh, sNoiSinh, sDiachi, sKhoa);
            int i = bussv.updateSinhVien(sv);
            if (i == 1)
            {
                a = 1;
                MessageBox.Show("Sua Thanh Cong!!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Sua Khong Thanh Cong!!");
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnxuatttsv_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                btnxoadiem.Enabled = true;
                int i = dataGridView2.SelectedCells[0].RowIndex;
                DataGridViewRow dtr = dataGridView2.Rows[i];
                cbomamonhoc.Text = dtr.Cells[1].Value.ToString();
                cbotenmonhoc.Text = dtr.Cells[2].Value.ToString();
                txtdiemthi.Text = dtr.Cells[3].Value.ToString();
            }
           else
            {
                btnxoadiem.Enabled = false;
            }                
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                string maSV = textBoxmasv.Text;
                string maMH = cbomamonhoc.Text;
                string tenMH = cbotenmonhoc.Text;
                double diem = double.Parse(txtdiemthi.Text);
                KetQua kq = new KetQua(maSV, maMH, tenMH, diem);
                if (buskq.insertDataKQ(kq) == 1)
                {
                    dataGridView2.DataSource = buskq.getDataFromKQ(lblmasv2.Text);
                    MessageBox.Show("Thêm Điểm Thành Công");
                }
                else if (buskq.insertDataKQ(kq) == 0)
                {
                    MessageBox.Show("Thêm Điểm Thành Công");
                }
                else if (buskq.insertDataKQ(kq) == -1)
                {
                    MessageBox.Show("Lỗi Dữ Liệu Vui Lòng Kiêm Tra Lại!!");
                }
            }
            catch (Exception r)
            {
                MessageBox.Show("Bạn Chưa Nhập Đầy Đủ Dữ Liệu Muốn Thêm, Vui Lòng Kiểm Tra Lại");
            }

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (cbomamonhoc.Text == string.Empty || cbotenmonhoc.Text == string.Empty || txtdiemthi.Text == string.Empty ||
                 cbomamonhoc.Text == string.Empty && cbotenmonhoc.Text == string.Empty && txtdiemthi.Text == string.Empty)
            {
                MessageBox.Show("Lỗi Dữ Liệu Không Thể Xóa!!");
            }
            else
            {
                string maSV = textBoxmasv.Text;
                string maMH = cbomamonhoc.Text;
                DialogResult r;
                r = MessageBox.Show("Bạn Có Chắc Chắn Muốn Xóa Dữ Liệu???", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    if (buskq.removeDataKQ(maSV, maMH) == 1)
                    {
                        dataGridView2.DataSource = buskq.getDataFromKQ(lblmasv2.Text);
                        MessageBox.Show("Xóa Điểm Thành Công");
                    }
                    else
                    {
                        MessageBox.Show("Xóa Điểm Không Thành Công");
                    }
                }
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (cbomamonhoc.Text == string.Empty || cbotenmonhoc.Text == string.Empty || txtdiemthi.Text == string.Empty ||
                cbomamonhoc.Text == string.Empty && cbotenmonhoc.Text == string.Empty && txtdiemthi.Text == string.Empty)
            {
                MessageBox.Show("Bạn Chưa Nhập Đầy Đủ Dữ Liệu Không Thể Sửa!!");
            }
            else
            {
                string maSV = textBoxmasv.Text;
                string maMH = cbomamonhoc.Text;
                string tenMH = cbotenmonhoc.Text;
                double diem = double.Parse(txtdiemthi.Text);
                KetQua kq = new KetQua(maSV, maMH, tenMH, diem);

                if (buskq.updateDataKQ(kq) == 1)
                {
                    dataGridView2.DataSource = buskq.getDataFromKQ(lblmasv2.Text);
                    MessageBox.Show("Cập Nhật Điểm Thành Công");
                }
                else if (buskq.updateDataKQ(kq) == 0)
                {
                    MessageBox.Show("Cập Nhật Điểm Không Thành Công");
                }
                else if (buskq.updateDataKQ(kq) == -1)
                {
                    MessageBox.Show("Bạn Chưa Điền Đầy Đủ Dữ Liệu Hoặc Sai Dữ Liệu Vui Lòng Kiểm Tra Lại!!!");
                }
            }

        }

        private void btnthoat1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string exchangeMaGV(string a, string s)
        {
            string z = "";
            DataTable dt = new DataTable();
            dt = busgiangvien.getDataFromGV1(s);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][1].ToString() == a)
                {
                    z = dt.Rows[i][0].ToString();
                }
            }
            return z;
        }
        public string exchangeMaMH(string a, string k)
        {
            string z = "";
            DataTable dt = new DataTable();
            dt = busmonhoc.getDataFromMH(k);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][1].ToString() == a)
                {
                    z = dt.Rows[i][0].ToString();
                }
            }
            return z;
        }
        private void buttonthemttkb_Click(object sender, EventArgs e)
        {
            string maLop = txtmalop.Text;
            string maSV = lblmasv2.Text;
            string thu = cbothu.Text;
            string buoi = cbobuoi.Text;
            string thoiGian = txtthoigian.Text;
            string phong = txtphong.Text;
            string maMH = exchangeMaMH(cbomonhoctkb.Text, exchangeMaKhoa(cbokhoa.Text));
            string maGV = exchangeMaGV(cbomagv.Text, exchangeMaKhoa(cbokhoa.Text));
            ThoiKhoaBieu tkb = new ThoiKhoaBieu(maLop, maSV, thu, buoi, thoiGian, phong, maMH, maGV);
            if (bustkb.insertDataFrommTKB(tkb) == 1)
            {
                dataGridView1.DataSource = bustkb.getDataFromTKB(frmttsv.maSV);
                MessageBox.Show("Thêm Lịch Thành Công!!!");
            }
            else if (bustkb.insertDataFrommTKB(tkb) == 0)
            {
                MessageBox.Show("Thêm Lịch  Không Thành Công!!!");
            }
            else
            {
                MessageBox.Show("Lỗi Dữ Liệu Vui Lòng Kiểm Tra!!!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                btnxoatkb.Enabled = true;
                int i = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow dgr = dataGridView1.Rows[i];
                txtmalop.Text = dgr.Cells[0].Value.ToString();
                cbothu.Text = dgr.Cells[1].Value.ToString();
                cbobuoi.Text = dgr.Cells[2].Value.ToString();
                txtthoigian.Text = dgr.Cells[3].Value.ToString();
                txtphong.Text = dgr.Cells[4].Value.ToString();
                cbomagv.Text = dgr.Cells[6].Value.ToString();
                string s = dgr.Cells[5].Value.ToString();
                cbomonhoctkb.Text = s;
            }
            else
            {
                btnxoatkb.Enabled = false;
            }                
        }

        private void buttonsuatkb_Click(object sender, EventArgs e)
        {
            if (cbobuoi.Text == string.Empty || cbothu.Text == string.Empty || cbomagv.Text == string.Empty || txtmalop.Text == string.Empty || txtthoigian.Text == string.Empty || txtphong.Text == string.Empty || cbomonhoctkb.Text == string.Empty
                || cbobuoi.Text == string.Empty && cbothu.Text == string.Empty && cbomagv.Text == string.Empty && txtmalop.Text == string.Empty && txtthoigian.Text == string.Empty && txtphong.Text == string.Empty && cbomonhoctkb.Text == string.Empty)
            {
                MessageBox.Show("Bạn Chưa Nhập Đầy Đủ Dữ Liệu Vui Lòng Nhập Lại!!");
            }
            else
            {
                string maLop = txtmalop.Text;
                string maSV = lblmasv2.Text;
                string thu = cbothu.Text;
                string buoi = cbobuoi.Text;
                string thoiGian = txtthoigian.Text;
                string phong = txtphong.Text;
                string maMH = exchangeMaMH(cbomonhoctkb.Text, exchangeMaKhoa(cbokhoa.Text));
                string maGV = exchangeMaGV(cbomagv.Text, exchangeMaKhoa(cbokhoa.Text));
                ThoiKhoaBieu tkb = new ThoiKhoaBieu(maLop, maSV, thu, buoi, thoiGian, phong, maMH, maGV);
                if (bustkb.updateDataFrommTKB(tkb) == 1)
                {
                    dataGridView1.DataSource = bustkb.getDataFromTKB(frmttsv.maSV);
                    MessageBox.Show("update Lịch Thành Công!!!");
                }
                else if (bustkb.updateDataFrommTKB(tkb) == 0)
                {
                    MessageBox.Show("update  Lịch  Không Thành Công!!!");
                }
                else
                {
                    MessageBox.Show("Lỗi Dữ Liệu Vui Lòng Kiểm Tra!!!");
                }
            }

        }

        private void buttonxoatkb_Click(object sender, EventArgs e)
        {
            if (cbobuoi.Text == string.Empty || cbothu.Text == string.Empty || cbomagv.Text == string.Empty || txtmalop.Text == string.Empty || txtthoigian.Text == string.Empty || txtphong.Text == string.Empty || cbomonhoctkb.Text == string.Empty
                 || cbobuoi.Text == string.Empty && cbothu.Text == string.Empty && cbomagv.Text == string.Empty && txtmalop.Text == string.Empty && txtthoigian.Text == string.Empty && txtphong.Text == string.Empty && cbomonhoctkb.Text == string.Empty)
            {
                MessageBox.Show("Lỗi Dữ Liệu Không Thể Xóa !!");
            }
            else
            {
                DialogResult r;
                r = MessageBox.Show("Bạn Có Chắc Chắn Muốn Xóa Dữ Liệu???", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    string maLop = txtmalop.Text;
                    if (bustkb.removeDataFrommTKB(maLop) == 1)
                    {
                        dataGridView1.DataSource = bustkb.getDataFromTKB(frmttsv.maSV);
                        MessageBox.Show("Xóa Lịch Thành Công!!!");
                    }
                    else if (bustkb.removeDataFrommTKB(maLop) == 0)
                    {
                        MessageBox.Show("Xóa Lịch  Không Thành Công!!!");
                    }
                    else if (bustkb.removeDataFrommTKB(maLop) == -1)
                    {
                        MessageBox.Show("Lỗi Dữ Liệu Vui Lòng Kiểm Tra Lại!!!");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btntaomoitkb_Click(object sender, EventArgs e)
        {
            cbobuoi.Text = string.Empty;
            cbothu.Text = string.Empty;
            cbomagv.Text = string.Empty;
            txtmalop.Text = string.Empty;
            txtthoigian.Text = string.Empty;
            txtphong.Text = string.Empty;
            cbomonhoctkb.Text = string.Empty;
        }
        private void btnlammoidiem_Click(object sender, EventArgs e)
        {
            cbomamonhoc.Text = string.Empty;
            cbotenmonhoc.Text = string.Empty;
            txtdiemthi.Text = string.Empty;
        }

        private void cbothu_TextChanged(object sender, EventArgs e)
        {
            if (cbothu.Text != string.Empty && cbobuoi.Text != string.Empty && txtmalop.Text != string.Empty
                && txtthoigian.Text != string.Empty && txtphong.Text != string.Empty && cbomonhoctkb.Text != string.Empty && cbomagv.Text != string.Empty)
            {
                btnthemtkb.Enabled = true;
                btnsuatkb.Enabled = true;
            }
            else
            {
                btnthemtkb.Enabled = false;
                btnsuatkb.Enabled = false;
            }                
        }

        private void cbobuoi_TextChanged(object sender, EventArgs e)
        {
            if (cbothu.Text != string.Empty && cbobuoi.Text != string.Empty && txtmalop.Text != string.Empty
               && txtthoigian.Text != string.Empty && txtphong.Text != string.Empty && cbomonhoctkb.Text != string.Empty && cbomagv.Text != string.Empty)
            {
                btnthemtkb.Enabled = true;
                btnsuatkb.Enabled = true;
            }
            else
            {
                btnthemtkb.Enabled = false;
                btnsuatkb.Enabled = false;
            }
        }

        private void txtmalop_TextChanged(object sender, EventArgs e)
        {
            if (cbothu.Text != string.Empty && cbobuoi.Text != string.Empty && txtmalop.Text != string.Empty
               && txtthoigian.Text != string.Empty && txtphong.Text != string.Empty && cbomonhoctkb.Text != string.Empty && cbomagv.Text != string.Empty)
            {
                btnthemtkb.Enabled = true;
                btnsuatkb.Enabled = true;
            }
            else
            {
                btnthemtkb.Enabled = false;
                btnsuatkb.Enabled = false;
            }
        }

        private void txtthoigian_TextChanged(object sender, EventArgs e)
        {
            if (cbothu.Text != string.Empty && cbobuoi.Text != string.Empty && txtmalop.Text != string.Empty
               && txtthoigian.Text != string.Empty && txtphong.Text != string.Empty && cbomonhoctkb.Text != string.Empty && cbomagv.Text != string.Empty)
            {
                btnthemtkb.Enabled = true;
                btnsuatkb.Enabled = true;
            }
            else
            {
                btnthemtkb.Enabled = false;
                btnsuatkb.Enabled = false;
            }
        }

        private void txtphong_TextChanged(object sender, EventArgs e)
        {
            if (cbothu.Text != string.Empty && cbobuoi.Text != string.Empty && txtmalop.Text != string.Empty
               && txtthoigian.Text != string.Empty && txtphong.Text != string.Empty && cbomonhoctkb.Text != string.Empty && cbomagv.Text != string.Empty)
            {
                btnthemtkb.Enabled = true;
                btnsuatkb.Enabled = true;
            }
            else
            {
                btnthemtkb.Enabled = false;
                btnsuatkb.Enabled = false;
            }
        }

       

        private void cbomagv_TextChanged(object sender, EventArgs e)
        {
            if (cbothu.Text != string.Empty && cbobuoi.Text != string.Empty && txtmalop.Text != string.Empty
               && txtthoigian.Text != string.Empty && txtphong.Text != string.Empty && cbomonhoctkb.Text != string.Empty && cbomagv.Text != string.Empty)
            {
                btnthemtkb.Enabled = true;
                btnsuatkb.Enabled = true;
            }
            else
            {
                btnthemtkb.Enabled = false;
                btnsuatkb.Enabled = false;
            }
        }

        private void cbomonhoctkb_TextChanged(object sender, EventArgs e)
        {
            if (cbothu.Text != string.Empty && cbobuoi.Text != string.Empty && txtmalop.Text != string.Empty
               && txtthoigian.Text != string.Empty && txtphong.Text != string.Empty && cbomonhoctkb.Text != string.Empty && cbomagv.Text != string.Empty)
            {
                btnthemtkb.Enabled = true;
                btnsuatkb.Enabled = true;
            }
            else
            {
                btnthemtkb.Enabled = false;
                btnsuatkb.Enabled = false;
            }
        }

        private void cbotenmonhoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt4 = busmonhoc.getDataFromMH(exchangeMaKhoa(cbokhoa.Text));
            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                if(cbotenmonhoc.Text == dt4.Rows[i][1].ToString())
                {
                    cbomamonhoc.Text = dt4.Rows[i][0].ToString();
                }    
            }
        }

        private void txtmasv_TextChanged(object sender, EventArgs e)
        {
            if(txtmasv.Text != string.Empty && txttensv.Text != string.Empty && txthosv.Text != string.Empty && txtgioitinh.Text != string.Empty
                && txtngaysinh.Text != string.Empty && txtnoisinh.Text != string.Empty && txtdiachi.Text != string.Empty && cbokhoa.Text != string.Empty)
            {
                btnsuathongtin.Enabled = true;
            }    
            else
            {
                btnsuathongtin.Enabled = false;
            }                
        }

        private void txthosv_TextChanged(object sender, EventArgs e)
        {
            if (txtmasv.Text != string.Empty && txttensv.Text != string.Empty && txthosv.Text != string.Empty && txtgioitinh.Text != string.Empty
             && txtngaysinh.Text != string.Empty && txtnoisinh.Text != string.Empty && txtdiachi.Text != string.Empty && cbokhoa.Text != string.Empty)
            {
                btnsuathongtin.Enabled = true;
            }
            else
            {
                btnsuathongtin.Enabled = false;
            }
        }

        private void txttensv_TextChanged(object sender, EventArgs e)
        {
            if (txtmasv.Text != string.Empty && txttensv.Text != string.Empty && txthosv.Text != string.Empty && txtgioitinh.Text != string.Empty
             && txtngaysinh.Text != string.Empty && txtnoisinh.Text != string.Empty && txtdiachi.Text != string.Empty && cbokhoa.Text != string.Empty)
            {
                btnsuathongtin.Enabled = true;
            }
            else
            {
                btnsuathongtin.Enabled = false;
            }
        }

        private void txtgioitinh_TextChanged(object sender, EventArgs e)
        {
            if (txtmasv.Text != string.Empty && txttensv.Text != string.Empty && txthosv.Text != string.Empty && txtgioitinh.Text != string.Empty
             && txtngaysinh.Text != string.Empty && txtnoisinh.Text != string.Empty && txtdiachi.Text != string.Empty && cbokhoa.Text != string.Empty)
            {
                btnsuathongtin.Enabled = true;
            }
            else
            {
                btnsuathongtin.Enabled = false;
            }
        }

        private void txtngaysinh_TextChanged(object sender, EventArgs e)
        {
            if (txtmasv.Text != string.Empty && txttensv.Text != string.Empty && txthosv.Text != string.Empty && txtgioitinh.Text != string.Empty
             && txtngaysinh.Text != string.Empty && txtnoisinh.Text != string.Empty && txtdiachi.Text != string.Empty && cbokhoa.Text != string.Empty)
            {
                btnsuathongtin.Enabled = true;
            }
            else
            {
                btnsuathongtin.Enabled = false;
            }
        }

        private void txtnoisinh_TextChanged(object sender, EventArgs e)
        {
            if (txtmasv.Text != string.Empty && txttensv.Text != string.Empty && txthosv.Text != string.Empty && txtgioitinh.Text != string.Empty
             && txtngaysinh.Text != string.Empty && txtnoisinh.Text != string.Empty && txtdiachi.Text != string.Empty && cbokhoa.Text != string.Empty)
            {
                btnsuathongtin.Enabled = true;
            }
            else
            {
                btnsuathongtin.Enabled = false;
            }
        }

        private void txtdiachi_TextChanged(object sender, EventArgs e)
        {
            if (txtmasv.Text != string.Empty && txttensv.Text != string.Empty && txthosv.Text != string.Empty && txtgioitinh.Text != string.Empty
             && txtngaysinh.Text != string.Empty && txtnoisinh.Text != string.Empty && txtdiachi.Text != string.Empty && cbokhoa.Text != string.Empty)
            {
                btnsuathongtin.Enabled = true;
            }
            else
            {
                btnsuathongtin.Enabled = false;
            }
        }

        private void cbokhoa_TextChanged(object sender, EventArgs e)
        {
            if (txtmasv.Text != string.Empty && txttensv.Text != string.Empty && txthosv.Text != string.Empty && txtgioitinh.Text != string.Empty
             && txtngaysinh.Text != string.Empty && txtnoisinh.Text != string.Empty && txtdiachi.Text != string.Empty && cbokhoa.Text != string.Empty)
            {
                btnsuathongtin.Enabled = true;
            }
            else
            {
                btnsuathongtin.Enabled = false;
            }
        }

        private void textBoxmasv_TextChanged(object sender, EventArgs e)
        {
            if(cbotenmonhoc.Text != string.Empty && txtdiemthi.Text != string.Empty)
            {
                btnthemdiem.Enabled = true;
                btnsuadiem.Enabled = true;
            }
            else
            {
                btnthemdiem.Enabled = false;
                btnsuadiem.Enabled = false;
            }                
        }

        private void txtdiemthi_TextChanged(object sender, EventArgs e)
        {
            if (cbotenmonhoc.Text != string.Empty && txtdiemthi.Text != string.Empty)
            {
                btnthemdiem.Enabled = true;
                btnsuadiem.Enabled = true;
            }
            else
            {
                btnthemdiem.Enabled = false;
                btnsuadiem.Enabled = false;
            }
        }

        private void btnintkb_Click(object sender, EventArgs e)
        {
            maSV = lblmasv2.Text;
            frmthoikhoabieusinhvien frm1 = new frmthoikhoabieusinhvien();
            frm1.ShowDialog();
        }

        private void btnxuatdiemsv_Click(object sender, EventArgs e)
        {
            maSV = lblmasv2.Text;
            frmreportdiemsinhvien  frm1 = new frmreportdiemsinhvien();
            frm1.ShowDialog();
        }
    }
}
