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
namespace GUI
{
    public partial class frmHangHoa : Form
    {
        public frmHangHoa()
        {
            InitializeComponent();
        }
        BUS_Hang busHang = new BUS_Hang();
        private bool checkPK()
        {
            for (int i = 0; i < dgvHangHoa.Rows.Count; i++)
            {
                string temp = dgvHangHoa.Rows[i].Cells[0].Value.ToString();
                if (txtMaHang.Text == temp)
                {
                    return false;
                }
            }

            return true;
        }
        private void showDataRow()
        {
            int i = dgvHangHoa.CurrentRow.Index;
            txtMaHang.Text = dgvHangHoa.Rows[i].Cells[0].Value.ToString();
            txtTenHang.Text = dgvHangHoa.Rows[i].Cells[1].Value.ToString();
            txtMaChatLieu.Text = dgvHangHoa.Rows[i].Cells[2].Value.ToString();
            txtSoLuong.Text = dgvHangHoa.Rows[i].Cells[3].Value.ToString();
            txtGiaNhap.Text = dgvHangHoa.Rows[i].Cells[4].Value.ToString();
            txtGiaBan.Text = dgvHangHoa.Rows[i].Cells[5].Value.ToString();
            txtAnh.Text = dgvHangHoa.Rows[i].Cells[6].Value.ToString();
            txtGhiChu.Text = dgvHangHoa.Rows[i].Cells[7].Value.ToString();
            
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu frmcl = new frmMenu();
            frmcl.ShowDialog();
            this.Close();
        }
        
        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            dgvHangHoa.DataSource = busHang.getDataFrom("Hang"); 
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maHang = txtMaHang.Text;
            string tenHang = txtTenHang.Text;
            string maChatLieu = txtMaChatLieu.Text;
            string soLuong = txtSoLuong.Text;
            string donGiaNhap = txtGiaNhap.Text;
            string donGiaBan = txtGiaBan.Text;
            string anh = txtAnh.Text;
            string ghiChu = txtGhiChu.Text;
            Hang h = new Hang(maHang,  tenHang,  maChatLieu,  soLuong,  donGiaNhap,  donGiaBan,  anh,  ghiChu);

            
            int iKQ = busHang.insertData(h);

            if ( iKQ >= 0)
            {
                dgvHangHoa.DataSource = busHang.getDataFrom("Hang");
            }
            else
            {
                MessageBox.Show("Lỗi !!!");
            }

        }

        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            showDataRow();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maHang = txtMaHang.Text;
            string tenHang = txtTenHang.Text;
            string maChatLieu = txtMaChatLieu.Text;
            string soLuong = txtSoLuong.Text;
            string donGiaNhap = txtGiaNhap.Text;
            string donGiaBan = txtGiaBan.Text;
            string anh = txtAnh.Text;
            string ghiChu = txtGhiChu.Text;
            Hang h = new Hang(maHang, tenHang, maChatLieu, soLuong, donGiaNhap, donGiaBan, anh, ghiChu);

            int iKQ = busHang.updateData(h);
            if (iKQ >= 0)
            {
                dgvHangHoa.DataSource = busHang.getDataFrom("Hang");
            }
            else
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maHang = txtMaHang.Text;
            int iKQ = busHang.deleteData(maHang);
            if (iKQ >= 0)
            {
                dgvHangHoa.DataSource = busHang.getDataFrom("Hang");
            }
            else
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string ten = txtTenHang.Text;
            dgvHangHoa.DataSource = busHang.find(ten);
        }
    }
}
