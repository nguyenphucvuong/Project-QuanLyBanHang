using BUS;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmHoaDonBan : Form
    {
        public frmHoaDonBan()
        {
            InitializeComponent();
        }
        BUS_HOADON busHoaDon = new BUS_HOADON();
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu frmcl = new frmMenu();
            frmcl.ShowDialog();
            this.Close();
        }

        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            cbo();
            dgvHDBan.DataSource = busHoaDon.getData("HDBan");
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void dgvHDBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvHDBan.Rows[e.RowIndex];
                txtMaHDBan.Text = row.Cells[0].Value.ToString();
                //txtMaNV.Text = row.Cells[1].Value.ToString();
                //txtMaHang.Text = row.Cells[2].Value.ToString();
                cboManv.Text = row.Cells[1].Value.ToString();
                cboMahang.Text = row.Cells[2].Value.ToString();
                dtpNgayBan.Text = row.Cells[3].Value.ToString();
                //txtMaKhach.Text = row.Cells[4].Value.ToString();
                cboMakhach.Text = row.Cells[4].Value.ToString();
                txtTongTien.Text = row.Cells[5].Value.ToString();

                //txtMaHDBan.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }
        private void cbo()
        {
            handleDatabase dtBase = new handleDatabase();
            SqlCommand cmd = new SqlCommand("select MaNV from NhanVien", dtBase.conSQL);
            SqlCommand cmd1 = new SqlCommand("select MaHang from Hang", dtBase.conSQL);
            SqlCommand cmd2 = new SqlCommand("select MaKhach from Khach", dtBase.conSQL);
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            SqlDataAdapter sqlDA1 = new SqlDataAdapter();
            SqlDataAdapter sqlDA2 = new SqlDataAdapter();
            sqlDA.SelectCommand = cmd;
            sqlDA1.SelectCommand = cmd1;
            sqlDA2.SelectCommand = cmd2;
            DataTable tb = new DataTable();
            DataTable tb1 = new DataTable();
            DataTable tb2 = new DataTable();

            sqlDA.Fill(tb);
            cboManv.DataSource = tb;
            cboManv.DisplayMember = "MaNV";
            cboManv.ValueMember = "MaNV";



            sqlDA1.Fill(tb1);
            cboMahang.DataSource = tb1;
            cboMahang.DisplayMember = "MaHang";
            cboMahang.ValueMember = "MaHang";


            sqlDA2.Fill(tb2);
            cboMakhach.DataSource = tb2;
            cboMakhach.DisplayMember = "MaKhach";
            cboMakhach.ValueMember = "MaKhach";
        }
        private void clearText()
        {

            txtMaHDBan.Clear();

            txtTongTien.Clear();
        }
        //kiem tra mã có trung với mã đã có
        private bool check()
        {
            for (int i = 0; i < dgvHDBan.Rows.Count - 1; i++)
            {
                string s = dgvHDBan.Rows[i].Cells[0].Value.ToString();
                if (s == txtMaHDBan.Text)
                {
                    return true;
                }
            }
            return false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            cbo();
            string maHD = txtMaHDBan.Text;
            //string maNV = txtMaNV.Text;
            //string maHang = txtMaHang.Text;
            string maNV = cboManv.Text;
            string maHang = cboMahang.Text;

            //string ngayBan = dtpNgayBan.Text;
            DateTime ngayBan = DateTime.Parse(dtpNgayBan.Value.ToShortDateString());

            //string maKhach = txtMaKhach.Text;
            string maKhach = cboMakhach.Text;
            //string tongTien = txtTongTien.Text;
            int tongTien = Convert.ToInt32(txtTongTien.Text);

            HoaDon hd = new HoaDon(maHD, maNV, maHang, ngayBan, maKhach, tongTien);
            if (check())
            {
                MessageBox.Show("Mã hóa đơn trùng!!!");
            }
            else
            {
                if (busHoaDon.insertData(hd) >= 0)
                {
                    dgvHDBan.DataSource = busHoaDon.getData("HDBan");
                    MessageBox.Show("Thêm thành công!!!");
                    clearText();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công!!!");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maHD = txtMaHDBan.Text;
            //string maNV = txtMaNV.Text;
            //string maHang = txtMaHang.Text;
            string maNV = cboManv.Text;
            string maHang = cboMahang.Text;

            //string ngayBan = dtpNgayBan.Text;
            DateTime ngayBan = DateTime.Parse(dtpNgayBan.Value.ToShortDateString());
            //string maKhach = txtMaKhach.Text;
            string maKhach = cboMakhach.Text;
            //string tongTien = txtTongTien.Text;
            int tongTien = Convert.ToInt32(txtTongTien.Text);
            HoaDon hd = new HoaDon(maHD, maNV, maHang, ngayBan, maKhach, tongTien);

            if (busHoaDon.updateData(hd) >= 0)
            {
                dgvHDBan.DataSource = busHoaDon.getData("HDBan");
                MessageBox.Show("Sửa thành công!!!");
                clearText();
            }
            else
            {
                MessageBox.Show("Sửa không thành công!!!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaHDBan.Text != null)
            {
                if (busHoaDon.deleteData(txtMaHDBan.Text) >= 0)
                {
                    MessageBox.Show("Xóa thành công");
                    clearText();
                    btnSua.Enabled = false;
                    btnThem.Enabled = true;
                    btnXoa.Enabled = false;
                    txtMaHDBan.Enabled = true;

                    dgvHDBan.DataSource = busHoaDon.getData("HDBan");
                }
            }
            else
            {
                MessageBox.Show("Nhập mã hóa đơn để xóa");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtTim.Text != string.Empty)
            {

                dgvHDBan.DataSource = busHoaDon.findData(txtTim.Text);

            }
            else
            {
                MessageBox.Show("Nhập mã hóa đơn ( khách, nhân viên, hàng ) để tìm");
            }
        }
    }
}
