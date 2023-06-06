using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Khach
    {
        private string maKhach;
        private string tenKhach;
        private string diaChi;
        private string dienThoai;

        //Constructor
        //co tham so
        public Khach(string maKhach, string tenKhach, string diaChi, string dienThoai)
        {
            this.maKhach = maKhach;
            this.tenKhach = tenKhach;
            this.diaChi = diaChi;
            this.dienThoai = dienThoai;
        }
        //khong tham so
        public Khach()
        {

        }
        //properties
        public string MaKhach
        {
            get
            {
                return maKhach;
            }

            set
            {
                maKhach = value;
            }
        }

        public string TenKhach
        {
            get
            {
                return tenKhach;
            }

            set
            {
                tenKhach = value;
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
    }
}
