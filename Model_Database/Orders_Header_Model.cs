using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace MM_Project
{
    public class ClsMM_Orders_Header
    {
        #region "Constants"
        private const string PP_MM_Orders_Header = "PP_MM_ORDERS_HEADER";
        #endregion
        #region "Member Variables"
        private int _Serialkey;
        private int _Table_Indicator;
        private string _Lsp_Identification;
        private string _Order_Number;
        private string _Order_Type;
        private string _Store_Number;
        private DateTime _Plan_Delivery_Date;
        private string _Warehouse_Number;
        private string _MM_Email_Number;
        private string _Memo_Field;
        private DateTime _Date_Record;
        private string _Action_Type;
        private string _Commercial_Supplier_Number;
        private DateTime _Plan_Delivery_To_Warehouse;
        private DateTime _Order_Date;
        private string _Free_Text1;
        private string _Free_Text2;
        private int _Order_Logistic_Type;
        private int _Customer_Store_Number;
        private string _Customer_Number;
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

        public string Order_Type
        {
            get { return _Order_Type; }
            set { _Order_Type = value; }
        }

        public string Store_Number
        {
            get { return _Store_Number; }
            set { _Store_Number = value; }
        }

        public DateTime Plan_Delivery_Date
        {
            get { return _Plan_Delivery_Date; }
            set { _Plan_Delivery_Date = value; }
        }

        public string Warehouse_Number
        {
            get { return _Warehouse_Number; }
            set { _Warehouse_Number = value; }
        }

        public string MM_Email_Number
        {
            get { return _MM_Email_Number; }
            set { _MM_Email_Number = value; }
        }

        public string Memo_Field
        {
            get { return _Memo_Field; }
            set { _Memo_Field = value; }
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

        public string Commercial_Supplier_Number
        {
            get { return _Commercial_Supplier_Number; }
            set { _Commercial_Supplier_Number = value; }
        }

        public DateTime Plan_Delivery_To_Warehouse
        {
            get { return _Plan_Delivery_To_Warehouse; }
            set { _Plan_Delivery_To_Warehouse = value; }
        }

        public DateTime Order_Date
        {
            get { return _Order_Date; }
            set { _Order_Date = value; }
        }

        public string Free_Text1
        {
            get { return _Free_Text1; }
            set { _Free_Text1 = value; }
        }

        public string Free_Text2
        {
            get { return _Free_Text2; }
            set { _Free_Text2 = value; }
        }

        public int Order_Logistic_Type
        {
            get { return _Order_Logistic_Type; }
            set { _Order_Logistic_Type = value; }
        }

        public int Customer_Store_Number
        {
            get { return _Customer_Store_Number; }
            set { _Customer_Store_Number = value; }
        }

        public string Customer_Number
        {
            get { return _Customer_Number; }
            set { _Customer_Number = value; }
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
        public ClsMM_Orders_Header()
        {
           
        }

        public ClsMM_Orders_Header(int Serialkey, int Table_Indicator, string Lsp_Identification, string Order_Number, string Order_Type, string Store_Number, DateTime Plan_Delivery_Date, string Warehouse_Number, string MM_Email_Number, string Memo_Field, DateTime Date_Record, string Action_Type, string Commercial_Supplier_Number, DateTime Plan_Delivery_To_Warehouse, DateTime Order_Date, string Free_Text1, string Free_Text2, int Order_Logistic_Type, int Customer_Store_Number, string Customer_Number, DateTime ADDDATE, DateTime EDITDATE, string STATUS, string FILENAME)
        {
            this.Serialkey = Serialkey;
            this.Table_Indicator = Table_Indicator;
            this.Lsp_Identification = Lsp_Identification;
            this.Order_Number = Order_Number;
            this.Order_Type = Order_Type;
            this.Store_Number = Store_Number;
            this.Plan_Delivery_Date = Plan_Delivery_Date;
            this.Warehouse_Number = Warehouse_Number;
            this.MM_Email_Number = MM_Email_Number;
            this.Memo_Field = Memo_Field;
            this.Date_Record = Date_Record;
            this.Action_Type = Action_Type;
            this.Commercial_Supplier_Number = Commercial_Supplier_Number;
            this.Plan_Delivery_To_Warehouse = Plan_Delivery_To_Warehouse;
            this.Order_Date = Order_Date;
            this.Free_Text1 = Free_Text1;
            this.Free_Text2 = Free_Text2;
            this.Order_Logistic_Type = Order_Logistic_Type;
            this.Customer_Store_Number = Customer_Store_Number;
            this.Customer_Number = Customer_Number;
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
            new SqlParameter( "@Order_Type", SqlDbType.Char, 4),
            new SqlParameter( "@Store_Number", SqlDbType.Char, 5),
            new SqlParameter( "@Plan_Delivery_Date", SqlDbType.Date, 3),
            new SqlParameter( "@Warehouse_Number", SqlDbType.Char, 6),
            new SqlParameter( "@MM_Email_Number", SqlDbType.Char, 5),
            new SqlParameter( "@Memo_Field", SqlDbType.Char, 60),
            new SqlParameter( "@Date_Record", SqlDbType.Date, 3),
            new SqlParameter( "@Action_Type", SqlDbType.Char, 1),
            new SqlParameter( "@Commercial_Supplier_Number", SqlDbType.Char, 6),
            new SqlParameter( "@Plan_Delivery_To_Warehouse", SqlDbType.Date, 3),
            new SqlParameter( "@Order_Date", SqlDbType.Date, 3),
            new SqlParameter( "@Free_Text1", SqlDbType.Char, 20),
            new SqlParameter( "@Free_Text2", SqlDbType.Char, 20),
            new SqlParameter( "@Order_Logistic_Type", SqlDbType.Int, 4),
            new SqlParameter( "@Customer_Store_Number", SqlDbType.Int, 4),
            new SqlParameter( "@Customer_Number", SqlDbType.Char, 6),
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

                sp[5].Value = this.Order_Type;

                sp[6].Value = this.Store_Number;

                sp[7].Value = this.Plan_Delivery_Date;

                sp[8].Value = this.Warehouse_Number;

                sp[9].Value = this.MM_Email_Number;

                sp[10].Value = this.Memo_Field;

                sp[11].Value = this.Date_Record;

                sp[12].Value = this.Action_Type;

                sp[13].Value = this.Commercial_Supplier_Number;

                sp[14].Value = this.Plan_Delivery_To_Warehouse;

                sp[15].Value = this.Order_Date;

                sp[16].Value = this.Free_Text1;

                sp[17].Value = this.Free_Text2;

                sp[18].Value = this.Order_Logistic_Type;

                sp[19].Value = this.Customer_Store_Number;

                sp[20].Value = this.Customer_Number;

                sp[21].Value = this.ADDDATE;

                sp[22].Value = this.EDITDATE;

                sp[23].Value = this.STATUS;

                sp[24].Value = this.FILENAME;

                DAL.excutequery(PP_MM_Orders_Header, sp, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception e)
            {
                string category = "Order_Header";
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
            new SqlParameter( "@Order_Type", SqlDbType.Char, 4),
            new SqlParameter( "@Store_Number", SqlDbType.Char, 5),
            new SqlParameter( "@Plan_Delivery_Date", SqlDbType.Date, 3),
            new SqlParameter( "@Warehouse_Number", SqlDbType.Char, 6),
            new SqlParameter( "@MM_Email_Number", SqlDbType.Char, 5),
            new SqlParameter( "@Memo_Field", SqlDbType.Char, 60),
            new SqlParameter( "@Date_Record", SqlDbType.Date, 3),
            new SqlParameter( "@Action_Type", SqlDbType.Char, 1),
            new SqlParameter( "@Commercial_Supplier_Number", SqlDbType.Char, 6),
            new SqlParameter( "@Plan_Delivery_To_Warehouse", SqlDbType.Date, 3),
            new SqlParameter( "@Order_Date", SqlDbType.Date, 3),
            new SqlParameter( "@Free_Text1", SqlDbType.Char, 20),
            new SqlParameter( "@Free_Text2", SqlDbType.Char, 20),
            new SqlParameter( "@Order_Logistic_Type", SqlDbType.Int, 4),
            new SqlParameter( "@Customer_Store_Number", SqlDbType.Int, 4),
            new SqlParameter( "@Customer_Number", SqlDbType.Char, 6),
            new SqlParameter( "@EDITDATE", SqlDbType.DateTime, 8),
           // new SqlParameter( "@STATUS", SqlDbType.NChar, 20),
            new SqlParameter( "@FILENAME", SqlDbType.NVarChar, 100),
            };
                sp[0].Value = "Update";

                sp[1].Value = this.Serialkey;

                sp[2].Value = this.Table_Indicator;

                sp[3].Value = this.Lsp_Identification;

                sp[4].Value = this.Order_Number;

                sp[5].Value = this.Order_Type;

                sp[6].Value = this.Store_Number;

                sp[7].Value = this.Plan_Delivery_Date;

                sp[8].Value = this.Warehouse_Number;

                sp[9].Value = this.MM_Email_Number;

                sp[10].Value = this.Memo_Field;

                sp[11].Value = this.Date_Record;

                sp[12].Value = this.Action_Type;

                sp[13].Value = this.Commercial_Supplier_Number;

                sp[14].Value = this.Plan_Delivery_To_Warehouse;

                sp[15].Value = this.Order_Date;

                sp[16].Value = this.Free_Text1;

                sp[17].Value = this.Free_Text2;

                sp[18].Value = this.Order_Logistic_Type;

                sp[19].Value = this.Customer_Store_Number;

                sp[20].Value = this.Customer_Number;

                sp[21].Value = this.EDITDATE;

                //sp[22].Value = this.STATUS;

                sp[22].Value = this.FILENAME;

                DAL.excutequery(PP_MM_Orders_Header, sp, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception e)
            {
                string category = "Order_Header";
                ResultDatabase_Model result = new ResultDatabase_Model();
                result.HandleError(fileName, text, e.Message.ToString(), this.Order_Number, category);
                return false;
            }
        }

        #endregion
    }
}
