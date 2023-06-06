using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BUS
{
    public class BUS_NhanVien
    {
        DAL_NhanVien dalNhanVien = new DAL_NhanVien();
        public DataTable getData(string nameTable)
        {
            DataTable dtResult = new DataTable();
            dtResult = dalNhanVien.getDataFrom(nameTable);
            return dtResult;
        }
        public int insertNhanVien(NhanVien nv)
        {
            return dalNhanVien.insertDataNhanVien(nv);
        }
        public int updateNhanVien(NhanVien nv)
        {
            return dalNhanVien.updateDataNhanVien(nv);
        }
        public int deleteNhanVien(string maNV)
        {
            return dalNhanVien.deleteDataNhanVien(maNV);
        }
        public DataTable findNhanVien(string tenNV)
        {
            return dalNhanVien.findDataNhanVien(tenNV);
        }
    }
}
