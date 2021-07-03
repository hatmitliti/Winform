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
    public partial class frmadmin : Form
    {
        public static string _message;
        public frmadmin()
        {
            InitializeComponent();
        }
        BUS_SinhVien bussv = new BUS_SinhVien();
        BUS_Account busacc = new BUS_Account();
        BUS_ThoiKhoaBieu bustkb = new BUS_ThoiKhoaBieu();
        BUS_KetQua buskq = new BUS_KetQua();
        BUS_Khoa buskhoa = new BUS_Khoa();
        BUS_GiangVien busgiangvien = new BUS_GiangVien();

        public string Message { get => _message; set => _message = value; }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = bussv.getDataFromSinhVien();
                dataGridView4.DataSource = buskhoa.getDataFromKhoa();
                dataGridView3.DataSource = busacc.getDataFromACC();
                dataGridView3.Columns[1].Visible = false;
                ///
                DataTable dt = new DataTable();
                dt = buskhoa.getDataFromKhoa();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbokhoaqlgv.Items.Add(dt.Rows[i][1]);
                    cbomakhoaqlgv.Items.Add(dt.Rows[i][1]);
                    cbokhoa.Items.Add(dt.Rows[i][1]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Connect !! " + ex);
            }
        }
        // sự kiện cho phím thông tin sinh viên
        private void btnthongtinsinhvien_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int i = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow r = dataGridView1.Rows[i];
                _message = r.Cells[0].Value.ToString();
                frmttsv frm2 = new frmttsv();
                frm2.ShowDialog();
                if (frmttsv.a == 1)
                {
                    dataGridView1.DataSource = bussv.getDataFromSinhVien();
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Chọn Đối Tượng Sinh Viên!!");
            }
        }
        //sự kiện cho phím thêm sinh viên
        private void btnthemsv_Click(object sender, EventArgs e)
        {
            frmthemsv frm = new frmthemsv();
            frm.ShowDialog();
            if (frmthemsv.a == 1)
            {
                dataGridView1.DataSource = bussv.getDataFromSinhVien();
            }
        }
        // sự kiện cho phím xoa sinh viên
        private void btnxoasv_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                DialogResult r;
                r = MessageBox.Show("Bạn Có Chắc Chắn Muốn Xóa Thông tin Sinh viên này không", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    int i = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow dt = dataGridView1.Rows[i];
                    if (bussv.removeSinhVien(dt.Cells[0].Value.ToString()) == 1)
                    {
                        MessageBox.Show("Xóa Thành Công!!");
                        dataGridView1.DataSource = bussv.getDataFromSinhVien();
                    }
                    else if (bussv.removeSinhVien(dt.Cells[0].Value.ToString()) == 0)
                    {
                        MessageBox.Show("Xóa Không Thành Công!!");
                    }
                    else
                    {
                        MessageBox.Show("Vì Lí Do Liên Kết Dữ Liệu Nên Hiện Tại Vẫn Chưa Thể Xóa, Vui Lòng Kiểm Tra Và Xóa Các Dữ Liệu Liên Quan Trước...");
                    }
                }

            }
            else
            {
                MessageBox.Show("Vui Lòng Chọn Đối Tượng Sinh Viên!!");
            }
        }


        // sự kiện cho phím thoát
        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn Có Muốn Thoát Chương Trình", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }
        // sự kiện cho phím  tìm sinh viên
        private void btnindssv_Click(object sender, EventArgs e)
        {
            frmxuatdssv frm = new frmxuatdssv();
            frm.ShowDialog();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        //hàm kiểm tra chuỗi
        public bool ktTtext(string s)
        {
            DataTable dt = bussv.getDataFromSinhVien();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (s.Trim().Equals(dt.Rows[i][0].ToString().Trim()))
                {
                    return true;
                }
            }
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            if (s != null && ktTtext(s) == true)
            {
                _message = s;
                frmttsv frm2 = new frmttsv();
                frm2.ShowDialog();
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Lỗi Dữ Liệu, Vui Lòng Kiểm Tra Lại!!");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        BUS_MonHoc busmh = new BUS_MonHoc();
        //sự kiện cho nút thêm giao diện quản lí môn học
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
        private void buttonthem_Click(object sender, EventArgs e)
        {
            try
            {
                string maMH = txtmamh.Text;
                string tenMH = txttenmh.Text;
                int soTinChi = int.Parse(txtsotinchi.Text);
                string maKhoa = exchangeString1(cbomakhoa.Text);
                string maGV = exchangeMaGV(cbomagv.Text, maKhoa);
                MonHoc mh = new MonHoc(maMH, tenMH, soTinChi, maKhoa, maGV);
                if (busmh.insertDataFrommMH(mh) == 1)
                {
                    dataGridView2.DataSource = busmh.getDataFromMH(exchangeString1(cbokhoa.Text));
                    MessageBox.Show("Thêm Môn Học Thành Công!!!");
                }
                else if (busmh.insertDataFrommMH(mh) == 0)
                {
                    MessageBox.Show("Thêm Môn Học Không Thành Công!!!");
                }
                else if (busmh.insertDataFrommMH(mh) == -1)
                {
                    MessageBox.Show("Dữ Liệu Mã Môn Học " + txtmamh.Text + " Bị Trùng Lặp Vui Lòng Nhập Lại");
                }
            }
            catch (Exception o)
            {
                MessageBox.Show("Bạn Chưa Nhập Dữ Liệu Đầy Đủ Vui Lòng Kiêm Tra Lại!!");
            }


        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        // hàm chuyển từ tên khoa về mã khoa
        public string exchangeString(string s)
        {
            string a = "";
            DataTable dt = new DataTable();
            dt = buskhoa.getDataFromKhoa();
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString().Trim() == s.Trim().ToString())
                {
                    a = dt.Rows[i][1].ToString().Trim();
                }
            }
            return a;
        }
        // hàm set dữ liệu cho comboboxkhoa trong giao diện quản lí môn học
        private void comboBoxkhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.DataSource = busmh.getDataFromMH(exchangeString1(cbokhoa.Text));
                cbomagv.Items.Clear();
                cbomagv.Text = null;
                if (exchangeString(cbokhoa.Text) != null)
                {
                    DataTable dt2 = bustkb.getMaGVFormSQL(exchangeString1(cbokhoa.Text));
                    DataTable dt3 = buskhoa.getDataFromKhoa();
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        cbomagv.Items.Add(dt2.Rows[i][1].ToString());
                    }
                    for (int j = 0; j < dt3.Rows.Count; j++)
                    {
                        cbomakhoa.Items.Add(dt3.Rows[j][1]);
                    }
                    txtmamh.Text = null;
                    txttenmh.Text = null;
                    txtsotinchi.Text = null;
                    cbomakhoa.Text = null;
                }
            }
            catch (Exception o)
            {
                throw o;
            }

        }
        // sự kiện cho nút xóa trong giao diện quản lí môn học 
        private void buttonxoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult r;
                r = MessageBox.Show("Bạn Có Chắc Chắn Muốn Xóa Dữ Liệu???", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {

                    if (busmh.removeDataFrommMH(txtmamh.Text) == 1)
                    {
                        dataGridView2.DataSource = busmh.getDataFromMH(exchangeString1(cbokhoa.Text));
                        MessageBox.Show("Xóa Môn Học Thành Công!!!");
                    }
                    if (busmh.removeDataFrommMH(txtmamh.Text) == 0)
                    {
                        MessageBox.Show("Xóa Môn Học Không Thành Công!!!");
                    }
                    if (busmh.removeDataFrommMH(txtmamh.Text) == -1)
                    {
                        MessageBox.Show("Lỗi Liên  Quan Đến Dữ Liệu, Không xóa được dữ liệu vui lòng kiểm tra lại");
                    }

                }
            }
            catch (Exception i)
            {
                MessageBox.Show("Lỗi Dữ Liệu Vui Lòng kiểm Tra Lại");
            }

        }
        // sự kiện cho phím sửa thông tin môn học trong giao diện quản lí môn học
        private void buttonsua_Click(object sender, EventArgs e)
        {
            try
            {
                string maMH = txtmamh.Text;
                string tenMH = txttenmh.Text;
                int soTinChi = int.Parse(txtsotinchi.Text);
                string maKhoa = exchangeString1(cbomakhoa.Text);
                string maGV = exchangeMaGV(cbomagv.Text, maKhoa);
                MonHoc mh = new MonHoc(maMH, tenMH, soTinChi, maKhoa, maGV);
                if (busmh.updateDataFrommMH(mh) == 1)
                {
                    dataGridView2.DataSource = busmh.getDataFromMH(exchangeString1(cbokhoa.Text));
                    MessageBox.Show("Update Môn Học Thành Công!!!");
                }
                else
                {
                    MessageBox.Show("Update Môn Học Không Thành Công!!!");
                }

            }
            catch (Exception i)
            {
                MessageBox.Show("bạn Chưa Nhập Đầy Đủ Thông Tin Dữ Liệu Muốn Sửa, Vui Lòng Kiểm Tra Lại!!");
            }
        }
        // sự kiện cho phím thoát trong giao diện quản lí môn học
        private void buttonthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // sự kiện khi click vào các cell trong dataGridView2 thuộc giao diện quản lí môn học
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                btnxoamonhoc.Enabled = true;
                int i = dataGridView2.SelectedCells[0].RowIndex;
                DataGridViewRow dgr = dataGridView2.Rows[i];
                txtmamh.Text = dgr.Cells[0].Value.ToString();
                txttenmh.Text = dgr.Cells[1].Value.ToString();
                txtsotinchi.Text = dgr.Cells[2].Value.ToString();
                cbomakhoa.Text = dgr.Cells[3].Value.ToString();
                cbomagv.Text = dgr.Cells[4].Value.ToString();
            }
            else
            {
                btnxoamonhoc.Enabled = false ;
            }
        }

        // sự kiện khi nhấn phím thêm trong giao diện account
        private void buttonthemaccount_Click(object sender, EventArgs e)
        {
            if (txttaikhoan.Text == string.Empty || txtmatkhau.Text == string.Empty || cbophanquyen.Text == string.Empty ||
                txttaikhoan.Text == string.Empty && txtmatkhau.Text == string.Empty && cbophanquyen.Text == string.Empty)
            {
                MessageBox.Show("Bạn Chưa Nhập Đầy Đủ Dữ Liệu,Vui Lòng Kiểm Tra Lại");
            }
            else
            {
                string taiKhoan = txttaikhoan.Text;
                string matKhau = txtmatkhau.Text;
                string phanQuyen = "";
                if (cbophanquyen.Text == "Giảng Viên")
                {
                    phanQuyen = "GV";
                }
                else
                {
                    phanQuyen = "SV";
                }
                Account acc = new Account(taiKhoan, matKhau, phanQuyen);
                if (busacc.insertDataACC(acc) == 1)
                {
                    dataGridView3.DataSource = busacc.getDataFromACC();
                    MessageBox.Show("Thêm Account Thành Công!!");
                }
                else if (busacc.insertDataACC(acc) == 0)
                {
                    MessageBox.Show("Thêm Account Không Thành Công!!");
                }
                else
                {
                    MessageBox.Show("Dữ Liệu Tài Khoản " + txttaikhoan.Text + " Bị Trùng Lặp Vui Lòng Nhập Lại");
                }
            }

        }
        //sự kiện khi nhấn phím xóa trong giao diện quản lí acccount
        private void buttonxoaaccount_Click(object sender, EventArgs e)
        {
            if (txttaikhoan.Text == string.Empty || txtmatkhau.Text == string.Empty || cbophanquyen.Text == string.Empty ||
               txttaikhoan.Text == string.Empty && txtmatkhau.Text == string.Empty && cbophanquyen.Text == string.Empty)
            {
                MessageBox.Show("Lỗi Dữ Liệu Không Thể Xóa!!");
            }
            else
            {
                DialogResult r;
                r = MessageBox.Show("Bạn Có Chắc Chắn Muốn Xóa Dữ Liệu???", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    string taiKhoan = txttaikhoan.Text;
                    if (busacc.removeDataACC(taiKhoan) == 1)
                    {
                        dataGridView3.DataSource = busacc.getDataFromACC();
                        MessageBox.Show("Xóa Account Thành Công!!");
                    }
                    else if (busacc.removeDataACC(taiKhoan) == 0)
                    {
                        MessageBox.Show("Xóa Account Không Thành Công!!");
                    }
                    else if (busacc.removeDataACC(taiKhoan) == -1)
                    {

                        MessageBox.Show("Dữ Liệu Này Ảnh Hưởng đến Các Miền Dữ Liệu Khác Vui Lòng Kiểm Tra Lại!!");
                    }
                }
            }

        }
        //sự kiện khi bấm phím sửa acccount
        private void buttonsuaaccount_Click(object sender, EventArgs e)
        {

            if (txttaikhoan.Text == string.Empty || txtmatkhau.Text == string.Empty || cbophanquyen.Text == string.Empty ||
          txttaikhoan.Text == string.Empty && txtmatkhau.Text == string.Empty && cbophanquyen.Text == string.Empty)
            {
                MessageBox.Show("bạn Chưa Nhập Đầy Đủ Thông Tin Dữ Liệu Muốn Sửa, Vui Lòng Kiểm Tra Lại!!");
            }
            else
            {
                string taiKhoan = txttaikhoan.Text;
                string matKhau = txtmatkhau.Text;
                string phanQuyen = "";
                if (cbophanquyen.Text == "Giảng Viên")
                {
                    phanQuyen = "GV";
                }
                else
                {
                    phanQuyen = "SV";
                }
                Account acc = new Account(taiKhoan, matKhau, phanQuyen);
                if (busacc.updateDataACC(acc) == 1)
                {
                    dataGridView3.DataSource = busacc.getDataFromACC();
                    MessageBox.Show("Update Account Thành Công!!");
                }
                else
                {
                    MessageBox.Show("Update Account Không Thành Công!!");
                }
            }

        }
        //sự kiện khi nhấn phím thoát trong giao diện account
        private void buttonthoataccount_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // sự khiện khi nhấn các cell của dataGridView3 trong giao diện quản lí account
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.SelectedCells.Count > 0)
            {
                btnxoaaccount.Enabled = true;
                int i = dataGridView3.SelectedCells[0].RowIndex;
                DataGridViewRow dgr = dataGridView3.Rows[i];
                txttaikhoan.Text = dgr.Cells[0].Value.ToString();
                txtmatkhau.Text = dgr.Cells[1].Value.ToString().Trim();
                if (dgr.Cells[2].Value.ToString() == "GV")
                {
                    cbophanquyen.Text = "Giảng Viên";
                }
                else
                {
                    cbophanquyen.Text = "Sinh Viên";
                }
            }
            else
            {
                btnxoaaccount.Enabled = false;
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        //sự kiện cho phím đăng xuất
        private void button2_Click(object sender, EventArgs e)
        {
            frmdangnhap f4 = new frmdangnhap();
            this.Hide();
            f4.ShowDialog();

        }
        //sự khiện cho phím làm mới trong giao diện quản lí môn học
        private void btnlammoimh_Click(object sender, EventArgs e)
        {
            txtmamh.Text = null;
            txttenmh.Text = null;
            txtsotinchi.Text = null;
            cbomakhoa.Text = null;
            cbomagv.Text = null;
        }
        //sự khiện cho phím làm mới trong giao diện quản lí account
        private void btnlammoiacc_Click(object sender, EventArgs e)
        {
            txttaikhoan.Text = string.Empty;
            txtmatkhau.Text = string.Empty;
            cbophanquyen.Text = string.Empty;
        }
        private void tpqlk_Click(object sender, EventArgs e)
        {

        }

        private void btnthemqlk_Click(object sender, EventArgs e)
        {
            if (txtmakhoaqlk.Text == string.Empty || txttenkhoaqlk.Text == string.Empty)
            {
                MessageBox.Show("Bạn Chưa Nhập Đầy Đủ Dữ Liệu,Vui Lòng Kiểm Tra Lại");
            }
            else
            {
                string makhoa = txtmakhoaqlk.Text;
                string tenkhoa = txttenkhoaqlk.Text;
                Khoa k = new Khoa(makhoa, tenkhoa);
                if (buskhoa.insertDataKhoa(k) == 1)
                {
                    dataGridView4.DataSource = buskhoa.getDataFromKhoa();
                    MessageBox.Show("Thêm Khoa Thành Công!!");
                }
                else if (buskhoa.insertDataKhoa(k) == 0)
                {
                    MessageBox.Show("Thêm Khoa Không Thành Công!!");
                }
                else
                {
                    MessageBox.Show("Dữ Liệu Tài Khoản " + txtmakhoaqlk.Text + " Bị Trùng Lặp Vui Lòng Nhập Lại");
                }
            }
        }

        private void btnsuaqlk_Click(object sender, EventArgs e)
        {
            if (txtmakhoaqlk.Text == string.Empty || txttenkhoaqlk.Text == string.Empty)
            {
                MessageBox.Show("Bạn Chưa Nhập Đầy Đủ Dữ Liệu,Vui Lòng Kiểm Tra Lại");
            }
            else
            {
                string makhoa = txtmakhoaqlk.Text;
                string tenkhoa = txttenkhoaqlk.Text;
                Khoa k = new Khoa(makhoa, tenkhoa);
                if (buskhoa.updateDataKhoa(k) == 1)
                {
                    dataGridView4.DataSource = buskhoa.getDataFromKhoa();
                    MessageBox.Show("Sửa Thông Tin  Khoa Thành Công!!");
                }
                else if (buskhoa.insertDataKhoa(k) == 0)
                {
                    MessageBox.Show("Sửa Thông Tin Khoa Không Thành Công!!");
                }
            }
        }

        private void btnthoatqlk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnxoaqlk_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedCells.Count == 0)
            {
                MessageBox.Show("Vui Lòng Chọn Khoa Để Xóa!!");
            }
            else
            {
                int i = dataGridView4.SelectedCells[0].RowIndex;
                DataGridViewRow datagv = dataGridView4.Rows[i];
                if (buskhoa.removeDataKhoa(datagv.Cells[0].Value.ToString()) == 1)
                {
                    dataGridView4.DataSource = buskhoa.getDataFromKhoa();
                    MessageBox.Show("Xóa Thông Tin  Khoa Thành Công!!");
                }
                else if (buskhoa.removeDataKhoa(datagv.Cells[0].Value.ToString()) == 0)
                {
                    MessageBox.Show("Xóa Thông Tin Khoa Không Thành Công!!");
                }
                else
                {
                    MessageBox.Show("Vì Lí Do Liên Kết Dữ Liệu Nên Hiện Tại Vẫn Chưa Thể Xóa, Vui Lòng Kiểm Tra Và Xóa Các Dữ Liệu Liên Quan Trước...");
                }
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.SelectedCells.Count > 0)
            {
                btnxoaqlk.Enabled = true;
                int i = dataGridView4.SelectedCells[0].RowIndex;
                DataGridViewRow datagv = dataGridView4.Rows[i];
                txtmakhoaqlk.Text = datagv.Cells[0].Value.ToString();
                txttenkhoaqlk.Text = datagv.Cells[1].Value.ToString();
            }
            else
            {
                btnxoaqlk.Enabled = false;
            }
        }

        private void btnthemqlgv_Click(object sender, EventArgs e)
        {

            if (txtmagv.Text == string.Empty || txttengv.Text == string.Empty || cbogioitinhqlgv.Text == string.Empty || cbokhoaqlgv.Text == string.Empty)
            {
                MessageBox.Show("Bạn Chưa Nhập Đầy Đủ Dữ Liệu,Vui Lòng Kiểm Tra Lại");
            }
            else
            {
                string maGV = txtmagv.Text;
                string tenGV = txttengv.Text;
                string gioiTinh = cbogioitinhqlgv.Text;
                string Khoa = exchangeString1(cbokhoaqlgv.Text);
                GiangVien gv = new GiangVien(maGV, tenGV, gioiTinh, Khoa);
                if (busgiangvien.insertDataGV(gv) == 1)
                {
                    dataGridView5.DataSource = busgiangvien.getDataFromGV2(exchangeString1(cbomakhoaqlgv.Text));
                    MessageBox.Show("Thêm Giảng Viên Thành Công!!");
                }
                else if (busgiangvien.insertDataGV(gv) == 0)
                {
                    MessageBox.Show("Thêm Giảng Viên Không Thành Công!!");
                }
                else
                {
                    MessageBox.Show("Dữ Liệu Tài Khoản " + txtmagv.Text + " Bị Trùng Lặp Vui Lòng Nhập Lại");
                }
            }
        }

        private void btnsuaqlgv_Click(object sender, EventArgs e)
        {
            if (txtmagv.Text == string.Empty || txttengv.Text == string.Empty || cbogioitinhqlgv.Text == string.Empty || cbokhoaqlgv.Text == string.Empty)
            {
                MessageBox.Show("Bạn Chưa Nhập Đầy Đủ Dữ Liệu,Vui Lòng Kiểm Tra Lại");
            }
            else
            {
                string maGV = txtmagv.Text;
                string tenGV = txttengv.Text;
                string gioiTinh = cbogioitinhqlgv.Text;
                string Khoa = exchangeString1(cbokhoaqlgv.Text);
                GiangVien gv = new GiangVien(maGV, tenGV, gioiTinh, Khoa);
                if (busgiangvien.updateDataGV(gv) == 1)
                {
                    dataGridView5.DataSource = busgiangvien.getDataFromGV2(exchangeString1(cbomakhoaqlgv.Text));
                    MessageBox.Show("Sửa Thông Tin Giảng Viên Thành Công!!");
                }
                else
                {
                    MessageBox.Show("Sửa Thông Tin Giảng Viên Không Thành Công!!");
                }
            }
        }

        private void btnxoaqlgv_Click(object sender, EventArgs e)
        {
            if (dataGridView5.SelectedCells.Count == 0 || dataGridView5.SelectedCells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("Vui Lòng Chọn Giảng Viên Để Xóa!!");
            }
            else
            {
                int i = dataGridView5.SelectedCells[0].RowIndex;
                DataGridViewRow datagv = dataGridView5.Rows[i];
                if (busgiangvien.removeDataGV(datagv.Cells[0].Value.ToString()) == 1)
                {
                    dataGridView5.DataSource = busgiangvien.getDataFromGV2(exchangeString1(cbomakhoaqlgv.Text));
                    MessageBox.Show("Xóa Thông Tin  Giảng Viên Thành Công!!");
                }
                else if (busgiangvien.removeDataGV(datagv.Cells[0].Value.ToString()) == 0)
                {
                    MessageBox.Show("Xóa Thông Tin Giảng Viên  Không  Thành Công!!");
                }
                else
                {
                    MessageBox.Show("Vì Lí Do Liên Kết Dữ Liệu Nên Hiện Tại Vẫn Chưa Thể Xóa, Vui Lòng Kiểm Tra Và Xóa Các Dữ Liệu Liên Quan Trước...");
                }
            }
        }

        private void btnmoiqlgv_Click(object sender, EventArgs e)
        {
            txtmagv.Text = null;
            txttengv.Text = null;
            cbogioitinhqlgv.Text = null;
            cbokhoaqlgv.Text = null;
        }

        private void btnthoatqlgv_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView5.SelectedCells.Count > 0)
            {
                btnxoaqlgv.Enabled = true;
                int i = dataGridView5.SelectedCells[0].RowIndex;
                DataGridViewRow datagv = dataGridView5.Rows[i];
                txtmagv.Text = datagv.Cells[0].Value.ToString();
                txttengv.Text = datagv.Cells[1].Value.ToString();
                cbogioitinhqlgv.Text = datagv.Cells[2].Value.ToString();
                cbokhoaqlgv.Text = datagv.Cells[3].Value.ToString();
            }
            else
            {
                btnxoaqlgv.Enabled = false;
            }
        }
        public string exchangeString1(string s)
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
        private void cbomakhoaqlgv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView5.DataSource = busgiangvien.getDataFromGV2(exchangeString1(cbomakhoaqlgv.Text));
                txtmagv.Text = null;
                txttengv.Text = null;
                cbogioitinhqlgv.Text = null;
                cbokhoaqlgv.Text = null;
            }
            catch (Exception o)
            {
                throw o;
            }
        }

        private void cbomagv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtmagv_TextChanged(object sender, EventArgs e)
        {
            if (txtmagv.Text != string.Empty && txttengv.Text != string.Empty && cbogioitinhqlgv.Text != string.Empty && cbokhoaqlgv.Text != string.Empty)
            {
                btnthemqlgv.Enabled = true;
                btnsuaqlgv.Enabled = true;
            }
            else
            {
                btnthemqlgv.Enabled = false;
                btnsuaqlgv.Enabled = false;
            }

        }

        private void txttengv_TextChanged(object sender, EventArgs e)
        {
            if (txtmagv.Text != string.Empty && txttengv.Text != string.Empty && cbogioitinhqlgv.Text != string.Empty && cbokhoaqlgv.Text != string.Empty)
            {
                btnthemqlgv.Enabled = true;
                btnsuaqlgv.Enabled = true;
            }
            else
            {
                btnthemqlgv.Enabled = false;
                btnsuaqlgv.Enabled = false;
            }

        }

        private void cbogioitinhqlgv_TextChanged(object sender, EventArgs e)
        {
            if (txtmagv.Text != string.Empty && txttengv.Text != string.Empty && cbogioitinhqlgv.Text != string.Empty && cbokhoaqlgv.Text != string.Empty)
            {
                btnthemqlgv.Enabled = true;
                btnsuaqlgv.Enabled = true;
            }
            else
            {
                btnthemqlgv.Enabled = false;
                btnsuaqlgv.Enabled = false;
            }
        }

        private void cbokhoaqlgv_TextChanged(object sender, EventArgs e)
        {
            //enable quan li giang viên
            if (txtmagv.Text != string.Empty && txttengv.Text != string.Empty && cbogioitinhqlgv.Text != string.Empty && cbokhoaqlgv.Text != string.Empty)
            {
                btnthemqlgv.Enabled = true;
                btnsuaqlgv.Enabled = true;
            }
            else
            {
                btnthemqlgv.Enabled = false;
                btnsuaqlgv.Enabled = false;
            }
        }

        private void txtmakhoaqlk_TextChanged(object sender, EventArgs e)
        {
            if (txtmakhoaqlk.Text != string.Empty && txttenkhoaqlk.Text != string.Empty)
            {
                btnthemqlk.Enabled = true;
                btnsuaqlk.Enabled = true;
            }
            else
            {
                btnthemqlk.Enabled = false;
                btnsuaqlk.Enabled = false;
            }
        }

        private void txttenkhoaqlk_TextChanged(object sender, EventArgs e)
        {
            if (txtmakhoaqlk.Text != string.Empty && txttenkhoaqlk.Text != string.Empty)
            {
                btnthemqlk.Enabled = true;
                btnsuaqlk.Enabled = true;
            }
            else
            {
                btnthemqlk.Enabled = false;
                btnsuaqlk.Enabled = false;
            }
        }

        private void btnmoiqlk_Click(object sender, EventArgs e)
        {
            txtmakhoaqlk.Text = null;
            txttenkhoaqlk.Text = null;
        }

        private void txtmatkhau_TextChanged(object sender, EventArgs e)
        {
            if (txttaikhoan.Text != string.Empty && txtmatkhau.Text != string.Empty && cbophanquyen.Text != string.Empty)
            {
                btnthemaccount.Enabled = true;
                btnsuaaccount.Enabled = true;
            }
            else
            {
                btnthemaccount.Enabled = false;
                btnsuaaccount.Enabled = false;
            }
        }

        private void txttaikhoan_TextChanged(object sender, EventArgs e)
        {
            if (txttaikhoan.Text != string.Empty && txtmatkhau.Text != string.Empty && cbophanquyen.Text != string.Empty)
            {
                btnthemaccount.Enabled = true;
                btnsuaaccount.Enabled = true;
            }
            else
            {
                btnthemaccount.Enabled = false;
                btnsuaaccount.Enabled = false;
            }
        }

        private void cbophanquyen_TextChanged(object sender, EventArgs e)
        {
            if (txttaikhoan.Text != string.Empty && txtmatkhau.Text != string.Empty && cbophanquyen.Text != string.Empty)
            {
                btnthemaccount.Enabled = true;
                btnsuaaccount.Enabled = true;
            }
            else
            {
                btnthemaccount.Enabled = false;
                btnsuaaccount.Enabled = false;
            }
        }

        private void cbomakhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtmamh_TextChanged(object sender, EventArgs e)
        {
            if (txtmamh.Text != string.Empty && txttenmh.Text != string.Empty && txtsotinchi.Text != string.Empty && cbomakhoa.Text != string.Empty && cbomagv.Text != string.Empty)
            {
                btnthemmonhoc.Enabled = true;
                btnsuamonhoc.Enabled = true;
            }
            else
            {
                btnthemmonhoc.Enabled = false;
                btnsuamonhoc.Enabled = false;
            }
        }

        private void txttenmh_TextChanged(object sender, EventArgs e)
        {
            if (txtmamh.Text != string.Empty && txttenmh.Text != string.Empty && txtsotinchi.Text != string.Empty && cbomakhoa.Text != string.Empty && cbomagv.Text != string.Empty)
            {
                btnthemmonhoc.Enabled = true;
                btnsuamonhoc.Enabled = true;
            }
            else
            {
                btnthemmonhoc.Enabled = false;
                btnsuamonhoc.Enabled = false;
            }
        }

        private void txtsotinchi_TextChanged(object sender, EventArgs e)
        {
            if (txtmamh.Text != string.Empty && txttenmh.Text != string.Empty && txtsotinchi.Text != string.Empty && cbomakhoa.Text != string.Empty && cbomagv.Text != string.Empty)
            {
                btnthemmonhoc.Enabled = true;
                btnsuamonhoc.Enabled = true;
            }
            else
            {
                btnthemmonhoc.Enabled = false;
                btnsuamonhoc.Enabled = false;
            }
        }

        private void cbomakhoa_TextChanged(object sender, EventArgs e)
        {
            if (txtmamh.Text != string.Empty && txttenmh.Text != string.Empty && txtsotinchi.Text != string.Empty && cbomakhoa.Text != string.Empty && cbomagv.Text != string.Empty)
            {
                btnthemmonhoc.Enabled = true;
                btnsuamonhoc.Enabled = true;
            }
            else
            {
                btnthemmonhoc.Enabled = false;
                btnsuamonhoc.Enabled = false;
            }
        }

        private void cbomagv_TextChanged(object sender, EventArgs e)
        {
            if (txtmamh.Text != string.Empty && txttenmh.Text != string.Empty && txtsotinchi.Text != string.Empty && cbomakhoa.Text != string.Empty && cbomagv.Text != string.Empty)
            {
                btnthemmonhoc.Enabled = true;
                btnsuamonhoc.Enabled = true;
            }
            else
            {
                btnthemmonhoc.Enabled = false;
                btnsuamonhoc.Enabled = false;
            }
        }
    }
}
