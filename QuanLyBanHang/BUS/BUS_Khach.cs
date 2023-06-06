using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;
using System.Security.Policy;
namespace BUS
{
    public class BUSKhach
    {
        DAL_Khach dalKhach = new DAL_Khach();
        //lay thong tin tu database
        public DataTable getData(string nameTable)
        {
            DataTable dtResutl = new DataTable();
            dtResutl = dalKhach.getDataFromKhach(nameTable);
            return dtResutl;
        }
        //them tt vao banng khach
        public int insertDataKhach(Khach kh)
        {
            return dalKhach.insertDataKhach(kh);
        }
        //cap nhat tt Khach
        public int updateDataKhach(Khach kh)
        {
            return dalKhach.updateDataKhach(kh);
        }
        //Xoa khach
        public int deleteDataKhach(string sMa)
        {
            return dalKhach.deleteDataKhach(sMa);
        }
        //Tim khach
        public DataTable findKhach(string sMa)
        {
            DataTable dtResutl = new DataTable();
            dtResutl = dalKhach.findDataKhach(sMa);
            return dtResutl;
        }
    }
}
