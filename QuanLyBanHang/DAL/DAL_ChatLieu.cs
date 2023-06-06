using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_ChatLieu
    {
        handleDatabase dtBase = new handleDatabase();
        //lay du lieu tu database
        public DataTable getDataFromChatLieu(string nameTable)
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
        public int insertDataChatLieu(ChatLieu chatLieu)
        {
            int iKQ = -1;
            //tao sql thuc hien truy van
            SqlCommand sqlcmd = new SqlCommand("insertDataChatLieu", dtBase.conSQL);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            //them tham so
            sqlcmd.Parameters.AddWithValue("@maClieu", chatLieu.MaChatLieu);
            sqlcmd.Parameters.AddWithValue("@tenClieu", chatLieu.TenChatLieu);

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
        public int updateDataChatLieu(ChatLieu chatLieu)
        {
            int iKQ = 1;

            //tao sql command de thuc hien cau truy van
            SqlCommand sqlcmd = new SqlCommand("updateDataChatLieu", dtBase.conSQL);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            //them tham so vao sqlcommand
            sqlcmd.Parameters.AddWithValue("@maClieu", chatLieu.MaChatLieu);
            sqlcmd.Parameters.AddWithValue("@tenClieu", chatLieu.TenChatLieu);


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
        //xoa 1 Chat Liệu theo ma
        public int deleteDataChatLieu(string sMa)
        {
            int iKQ = 1;

            //tao sql command de thuc hien cau truy van
            SqlCommand sqlcmd = new SqlCommand("deleteDataChatLieu", dtBase.conSQL);
            sqlcmd.CommandType = CommandType.StoredProcedure;

            //them tham so vao sqlcommand
            sqlcmd.Parameters.AddWithValue("@maClieu", sMa);


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
        //tim Chất Liệu
        public DataTable findDataChatLieu(string sKey)
        {
            DataTable dtResutl = new DataTable();

            //tao sqlCommand
            SqlCommand sqlCMD = new SqlCommand("findDataChatLieu", dtBase.conSQL);

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
