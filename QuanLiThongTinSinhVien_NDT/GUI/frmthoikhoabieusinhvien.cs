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
    public partial class frmthoikhoabieusinhvien : Form
    {
        public frmthoikhoabieusinhvien()
        {
            InitializeComponent();
        }
        BUS_ThoiKhoaBieu busthoikhoabieu = new BUS_ThoiKhoaBieu();
        private void frmthoikhoabieusinhvien_Load(object sender, EventArgs e)
        {
            CrystalReportTKB crpt1 = new CrystalReportTKB();
            DataTable dt = new DataTable();
            if(frmuser.MaSV != null)
            {
                dt = busthoikhoabieu.getDataFromTKB(frmuser.MaSV);
                crpt1.SetDataSource(dt);
                crystalReportViewer1.ReportSource = crpt1;
            }
            else if(frmttsv.maSV != null)
            {
                dt = busthoikhoabieu.getDataFromTKB(frmttsv.maSV);
                crpt1.SetDataSource(dt);
                crystalReportViewer1.ReportSource = crpt1;

            }    
        }    
            
    }
}
