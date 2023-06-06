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
    public partial class frmKhachHang : Form
    {
        BUSKhach busKhach = new BUSKhach();
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Bạn muốn Thoát Không ?", "Thông Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (exit == DialogResult.Yes)
            {
                this.Hide();
                frmMenu frmcl = new frmMenu();
                frmcl.ShowDialog();
                this.Close();
            }

        }
        // Su kien form load
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            dtgvKhach.DataSource = busKhach.getData("Khach");
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void clearText()
        {
            txtMa.Clear();
            txtTen.Clear();
            txtDC.Clear();
            txtDT.Clear();
        }
        //check ma khach nhap
        private bool check()
        {
            for (int i = 0; i < dtgvKhach.Rows.Count - 1; i++)
            {
                string s = dtgvKhach.Rows[i].Cells[0].Value.ToString();
                if (s == txtMa.Text)
                {
                    return false;
                }
            }
            return true;
        }
        //Su kien Cell Click
        private void dtgvKhach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvKhach.Rows[e.RowIndex];
                txtMa.Text = row.Cells[0].Value.ToString();
                txtTen.Text = row.Cells[1].Value.ToString();
                txtDC.Text = row.Cells[2].Value.ToString();
                txtDT.Text = row.Cells[3].Value.ToString();

                txtMa.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }
        //them 1 khach
        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;
            string ten = txtTen.Text;
            string DC = txtDC.Text;
            string DT = txtDT.Text;
            Khach kh = new Khach(ma, ten, DC, DT);
            if (check() == false)
            {
                MessageBox.Show("Ma Khach khong duoc trung nhau");
            }
            else
            {
                if (busKhach.insertDataKhach(kh) >= 0)
                {
                    dtgvKhach.DataSource = busKhach.getData("Khach");
                    MessageBox.Show("Them Thanh cong");
                    clearText();
                }
                else
                {
                    MessageBox.Show("Them khong Thanh cong");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;
            string ten = txtTen.Text;
            string DC = txtDC.Text;
            string DT = txtDT.Text;
            Khach kh = new Khach(ma, ten, DC, DT);
            if (busKhach.updateDataKhach(kh) >= 0)
            {
                MessageBox.Show("Sua Thanh cong");
                dtgvKhach.DataSource = busKhach.getData("Khach");
                clearText();
                txtMa.Enabled = true;
                btnSua.Enabled = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = false;
            }
            else
            {
                MessageBox.Show("Sua khong Thanh cong");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //hoi muon xoa 
            DialogResult delete = MessageBox.Show("Bạn Muốn Xóa khách này Không ?", "Thông Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (delete == DialogResult.Yes)
            {
                //kiem tra du lieu
                if (txtMa == null && txtTen == null)
                {
                    MessageBox.Show("khong duoc de trong");
                }
                else
                {

                    int iKQ = busKhach.deleteDataKhach(txtMa.Text);
                    if (iKQ >= 0)
                    {
                        MessageBox.Show("Delete thành công");
                        clearText();
                        btnSua.Enabled = false;
                        btnThem.Enabled = true;
                        btnXoa.Enabled = false;
                        txtMa.Enabled = true;
                        dtgvKhach.DataSource = busKhach.getData("Khach");
                    }
                    else
                    {
                        MessageBox.Show("Không Xóa duoc");
                    }
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            String sMa = txtMa.Text;
            if (txtMa.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập mã Khách hàng muốn tìm ");
            }
            else
            {
                dtgvKhach.DataSource = busKhach.findKhach(sMa);
            }
        }

 
    }
}
