using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;

namespace MM_Project
{
    public class IonReponse
    {
        public bool check { get; set; }
        public string message { get; set; }
        public System.Net.HttpStatusCode errcode { get; set; }
        public void RecordResultAPI(string type,string code)
        {
            this.message = this.message.Replace("'", "\"");
            string sql = string.Format("insert into MM_Error_ION (Type,Code,Message,ERROR_CODE,FileName,ADDDATE) values ('{0}','{1}','{2}','{3}','{4}','{5}')",type,code, this.message, this.errcode.ToString(),"", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            DAL.SELECT_SQL(sql);            
        }
        public async void Get_Token()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory +"token" +".txt";
            string token = await ClientHttpController.GetToken();
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(token);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(token);

                }
            }

        }
    }
}
