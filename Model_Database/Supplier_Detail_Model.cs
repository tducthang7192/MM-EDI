using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace MM_Project
{
    public class Supplier_Detail_Model
    {
        #region "Constants"
        private const string PP_MM_Supplier_Detail = "PP_MM_SUPPLIER_DETAIL";
        #endregion
        #region "Member Variables"
        private int _Serialkey;
        private int _Table_Indicator;
        private string _Action_Code;
        private string _Lsp_Identification;
        private string _Supplier_Code;
        private int _Address_Indicator;
        private string _Contact_Person;
        private string _Building;
        private string _Address;
        private string _Town;
        private string _Phone;
        private string _Fax_Number;
        private string _Postal_Code;
        private string _DC_Phone_Number;
        private string _Origin;
        private string _Supplier_Repressentative;
        private string _Warehouse_Number;
        private DateTime _Date_Record;
        private string _Email_Address;
        private DateTime _AddDate;
        private DateTime _Editdate;
        private string _BLANK1;
        private string _BLANK2;
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

        public int Address_Indicator
        {
            get { return _Address_Indicator; }
            set { _Address_Indicator = value; }
        }

        public string Contact_Person
        {
            get { return _Contact_Person; }
            set { _Contact_Person = value; }
        }

        public string Building
        {
            get { return _Building; }
            set { _Building = value; }
        }

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public string Town
        {
            get { return _Town; }
            set { _Town = value; }
        }

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        public string Fax_Number
        {
            get { return _Fax_Number; }
            set { _Fax_Number = value; }
        }

        public string Postal_Code
        {
            get { return _Postal_Code; }
            set { _Postal_Code = value; }
        }

        public string DC_Phone_Number
        {
            get { return _DC_Phone_Number; }
            set { _DC_Phone_Number = value; }
        }

        public string Origin
        {
            get { return _Origin; }
            set { _Origin = value; }
        }

        public string Supplier_Repressentative
        {
            get { return _Supplier_Repressentative; }
            set { _Supplier_Repressentative = value; }
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

        public string Email_Address
        {
            get { return _Email_Address; }
            set { _Email_Address = value; }
        }

        public DateTime AddDate
        {
            get { return _AddDate; }
            set { _AddDate = value; }
        }

        public DateTime Editdate
        {
            get { return _Editdate; }
            set { _Editdate = value; }
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

        #endregion
        #region "Connection"
        public Supplier_Detail_Model()
        {
      
        }

        public Supplier_Detail_Model(int Serialkey, int Table_Indicator, string Action_Code, string Lsp_Identification, string Supplier_Code, int Address_Indicator, string Contact_Person, string Building, string Address, string Town, string Phone, string Fax_Number, string Postal_Code, string DC_Phone_Number, string Origin, string Supplier_Repressentative, string Warehouse_Number, DateTime Date_Record, string Email_Address, DateTime AddDate, DateTime Editdate, string BLANK1, string BLANK2, string FILENAME, string STATUS)
        {
            this.Serialkey = Serialkey;
            this.Table_Indicator = Table_Indicator;
            this.Action_Code = Action_Code;
            this.Lsp_Identification = Lsp_Identification;
            this.Supplier_Code = Supplier_Code;
            this.Address_Indicator = Address_Indicator;
            this.Contact_Person = Contact_Person;
            this.Building = Building;
            this.Address = Address;
            this.Town = Town;
            this.Phone = Phone;
            this.Fax_Number = Fax_Number;
            this.Postal_Code = Postal_Code;
            this.DC_Phone_Number = DC_Phone_Number;
            this.Origin = Origin;
            this.Supplier_Repressentative = Supplier_Repressentative;
            this.Warehouse_Number = Warehouse_Number;
            this.Date_Record = Date_Record;
            this.Email_Address = Email_Address;
            this.AddDate = AddDate;
            this.Editdate = Editdate;
            this.BLANK1 = BLANK1;
            this.BLANK2 = BLANK2;
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
            new SqlParameter( "@Supplier_Code", SqlDbType.Char, 6),
            new SqlParameter( "@Address_Indicator", SqlDbType.Int, 4),
            new SqlParameter( "@Contact_Person", SqlDbType.Char, 35),
            new SqlParameter( "@Building", SqlDbType.Char, 28),
            new SqlParameter( "@Address", SqlDbType.Char, 28),
            new SqlParameter( "@Town", SqlDbType.Char, 25),
            new SqlParameter( "@Phone", SqlDbType.Char, 15),
            new SqlParameter( "@Fax_Number", SqlDbType.Char, 18),
            new SqlParameter( "@Postal_Code", SqlDbType.Char, 11),
            new SqlParameter( "@DC_Phone_Number", SqlDbType.Char, 15),
            new SqlParameter( "@Origin", SqlDbType.Char, 4),
            new SqlParameter( "@Supplier_Repressentative", SqlDbType.Char, 35),
            new SqlParameter( "@Warehouse_Number", SqlDbType.Char, 5),
            new SqlParameter( "@Date_Record", SqlDbType.Date, 3),
            new SqlParameter( "@Email_Address", SqlDbType.Char, 100),
            new SqlParameter( "@AddDate", SqlDbType.DateTime, 8),
            new SqlParameter( "@Editdate", SqlDbType.DateTime, 8),
            new SqlParameter( "@BLANK1", SqlDbType.Char, 7),
            new SqlParameter( "@BLANK2", SqlDbType.Char, 11),
            new SqlParameter( "@FILENAME", SqlDbType.NVarChar, 200)
            };
                sp[0].Value = "Addnew";

                sp[1].Value = this.Serialkey;

                sp[2].Value = this.Table_Indicator;

                sp[3].Value = this.Action_Code;

                sp[4].Value = this.Lsp_Identification;

                sp[5].Value = this.Supplier_Code;

                sp[6].Value = this.Address_Indicator;

                sp[7].Value = this.Contact_Person;

                sp[8].Value = this.Building;

                sp[9].Value = this.Address;

                sp[10].Value = this.Town;

                sp[11].Value = this.Phone;

                sp[12].Value = this.Fax_Number;

                sp[13].Value = this.Postal_Code;

                sp[14].Value = this.DC_Phone_Number;

                sp[15].Value = this.Origin;

                sp[16].Value = this.Supplier_Repressentative;

                sp[17].Value = this.Warehouse_Number;

                sp[18].Value = this.Date_Record;

                sp[19].Value = this.Email_Address;

                sp[20].Value = this.AddDate;

                sp[21].Value = this.Editdate;

                sp[22].Value = this.BLANK1;

                sp[23].Value = this.BLANK2;

                sp[24].Value = this.FILENAME;


                DAL.excutequery(PP_MM_Supplier_Detail, sp, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception e)
            {
                string category = "SUPPLIER_DETAIL";
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
            new SqlParameter( "@Lsp_Identification", SqlDbType.Char, 1),
            new SqlParameter( "@Supplier_Code", SqlDbType.Char, 6),
            new SqlParameter( "@Address_Indicator", SqlDbType.Int, 4),
            new SqlParameter( "@Contact_Person", SqlDbType.Char, 35),
            new SqlParameter( "@Building", SqlDbType.Char, 28),
            new SqlParameter( "@Address", SqlDbType.Char, 28),
            new SqlParameter( "@Town", SqlDbType.Char, 25),
            new SqlParameter( "@Phone", SqlDbType.Char, 15),
            new SqlParameter( "@Fax_Number", SqlDbType.Char, 18),
            new SqlParameter( "@Postal_Code", SqlDbType.Char, 11),
            new SqlParameter( "@DC_Phone_Number", SqlDbType.Char, 15),
            new SqlParameter( "@Origin", SqlDbType.Char, 4),
            new SqlParameter( "@Supplier_Repressentative", SqlDbType.Char, 35),
            new SqlParameter( "@Warehouse_Number", SqlDbType.Char, 5),
            new SqlParameter( "@Date_Record", SqlDbType.Date, 3),
            new SqlParameter( "@Email_Address", SqlDbType.Char, 100),
            new SqlParameter( "@Editdate", SqlDbType.DateTime, 8),
            new SqlParameter( "@BLANK1", SqlDbType.Char, 7),
            new SqlParameter( "@BLANK2", SqlDbType.Char, 11),
            new SqlParameter( "@FILENAME", SqlDbType.NVarChar, 200),
            };
                sp[0].Value = "Update";

                sp[1].Value = this.Serialkey;

                sp[2].Value = this.Table_Indicator;

                sp[3].Value = this.Action_Code;

                sp[4].Value = this.Lsp_Identification;

                sp[5].Value = this.Supplier_Code;

                sp[6].Value = this.Address_Indicator;

                sp[7].Value = this.Contact_Person;

                sp[8].Value = this.Building;

                sp[9].Value = this.Address;

                sp[10].Value = this.Town;

                sp[11].Value = this.Phone;

                sp[12].Value = this.Fax_Number;

                sp[13].Value = this.Postal_Code;

                sp[14].Value = this.DC_Phone_Number;

                sp[15].Value = this.Origin;

                sp[16].Value = this.Supplier_Repressentative;

                sp[17].Value = this.Warehouse_Number;

                sp[18].Value = this.Date_Record;

                sp[19].Value = this.Email_Address;

                sp[20].Value = this.Editdate;

                sp[21].Value = this.BLANK1;

                sp[22].Value = this.BLANK2;

                sp[23].Value = this.FILENAME;



                DAL.excutequery(PP_MM_Supplier_Detail, sp, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception e)
            {
                string category = "SUPPLIER_DETAIL";
                ResultDatabase_Model result = new ResultDatabase_Model();
                result.HandleError(fileName, text, e.Message.ToString(), this.Supplier_Code, category);
                return false;
            }
        }

        #endregion
    }
}
