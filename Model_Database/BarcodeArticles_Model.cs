using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;


namespace MM_Project
{
    public class BarcodeArticles_Model
    {
        #region "Constants"
        private const string PP_MM_Barcode_Articles = "PP_MM_BARCODE_ARTICLES";
        #endregion
        #region "Member Variables"
        private int _Serialkey;
        private int _Table_Indicator;
        private string _Action_Code;
        private string _Lsp_Identification;
        private string _Article_Number;
        private string _Barcode;
        private string _Warehouse_Number;
        private DateTime _Date_Record;
        private int _Barcode_Sequence_Number;
        private DateTime _Editdate;
        private DateTime _AddDate;
        private string _FILENAME;

        #endregion

        #region "Public Properties"
        public int Serialkey
        {
            get { return _Serialkey; }
            set { _Serialkey = value; }
        }

        public int Table_Indicator
        {
            get { return _Table_Indicator; }
            set { _Table_Indicator = value; }
        }

        public string Action_Code
        {
            get { return _Action_Code; }
            set { _Action_Code = value; }
        }

        public string Lsp_Identification
        {
            get { return _Lsp_Identification; }
            set { _Lsp_Identification = value; }
        }

        public string Article_Number
        {
            get { return _Article_Number; }
            set { _Article_Number = value; }
        }

        public string Barcode
        {
            get { return _Barcode; }
            set { _Barcode = value; }
        }

        public string Warehouse_Number
        {
            get { return _Warehouse_Number; }
            set { _Warehouse_Number = value; }
        }

        public DateTime Date_Record
        {
            get { return _Date_Record; }
            set { _Date_Record = value; }
        }

        public int Barcode_Sequence_Number
        {
            get { return _Barcode_Sequence_Number; }
            set { _Barcode_Sequence_Number = value; }
        }

        public DateTime Editdate
        {
            get { return _Editdate; }
            set { _Editdate = value; }
        }

        public DateTime AddDate
        {
            get { return _AddDate; }
            set { _AddDate = value; }
        }

        public string FILENAME
        {
            get { return _FILENAME; }
            set { _FILENAME = value; }
        }



        #endregion
        #region "Connection"
        public BarcodeArticles_Model()
        {
        }

        public BarcodeArticles_Model(int Serialkey, int Table_Indicator, string Action_Code, string Lsp_Identification, string Article_Number, string Barcode, string Warehouse_Number, DateTime Date_Record, int Barcode_Sequence_Number, DateTime Editdate, DateTime AddDate, string FILENAME, string STATUS)
        {
            this.Serialkey = Serialkey;
            this.Table_Indicator = Table_Indicator;
            this.Action_Code = Action_Code;
            this.Lsp_Identification = Lsp_Identification;
            this.Article_Number = Article_Number;
            this.Barcode = Barcode;
            this.Warehouse_Number = Warehouse_Number;
            this.Date_Record = Date_Record;
            this.Barcode_Sequence_Number = Barcode_Sequence_Number;
            this.Editdate = Editdate;
            this.AddDate = AddDate;
            this.FILENAME = FILENAME;
        }
        #endregion

        #region "Main Procedure"
        public Boolean Add(string fileName, string text)
        {
            try
            {
                SqlParameter[] sp =
            {
            new SqlParameter( "@Action", SqlDbType.NVarChar, 255),
            new SqlParameter( "@Serialkey", SqlDbType.Int, 4),
            new SqlParameter( "@Table_Indicator", SqlDbType.Int, 4),
            new SqlParameter( "@Action_Code", SqlDbType.Char, 1),
            new SqlParameter( "@Lsp_Identification", SqlDbType.Char, 1),
            new SqlParameter( "@Article_Number", SqlDbType.Char, 8),
            new SqlParameter( "@Barcode", SqlDbType.Char, 14),
            new SqlParameter( "@Warehouse_Number", SqlDbType.Char, 6),
            new SqlParameter( "@Date_Record", SqlDbType.Date, 3),
            new SqlParameter( "@Barcode_Sequence_Number", SqlDbType.Int, 4),
            new SqlParameter( "@Editdate", SqlDbType.DateTime, 8),
            new SqlParameter( "@AddDate", SqlDbType.DateTime, 8),
            new SqlParameter( "@FILENAME", SqlDbType.NVarChar, 200),
            };
                sp[0].Value = "Addnew";

                sp[1].Value = this.Serialkey;

                sp[2].Value = this.Table_Indicator;

                sp[3].Value = this.Action_Code;

                sp[4].Value = this.Lsp_Identification;

                sp[5].Value = this.Article_Number;

                sp[6].Value = this.Barcode;

                sp[7].Value = this.Warehouse_Number;

                sp[8].Value = this.Date_Record;

                sp[9].Value = this.Barcode_Sequence_Number;

                sp[10].Value = this.Editdate;

                sp[11].Value = this.AddDate;

                sp[12].Value = this.FILENAME;


                DAL.excutequery(PP_MM_Barcode_Articles, sp, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception e)
            {
                string category = "Barcode_Article";
                ResultDatabase_Model result = new ResultDatabase_Model();
                result.HandleError(fileName, text, e.Message.ToString(), this.Barcode,category);
                return false;
            }
            
        }

        public Boolean Update(string fileName,string text)
        {
            try
            {
                SqlParameter[] sp =
            {
            new SqlParameter( "@Action", SqlDbType.NVarChar, 255),
            new SqlParameter( "@Serialkey", SqlDbType.Int, 4),
            new SqlParameter( "@Table_Indicator", SqlDbType.Int, 4),
            new SqlParameter( "@Action_Code", SqlDbType.Char, 1),
            new SqlParameter( "@Lsp_Identification", SqlDbType.Char, 1),
            new SqlParameter( "@Article_Number", SqlDbType.Char, 8),
            new SqlParameter( "@Barcode", SqlDbType.Char, 14),
            new SqlParameter( "@Warehouse_Number", SqlDbType.Char, 6),
            new SqlParameter( "@Date_Record", SqlDbType.Date, 3),
            new SqlParameter( "@Barcode_Sequence_Number", SqlDbType.Int, 4),
            new SqlParameter( "@Editdate", SqlDbType.DateTime, 8),
            new SqlParameter( "@FILENAME", SqlDbType.NVarChar, 200)
            };
                sp[0].Value = "Update";

                sp[1].Value = this.Serialkey;

                sp[2].Value = this.Table_Indicator;

                sp[3].Value = this.Action_Code;

                sp[4].Value = this.Lsp_Identification;

                sp[5].Value = this.Article_Number;

                sp[6].Value = this.Barcode;

                sp[7].Value = this.Warehouse_Number;

                sp[8].Value = this.Date_Record;

                sp[9].Value = this.Barcode_Sequence_Number;

                sp[10].Value = this.Editdate;

                sp[11].Value = this.FILENAME;


                DAL.excutequery(PP_MM_Barcode_Articles, sp, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception e)
            {
                string category = "Barcode_Article";
                ResultDatabase_Model result = new ResultDatabase_Model();
                result.HandleError(fileName, text, e.Message.ToString(), this.Barcode, category);
                return false;
            }
        }

        #endregion
    }
}