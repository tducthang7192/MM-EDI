using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM_Project
{
    public class ResultDatabase_Model
    {
        public bool check { get; set; }
        public string type  { get; set; }
        #region sku/supplier/so/asn
        public string code { get; set; }
        #endregion
        public int indicator { get; set; }
        public int numberRowSuccess { get; set; }
        public ResultDatabase_Model() { }
        // type là trạng thái insert or delete 
        public  void result(bool check, string type, string code)
        {
            this.check = check;
            this.type = type;
            this.code = code;
        }
        public void HandleError(string fileName,string text, string message,string code, string category) 
        {
             message = message.Replace("'", "\"");
            string sql = string.Format("INSERT INTO MM_Error_Insert_Update(FILENAME,CODE,TEXT,MESSAGE,ADDDATE,CATEGORY) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", fileName,code, text, message, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),category);
            DAL.SELECT_SQL(sql);
        } 

    }
}
