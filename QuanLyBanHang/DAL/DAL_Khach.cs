using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_Khach
    {
        handleDatabase dtBase = new handleDatabase();
        //lay du lieu tu database
        public DataTable getDataFromKhach(string nameTable)
        {
            DataTable dtResutl = new DataTable();

            //tao sqlCommand
            SqlCommand sqlCMD = new SqlCommand("getDataFrom", dtBase.conSQL);

            sqlCMD.CommandType = CommandType.StoredProcedure;
            sqlCMD.Parameters.AddWithValue("@nameTable", nameTable);

            //tao DataAdapter
            SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCMD);

            //doi du lieu tu dataAdpter qua DataTable

            sqlDA.Fill(dtResutl);
            //tra ve kq
            return dtResutl;
        }
        //them du lieu vao database
        public int insertDataKhach(Khach k)
        {
            int iKQ = -1;
            //tao sql thuc hien truy van
            SqlCommand sqlcmd = new SqlCommand("insertDataKhach", dtBase.conSQL);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            //them tham so
            sqlcmd.Parameters.AddWithValue("@maKhach", k.MaKhach);
            sqlcmd.Parameters.AddWithValue("@tenKhach", k.TenKhach);
            sqlcmd.Parameters.AddWithValue("@diaChi", k.DiaChi);
            sqlcmd.Parameters.AddWithValue("@dThoai", k.DienThoai);

            try
            {
                iKQ = sqlcmd.ExecuteNonQuery();
                if (iKQ >= 0)
                {
                    iKQ = 0;
                }
                else
                {
                    iKQ = -1;
                }
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show("loi" + ex);
            }
            return iKQ;
        }
        //cap nhat
        public int updateDataKhach(Khach k)
        {
            int iKQ = 1;

            //tao sql command de thuc hien cau truy van
            SqlCommand sqlcmd = new SqlCommand("updateDataKhach", dtBase.conSQL);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            //them tham so vao sqlcommand
            sqlcmd.Parameters.AddWithValue("@maKhach", k.MaKhach);
            sqlcmd.Parameters.AddWithValue("@tenKhach", k.TenKhach);
            sqlcmd.Parameters.AddWithValue("@diaChi", k.DiaChi);
            sqlcmd.Parameters.AddWithValue("@dThoai", k.DienThoai);


            try
            {
                iKQ = sqlcmd.ExecuteNonQuery();
                if (iKQ >= 0)
                {
                    iKQ = 0;
                }
                else
                {
                    iKQ = -1;
                }
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show("loi" + ex);
            }

            return iKQ;
        }
        //xoa 1 vat tu theo ma
        public int deleteDataKhach(string sMa)
        {
            int iKQ = 1;

            //tao sql command de thuc hien cau truy van
            SqlCommand sqlcmd = new SqlCommand("deleteDataKhach", dtBase.conSQL);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            //them tham so vao sqlcommand
            sqlcmd.Parameters.AddWithValue("@maKhach", sMa);


            try
            {
                iKQ = sqlcmd.ExecuteNonQuery();
                if (iKQ >= 0)
                {
                    iKQ = 0;
                }
                else
                {
                    iKQ = -1;
                }
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show("loi" + ex);
            }

            return iKQ;
        }
        //tim khach
        public DataTable findDataKhach(string sKey)
        {
            DataTable dtResutl = new DataTable();

            //tao sqlCommand
            SqlCommand sqlCMD = new SqlCommand("findDataKhach", dtBase.conSQL);

            sqlCMD.CommandType = CommandType.StoredProcedure;
            sqlCMD.Parameters.AddWithValue("@ma", sKey);

            //tao DataAdapter
            SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCMD);

            //doi du lieu tu dataAdpter qua DataTable

            sqlDA.Fill(dtResutl);
            //tra ve kq
            return dtResutl;
        }
    }
}
