using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon
    {

        private string maHDBan;
        private string maNV;
        private string maHang;
        private DateTime ngayBan;
        private string maKhach;
        private int tongTien;

        public HoaDon(string maHDBan, string maNV, string maHang, DateTime ngayBan, string maKhach, int tongTien)
        {
            this.maHDBan = maHDBan;
            this.maNV = maNV;
            this.maHang = maHang;
            this.ngayBan = ngayBan;
            this.maKhach = maKhach;
            this.tongTien = tongTien;
        }


        public HoaDon(string maHDBan, string maNV, string maHang, string ngayBan, string maKhach, string tongTien)
        {
            this.maHDBan = maHDBan;
            this.maNV = maNV;
            this.maHang = maHang;
            this.ngayBan = DateTime.ParseExact(ngayBan, "dd/MM/yyyy", null);
            this.maKhach = maKhach;
            this.tongTien = Convert.ToInt32(tongTien);
        }


        public string MaHDBan
        {
            get => maHDBan;
            set => maHDBan = value;
        }

        public string MaNV
        {
            get => maNV;
            set => maNV = value;
        }

        public string MaHang
        {
            get => maHang;
            set => maHang = value;
        }

        public DateTime NgayBan
        {
            get => ngayBan;
            set => ngayBan = value;
        }

        public string MaKhach
        {
            get => maKhach;
            set => maKhach = value;
        }

        public int TongTien
        {
            get => tongTien;
            set => tongTien = value;
        }


    }
}
