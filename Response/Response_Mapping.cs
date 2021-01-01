using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM_Project
{
    public class Response_Mapping
    {
        public void Handle_Error_Mapping(string code, string message, string step)
        {
            message = message.Replace("'", "\"").Replace("\r\n", " ").Replace("\n", " ");
            string sql = string.Format("INSERT INTO MM_ERROR_MAPPING(CODE,Message,STEP,AddDate) VALUES ('{0}','{1}','{2}','{3}')", code, message,step, DateTime.Now);
            DAL.SELECT_SQL(sql);
        }
        
    }
}
