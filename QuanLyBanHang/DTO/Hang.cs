using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Hang
    {
        private string maHang, tenHang, maChatLieu;
        private int soLuong, donGiaNhap, donGiaBan;
        private string anh, ghiChu;

        public string MaHang
        {
            get
            {
                return maHang;
            }

            set
            {
                maHang = value;
            }
        }

        public string TenHang
        {
            get
            {
                return tenHang;
            }

            set
            {
                tenHang = value;
            }
        }

        public string MaChatLieu
        {
            get
            {
                return maChatLieu;
            }

            set
            {
                maChatLieu = value;
            }
        }

        public int SoLuong
        {
            get
            {
                return soLuong;
            }

            set
            {
                soLuong = value;
            }
        }

        public int DonGiaNhap
        {
            get
            {
                return donGiaNhap;
            }

            set
            {
                donGiaNhap = value;
            }
        }

        public int DonGiaBan
        {
            get
            {
                return donGiaBan;
            }

            set
            {
                donGiaBan = value;
            }
        }

        public string Anh
        {
            get
            {
                return anh;
            }

            set
            {
                anh = value;
            }
        }

        public string GhiChu
        {
            get
            {
                return ghiChu;
            }

            set
            {
                ghiChu = value;
            }
        }
        public Hang()
        {

        }
        public Hang(string maHang, string tenHang, string maChatLieu, string soLuong, string donGiaNhap, string donGiaBan, string anh, string ghiChu)
        {
            this.MaHang = maHang;
            this.TenHang = tenHang;
            this.MaChatLieu = maChatLieu;
            this.SoLuong = int.Parse(soLuong);
            this.DonGiaNhap = int.Parse(donGiaNhap);
            this.DonGiaBan = int.Parse(donGiaBan);
            this.Anh = anh;
            this.GhiChu = ghiChu;
        }


    }
}
