using MM_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM_EDI
{
    public class Response_ReadFile
    {
        public void HandleError(string fileName,string text ,string message, string category)
        {
            message = message.Replace("'", "\"");
            string sql = string.Format("INSERT INTO MM_Error_File(FILENAME,TEXTFILE,MESSAGE,CATEGORY,ADDDATE) VALUES('{0}','{1}','{2}','{3}','{4}')",fileName, text, message,category,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            DAL.SELECT_SQL(sql);
        }
    }
}
