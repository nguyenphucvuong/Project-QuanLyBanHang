using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class handleDatabase
    {
        public SqlConnection conSQL = new SqlConnection();
        public handleDatabase()
        {
            //conSQL.ConnectionString = @"Data Source=TIEN\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=True";
            conSQL.ConnectionString = @"Data Source=Mr_Vuong-LT\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=True";
            try
            {
                conSQL.Open();
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Loi ket noi");
            }
        }
    }
}
