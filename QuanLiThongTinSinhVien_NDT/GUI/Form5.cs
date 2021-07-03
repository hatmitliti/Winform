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
    public partial class frmxuatdssv : Form
    {
        public frmxuatdssv()
        {
            InitializeComponent();
        }
        BUS_SinhVien bussv = new BUS_SinhVien();
        private void Form5_Load(object sender, EventArgs e)
        {
            CrystalReportDSSV crpt1 = new CrystalReportDSSV();
            DataTable dt = new DataTable();
            dt = bussv.getDataFromSinhVien();
            crpt1.SetDataSource(dt);
            crystalReportViewer1.ReportSource = crpt1;
        }
    }
}
