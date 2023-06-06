using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace DAL
{
    public class DAL_HOADON
    {
        handleDatabase dtBase = new handleDatabase();

        public DataTable getDataFromHoaDon(string nameTable)
        {
            DataTable dtResult = new DataTable();

            SqlCommand sqlCmd = new SqlCommand("getDataFrom", dtBase.conSQL);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@nameTable", nameTable);

            SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCmd);
            sqlDA.Fill(dtResult);

            return dtResult;
        }

        public int insertDataHoaDon(HoaDon hd)
        {
            int iKQ = 1;

            SqlCommand sqlCmd = new SqlCommand("insertDataHoaDon", dtBase.conSQL);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@MaHDBan", hd.MaHDBan);
            sqlCmd.Parameters.AddWithValue("@MaNV", hd.MaNV);
            sqlCmd.Parameters.AddWithValue("@MaHang", hd.MaHang);
            sqlCmd.Parameters.AddWithValue("@NgayBan", hd.NgayBan);
            sqlCmd.Parameters.AddWithValue("@MaKhach", hd.MaKhach);
            sqlCmd.Parameters.AddWithValue("@TongTien", hd.TongTien);

            try
            {
                iKQ = sqlCmd.ExecuteNonQuery();
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

                MessageBox.Show("Lỗi!!!" + ex);
            }
            return iKQ;
        }

        public int updateDataHoaDon(HoaDon hd)
        {
            int iKQ = 1;

            SqlCommand sqlCmd = new SqlCommand("updateDataHoaDon", dtBase.conSQL);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@MaHDBan", hd.MaHDBan);
            sqlCmd.Parameters.AddWithValue("@MaNV", hd.MaNV);
            sqlCmd.Parameters.AddWithValue("@MaHang", hd.MaHang);
            sqlCmd.Parameters.AddWithValue("@NgayBan", hd.NgayBan);
            sqlCmd.Parameters.AddWithValue("@MaKhach", hd.MaKhach);
            sqlCmd.Parameters.AddWithValue("@TongTien", hd.TongTien);

            try
            {
                iKQ = sqlCmd.ExecuteNonQuery();
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
                MessageBox.Show("Lỗi!!!" + ex);
            }
            return iKQ;
        }

        public int deleteDataHoaDon(string MaHDBan)
        {
            int iKQ = 1;

            SqlCommand sqlCmd = new SqlCommand("deleteDataHoaDon", dtBase.conSQL);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@MaHDBan", MaHDBan);
            try
            {
                iKQ = sqlCmd.ExecuteNonQuery();
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
                MessageBox.Show("Lỗi!!!" + ex);
            }
            return iKQ;
        }

        public DataTable findDataHoaDon(string Ma)
        {


            DataTable dtResult = new DataTable();

            SqlCommand sqlCmd = new SqlCommand("findDataHoaDon", dtBase.conSQL);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Ma", Ma);

            SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCmd);
            sqlDA.Fill(dtResult);

            return dtResult;
        }
    }
}
