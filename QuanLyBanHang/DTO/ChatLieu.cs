using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChatLieu
    {
        private string maChatLieu;
        private string tenChatLieu;

        //constructor
        //co tham so
        public ChatLieu(string maChatLieu, string tenChatLieu)
        {
            this.maChatLieu = maChatLieu;
            this.tenChatLieu = tenChatLieu;
        }

        //khong tham so
        public ChatLieu()
        {

        }

        //properties
        public string MaChatLieu
        {
            get
            {
                return maChatLieu;
            }

            set
            {
                maChatLieu = value;
            }
        }

        public string TenChatLieu
        {
            get
            {
                return tenChatLieu;
            }

            set
            {
                tenChatLieu = value;
            }
        }
    }
}
