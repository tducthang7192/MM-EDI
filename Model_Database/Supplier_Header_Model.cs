using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace MM_Project
{
    public class Supplier_Header_Model
    {
        #region "Constants"
        private const string PP_MM_Supplier_Header = "PP_MM_SUPPLIER_HEADER";
        #endregion
        #region "Member Variables"
        private int _Serialkey;
        private int _Table_Indicator;
        private string _Action_Code;
        private string _Lsp_Identification;
        private string _Supplier_Code;
        private string _Supplier_Name;
        private int _Supplier_Status;
        private int _Supplier_Type;
        private string _Buyer_User_Id;
        private string _Supplier_Fiscal_Number;
        private int _Way_Of_Order;
        private string _Language_Code;
        private string _Currency_Code;
        private string _Warehouse_Number;
        private DateTime _Date_Record;
        private int _Default_Logistic_Flow;
        private string _Supplier_Registration_Number;
        private DateTime _AddDate;
        private DateTime _EditDate;
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

        public string Supplier_Code
        {
            get { return _Supplier_Code; }
            set { _Supplier_Code = value; }
        }

        public string Supplier_Name
        {
            get { return _Supplier_Name; }
            set { _Supplier_Name = value; }
        }

        public int Supplier_Status
        {
            get { return _Supplier_Status; }
            set { _Supplier_Status = value; }
        }

        public int Supplier_Type
        {
            get { return _Supplier_Type; }
            set { _Supplier_Type = value; }
        }

        public string Buyer_User_Id
        {
            get { return _Buyer_User_Id; }
            set { _Buyer_User_Id = value; }
        }

        public string Supplier_Fiscal_Number
        {
            get { return _Supplier_Fiscal_Number; }
            set { _Supplier_Fiscal_Number = value; }
        }

        public int Way_Of_Order
        {
            get { return _Way_Of_Order; }
            set { _Way_Of_Order = value; }
        }

        public string Language_Code
        {
            get { return _Language_Code; }
            set { _Language_Code = value; }
        }

        public string Currency_Code
        {
            get { return _Currency_Code; }
            set { _Currency_Code = value; }
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

        public int Default_Logistic_Flow
        {
            get { return _Default_Logistic_Flow; }
            set { _Default_Logistic_Flow = value; }
        }

        public string Supplier_Registration_Number
        {
            get { return _Supplier_Registration_Number; }
            set { _Supplier_Registration_Number = value; }
        }

        public DateTime AddDate
        {
            get { return _AddDate; }
            set { _AddDate = value; }
        }

        public DateTime EditDate
        {
            get { return _EditDate; }
            set { _EditDate = value; }
        }

        public string FILENAME
        {
            get { return _FILENAME; }
            set { _FILENAME = value; }
        }



        #endregion
        #region "Connection"
        public Supplier_Header_Model()
        {
        }

        public Supplier_Header_Model(int Serialkey, int Table_Indicator, string Action_Code, string Lsp_Identification, string Supplier_Code, string Supplier_Name, int Supplier_Status, int Supplier_Type, string Buyer_User_Id, string Supplier_Fiscal_Number, int Way_Of_Order, string Language_Code, string Currency_Code, string Warehouse_Number, DateTime Date_Record, int Default_Logistic_Flow, string Supplier_Registration_Number, DateTime AddDate, DateTime EditDate, string FILENAME, string STATUS)
        {
            this.Serialkey = Serialkey;
            this.Table_Indicator = Table_Indicator;
            this.Action_Code = Action_Code;
            this.Lsp_Identification = Lsp_Identification;
            this.Supplier_Code = Supplier_Code;
            this.Supplier_Name = Supplier_Name;
            this.Supplier_Status = Supplier_Status;
            this.Supplier_Type = Supplier_Type;
            this.Buyer_User_Id = Buyer_User_Id;
            this.Supplier_Fiscal_Number = Supplier_Fiscal_Number;
            this.Way_Of_Order = Way_Of_Order;
            this.Language_Code = Language_Code;
            this.Currency_Code = Currency_Code;
            this.Warehouse_Number = Warehouse_Number;
            this.Date_Record = Date_Record;
            this.Default_Logistic_Flow = Default_Logistic_Flow;
            this.Supplier_Registration_Number = Supplier_Registration_Number;
            this.AddDate = AddDate;
            this.EditDate = EditDate;
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
            new SqlParameter( "@Lsp_Identification", SqlDbType.Char, 4),
            new SqlParameter( "@Supplier_Code", SqlDbType.Char, 6),
            new SqlParameter( "@Supplier_Name", SqlDbType.Char, 35),
            new SqlParameter( "@Supplier_Status", SqlDbType.Int, 4),
            new SqlParameter( "@Supplier_Type", SqlDbType.Int, 4),
            new SqlParameter( "@Buyer_User_Id", SqlDbType.Char, 6),
            new SqlParameter( "@Supplier_Fiscal_Number", SqlDbType.Char, 15),
            new SqlParameter( "@Way_Of_Order", SqlDbType.Int, 4),
            new SqlParameter( "@Language_Code", SqlDbType.Char, 2),
            new SqlParameter( "@Currency_Code", SqlDbType.Char, 3),
            new SqlParameter( "@Warehouse_Number", SqlDbType.Char, 5),
            new SqlParameter( "@Date_Record", SqlDbType.Date, 3),
            new SqlParameter( "@Default_Logistic_Flow", SqlDbType.Int, 4),
            new SqlParameter( "@Supplier_Registration_Number", SqlDbType.Char, 15),
            new SqlParameter( "@AddDate", SqlDbType.DateTime, 8),
            new SqlParameter( "@EditDate", SqlDbType.DateTime, 8),
            new SqlParameter( "@FILENAME", SqlDbType.NVarChar, 200)
            };
                sp[0].Value = "Addnew";

                sp[1].Value = this.Serialkey;

                sp[2].Value = this.Table_Indicator;

                sp[3].Value = this.Action_Code;

                sp[4].Value = this.Lsp_Identification;

                sp[5].Value = this.Supplier_Code;

                sp[6].Value = this.Supplier_Name;

                sp[7].Value = this.Supplier_Status;

                sp[8].Value = this.Supplier_Type;

                sp[9].Value = this.Buyer_User_Id;

                sp[10].Value = this.Supplier_Fiscal_Number;

                sp[11].Value = this.Way_Of_Order;

                sp[12].Value = this.Language_Code;

                sp[13].Value = this.Currency_Code;

                sp[14].Value = this.Warehouse_Number;

                sp[15].Value = this.Date_Record;

                sp[16].Value = this.Default_Logistic_Flow;

                sp[17].Value = this.Supplier_Registration_Number;

                sp[18].Value = this.AddDate;

                sp[19].Value = this.EditDate;

                sp[20].Value = this.FILENAME;

                DAL.excutequery(PP_MM_Supplier_Header, sp, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception e)
            {
                string category = "SUPPLIER_HEADER";
                ResultDatabase_Model result = new ResultDatabase_Model();
                result.HandleError(fileName, text, e.Message.ToString(), this.Supplier_Code, category);
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
            new SqlParameter( "@Action_Code", SqlDbType.Char, 1),
            new SqlParameter( "@Lsp_Identification", SqlDbType.Char, 4),
            new SqlParameter( "@Supplier_Code", SqlDbType.Char, 6),
            new SqlParameter( "@Supplier_Name", SqlDbType.Char, 35),
            new SqlParameter( "@Supplier_Status", SqlDbType.Int, 4),
            new SqlParameter( "@Supplier_Type", SqlDbType.Int, 4),
            new SqlParameter( "@Buyer_User_Id", SqlDbType.Char, 6),
            new SqlParameter( "@Supplier_Fiscal_Number", SqlDbType.Char, 15),
            new SqlParameter( "@Way_Of_Order", SqlDbType.Int, 4),
            new SqlParameter( "@Language_Code", SqlDbType.Char, 2),
            new SqlParameter( "@Currency_Code", SqlDbType.Char, 3),
            new SqlParameter( "@Warehouse_Number", SqlDbType.Char, 5),
            new SqlParameter( "@Date_Record", SqlDbType.Date, 3),
            new SqlParameter( "@Default_Logistic_Flow", SqlDbType.Int, 4),
            new SqlParameter( "@Supplier_Registration_Number", SqlDbType.Char, 15),
            new SqlParameter( "@EditDate", SqlDbType.DateTime, 8),
            new SqlParameter( "@FILENAME", SqlDbType.NVarChar, 200),
            };
                sp[0].Value = "Update";

                sp[1].Value = this.Serialkey;

                sp[2].Value = this.Table_Indicator;

                sp[3].Value = this.Action_Code;

                sp[4].Value = this.Lsp_Identification;

                sp[5].Value = this.Supplier_Code;

                sp[6].Value = this.Supplier_Name;

                sp[7].Value = this.Supplier_Status;

                sp[8].Value = this.Supplier_Type;

                sp[9].Value = this.Buyer_User_Id;

                sp[10].Value = this.Supplier_Fiscal_Number;

                sp[11].Value = this.Way_Of_Order;

                sp[12].Value = this.Language_Code;

                sp[13].Value = this.Currency_Code;

                sp[14].Value = this.Warehouse_Number;

                sp[15].Value = this.Date_Record;

                sp[16].Value = this.Default_Logistic_Flow;

                sp[17].Value = this.Supplier_Registration_Number;

                sp[18].Value = this.EditDate;

                sp[19].Value = this.FILENAME;

                DAL.excutequery(PP_MM_Supplier_Header, sp, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception e)
            {
                string category = "SUPPLIER_HEADER";
                ResultDatabase_Model result = new ResultDatabase_Model();
                result.HandleError(fileName, text, e.Message.ToString(), this.Supplier_Code, category);
                return false;
            }
        }

        #endregion
    }
}