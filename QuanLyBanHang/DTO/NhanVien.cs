using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien
    {
        private string maNV;
        private string tenNV;
        private string gioiTinh;
        private string diaChi;
        private string dienThoai;
        private DateTime ngaySinh;

        public string MaNV
        {
            get
            {
                return maNV;
            }

            set
            {
                maNV = value;
            }
        }

        public string TenNV
        {
            get
            {
                return tenNV;
            }

            set
            {
                tenNV = value;
            }
        }

        public string GioiTinh
        {
            get
            {
                return gioiTinh;
            }

            set
            {
                gioiTinh = value;
            }
        }

        public string DiaChi
        {
            get
            {
                return diaChi;
            }

            set
            {
                diaChi = value;
            }
        }

        public string DienThoai
        {
            get
            {
                return dienThoai;
            }

            set
            {
                dienThoai = value;
            }
        }

        public DateTime NgaySinh
        {
            get
            {
                return ngaySinh;
            }

            set
            {
                ngaySinh = value;
            }
        }

        public NhanVien(string maNV, string tenNV, string gioiTinh, string diaChi, string dienThoai, string ngaySinh)
        {
            this.MaNV = maNV;
            this.TenNV = tenNV;
            this.GioiTinh = gioiTinh;
            this.DiaChi = diaChi;
            this.DienThoai = dienThoai;
            this.NgaySinh = DateTime.ParseExact(ngaySinh, "dd/MM/yyyy", null);
        }
        public NhanVien()
        {

        }


    }
}
