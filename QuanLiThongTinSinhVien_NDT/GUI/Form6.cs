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
    public partial class frmuser : Form
    {
        private static string maSV;
        public frmuser()
        {
            InitializeComponent();
        }
        BUS_SinhVien bussv = new BUS_SinhVien();
        BUS_ThoiKhoaBieu bustkb = new BUS_ThoiKhoaBieu();
        BUS_KetQua buskq = new BUS_KetQua();

        public static string MaSV { get => maSV; set => maSV = value; }

        private void Form6_Load(object sender, EventArgs e)
        {
            string s = frmdangnhap.maSV;
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
            }

            dataGridView1.DataSource = bustkb.getDataFromTKB(txtmasv.Text);
            lblmasv2.Text = txtmasv.Text;
            lbltensv2.Text = txthosv.Text + txttensv.Text;
            //////////////////////////////////////////////////////////////////
            DataTable dt1 = new DataTable();
            dataGridView2.DataSource = buskq.getDataFromKQ(lblmasv2.Text);
            textBoxtensv.Text = lbltensv2.Text;
            textBoxmasv.Text = lblmasv2.Text;

        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmdangnhap f4 = new frmdangnhap();
            f4.ShowDialog();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int i = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow dgr = dataGridView1.Rows[i];
                textBoxmalop.Text = dgr.Cells[0].Value.ToString();
                comboBoxthu.Text = dgr.Cells[1].Value.ToString();
                comboBoxbuoi.Text = dgr.Cells[2].Value.ToString();
                textBoxthoigian.Text = dgr.Cells[3].Value.ToString();
                textBoxphong.Text = dgr.Cells[4].Value.ToString();
                string s = bustkb.getMaMHFormSQL(dgr.Cells[5].Value.ToString()).Rows[0][0].ToString();
                textBoxmamonhoc.Text = s;
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                int i = dataGridView2.SelectedCells[0].RowIndex;
                DataGridViewRow dtr = dataGridView2.Rows[i];
                textBoxmamh.Text = dtr.Cells[1].Value.ToString();
                textBoxtenmh.Text = dtr.Cells[2].Value.ToString();
                textBoxdiemthi.Text = dtr.Cells[3].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmdangnhap f4 = new frmdangnhap();
            f4.ShowDialog();
            
        }

        private void btnthoat1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmdangnhap f4 = new frmdangnhap();
            f4.ShowDialog();
            
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
            frmreportdiemsinhvien frm1 = new frmreportdiemsinhvien();
            frm1.ShowDialog();
        }
    }
}
