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

namespace QuanLiThongTinSinhVien_NDT
{
    public partial class frmreportdiemsinhvien : Form
    {
        public frmreportdiemsinhvien()
        {
            InitializeComponent();
        }
        BUS_KetQua busketqua = new BUS_KetQua();
        private void frmreportdiemsinhvien_Load(object sender, EventArgs e)
        {
            CrystalReportDSDSV crpt1 = new CrystalReportDSDSV();
            DataTable dt = new DataTable();
            if (frmuser.MaSV != null)
            {
                dt = busketqua.getDataFromKQ(frmuser.MaSV);
                crpt1.SetDataSource(dt);
                crystalReportViewer1.ReportSource = crpt1;
            }
            else if (frmttsv.maSV != null)
            {
                dt = busketqua.getDataFromKQ(frmttsv.maSV);
                crpt1.SetDataSource(dt);
                crystalReportViewer1.ReportSource = crpt1;

            }
        }
    }
}
