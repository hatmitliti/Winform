using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BUS;


namespace QuanLiThongTinSinhVien_NDT
{
    public partial class frmdangnhap : Form
    {
        public static string maSV;
        public frmdangnhap()
        {
            InitializeComponent();
        }
        BUS_Account acc = new BUS_Account();

        public static string MaSV { get => maSV; set => maSV = value; }

        private void txtmatkhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            DataTable dt = acc.getDataFromACC1(txtDangNhap.Text, txtmatkhau.Text);

            if (txtDangNhap.Text == string.Empty && txtmatkhau.Text == string.Empty)
            {
                MessageBox.Show("Bạn Chưa Nhập Tài Khoản Và Mật Khẩu, Vui Lòng Nhập Tài Khoản");
            }
            else
            {
                if (txtDangNhap.Text == string.Empty)
                {
                    MessageBox.Show("Bạn Chưa Nhập  Tài Khoản, Vui Lòng Nhập Tài Khoản");
                }
                else
                {
                    if (txtmatkhau.Text == string.Empty)
                    {
                        MessageBox.Show("Bạn Chưa Nhập  Mật Khẩu, Vui Lòng Nhập Mật Khẩu");
                    }
                    else
                    {
                        if (dt.Rows.Count > 0)
                        {
                            if (string.Compare(txtDangNhap.Text.Trim(), dt.Rows[0][0].ToString().Trim(), true) == 0)
                            {
                                if (string.Compare(txtmatkhau.Text.Trim(), dt.Rows[0][1].ToString().Trim(), true) == 0)
                                {
                                    if (dt.Rows[0][2].ToString().Trim() == "GV")
                                    {
                                        this.Hide();
                                        frmadmin frm1 = new frmadmin();
                                        frm1.ShowDialog();
                                        this.Close();
                                    }
                                    else
                                    {
                                        this.Hide();
                                        frmuser frm1 = new frmuser();
                                        frmdangnhap.MaSV = txtDangNhap.Text.Trim();
                                        frm1.ShowDialog();
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Sai Mật Khẩu, Vui Lòng Nhập Lại");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Sai Tài Khoản, Vui Lòng Nhập Lại");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sai Tài Khoản hoặc Mật Khẩu, Vui Lòng Nhập Lại");
                        }
                    }

                }
            }
        }

    private void txtDangNhap_TextChanged(object sender, EventArgs e)
    {

    }

    private void Form4_Load(object sender, EventArgs e)
    {
        txtmatkhau.Text = "";
        txtmatkhau.PasswordChar = '*';
        txtmatkhau.MaxLength = 30;
    }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
