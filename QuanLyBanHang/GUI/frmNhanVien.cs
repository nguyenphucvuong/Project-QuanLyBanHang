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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu frmcl = new frmMenu();
            frmcl.ShowDialog();
            this.Close();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmMenu frmcl = new frmMenu();
            frmcl.ShowDialog();
            this.Close();
        }
        private void showDataRow()
        {
            int i = dgvNhanVien.CurrentRow.Index;
            txtManv.Text = dgvNhanVien.Rows[i].Cells[0].Value.ToString();
            txtTenNV.Text = dgvNhanVien.Rows[i].Cells[1].Value.ToString();
            txtGioitinh.Text = dgvNhanVien.Rows[i].Cells[2].Value.ToString();
            txtDiachi.Text = dgvNhanVien.Rows[i].Cells[3].Value.ToString();
            txtDt.Text = dgvNhanVien.Rows[i].Cells[4].Value.ToString();
            txtNgaySinh.Text = dgvNhanVien.Rows[i].Cells[5].Value.ToString();

        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = busNhanVien.getData("NhanVien");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.MaNV = txtManv.Text;
            nv.TenNV = txtTenNV.Text;
            nv.GioiTinh = txtGioitinh.Text;
            nv.DiaChi = txtDiachi.Text;
            nv.DienThoai = txtDt.Text;
            nv.NgaySinh = DateTime.ParseExact(txtNgaySinh.Text, "dd/MM/yyyy", null);
            if (busNhanVien.insertNhanVien(nv) >= 0)
            {
                dgvNhanVien.DataSource = busNhanVien.getData("NhanVien");
                MessageBox.Show("Them thanh cong");
            }
            else
            {
                MessageBox.Show("Them khong thanh cong");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.MaNV = txtManv.Text;
            nv.TenNV = txtTenNV.Text;
            nv.GioiTinh = txtGioitinh.Text;
            nv.DiaChi = txtDiachi.Text;
            nv.DienThoai = txtDt.Text;
            nv.NgaySinh = DateTime.ParseExact(txtNgaySinh.Text, "dd/MM/yyyy", null);
            if (busNhanVien.updateNhanVien(nv) >= 0)
            {
                dgvNhanVien.DataSource = busNhanVien.getData("NhanVien");
                MessageBox.Show("Sua thanh cong");
            }
            else
            {
                MessageBox.Show("Sua khong thanh cong");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtManv.Text == string.Empty)
            {
                MessageBox.Show("Khong duoc de trong");
            }
            else
            {
                int iKQ = busNhanVien.deleteNhanVien(txtManv.Text);
                if (iKQ >= 0)
                {
                    dgvNhanVien.DataSource = busNhanVien.getData("NhanVien");
                    MessageBox.Show("Xoa thanh cong");
                }
                else
                {
                    MessageBox.Show("Khong xoa duoc");
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtTenNV.Text == string.Empty)
            {
                MessageBox.Show("Khong duoc de trong");

            }
            else
            {
                dgvNhanVien.DataSource = busNhanVien.findNhanVien(txtTenNV.Text);
            }
        }
    }
}
