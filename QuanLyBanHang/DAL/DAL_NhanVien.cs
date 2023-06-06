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
    public class DAL_NhanVien
    {
        handleDatabase dtBase = new handleDatabase();
        public DataTable getDataFrom(string nameTable)
        {
            DataTable dtResult = new DataTable();
            //tạo SqlCommand
            SqlCommand sqlcmd = new SqlCommand("getDataFrom", dtBase.conSQL);

            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@nameTable", nameTable);

            //tạo DataAdapter
            SqlDataAdapter sqlDA = new SqlDataAdapter(sqlcmd);

            //do dữ liệu từ SqlDataAdapter qua DataTable
            sqlDA.Fill(dtResult);
            return dtResult;
        }
        public int insertDataNhanVien(NhanVien nv)
        {
            int iKQ = 1;
            //tạo SqlCommand de thuc hien cau truy van
            SqlCommand sqlcmd = new SqlCommand("insertDataNhanVien", dtBase.conSQL);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
            sqlcmd.Parameters.AddWithValue("@TenNV", nv.TenNV);
            sqlcmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
            sqlcmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
            sqlcmd.Parameters.AddWithValue("@DienThoai", nv.DienThoai);
            sqlcmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);

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
            catch (Exception e)
            {
                //System.Windows.Forms.MessageBox.Show("loi" + ex);
            }
            return iKQ;
        }
        public int updateDataNhanVien(NhanVien nv)
        {
            int iKQ = 1;
            //tạo SqlCommand de thuc hien cau truy van
            SqlCommand sqlcmd = new SqlCommand("updateDataNhanVien", dtBase.conSQL);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
            sqlcmd.Parameters.AddWithValue("@TenNV", nv.TenNV);
            sqlcmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
            sqlcmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
            sqlcmd.Parameters.AddWithValue("@DienThoai", nv.DienThoai);
            sqlcmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
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
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("loi" + e);
            }
            return iKQ;
        }
        public int deleteDataNhanVien(string maNV)
        {
            int iKQ = 1;
            //tạo SqlCommand de thuc hien cau truy vấn
            SqlCommand sqlcmd = new SqlCommand("deleteDataNhanVien", dtBase.conSQL);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@MaNV", maNV);
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
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("loi" + e);
            }
            return iKQ;
        }
        public DataTable findDataNhanVien(string tenNV)
        {
            //tạo DataTable chứa kết quả trả về
            DataTable dtResult = new DataTable();
            try
            {
                //tạo SqlCommand 
                SqlCommand sqlcmd = new SqlCommand("findDataNhanVien", dtBase.conSQL);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@TenNV", tenNV);

                //tạo SqlDataAdapter
                SqlDataAdapter sqlDA = new SqlDataAdapter(sqlcmd);
                sqlDA.Fill(dtResult);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Khong tim duoc" + e.ToString());

            }
            return dtResult;
        }

    }
}
