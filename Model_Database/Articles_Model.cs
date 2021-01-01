using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace MM_Project
{
    public class Articles_Model
    {
        #region "Constants"
        private const string PP_MM_Articles = "PP_MM_Articles";
        #endregion
        #region "Member Variables"
        private int _Serialkey;
        private int _Table_Indicator;
        private string _Action_Code;
        private string _Lsp_Identification;
        private string _Article_Number;
        private string _Supplier_Code;
        private decimal _Buying_Unit;
        private int _Selling_Unit;
        private string _Ordering_Unit;
        private int _Article_Type;
        private int _Article_Status;
        private string _Buyer_User_Id;
        private string _Desc_Article;
        private string _Packing_type_Article;
        private int _Article_Related;
        private string _EAN_Code;
        private string _Supplier_Article_Number;
        private string _Article_Desc;
        private int _Number_Mu_Carton;
        private int _Number_Mu_Layer;
        private int _Number_Mu_Pallet;
        private decimal _Carton_Length;
        private decimal _Carton_GrossWeight;
        private decimal _Carton_NetWeight;
        private string _Warehouse_Number;
        private DateTime _Date_Record;
        private int _Logistic_Deposit_Type;
        private int _Logistic_Flow_Indicator;
        private int _Ordering_Indicator;
        private int _Link_Logistic_Deposit;
        private int _Expiry_Days;
        private int _Expiry_Days_Checking_Indicator;
        private int _Minimum_Expiry_Days;
        private int _Pallet_Indicator;
        private int _Number_Layer_Pallet;
        private int _Number_Units_Inbox;
        private decimal _Gross_Volume;
        private string _Measure_Unit_GrossVolume;
        private string _Packing_Type;
        private decimal _Carton_Width;
        private decimal _Carton_Height;
        private string _UOM_Carton_Size;
        private string _UOM_Carton_Weight;
        private decimal _Carton_Gross_Volume;
        private string _UOM_Carton_Volume;
        private int _Selling_Unit_Length;
        private int _Selling_Unit_Width;
        private int _Selling_Unit_Height;
        private string _UOM_Selling_Size;
        private decimal _Grossweight_Selling;
        private decimal _Netweight_Selling;
        private string _UOM_Selling_Weight;
        private int _Article_Group_Number;
        private int _Artice_Subgroup_Number;
        private int _Excise_Tax_Indicator;
        private decimal _Excise_Tax_Amount;
        private int _High_Value_Indicator;
        private string _Storage_Temperature_Desc;
        private string _Remark;
        private DateTime _EditDate;
        private DateTime _AddDate;
        private string _BLANK1;
        private string _BLANK2;
        private string _BLANK3;
        private string _BLANK4;
        private string _BLANK5;
        private string _BLANK6;
        private string _BLANK7;
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

        public string Supplier_Code
        {
            get { return _Supplier_Code; }
            set { _Supplier_Code = value; }
        }

        public decimal Buying_Unit
        {
            get { return _Buying_Unit; }
            set { _Buying_Unit = value; }
        }

        public int Selling_Unit
        {
            get { return _Selling_Unit; }
            set { _Selling_Unit = value; }
        }

        public string Ordering_Unit
        {
            get { return _Ordering_Unit; }
            set { _Ordering_Unit = value; }
        }

        public int Article_Type
        {
            get { return _Article_Type; }
            set { _Article_Type = value; }
        }

        public int Article_Status
        {
            get { return _Article_Status; }
            set { _Article_Status = value; }
        }

        public string Buyer_User_Id
        {
            get { return _Buyer_User_Id; }
            set { _Buyer_User_Id = value; }
        }

        public string Desc_Article
        {
            get { return _Desc_Article; }
            set { _Desc_Article = value; }
        }

        public string Packing_type_Article
        {
            get { return _Packing_type_Article; }
            set { _Packing_type_Article = value; }
        }

        public int Article_Related
        {
            get { return _Article_Related; }
            set { _Article_Related = value; }
        }

        public string EAN_Code
        {
            get { return _EAN_Code; }
            set { _EAN_Code = value; }
        }

        public string Supplier_Article_Number
        {
            get { return _Supplier_Article_Number; }
            set { _Supplier_Article_Number = value; }
        }

        public string Article_Desc
        {
            get { return _Article_Desc; }
            set { _Article_Desc = value; }
        }

        public int Number_Mu_Carton
        {
            get { return _Number_Mu_Carton; }
            set { _Number_Mu_Carton = value; }
        }

        public int Number_Mu_Layer
        {
            get { return _Number_Mu_Layer; }
            set { _Number_Mu_Layer = value; }
        }

        public int Number_Mu_Pallet
        {
            get { return _Number_Mu_Pallet; }
            set { _Number_Mu_Pallet = value; }
        }

        public decimal Carton_Length
        {
            get { return _Carton_Length; }
            set { _Carton_Length = value; }
        }

        public decimal Carton_GrossWeight
        {
            get { return _Carton_GrossWeight; }
            set { _Carton_GrossWeight = value; }
        }

        public decimal Carton_NetWeight
        {
            get { return _Carton_NetWeight; }
            set { _Carton_NetWeight = value; }
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

        public int Logistic_Deposit_Type
        {
            get { return _Logistic_Deposit_Type; }
            set { _Logistic_Deposit_Type = value; }
        }

        public int Logistic_Flow_Indicator
        {
            get { return _Logistic_Flow_Indicator; }
            set { _Logistic_Flow_Indicator = value; }
        }

        public int Ordering_Indicator
        {
            get { return _Ordering_Indicator; }
            set { _Ordering_Indicator = value; }
        }

        public int Link_Logistic_Deposit
        {
            get { return _Link_Logistic_Deposit; }
            set { _Link_Logistic_Deposit = value; }
        }

        public int Expiry_Days
        {
            get { return _Expiry_Days; }
            set { _Expiry_Days = value; }
        }

        public int Expiry_Days_Checking_Indicator
        {
            get { return _Expiry_Days_Checking_Indicator; }
            set { _Expiry_Days_Checking_Indicator = value; }
        }

        public int Minimum_Expiry_Days
        {
            get { return _Minimum_Expiry_Days; }
            set { _Minimum_Expiry_Days = value; }
        }

        public int Pallet_Indicator
        {
            get { return _Pallet_Indicator; }
            set { _Pallet_Indicator = value; }
        }

        public int Number_Layer_Pallet
        {
            get { return _Number_Layer_Pallet; }
            set { _Number_Layer_Pallet = value; }
        }

        public int Number_Units_Inbox
        {
            get { return _Number_Units_Inbox; }
            set { _Number_Units_Inbox = value; }
        }

        public decimal Gross_Volume
        {
            get { return _Gross_Volume; }
            set { _Gross_Volume = value; }
        }

        public string Measure_Unit_GrossVolume
        {
            get { return _Measure_Unit_GrossVolume; }
            set { _Measure_Unit_GrossVolume = value; }
        }

        public string Packing_Type
        {
            get { return _Packing_Type; }
            set { _Packing_Type = value; }
        }

        public decimal Carton_Width
        {
            get { return _Carton_Width; }
            set { _Carton_Width = value; }
        }

        public decimal Carton_Height
        {
            get { return _Carton_Height; }
            set { _Carton_Height = value; }
        }

        public string UOM_Carton_Size
        {
            get { return _UOM_Carton_Size; }
            set { _UOM_Carton_Size = value; }
        }

        public string UOM_Carton_Weight
        {
            get { return _UOM_Carton_Weight; }
            set { _UOM_Carton_Weight = value; }
        }

        public decimal Carton_Gross_Volume
        {
            get { return _Carton_Gross_Volume; }
            set { _Carton_Gross_Volume = value; }
        }

        public string UOM_Carton_Volume
        {
            get { return _UOM_Carton_Volume; }
            set { _UOM_Carton_Volume = value; }
        }

        public int Selling_Unit_Length
        {
            get { return _Selling_Unit_Length; }
            set { _Selling_Unit_Length = value; }
        }

        public int Selling_Unit_Width
        {
            get { return _Selling_Unit_Width; }
            set { _Selling_Unit_Width = value; }
        }

        public int Selling_Unit_Height
        {
            get { return _Selling_Unit_Height; }
            set { _Selling_Unit_Height = value; }
        }

        public string UOM_Selling_Size
        {
            get { return _UOM_Selling_Size; }
            set { _UOM_Selling_Size = value; }
        }

        public decimal Grossweight_Selling
        {
            get { return _Grossweight_Selling; }
            set { _Grossweight_Selling = value; }
        }

        public decimal Netweight_Selling
        {
            get { return _Netweight_Selling; }
            set { _Netweight_Selling = value; }
        }

        public string UOM_Selling_Weight
        {
            get { return _UOM_Selling_Weight; }
            set { _UOM_Selling_Weight = value; }
        }

        public int Article_Group_Number
        {
            get { return _Article_Group_Number; }
            set { _Article_Group_Number = value; }
        }

        public int Artice_Subgroup_Number
        {
            get { return _Artice_Subgroup_Number; }
            set { _Artice_Subgroup_Number = value; }
        }

        public int Excise_Tax_Indicator
        {
            get { return _Excise_Tax_Indicator; }
            set { _Excise_Tax_Indicator = value; }
        }

        public decimal Excise_Tax_Amount
        {
            get { return _Excise_Tax_Amount; }
            set { _Excise_Tax_Amount = value; }
        }

        public int High_Value_Indicator
        {
            get { return _High_Value_Indicator; }
            set { _High_Value_Indicator = value; }
        }

        public string Storage_Temperature_Desc
        {
            get { return _Storage_Temperature_Desc; }
            set { _Storage_Temperature_Desc = value; }
        }

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        public DateTime EditDate
        {
            get { return _EditDate; }
            set { _EditDate = value; }
        }

        public DateTime AddDate
        {
            get { return _AddDate; }
            set { _AddDate = value; }
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

        public string BLANK3
        {
            get { return _BLANK3; }
            set { _BLANK3 = value; }
        }

        public string BLANK4
        {
            get { return _BLANK4; }
            set { _BLANK4 = value; }
        }

        public string BLANK5
        {
            get { return _BLANK5; }
            set { _BLANK5 = value; }
        }

        public string BLANK6
        {
            get { return _BLANK6; }
            set { _BLANK6 = value; }
        }

        public string BLANK7
        {
            get { return _BLANK7; }
            set { _BLANK7 = value; }
        }

        public string FILENAME
        {
            get { return _FILENAME; }
            set { _FILENAME = value; }
        }


        #endregion
        #region "Connection"
        public Articles_Model()
        {
        }

        public Articles_Model(int Serialkey, int Table_Indicator, string Action_Code, string Lsp_Identification, string Article_Number, string Supplier_Code, decimal Buying_Unit, int Selling_Unit, string Ordering_Unit, int Article_Type, int Article_Status, string Buyer_User_Id, string Desc_Article, string Packing_type_Article, int Article_Related, string EAN_Code, string Supplier_Article_Number, string Article_Desc, int Number_Mu_Carton, int Number_Mu_Layer, int Number_Mu_Pallet, decimal Carton_Length, decimal Carton_GrossWeight, decimal Carton_NetWeight, string Warehouse_Number, DateTime Date_Record, int Logistic_Deposit_Type, int Logistic_Flow_Indicator, int Ordering_Indicator, int Link_Logistic_Deposit, int Expiry_Days, int Expiry_Days_Checking_Indicator, int Minimum_Expiry_Days, int Pallet_Indicator, int Number_Layer_Pallet, int Number_Units_Inbox, decimal Gross_Volume, string Measure_Unit_GrossVolume, string Packing_Type, decimal Carton_Width, decimal Carton_Height, string UOM_Carton_Size, string UOM_Carton_Weight, decimal Carton_Gross_Volume, string UOM_Carton_Volume, int Selling_Unit_Length, int Selling_Unit_Width, int Selling_Unit_Height, string UOM_Selling_Size, decimal Grossweight_Selling, decimal Netweight_Selling, string UOM_Selling_Weight, int Article_Group_Number, int Artice_Subgroup_Number, int Excise_Tax_Indicator, decimal Excise_Tax_Amount, int High_Value_Indicator, string Storage_Temperature_Desc, string Remark, DateTime EditDate, DateTime AddDate, string BLANK1, string BLANK2, string BLANK3, string BLANK4, string BLANK5, string BLANK6, string BLANK7, string FILENAME, string STATUS)
        {
            this.Serialkey = Serialkey;
            this.Table_Indicator = Table_Indicator;
            this.Action_Code = Action_Code;
            this.Lsp_Identification = Lsp_Identification;
            this.Article_Number = Article_Number;
            this.Supplier_Code = Supplier_Code;
            this.Buying_Unit = Buying_Unit;
            this.Selling_Unit = Selling_Unit;
            this.Ordering_Unit = Ordering_Unit;
            this.Article_Type = Article_Type;
            this.Article_Status = Article_Status;
            this.Buyer_User_Id = Buyer_User_Id;
            this.Desc_Article = Desc_Article;
            this.Packing_type_Article = Packing_type_Article;
            this.Article_Related = Article_Related;
            this.EAN_Code = EAN_Code;
            this.Supplier_Article_Number = Supplier_Article_Number;
            this.Article_Desc = Article_Desc;
            this.Number_Mu_Carton = Number_Mu_Carton;
            this.Number_Mu_Layer = Number_Mu_Layer;
            this.Number_Mu_Pallet = Number_Mu_Pallet;
            this.Carton_Length = Carton_Length;
            this.Carton_GrossWeight = Carton_GrossWeight;
            this.Carton_NetWeight = Carton_NetWeight;
            this.Warehouse_Number = Warehouse_Number;
            this.Date_Record = Date_Record;
            this.Logistic_Deposit_Type = Logistic_Deposit_Type;
            this.Logistic_Flow_Indicator = Logistic_Flow_Indicator;
            this.Ordering_Indicator = Ordering_Indicator;
            this.Link_Logistic_Deposit = Link_Logistic_Deposit;
            this.Expiry_Days = Expiry_Days;
            this.Expiry_Days_Checking_Indicator = Expiry_Days_Checking_Indicator;
            this.Minimum_Expiry_Days = Minimum_Expiry_Days;
            this.Pallet_Indicator = Pallet_Indicator;
            this.Number_Layer_Pallet = Number_Layer_Pallet;
            this.Number_Units_Inbox = Number_Units_Inbox;
            this.Gross_Volume = Gross_Volume;
            this.Measure_Unit_GrossVolume = Measure_Unit_GrossVolume;
            this.Packing_Type = Packing_Type;
            this.Carton_Width = Carton_Width;
            this.Carton_Height = Carton_Height;
            this.UOM_Carton_Size = UOM_Carton_Size;
            this.UOM_Carton_Weight = UOM_Carton_Weight;
            this.Carton_Gross_Volume = Carton_Gross_Volume;
            this.UOM_Carton_Volume = UOM_Carton_Volume;
            this.Selling_Unit_Length = Selling_Unit_Length;
            this.Selling_Unit_Width = Selling_Unit_Width;
            this.Selling_Unit_Height = Selling_Unit_Height;
            this.UOM_Selling_Size = UOM_Selling_Size;
            this.Grossweight_Selling = Grossweight_Selling;
            this.Netweight_Selling = Netweight_Selling;
            this.UOM_Selling_Weight = UOM_Selling_Weight;
            this.Article_Group_Number = Article_Group_Number;
            this.Artice_Subgroup_Number = Artice_Subgroup_Number;
            this.Excise_Tax_Indicator = Excise_Tax_Indicator;
            this.Excise_Tax_Amount = Excise_Tax_Amount;
            this.High_Value_Indicator = High_Value_Indicator;
            this.Storage_Temperature_Desc = Storage_Temperature_Desc;
            this.Remark = Remark;
            this.EditDate = EditDate;
            this.AddDate = AddDate;
            this.BLANK1 = BLANK1;
            this.BLANK2 = BLANK2;
            this.BLANK3 = BLANK3;
            this.BLANK4 = BLANK4;
            this.BLANK5 = BLANK5;
            this.BLANK6 = BLANK6;
            this.BLANK7 = BLANK7;
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
            new SqlParameter( "@Action_Code", SqlDbType.Char, 4),
            new SqlParameter( "@Lsp_Identification", SqlDbType.Char, 1),
            new SqlParameter( "@Article_Number", SqlDbType.Char, 8),
            new SqlParameter( "@Supplier_Code", SqlDbType.Char, 6),
            new SqlParameter( "@Buying_Unit", SqlDbType.Decimal, 13),
            new SqlParameter( "@Selling_Unit", SqlDbType.Int, 4),
            new SqlParameter( "@Ordering_Unit", SqlDbType.Char, 3),
            new SqlParameter( "@Article_Type", SqlDbType.Int, 4),
            new SqlParameter( "@Article_Status", SqlDbType.Int, 4),
            new SqlParameter( "@Buyer_User_Id", SqlDbType.Char, 6),
            new SqlParameter( "@Desc_Article", SqlDbType.Char, 33),
            new SqlParameter( "@Packing_type_Article", SqlDbType.Char, 2),
            new SqlParameter( "@Article_Related", SqlDbType.Int, 4),
            new SqlParameter( "@EAN_Code", SqlDbType.Char, 14),
            new SqlParameter( "@Supplier_Article_Number", SqlDbType.Char, 8),
            new SqlParameter( "@Article_Desc", SqlDbType.Char, 33),
            new SqlParameter( "@Number_Mu_Carton", SqlDbType.Int, 4),
            new SqlParameter( "@Number_Mu_Layer", SqlDbType.Int, 4),
            new SqlParameter( "@Number_Mu_Pallet", SqlDbType.Int, 4),
            new SqlParameter( "@Carton_Length", SqlDbType.Decimal, 13),
            new SqlParameter( "@Carton_GrossWeight", SqlDbType.Decimal, 13),
            new SqlParameter( "@Carton_NetWeight", SqlDbType.Decimal, 13),
            new SqlParameter( "@Warehouse_Number", SqlDbType.Char, 5),
            new SqlParameter( "@Date_Record", SqlDbType.Date, 3),
            new SqlParameter( "@Logistic_Deposit_Type", SqlDbType.Int, 4),
            new SqlParameter( "@Logistic_Flow_Indicator", SqlDbType.Int, 4),
            new SqlParameter( "@Ordering_Indicator", SqlDbType.Int, 4),
            new SqlParameter( "@Link_Logistic_Deposit", SqlDbType.Int, 4),
            new SqlParameter( "@Expiry_Days", SqlDbType.Int, 4),
            new SqlParameter( "@Expiry_Days_Checking_Indicator", SqlDbType.Int, 4),
            new SqlParameter( "@Minimum_Expiry_Days", SqlDbType.Int, 4),
            new SqlParameter( "@Pallet_Indicator", SqlDbType.Int, 4),
            new SqlParameter( "@Number_Layer_Pallet", SqlDbType.Int, 4),
            new SqlParameter( "@Number_Units_Inbox", SqlDbType.Int, 4),
            new SqlParameter( "@Gross_Volume", SqlDbType.Decimal, 13),
            new SqlParameter( "@Measure_Unit_GrossVolume", SqlDbType.Char, 3),
            new SqlParameter( "@Packing_Type", SqlDbType.Char, 2),
            new SqlParameter( "@Carton_Width", SqlDbType.Decimal, 13),
            new SqlParameter( "@Carton_Height", SqlDbType.Decimal, 13),
            new SqlParameter( "@UOM_Carton_Size", SqlDbType.Char, 3),
            new SqlParameter( "@UOM_Carton_Weight", SqlDbType.Char, 3),
            new SqlParameter( "@Carton_Gross_Volume", SqlDbType.Decimal, 13),
            new SqlParameter( "@UOM_Carton_Volume", SqlDbType.Char, 3),
            new SqlParameter( "@Selling_Unit_Length", SqlDbType.Int, 4),
            new SqlParameter( "@Selling_Unit_Width", SqlDbType.Int, 4),
            new SqlParameter( "@Selling_Unit_Height", SqlDbType.Int, 4),
            new SqlParameter( "@UOM_Selling_Size", SqlDbType.Char, 3),
            new SqlParameter( "@Grossweight_Selling", SqlDbType.Decimal, 13),
            new SqlParameter( "@Netweight_Selling", SqlDbType.Decimal, 13),
            new SqlParameter( "@UOM_Selling_Weight", SqlDbType.Char, 3),
            new SqlParameter( "@Article_Group_Number", SqlDbType.Int, 4),
            new SqlParameter( "@Artice_Subgroup_Number", SqlDbType.Int, 4),
            new SqlParameter( "@Excise_Tax_Indicator", SqlDbType.Int, 4),
            new SqlParameter( "@Excise_Tax_Amount", SqlDbType.Decimal, 13),
            new SqlParameter( "@High_Value_Indicator", SqlDbType.Int, 4),
            new SqlParameter( "@Storage_Temperature_Desc", SqlDbType.Char, 25),
            new SqlParameter( "@Remark", SqlDbType.NVarChar, 466),
            new SqlParameter( "@EditDate", SqlDbType.DateTime, 8),
            new SqlParameter( "@AddDate", SqlDbType.DateTime, 8),
            new SqlParameter( "@BLANK1", SqlDbType.Char, 4),
            new SqlParameter( "@BLANK2", SqlDbType.Char, 4),
            new SqlParameter( "@BLANK3", SqlDbType.Char, 4),
            new SqlParameter( "@BLANK4", SqlDbType.Char, 1),
            new SqlParameter( "@BLANK5", SqlDbType.Char, 1),
            new SqlParameter( "@BLANK6", SqlDbType.Char, 8),
            new SqlParameter( "@BLANK7", SqlDbType.Char, 8),
            new SqlParameter( "@FILENAME", SqlDbType.NVarChar, 200),
            };
                sp[0].Value = "Addnew";

                sp[1].Value = this.Serialkey;

                sp[2].Value = this.Table_Indicator;

                sp[3].Value = this.Action_Code;

                sp[4].Value = this.Lsp_Identification;

                sp[5].Value = this.Article_Number;

                sp[6].Value = this.Supplier_Code;

                sp[7].Value = this.Buying_Unit;

                sp[8].Value = this.Selling_Unit;

                sp[9].Value = this.Ordering_Unit;

                sp[10].Value = this.Article_Type;

                sp[11].Value = this.Article_Status;

                sp[12].Value = this.Buyer_User_Id;

                sp[13].Value = this.Desc_Article;

                sp[14].Value = this.Packing_type_Article;

                sp[15].Value = this.Article_Related;

                sp[16].Value = this.EAN_Code;

                sp[17].Value = this.Supplier_Article_Number;

                sp[18].Value = this.Article_Desc;

                sp[19].Value = this.Number_Mu_Carton;

                sp[20].Value = this.Number_Mu_Layer;

                sp[21].Value = this.Number_Mu_Pallet;

                sp[22].Value = this.Carton_Length;

                sp[23].Value = this.Carton_GrossWeight;

                sp[24].Value = this.Carton_NetWeight;

                sp[25].Value = this.Warehouse_Number;

                sp[26].Value = this.Date_Record;

                sp[27].Value = this.Logistic_Deposit_Type;

                sp[28].Value = this.Logistic_Flow_Indicator;

                sp[29].Value = this.Ordering_Indicator;

                sp[30].Value = this.Link_Logistic_Deposit;

                sp[31].Value = this.Expiry_Days;

                sp[32].Value = this.Expiry_Days_Checking_Indicator;

                sp[33].Value = this.Minimum_Expiry_Days;

                sp[34].Value = this.Pallet_Indicator;

                sp[35].Value = this.Number_Layer_Pallet;

                sp[36].Value = this.Number_Units_Inbox;

                sp[37].Value = this.Gross_Volume;

                sp[38].Value = this.Measure_Unit_GrossVolume;

                sp[39].Value = this.Packing_Type;

                sp[40].Value = this.Carton_Width;

                sp[41].Value = this.Carton_Height;

                sp[42].Value = this.UOM_Carton_Size;

                sp[43].Value = this.UOM_Carton_Weight;

                sp[44].Value = this.Carton_Gross_Volume;

                sp[45].Value = this.UOM_Carton_Volume;

                sp[46].Value = this.Selling_Unit_Length;

                sp[47].Value = this.Selling_Unit_Width;

                sp[48].Value = this.Selling_Unit_Height;

                sp[49].Value = this.UOM_Selling_Size;

                sp[50].Value = this.Grossweight_Selling;

                sp[51].Value = this.Netweight_Selling;

                sp[52].Value = this.UOM_Selling_Weight;

                sp[53].Value = this.Article_Group_Number;

                sp[54].Value = this.Artice_Subgroup_Number;

                sp[55].Value = this.Excise_Tax_Indicator;

                sp[56].Value = this.Excise_Tax_Amount;

                sp[57].Value = this.High_Value_Indicator;

                sp[58].Value = this.Storage_Temperature_Desc;

                sp[59].Value = this.Remark;

                sp[60].Value = this.EditDate;

                sp[61].Value = this.AddDate;

                sp[62].Value = this.BLANK1;

                sp[63].Value = this.BLANK2;

                sp[64].Value = this.BLANK3;

                sp[65].Value = this.BLANK4;

                sp[66].Value = this.BLANK5;

                sp[67].Value = this.BLANK6;

                sp[68].Value = this.BLANK7;

                sp[69].Value = this.FILENAME;


                DAL.excutequery(PP_MM_Articles, sp, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception e)
            {
                string category = "Article";
                ResultDatabase_Model result = new ResultDatabase_Model();
                result.HandleError(fileName, text, e.Message.ToString(), this.Article_Number, category);
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
            new SqlParameter( "@Action_Code", SqlDbType.Char, 4),
            new SqlParameter( "@Lsp_Identification", SqlDbType.Char, 1),
            new SqlParameter( "@Article_Number", SqlDbType.Char, 8),
            new SqlParameter( "@Supplier_Code", SqlDbType.Char, 6),
            new SqlParameter( "@Buying_Unit", SqlDbType.Decimal, 13),
            new SqlParameter( "@Selling_Unit", SqlDbType.Int, 4),
            new SqlParameter( "@Ordering_Unit", SqlDbType.Char, 3),
            new SqlParameter( "@Article_Type", SqlDbType.Int, 4),
            new SqlParameter( "@Article_Status", SqlDbType.Int, 4),
            new SqlParameter( "@Buyer_User_Id", SqlDbType.Char, 6),
            new SqlParameter( "@Desc_Article", SqlDbType.Char, 33),
            new SqlParameter( "@Packing_type_Article", SqlDbType.Char, 2),
            new SqlParameter( "@Article_Related", SqlDbType.Int, 4),
            new SqlParameter( "@EAN_Code", SqlDbType.Char, 14),
            new SqlParameter( "@Supplier_Article_Number", SqlDbType.Char, 8),
            new SqlParameter( "@Article_Desc", SqlDbType.Char, 33),
            new SqlParameter( "@Number_Mu_Carton", SqlDbType.Int, 4),
            new SqlParameter( "@Number_Mu_Layer", SqlDbType.Int, 4),
            new SqlParameter( "@Number_Mu_Pallet", SqlDbType.Int, 4),
            new SqlParameter( "@Carton_Length", SqlDbType.Decimal, 13),
            new SqlParameter( "@Carton_GrossWeight", SqlDbType.Decimal, 13),
            new SqlParameter( "@Carton_NetWeight", SqlDbType.Decimal, 13),
            new SqlParameter( "@Warehouse_Number", SqlDbType.Char, 5),
            new SqlParameter( "@Date_Record", SqlDbType.Date, 3),
            new SqlParameter( "@Logistic_Deposit_Type", SqlDbType.Int, 4),
            new SqlParameter( "@Logistic_Flow_Indicator", SqlDbType.Int, 4),
            new SqlParameter( "@Ordering_Indicator", SqlDbType.Int, 4),
            new SqlParameter( "@Link_Logistic_Deposit", SqlDbType.Int, 4),
            new SqlParameter( "@Expiry_Days", SqlDbType.Int, 4),
            new SqlParameter( "@Expiry_Days_Checking_Indicator", SqlDbType.Int, 4),
            new SqlParameter( "@Minimum_Expiry_Days", SqlDbType.Int, 4),
            new SqlParameter( "@Pallet_Indicator", SqlDbType.Int, 4),
            new SqlParameter( "@Number_Layer_Pallet", SqlDbType.Int, 4),
            new SqlParameter( "@Number_Units_Inbox", SqlDbType.Int, 4),
            new SqlParameter( "@Gross_Volume", SqlDbType.Decimal, 13),
            new SqlParameter( "@Measure_Unit_GrossVolume", SqlDbType.Char, 3),
            new SqlParameter( "@Packing_Type", SqlDbType.Char, 2),
            new SqlParameter( "@Carton_Width", SqlDbType.Decimal, 13),
            new SqlParameter( "@Carton_Height", SqlDbType.Decimal, 13),
            new SqlParameter( "@UOM_Carton_Size", SqlDbType.Char, 3),
            new SqlParameter( "@UOM_Carton_Weight", SqlDbType.Char, 3),
            new SqlParameter( "@Carton_Gross_Volume", SqlDbType.Decimal, 13),
            new SqlParameter( "@UOM_Carton_Volume", SqlDbType.Char, 3),
            new SqlParameter( "@Selling_Unit_Length", SqlDbType.Int, 4),
            new SqlParameter( "@Selling_Unit_Width", SqlDbType.Int, 4),
            new SqlParameter( "@Selling_Unit_Height", SqlDbType.Int, 4),
            new SqlParameter( "@UOM_Selling_Size", SqlDbType.Char, 3),
            new SqlParameter( "@Grossweight_Selling", SqlDbType.Decimal, 13),
            new SqlParameter( "@Netweight_Selling", SqlDbType.Decimal, 13),
            new SqlParameter( "@UOM_Selling_Weight", SqlDbType.Char, 3),
            new SqlParameter( "@Article_Group_Number", SqlDbType.Int, 4),
            new SqlParameter( "@Artice_Subgroup_Number", SqlDbType.Int, 4),
            new SqlParameter( "@Excise_Tax_Indicator", SqlDbType.Int, 4),
            new SqlParameter( "@Excise_Tax_Amount", SqlDbType.Decimal, 13),
            new SqlParameter( "@High_Value_Indicator", SqlDbType.Int, 4),
            new SqlParameter( "@Storage_Temperature_Desc", SqlDbType.Char, 25),
            new SqlParameter( "@Remark", SqlDbType.NVarChar, 466),
            new SqlParameter( "@EditDate", SqlDbType.DateTime, 8),
            new SqlParameter( "@BLANK1", SqlDbType.Char, 4),
            new SqlParameter( "@BLANK2", SqlDbType.Char, 4),
            new SqlParameter( "@BLANK3", SqlDbType.Char, 4),
            new SqlParameter( "@BLANK4", SqlDbType.Char, 1),
            new SqlParameter( "@BLANK5", SqlDbType.Char, 1),
            new SqlParameter( "@BLANK6", SqlDbType.Char, 8),
            new SqlParameter( "@BLANK7", SqlDbType.Char, 8),
            new SqlParameter( "@FILENAME", SqlDbType.NVarChar, 200)
            };
                sp[0].Value = "Update";

                sp[1].Value = this.Serialkey;

                sp[2].Value = this.Table_Indicator;

                sp[3].Value = this.Action_Code;

                sp[4].Value = this.Lsp_Identification;

                sp[5].Value = this.Article_Number;

                sp[6].Value = this.Supplier_Code;

                sp[7].Value = this.Buying_Unit;

                sp[8].Value = this.Selling_Unit;

                sp[9].Value = this.Ordering_Unit;

                sp[10].Value = this.Article_Type;

                sp[11].Value = this.Article_Status;

                sp[12].Value = this.Buyer_User_Id;

                sp[13].Value = this.Desc_Article;

                sp[14].Value = this.Packing_type_Article;

                sp[15].Value = this.Article_Related;

                sp[16].Value = this.EAN_Code;

                sp[17].Value = this.Supplier_Article_Number;

                sp[18].Value = this.Article_Desc;

                sp[19].Value = this.Number_Mu_Carton;

                sp[20].Value = this.Number_Mu_Layer;

                sp[21].Value = this.Number_Mu_Pallet;

                sp[22].Value = this.Carton_Length;

                sp[23].Value = this.Carton_GrossWeight;

                sp[24].Value = this.Carton_NetWeight;

                sp[25].Value = this.Warehouse_Number;

                sp[26].Value = this.Date_Record;

                sp[27].Value = this.Logistic_Deposit_Type;

                sp[28].Value = this.Logistic_Flow_Indicator;

                sp[29].Value = this.Ordering_Indicator;

                sp[30].Value = this.Link_Logistic_Deposit;

                sp[31].Value = this.Expiry_Days;

                sp[32].Value = this.Expiry_Days_Checking_Indicator;

                sp[33].Value = this.Minimum_Expiry_Days;

                sp[34].Value = this.Pallet_Indicator;

                sp[35].Value = this.Number_Layer_Pallet;

                sp[36].Value = this.Number_Units_Inbox;

                sp[37].Value = this.Gross_Volume;

                sp[38].Value = this.Measure_Unit_GrossVolume;

                sp[39].Value = this.Packing_Type;

                sp[40].Value = this.Carton_Width;

                sp[41].Value = this.Carton_Height;

                sp[42].Value = this.UOM_Carton_Size;

                sp[43].Value = this.UOM_Carton_Weight;

                sp[44].Value = this.Carton_Gross_Volume;

                sp[45].Value = this.UOM_Carton_Volume;

                sp[46].Value = this.Selling_Unit_Length;

                sp[47].Value = this.Selling_Unit_Width;

                sp[48].Value = this.Selling_Unit_Height;

                sp[49].Value = this.UOM_Selling_Size;

                sp[50].Value = this.Grossweight_Selling;

                sp[51].Value = this.Netweight_Selling;

                sp[52].Value = this.UOM_Selling_Weight;

                sp[53].Value = this.Article_Group_Number;

                sp[54].Value = this.Artice_Subgroup_Number;

                sp[55].Value = this.Excise_Tax_Indicator;

                sp[56].Value = this.Excise_Tax_Amount;

                sp[57].Value = this.High_Value_Indicator;

                sp[58].Value = this.Storage_Temperature_Desc;

                sp[59].Value = this.Remark;

                sp[60].Value = this.EditDate;

                sp[61].Value = this.BLANK1;

                sp[62].Value = this.BLANK2;

                sp[63].Value = this.BLANK3;

                sp[64].Value = this.BLANK4;

                sp[65].Value = this.BLANK5;

                sp[66].Value = this.BLANK6;

                sp[67].Value = this.BLANK7;

                sp[68].Value = this.FILENAME;



                DAL.excutequery(PP_MM_Articles, sp, CommandType.StoredProcedure);
                return true;
            }
            catch (Exception e)
            {
                string category = "Article";
                ResultDatabase_Model result = new ResultDatabase_Model();
                result.HandleError(fileName, text, e.Message.ToString(), this.Article_Number, category);
                return false;
            }
        }

        #endregion
    }
}