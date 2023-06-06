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
    public class DAL_Hang
    {
        handleDatabase dtBase = new handleDatabase();
        public DataTable getdataFrom(string tbName)
        {
            //tao datatable
            DataTable dtResult = new DataTable();
            //tao sql command
            SqlCommand sqlcmd = new SqlCommand("getDataFrom",dtBase.conSQL);
            //set type sql command
            sqlcmd.CommandType = CommandType.StoredProcedure;
            //add parameter value
            sqlcmd.Parameters.AddWithValue("@nameTable",tbName);
            //tao sql adapter
            SqlDataAdapter sqlDA = new SqlDataAdapter(sqlcmd);
            //do du lieu tu sql adapter sang datatable
            sqlDA.Fill(dtResult);
            //tra ve
            return dtResult;
        }

        public int insertData(Hang hang)
        {
            int iKQ = 1;

            //tao sql command thuc hien cau truy van
            SqlCommand sqlcmd = new SqlCommand("insertDataHang",dtBase.conSQL);
            //set command type 
            sqlcmd.CommandType = CommandType.StoredProcedure;
            //add parameter value
            sqlcmd.Parameters.AddWithValue("@MaHang",hang.MaHang);
            sqlcmd.Parameters.AddWithValue("@TenHang", hang.TenHang);
            sqlcmd.Parameters.AddWithValue("@MaChatLieu", hang.MaChatLieu);
            sqlcmd.Parameters.AddWithValue("@SoLuong", hang.SoLuong);
            sqlcmd.Parameters.AddWithValue("@DonGiaNhap", hang.DonGiaNhap);
            sqlcmd.Parameters.AddWithValue("@DonGiaBan", hang.DonGiaBan);
            sqlcmd.Parameters.AddWithValue("@Anh", hang.Anh);
            sqlcmd.Parameters.AddWithValue("@GhiChu", hang.GhiChu);

            try
            {
                iKQ = sqlcmd.ExecuteNonQuery();
                if (iKQ >= 0)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {

                System.Windows.Forms.MessageBox.Show("Loi");
            }
            return iKQ;
        }

        public int deleteData(string maHang)
        {
            int iKQ = 1;
            //tao sql command
            SqlCommand sqlcmd = new SqlCommand("deleteDataHang",dtBase.conSQL);
            //set type sqlcmd
            sqlcmd.CommandType = CommandType.StoredProcedure;
            //add paremeter value
            sqlcmd.Parameters.AddWithValue("@MaHang",maHang);

            try
            {
                iKQ = sqlcmd.ExecuteNonQuery();
                if (iKQ>=0)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {

                System.Windows.Forms.MessageBox.Show("Loi");
            }

            return iKQ;
        }

        public int updateData(Hang hang)
        {
            int iKQ = 1;
            //tao sql command 
            SqlCommand sqlcmd = new SqlCommand("updateDataHang",dtBase.conSQL);
            //set cmnd type 
            sqlcmd.CommandType = CommandType.StoredProcedure;
            //add parameter value
            sqlcmd.Parameters.AddWithValue("@MaHang", hang.MaHang);
            sqlcmd.Parameters.AddWithValue("@TenHang", hang.TenHang);
            sqlcmd.Parameters.AddWithValue("@MaChatLieu", hang.MaChatLieu);
            sqlcmd.Parameters.AddWithValue("@SoLuong", hang.SoLuong);
            sqlcmd.Parameters.AddWithValue("@DonGiaNhap", hang.DonGiaNhap);
            sqlcmd.Parameters.AddWithValue("@DonGiaBan", hang.DonGiaBan);
            sqlcmd.Parameters.AddWithValue("@Anh", hang.Anh);
            sqlcmd.Parameters.AddWithValue("@GhiChu", hang.GhiChu);

            try
            {
                iKQ = sqlcmd.ExecuteNonQuery();
                if (iKQ >= 0)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {

                System.Windows.Forms.MessageBox.Show("Loi");
            }
            return iKQ;

        }

        public DataTable find(string tenH)
        {
            //tao datattable
            DataTable dtResult = new DataTable();
            //tao sql cmd
            SqlCommand sqlcmd = new SqlCommand("findDataHang", dtBase.conSQL);
            //set cmd type
            sqlcmd.CommandType = CommandType.StoredProcedure;
            //add parameter value
            sqlcmd.Parameters.AddWithValue("@TenHang",tenH);
            //tao adapter
            SqlDataAdapter sqlDA = new SqlDataAdapter(sqlcmd);
            //do du lieu tu sql adapter sang datatable
            sqlDA.Fill(dtResult);
            //tra ve
            return dtResult;
        }

        


    }
}
