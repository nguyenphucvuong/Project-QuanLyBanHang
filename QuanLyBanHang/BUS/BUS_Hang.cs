using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BUS
{
    public class BUS_Hang
    {
        DAL_Hang dalHang = new DAL_Hang();
        public DataTable getDataFrom(string tbName)
        {
            return dalHang.getdataFrom(tbName);
        }
        public int insertData(Hang h)
        {
            return dalHang.insertData(h);
        }
        public int deleteData(string ma)
        {
            return dalHang.deleteData(ma);
        }
        public int updateData(Hang h)
        {
            return dalHang.updateData(h);
        }
        public DataTable find(string ten)
        {
            return dalHang.find(ten);
        }
    }
}
