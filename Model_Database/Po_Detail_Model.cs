using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace MM_Project
{
    public class MM_PO_Detail
    {
        #region "Constants"
        private const string PP_MM_PO_Detail = "PP_MM_PO_DETAIL";
        #endregion
        #region "Member Variables"
        private int _Serialkey;
        private int _Table_Indicator;
        private string _Lsp_Identification;
        private string _Order_Number;
        private string _Article_Number;
        private decimal _Order_Quantity;
        private DateTime _Date_Record;
        private string _Action_Type;
        private string _Warehouse_Number;
        private string _Orderline;
        private string _MM_Email_Number;
        private DateTime _ADDDATE;
        private DateTime _EDITDATE;
        private string _BLANK1;
        private string _BLANK2;
        private string _BLANK10;
        private string _FILENAME;
        private string _STATUS;
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

        public string Lsp_Identification
        {
            get { return _Lsp_Identification; }
            set { _Lsp_Identification = value; }
        }

        public string Order_Number
        {
            get { return _Order_Number; }
            set { _Order_Number = value; }
        }

        public string Article_Number
        {
            get { return _Article_Number; }
            set { _Article_Number = value; }
        }

        public decimal Order_Quantity
        {
            get { return _Order_Quantity; }
            set { _Order_Quantity = value; }
        }

        public DateTime Date_Record
        {
            get { return _Date_Record; }
            set { _Date_Record = value; }
        }

        public string Action_Type
        {
            get { return _Action_Type; }
            set { _Action_Type = value; }
        }

        public string Warehouse_Number
        {
            get { return _Warehouse_Number; }
            set { _Warehouse_Number = value; }
        }

        public string Orderline
        {
            get { return _Orderline; }
            set { _Orderline = value; }
        }

        public string MM_Email_Number
        {
            get { return _MM_Email_Number; }
            set { _MM_Email_Number = value; }
        }

        public DateTime ADDDATE
        {
            get { return _ADDDATE; }
            set { _ADDDATE = value; }
        }

        public DateTime EDITDATE
        {
            get { return _EDITDATE; }
            set { _EDITDATE = value; }
        }

        public string BLANK1
        {
            get { return _BLANK1; }
            set { _BLANK1 = value; }
        }

        public string BLANK2
        {
            get { return _BLANK2; }
            set { _BLANK2 = value; }
        }

        public string BLANK10
        {
            get { return _BLANK10; }
            set { _BLANK10 = value; }
        }

        public string FILENAME
        {
            get { return _FILENAME; }
            set { _FILENAME = value; }
        }

        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
        }

        #endregion
        #region "Connection"
        public MM_PO_Detail()
        {
        }

        public MM_PO_Detail(int Serialkey, int Table_Indicator, string Lsp_Identification, string Order_Number, string Article_Number, decimal Order_Quantity, DateTime Date_Record, string Action_Type, string Warehouse_Number, string Orderline, string MM_Email_Number, DateTime ADDDATE, DateTime EDITDATE, string BLANK1, string BLANK2, string BLANK10, string FILENAME, string STATUS)
        {
            this.Serialkey = Serialkey;
            this.Table_Indicator = Table_Indicator;
            this.Lsp_Identification = Lsp_Identification;
            this.Order_Number = Order_Number;
            this.Article_Number = Article_Number;
            this.Order_Quantity = Order_Quantity;
            this.Date_Record = Date_Record;
            this.Action_Type = Action_Type;
            this.Warehouse_Number = Warehouse_Number;
            this.Orderline = Orderline;
            this.MM_Email_Number = MM_Email_Number;
            this.ADDDATE = ADDDATE;
            this.EDITDATE = EDITDATE;
            this.BLANK1 = BLANK1;
            this.BLANK2 = BLANK2;
            this.BLANK10 = BLANK10;
            this.FILENAME = FILENAME;
            this.STATUS = STATUS;
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
            new SqlParameter( "@Lsp_Identification", SqlDbType.Char, 4),
            new SqlParameter( "@Order_Number", SqlDbType.Char, 17),
            new SqlParameter( "@Article_Number", SqlDbType.Char, 8),
            new SqlParameter( "@Order_Quantity", SqlDbType.Decimal, 9),
            new SqlParameter( "@Date_Record", SqlDbType.Date, 3),
            new SqlParameter( "@Action_Type", SqlDbType.Char, 1),
            new SqlParameter( "@Warehouse_Number", SqlDbType.Char, 6),
            new SqlParameter( "@Orderline", SqlDbType.Char, 20),
            new SqlParameter( "@MM_Email_Number", SqlDbType.Char, 5),
            new SqlParameter( "@ADDDATE", SqlDbType.DateTime, 8),
            new SqlParameter( "@EDITDATE", SqlDbType.DateTime, 8),
            new SqlParameter( "@BLANK1", SqlDbType.Char, 38),
            new SqlParameter( "@BLANK2", SqlDbType.Char, 8),
            new SqlParameter( "@BLANK10", SqlDbType.Char, 10),
            new SqlParameter( "@FILENAME", SqlDbType.NVarChar, 200),
            new SqlParameter( "@STATUS", SqlDbType.NVarChar, 40),
            };
                sp[0].Value = "Addnew";

                sp[1].Value = this.Serialkey;

                sp[2].Value = this.Table_Indicator;

                sp[3].Value = this.Lsp_Identification;

                sp[4].Value = this.Order_Number;

                sp[5].Value = this.Article_Number;

                sp[6].Value = this.Order_Quantity;

                sp[7].Value = this.Date_Record;

                sp[8].Value = this.Action_Type;

                sp[9].Value = this.Warehouse_Number;

                sp[10].Value = this.Orderline;

                sp[11].Value = this.MM_Email_Number;

                sp[12].Value = this.ADDDATE;

                sp[13].Value = this.EDITDATE;

                sp[14].Value = this.BLANK1;

                sp[15].Value = this.BLANK2;

                sp[16].Value = this.BLANK10;

                sp[17].Value = this.FILENAME;

                sp[18].Value = this.STATUS;

                DAL.excutequery(PP_MM_PO_Detail, sp, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception e)
            {
                string category = "PO_DETAIL";
                ResultDatabase_Model result = new ResultDatabase_Model();
                result.HandleError(fileName, text, e.Message.ToString(), this.Order_Number, category);
                return false;
            }
        }

        public Boolean Update(string fileName, string text)
        {
            try
            {
                SqlParameter[] sp =
                {
            new SqlParameter( "@Action", SqlDbType.NVarChar, 255),
            new SqlParameter( "@Serialkey", SqlDbType.Int, 4),
            new SqlParameter( "@Table_Indicator", SqlDbType.Int, 4),
            new SqlParameter( "@Lsp_Identification", SqlDbType.Char, 4),
            new SqlParameter( "@Order_Number", SqlDbType.Char, 17),
            new SqlParameter( "@Article_Number", SqlDbType.Char, 8),
            new SqlParameter( "@Order_Quantity", SqlDbType.Decimal, 9),
            new SqlParameter( "@Date_Record", SqlDbType.Date, 3),
            new SqlParameter( "@Action_Type", SqlDbType.Char, 1),
            new SqlParameter( "@Warehouse_Number", SqlDbType.Char, 6),
            new SqlParameter( "@Orderline", SqlDbType.Char, 20),
            new SqlParameter( "@MM_Email_Number", SqlDbType.Char, 5),
            new SqlParameter( "@EDITDATE", SqlDbType.DateTime, 8),
            new SqlParameter( "@BLANK1", SqlDbType.Char, 38),
            new SqlParameter( "@BLANK2", SqlDbType.Char, 8),
            new SqlParameter( "@BLANK10", SqlDbType.Char, 10),
            new SqlParameter( "@FILENAME", SqlDbType.NVarChar, 200)
            };
                sp[0].Value = "Update";

                sp[1].Value = this.Serialkey;

                sp[2].Value = this.Table_Indicator;

                sp[3].Value = this.Lsp_Identification;

                sp[4].Value = this.Order_Number;

                sp[5].Value = this.Article_Number;

                sp[6].Value = this.Order_Quantity;

                sp[7].Value = this.Date_Record;

                sp[8].Value = this.Action_Type;

                sp[9].Value = this.Warehouse_Number;

                sp[10].Value = this.Orderline;

                sp[11].Value = this.MM_Email_Number;

                sp[12].Value = this.EDITDATE;

                sp[13].Value = this.BLANK1;

                sp[14].Value = this.BLANK2;

                sp[15].Value = this.BLANK10;

                sp[16].Value = this.FILENAME;

                DAL.excutequery(PP_MM_PO_Detail, sp, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception e)
            {
                string category = "PO_DETAIL";
                ResultDatabase_Model result = new ResultDatabase_Model();
                result.HandleError(fileName, text, e.Message.ToString(), this.Order_Number, category);
                return false;
            }
        }

        #endregion
    }
}

