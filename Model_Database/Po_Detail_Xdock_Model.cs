using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace MM_Project
{
    public class MM_PO_Detail_XD
    {
        #region "Constants"
        private const string PP_MM_PO_Detail_XD = "PP_MM_PO_DETAIL_XD";
        #endregion
        #region "Member Variables"
        private int _Serialkey;
        private int _Table_Indicator;
        private string _Lsp_Identification;
        private string _Order_Number;
        private string _Article_Number;
        private string _Store_Number;
        private decimal _Order_Quantity;
        private string _Warehouse_Number;
        private string _Sale_Order;
        private string _Metro_Mail;
        private string _Buying_Article_Number;
        private DateTime _ADDDATE;
        private DateTime _EDITDATE;
        private string _BLANK1;
        private string _BLANK2;
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

        public string Store_Number
        {
            get { return _Store_Number; }
            set { _Store_Number = value; }
        }

        public decimal Order_Quantity
        {
            get { return _Order_Quantity; }
            set { _Order_Quantity = value; }
        }

        public string Warehouse_Number
        {
            get { return _Warehouse_Number; }
            set { _Warehouse_Number = value; }
        }

        public string Sale_Order
        {
            get { return _Sale_Order; }
            set { _Sale_Order = value; }
        }

        public string Metro_Mail
        {
            get { return _Metro_Mail; }
            set { _Metro_Mail = value; }
        }

        public string Buying_Article_Number
        {
            get { return _Buying_Article_Number; }
            set { _Buying_Article_Number = value; }
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
        public MM_PO_Detail_XD()
        {
        }

        public MM_PO_Detail_XD(int Serialkey, int Table_Indicator, string Lsp_Identification, string Order_Number, string Article_Number, string Store_Number, decimal Order_Quantity, string Warehouse_Number, string Sale_Order, string Metro_Mail, string Buying_Article_Number, DateTime ADDDATE, DateTime EDITDATE, string BLANK1, string BLANK2, string FILENAME, string STATUS)
        {
            this.Serialkey = Serialkey;
            this.Table_Indicator = Table_Indicator;
            this.Lsp_Identification = Lsp_Identification;
            this.Order_Number = Order_Number;
            this.Article_Number = Article_Number;
            this.Store_Number = Store_Number;
            this.Order_Quantity = Order_Quantity;
            this.Warehouse_Number = Warehouse_Number;
            this.Sale_Order = Sale_Order;
            this.Metro_Mail = Metro_Mail;
            this.Buying_Article_Number = Buying_Article_Number;
            this.ADDDATE = ADDDATE;
            this.EDITDATE = EDITDATE;
            this.BLANK1 = BLANK1;
            this.BLANK2 = BLANK2;
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
            new SqlParameter( "@Store_Number", SqlDbType.Char, 5),
            new SqlParameter( "@Order_Quantity", SqlDbType.Decimal, 9),
            new SqlParameter( "@Warehouse_Number", SqlDbType.Char, 6),
            new SqlParameter( "@Sale_Order", SqlDbType.Char, 17),
            new SqlParameter( "@Metro_Mail", SqlDbType.Char, 5),
            new SqlParameter( "@Buying_Article_Number", SqlDbType.Char, 7),
            new SqlParameter( "@ADDDATE", SqlDbType.DateTime, 8),
            new SqlParameter( "@EDITDATE", SqlDbType.DateTime, 8),
            new SqlParameter( "@BLANK1", SqlDbType.Char, 38),
            new SqlParameter( "@BLANK2", SqlDbType.Char, 8),
            new SqlParameter( "@FILENAME", SqlDbType.NVarChar, 200),
            new SqlParameter( "@STATUS", SqlDbType.NVarChar, 40),
            };
                sp[0].Value = "Addnew";

                sp[1].Value = this.Serialkey;

                sp[2].Value = this.Table_Indicator;

                sp[3].Value = this.Lsp_Identification;

                sp[4].Value = this.Order_Number;

                sp[5].Value = this.Article_Number;

                sp[6].Value = this.Store_Number;

                sp[7].Value = this.Order_Quantity;

                sp[8].Value = this.Warehouse_Number;

                sp[9].Value = this.Sale_Order;

                sp[10].Value = this.Metro_Mail;

                sp[11].Value = this.Buying_Article_Number;

                sp[12].Value = this.ADDDATE;

                sp[13].Value = this.EDITDATE;

                sp[14].Value = this.BLANK1;

                sp[15].Value = this.BLANK2;

                sp[16].Value = this.FILENAME;

                sp[17].Value = this.STATUS;

                DAL.excutequery(PP_MM_PO_Detail_XD, sp, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception e)
            {
                string category = "PO_DETAIL_XDOCK";
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
            new SqlParameter( "@Store_Number", SqlDbType.Char, 5),
            new SqlParameter( "@Order_Quantity", SqlDbType.Decimal, 9),
            new SqlParameter( "@Warehouse_Number", SqlDbType.Char, 6),
            new SqlParameter( "@Sale_Order", SqlDbType.Char, 17),
            new SqlParameter( "@Metro_Mail", SqlDbType.Char, 5),
            new SqlParameter( "@Buying_Article_Number", SqlDbType.Char, 7),
            new SqlParameter( "@EDITDATE", SqlDbType.DateTime, 8),
            new SqlParameter( "@BLANK1", SqlDbType.Char, 38),
            new SqlParameter( "@BLANK2", SqlDbType.Char, 8),
            new SqlParameter( "@FILENAME", SqlDbType.NVarChar, 200),
            };
                sp[0].Value = "Update";

                sp[1].Value = this.Serialkey;

                sp[2].Value = this.Table_Indicator;

                sp[3].Value = this.Lsp_Identification;

                sp[4].Value = this.Order_Number;

                sp[5].Value = this.Article_Number;

                sp[6].Value = this.Store_Number;

                sp[7].Value = this.Order_Quantity;

                sp[8].Value = this.Warehouse_Number;

                sp[9].Value = this.Sale_Order;

                sp[10].Value = this.Metro_Mail;

                sp[11].Value = this.Buying_Article_Number;

                sp[12].Value = this.EDITDATE;

                sp[13].Value = this.BLANK1;

                sp[14].Value = this.BLANK2;

                sp[15].Value = this.FILENAME;


                DAL.excutequery(PP_MM_PO_Detail_XD, sp, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception e)
            {
                string category = "PO_DETAIL_XDOCK";
                ResultDatabase_Model result = new ResultDatabase_Model();
                result.HandleError(fileName, text, e.Message.ToString(), this.Order_Number, category);
                return false;
            }
        }

        #endregion
    }
}