using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;

namespace BUS
{
    public class BUS_HOADON
    {
        DAL_HOADON dalHoaDon = new DAL_HOADON();
        public DataTable getData(string NameTable)
        {
            DataTable dtResult = new DataTable();
            dtResult = dalHoaDon.getDataFromHoaDon(NameTable);
            return dtResult;
        }

        public int insertData(HoaDon hd)
        {
            return dalHoaDon.insertDataHoaDon(hd);
        }

        public int updateData(HoaDon hd)
        {
            return dalHoaDon.updateDataHoaDon(hd);
        }

        public int deleteData(string ma)
        {
            return dalHoaDon.deleteDataHoaDon(ma);
        }

        public DataTable findData(string ma)
        {
            DataTable dtResult = new DataTable();
            dtResult = dalHoaDon.findDataHoaDon(ma);
            return dtResult;
        }
    }
}
