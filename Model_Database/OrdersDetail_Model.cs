using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace MM_Project
{
    public class ClsMM_Orders_Detail
    {
        #region "Constants"
        private const string PP_MM_Orders_Detail = "PP_MM_ORDERS_DETAIL";
        #endregion
        #region "Member Variables"
        private int _Serialkey;
        private int _Table_Indicator;
        private string _Lsp_Identification;
        private string _Order_Number;
        private string _Store_Number;
        private string _Article_Number;
        private decimal _Order_Quantity;
        private DateTime _Date_Record;
        private string _Action_Code;
        private string _Warehouse_Number;
        private string _Orderline_Fretext;
        private string _Purchase_Order;
        private string _MM_Mail_Number;
        private string _Buying_Article_Number;
        private decimal _Article_Selling_Price;
        private DateTime _ADDDATE;
        private DateTime _EDITDATE;
        private string _STATUS;
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

        public string Store_Number
        {
            get { return _Store_Number; }
            set { _Store_Number = value; }
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

        public string Action_Code
        {
            get { return _Action_Code; }
            set { _Action_Code = value; }
        }

        public string Warehouse_Number
        {
            get { return _Warehouse_Number; }
            set { _Warehouse_Number = value; }
        }

        public string Orderline_Fretext
        {
            get { return _Orderline_Fretext; }
            set { _Orderline_Fretext = value; }
        }

        public string Purchase_Order
        {
            get { return _Purchase_Order; }
            set { _Purchase_Order = value; }
        }

        public string MM_Mail_Number
        {
            get { return _MM_Mail_Number; }
            set { _MM_Mail_Number = value; }
        }

        public string Buying_Article_Number
        {
            get { return _Buying_Article_Number; }
            set { _Buying_Article_Number = value; }
        }

        public decimal Article_Selling_Price
        {
            get { return _Article_Selling_Price; }
            set { _Article_Selling_Price = value; }
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

        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
        }

        public string FILENAME
        {
            get { return _FILENAME; }
            set { _FILENAME = value; }
        }

        #endregion
        #region "Connection"
        public ClsMM_Orders_Detail()
        {

        }

        public ClsMM_Orders_Detail(int Serialkey, int Table_Indicator, string Lsp_Identification, string Order_Number, string Store_Number, string Article_Number, decimal Order_Quantity, DateTime Date_Record, string Action_Code, string Warehouse_Number, string Orderline_Fretext, string Purchase_Order, string MM_Mail_Number, string Buying_Article_Number, decimal Article_Selling_Price, DateTime ADDDATE, DateTime EDITDATE, string STATUS, string FILENAME)
        {
            this.Serialkey = Serialkey;
            this.Table_Indicator = Table_Indicator;
            this.Lsp_Identification = Lsp_Identification;
            this.Order_Number = Order_Number;
            this.Store_Number = Store_Number;
            this.Article_Number = Article_Number;
            this.Order_Quantity = Order_Quantity;
            this.Date_Record = Date_Record;
            this.Action_Code = Action_Code;
            this.Warehouse_Number = Warehouse_Number;
            this.Orderline_Fretext = Orderline_Fretext;
            this.Purchase_Order = Purchase_Order;
            this.MM_Mail_Number = MM_Mail_Number;
            this.Buying_Article_Number = Buying_Article_Number;
            this.Article_Selling_Price = Article_Selling_Price;
            this.ADDDATE = ADDDATE;
            this.EDITDATE = EDITDATE;
            this.STATUS = STATUS;
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
            new SqlParameter( "@Lsp_Identification", SqlDbType.Char, 4),
            new SqlParameter( "@Order_Number", SqlDbType.Char, 17),
            new SqlParameter( "@Store_Number", SqlDbType.Char, 5),
            new SqlParameter( "@Article_Number", SqlDbType.Char, 8),
            new SqlParameter( "@Order_Quantity", SqlDbType.Decimal, 9),
            new SqlParameter( "@Date_Record", SqlDbType.Date, 3),
            new SqlParameter( "@Action_Code", SqlDbType.Char, 1),
            new SqlParameter( "@Warehouse_Number", SqlDbType.Char, 6),
            new SqlParameter( "@Orderline_Fretext", SqlDbType.Char, 15),
            new SqlParameter( "@Purchase_Order", SqlDbType.Char, 12),
            new SqlParameter( "@MM_Mail_Number", SqlDbType.Char, 5),
            new SqlParameter( "@Buying_Article_Number", SqlDbType.Char, 8),
            new SqlParameter( "@Article_Selling_Price", SqlDbType.Decimal, 9),
            new SqlParameter( "@ADDDATE", SqlDbType.DateTime, 8),
            new SqlParameter( "@EDITDATE", SqlDbType.DateTime, 8),
            new SqlParameter( "@STATUS", SqlDbType.NChar, 50),
            new SqlParameter( "@FILENAME", SqlDbType.NVarChar, 100),
            };
                sp[0].Value = "Addnew";

                sp[1].Value = this.Serialkey;

                sp[2].Value = this.Table_Indicator;

                sp[3].Value = this.Lsp_Identification;

                sp[4].Value = this.Order_Number;

                sp[5].Value = this.Store_Number;

                sp[6].Value = this.Article_Number;

                sp[7].Value = this.Order_Quantity;

                sp[8].Value = this.Date_Record;

                sp[9].Value = this.Action_Code;

                sp[10].Value = this.Warehouse_Number;

                sp[11].Value = this.Orderline_Fretext;

                sp[12].Value = this.Purchase_Order;

                sp[13].Value = this.MM_Mail_Number;

                sp[14].Value = this.Buying_Article_Number;

                sp[15].Value = this.Article_Selling_Price;

                sp[16].Value = this.ADDDATE;

                sp[17].Value = this.EDITDATE;

                sp[18].Value = this.STATUS;

                sp[19].Value = this.FILENAME;

                DAL.excutequery(PP_MM_Orders_Detail, sp, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception e)
            {
                string category = "Order_Detail";
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
            new SqlParameter( "@Store_Number", SqlDbType.Char, 5),
            new SqlParameter( "@Article_Number", SqlDbType.Char, 8),
            new SqlParameter( "@Order_Quantity", SqlDbType.Decimal, 9),
            new SqlParameter( "@Date_Record", SqlDbType.Date, 3),
            new SqlParameter( "@Action_Code", SqlDbType.Char, 1),
            new SqlParameter( "@Warehouse_Number", SqlDbType.Char, 6),
            new SqlParameter( "@Orderline_Fretext", SqlDbType.Char, 15),
            new SqlParameter( "@Purchase_Order", SqlDbType.Char, 12),
            new SqlParameter( "@MM_Mail_Number", SqlDbType.Char, 5),
            new SqlParameter( "@Buying_Article_Number", SqlDbType.Char, 8),
            new SqlParameter( "@Article_Selling_Price", SqlDbType.Decimal, 9),
            new SqlParameter( "@EDITDATE", SqlDbType.DateTime, 8),
           // new SqlParameter( "@STATUS", SqlDbType.NChar, 20),
            new SqlParameter( "@FILENAME", SqlDbType.NVarChar, 100),
            };
                sp[0].Value = "Update";

                sp[1].Value = this.Serialkey;

                sp[2].Value = this.Table_Indicator;

                sp[3].Value = this.Lsp_Identification;

                sp[4].Value = this.Order_Number;

                sp[5].Value = this.Store_Number;

                sp[6].Value = this.Article_Number;

                sp[7].Value = this.Order_Quantity;

                sp[8].Value = this.Date_Record;

                sp[9].Value = this.Action_Code;

                sp[10].Value = this.Warehouse_Number;

                sp[11].Value = this.Orderline_Fretext;

                sp[12].Value = this.Purchase_Order;

                sp[13].Value = this.MM_Mail_Number;

                sp[14].Value = this.Buying_Article_Number;

                sp[15].Value = this.Article_Selling_Price;

                sp[16].Value = this.EDITDATE;

                //sp[17].Value = this.STATUS;

                sp[17].Value = this.FILENAME;

                DAL.excutequery(PP_MM_Orders_Detail, sp, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception e)
            {
                string category = "Order_Detail";
                ResultDatabase_Model result = new ResultDatabase_Model();
                result.HandleError(fileName, text, e.Message.ToString(), this.Order_Number, category);
                return false;
            }
        }
        #endregion
    }
}

