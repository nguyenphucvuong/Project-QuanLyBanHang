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
    public partial class frmChatLieu : Form
    {
        BUSChatLieu busCL = new BUSChatLieu();
        public frmChatLieu()
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

        private void frmChatLieu_Load(object sender, EventArgs e)
        {
            dgvChatLieu.DataSource = busCL.getData("ChatLieu");
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        //
        private void clearText()
        {
            txtMa.Clear();
            txtTen.Clear();

        }
        //kiem tra mã có trung với mã đã có
        private bool check()
        {
            for (int i = 0; i < dgvChatLieu.Rows.Count - 1; i++)
            {
                string s = dgvChatLieu.Rows[i].Cells[0].Value.ToString();
                if (s == txtMa.Text)
                {
                    return false;
                }
            }
            return true;
        }
        //Sự kiện CellClick
     
        private void dgvChatLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvChatLieu.Rows[e.RowIndex];
                txtMa.Text = row.Cells[0].Value.ToString();
                txtTen.Text = row.Cells[1].Value.ToString();

                //txtMa.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }
        //Thêm 1 Chất Liệu
        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;
            string ten = txtTen.Text;

            ChatLieu cL = new ChatLieu(ma, ten);
            if (check() == false)
            {
                MessageBox.Show("Ma Chất liệu khong duoc trung nhau");
            }
            else
            {
                if (busCL.insertDataChatLieu(cL) >= 0)
                {
                    dgvChatLieu.DataSource = busCL.getData("ChatLieu");
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

            ChatLieu cL = new ChatLieu(ma, ten);
            if (busCL.updateDataChatLieu(cL) >= 0)
            {
                MessageBox.Show("Sua Thanh cong");
                dgvChatLieu.DataSource = busCL.getData("ChatLieu");
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
            DialogResult delete = MessageBox.Show("Bạn Muốn Xóa Chất Liệu này Không ?", "Thông Báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (delete == DialogResult.Yes)
            {
                //kiem tra du lieu
                if (txtMa == null && txtTen == null)
                {
                    MessageBox.Show("khong duoc de trong");
                }
                else
                {

                    int iKQ = busCL.deleteDataChatLieu(txtMa.Text);
                    if (iKQ >= 0)
                    {
                        MessageBox.Show("Delete thành công");
                        clearText();
                        btnSua.Enabled = false;
                        btnThem.Enabled = true;
                        btnXoa.Enabled = false;
                        txtMa.Enabled = true;
                        dgvChatLieu.DataSource = busCL.getData("ChatLieu");
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
                MessageBox.Show("Vui lòng nhập mã Chất Liệu muốn tìm ");
            }
            else
            {
                dgvChatLieu.DataSource = busCL.findChatLieu(sMa);
            }
        }

        
    }
}
