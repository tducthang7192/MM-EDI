using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MM_Project
{
    class Response_SFTP
    {
        public void Handle_Error_Sftp(string fileName, string message)
        {
            message = message.Replace("'", "\"").Replace("\r\n"," ").Replace("\n"," ");
            string sql = string.Format("INSERT INTO MM_Error_SFTP(FileName,Message,AddDate) VALUES ('{0}','{1}','{2}')",fileName,message,DateTime.Now);
            DAL.SELECT_SQL(sql);
        }
    }
}
