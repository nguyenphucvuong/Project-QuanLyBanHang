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
    public class BUSChatLieu
    {

        DAL_ChatLieu dalChatLieu = new DAL_ChatLieu();
        //lay thong tin tu database
        public DataTable getData(string nameTable)
        {
            DataTable dtResutl = new DataTable();
            dtResutl = dalChatLieu.getDataFromChatLieu(nameTable);
            return dtResutl;
        }
        //them tt vao banng chất liệu
        public int insertDataChatLieu(ChatLieu chatLieu)
        {
            return dalChatLieu.insertDataChatLieu(chatLieu);
        }
        //cap nhat tt chất liệu
        public int updateDataChatLieu(ChatLieu chatLieu)
        {
            return dalChatLieu.updateDataChatLieu(chatLieu);
        }
        //Xoa chất liệu
        public int deleteDataChatLieu(string sMa)
        {
            return dalChatLieu.deleteDataChatLieu(sMa);
        }
        //Tim chất liệu
        public DataTable findChatLieu(string sMa)
        {
            DataTable dtResutl = new DataTable();
            dtResutl = dalChatLieu.findDataChatLieu(sMa);
            return dtResutl;
        }
    }
}
