using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void chấtLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmChatLieu frmcl = new frmChatLieu();
            frmcl.ShowDialog();
            this.Close();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmNhanVien frmcl = new frmNhanVien();
            frmcl.ShowDialog();
            this.Close();
        }

        private void kháchHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmKhachHang frmcl = new frmKhachHang();
            frmcl.ShowDialog();
            this.Close();
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHangHoa frmcl = new frmHangHoa();
            frmcl.ShowDialog();
            this.Close();
        }

        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHoaDonBan frmcl = new frmHoaDonBan();
            frmcl.ShowDialog();
            this.Close();
        }

        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //frmChiTietHoaDon frmcl = new frmChiTietHoaDon();
            //frmcl.ShowDialog();
            //this.Close();
        }

        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmrReportHoaDon frmcl = new frmrReportHoaDon();
            frmcl.ShowDialog();
            this.Close();
        }
    }
}
