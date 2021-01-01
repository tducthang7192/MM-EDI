using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using MM_EDI;

namespace MM_Project
{
    public class SupplierController
    {
        private JArray hrefs = new JArray();
        Response_Mapping resultMapping = new Response_Mapping();
        string code = "";
        string token = "";
        DateTime endTime;

        public ResultDatabase_Model InsertDatabase(string text,int indicator, string fileName)
        {
            ResultDatabase_Model result = new ResultDatabase_Model();
            Response_ReadFile error = new Response_ReadFile();
            bool check = false;
            if (indicator == 1)
            {
                Supplier_Header_Model supplierHeader = new Supplier_Header_Model();
                try
                {
                    supplierHeader.Table_Indicator = DAL.IntReturn(text.Substring(0, 1));
                    supplierHeader.Action_Code = text.Substring(1, 1);
                    supplierHeader.Lsp_Identification = text.Substring(2, 4).ToString();

                    string supplierCode = text.Substring(6, 20);
                    supplierHeader.Supplier_Code = supplierCode.Substring(14, 6).ToString();

                    supplierHeader.Supplier_Name = text.Substring(26, 35).Replace("'", "\""); 
                    supplierHeader.Supplier_Status = DAL.IntReturn(text.Substring(61, 2));
                    supplierHeader.Supplier_Type = DAL.IntReturn(text.Substring(63, 2));
                    supplierHeader.Buyer_User_Id = text.Substring(65, 6);
                    supplierHeader.Supplier_Fiscal_Number = text.Substring(71, 15);
                    supplierHeader.Way_Of_Order = DAL.IntReturn(text.Substring(86, 1));
                    supplierHeader.Language_Code = text.Substring(87, 2);
                    supplierHeader.Currency_Code = text.Substring(89, 3);

                    //string warehouse= text.Substring(92, 5);
                    supplierHeader.Warehouse_Number = text.Substring(92, 5);
                 
                    string dateRecord = text.Substring(97, 8);
                    int year = DAL.IntReturn(dateRecord.Substring(0, 4));
                    int month = DAL.IntReturn(dateRecord.Substring(4, 2));
                    int day = DAL.IntReturn(dateRecord.Substring(6, 2));
                    supplierHeader.Date_Record = new DateTime(year, month, day);
                    supplierHeader.Default_Logistic_Flow = int.Parse(text.Substring(105, 2));
                    supplierHeader.Supplier_Registration_Number = text.Substring(107, 15);
                    supplierHeader.FILENAME = fileName;
                    

                    string sql = string.Format("select * from MM_Supplier_Header where Supplier_Code = '{0}' and Warehouse_Number='{1}' ", supplierHeader.Supplier_Code,supplierHeader.Warehouse_Number);
                    DataTable supplierHeaderTable = DAL.SELECT_SQL(sql);
                    int count = DAL.IntReturn(supplierHeaderTable.Rows.Count);
                    if (count > 0 && supplierHeader.Supplier_Status == 1)
                    {
                        supplierHeader.EditDate = DateTime.Now;
                        check = supplierHeader.Update(fileName, text);
                        result.result(check, supplierHeader.Supplier_Status.ToString(), supplierHeader.Supplier_Code);
                    }
                    else if (count > 0 && (supplierHeader.Supplier_Status == 5 || supplierHeader.Supplier_Status == 9))
                    {
                        supplierHeader.EditDate = DateTime.Now;
                        check = supplierHeader.Update(fileName, text);
                        result.result(check, supplierHeader.Supplier_Status.ToString(), supplierHeader.Supplier_Code);
                    }
                    else if (count == 0 && supplierHeader.Supplier_Status == 1)
                    {
                        supplierHeader.AddDate = DateTime.Now;
                        supplierHeader.EditDate = DateTime.Now;
                        check = supplierHeader.Add(fileName, text);
                        result.result(check, supplierHeader.Supplier_Status.ToString(), supplierHeader.Supplier_Code);
                    }
                    else
                    {
                        check = false;
                        result.result(check, supplierHeader.Supplier_Status.ToString(), supplierHeader.Supplier_Code);
                    }
                }
                catch(Exception e)
                {
                    string category = "supplierHeader";
                    error.HandleError(fileName, text, e.Message.ToString(), category);
                    check = false;
                    result.result(check, supplierHeader.Supplier_Status.ToString(), supplierHeader.Supplier_Code);
                }
              
                

            }
            else if(indicator == 2)
            {
                Supplier_Detail_Model supplierDetail = new Supplier_Detail_Model();
                try
                {
                    supplierDetail.Table_Indicator = DAL.IntReturn(text.Substring(0, 1));
                    supplierDetail.Action_Code = text.Substring(1, 1);
                    supplierDetail.Lsp_Identification = text.Substring(2, 4);

                    string supplierCode = text.Substring(6, 20);
                    supplierDetail.Supplier_Code = supplierCode.Substring(14, 6).ToString();

                    supplierDetail.Address_Indicator = DAL.IntReturn(text.Substring(26, 2));
                    supplierDetail.Contact_Person = text.Substring(28, 35);
                    supplierDetail.Building = text.Substring(63, 28);
                    supplierDetail.Town = text.Substring(119, 25);
                    supplierDetail.Phone = text.Substring(144, 15);
                    supplierDetail.Fax_Number = text.Substring(159, 18);
                    supplierDetail.Postal_Code = text.Substring(176, 11);
                    supplierDetail.DC_Phone_Number = text.Substring(188, 15);
                    supplierDetail.Origin = text.Substring(221, 4);
                    supplierDetail.Supplier_Repressentative = text.Substring(225, 35);

                 
                    supplierDetail.Warehouse_Number = text.Substring(260, 5).ToString();

                    string dateRecord = text.Substring(265, 8);
                    int year = DAL.IntReturn(dateRecord.Substring(0, 4));
                    int month = DAL.IntReturn(dateRecord.Substring(4, 2));
                    int day = DAL.IntReturn(dateRecord.Substring(6, 2));
                    supplierDetail.Date_Record = new DateTime(year, month, day);
                    supplierDetail.Email_Address = text.Substring(273, 100);
                    supplierDetail.FILENAME = fileName;

                    string sql = string.Format("select * from MM_Supplier_Detail where Supplier_Code = '{0}' and Warehouse_Number='{1}' ", supplierDetail.Supplier_Code,supplierDetail.Warehouse_Number);
                    DataTable supplierDetailTable = DAL.SELECT_SQL(sql);
                    int count = DAL.IntReturn(supplierDetailTable.Rows.Count);
                    if (count > 0)
                    {
                        supplierDetail.Editdate = DateTime.Now;
                        check = supplierDetail.Update(fileName, text);
                        result.result(check, "U", supplierDetail.Supplier_Code);
                    }
                    else if (count == 0)
                    {
                        supplierDetail.AddDate = DateTime.Now;
                        supplierDetail.Editdate = DateTime.Now;
                        check = supplierDetail.Add(fileName, text);
                        result.result(check, "I", supplierDetail.Supplier_Code);
                    }
                }
                catch(Exception e)
                {
                    string category = "supplierDetail";
                    error.HandleError(fileName, text, e.Message.ToString(), category);
                    check = false;
                    result.result(check, "", supplierDetail.Supplier_Code);
                }
                     
            }
            return result;
        }

        public  async void PostToIon_South()
        {
            IonReponse result = new IonReponse();           
            JArray suppliers = new JArray();

            string url = Constant.ION_SUPPLIER_URL_SOUTH;

            suppliers = this.CreateModelSupplier("SOUTH");

            DataTable dtToken = DAL.GetNewToken();
            if (dtToken.Rows.Count > 0)
            {
                token = dtToken.Rows[0]["AccessToken"].ToString();
                endTime = DateTime.Parse(dtToken.Rows[0]["EndTime"].ToString());
            }

            foreach ( JObject supplier in suppliers)
            {
                DateTime now = DateTime.Now;
                int resDate = DateTime.Compare(endTime, now);

                if (resDate < 0 || resDate == 0)
                {
                    if (dtToken.Rows.Count > 0)
                    {
                        token = dtToken.Rows[0]["AccessToken"].ToString();
                        endTime = DateTime.Parse(dtToken.Rows[0]["EndTime"].ToString());
                    }
                }
                System.Threading.Thread.Sleep(3000);

                string supplier_code = supplier.GetValue("storerkey").ToString().Trim();

                supplier_code = DAL.GetString(supplier_code,6);

                string category = "Supplier_South";
                
                result = await ClientHttpController.Post(supplier, url, token);
                                       
                if (result.check)
                {
                    DAL.UpdateStatus(supplier_code, "OK", category);                    
                }
                else
                {
                    result.RecordResultAPI(category, supplier_code);
                }
            }

        }

        public async void PostToIon_North()
        {
            IonReponse result = new IonReponse();
            JArray suppliers = new JArray();

            string url = Constant.ION_SUPPLIER_URL_NORTH;

            suppliers = this.CreateModelSupplier("NORTH");

            DataTable dtToken = DAL.GetNewToken();
            if (dtToken.Rows.Count > 0)
            {
                token = dtToken.Rows[0]["AccessToken"].ToString();
                endTime = DateTime.Parse(dtToken.Rows[0]["EndTime"].ToString());
            }

            foreach (JObject supplier in suppliers)
            {
                DateTime now = DateTime.Now;
                int resDate = DateTime.Compare(endTime, now);

                if (resDate < 0 || resDate == 0)
                {
                    if (dtToken.Rows.Count > 0)
                    {
                        token = dtToken.Rows[0]["AccessToken"].ToString();
                        endTime = DateTime.Parse(dtToken.Rows[0]["EndTime"].ToString());
                    }
                }
                System.Threading.Thread.Sleep(3000);

                string supplier_code = supplier.GetValue("storerkey").ToString().Trim();

                supplier_code = DAL.GetString(supplier_code, 6);

                string category = "Supplier_North";

                result = await ClientHttpController.Post(supplier, url, token);

                if (result.check)
                {
                    DAL.UpdateStatus(supplier_code, "OK", category);
                }
                else
                {
                    result.RecordResultAPI(category, supplier_code);
                }
            }

        }

        public JArray CreateModelSupplier(string warehouse)
        {
            JArray suppliers = new JArray();
            string sql = string.Format("EXEC PP_MM_SUPPLIER_INFORMATION '{0}'",warehouse);
            DataTable dt = DAL.SELECT_SQL(sql);
            
            if (dt.Rows.Count > 0)
            {
                int count = dt.Rows.Count;
                for (int j = 0; j < count; j++)
                {
                    try
                    {
                        SupplierInfor_Model supplier_Model = new SupplierInfor_Model();
                        string storerkey = dt.Rows[j]["Supplier_Code"].ToString().Trim().TrimStart('0');
                        code = dt.Rows[j]["Supplier_Code"].ToString().Trim();
                        string company = dt.Rows[j]["Supplier_Name"].ToString().Trim().Replace("'", "\"");
                        

                        supplier_Model.storerkey = storerkey;
                        supplier_Model.company = company;
                        supplier_Model.susr1 = dt.Rows[j]["Supplier_Type"].ToString().Trim().Replace("'", "\"");
                        supplier_Model.susr2 = dt.Rows[j]["Buyer_User_Id"].ToString().Trim().Replace("'", "\"");
                        supplier_Model.susr3 = dt.Rows[j]["Supplier_Fiscal_Number"].ToString().Trim().Replace("'", "\"");
                        supplier_Model.susr4 = dt.Rows[j]["Warehouse_Number"].ToString().Trim().Replace("'", "\"");
                        supplier_Model.susr5 = dt.Rows[j]["Default_Logistic_Flow"].ToString().Trim().Replace("'", "\"");
                        supplier_Model.notes1 = dt.Rows[j]["Contact_Person"].ToString().Trim().Replace("'", "\"");
                        supplier_Model.address2 = dt.Rows[j]["Building"].ToString().Trim().Replace("'", "\"");
                        supplier_Model.address1 = dt.Rows[j]["Address"].ToString().Trim().Replace("'", "\"");
                        supplier_Model.city = dt.Rows[j]["Town"].ToString().Trim().Replace("'", "\"");
                        supplier_Model.phone1 = dt.Rows[j]["phone"].ToString().Trim().Replace("'", "\"");
                        supplier_Model.fax1 = dt.Rows[j]["Fax_Number"].ToString().Trim().Replace("'", "\"");
                        supplier_Model.zip = dt.Rows[j]["Postal_Code"].ToString().Trim().Replace("'", "\"");
                        supplier_Model.country = dt.Rows[j]["Origin"].ToString().Trim().Replace("'", "\"");
                        supplier_Model.notes2= dt.Rows[j]["email"].ToString().Trim().Replace("'", "\"");
                        supplier_Model.contact1 = "MM";
                        for (int i = 0; i < 2; i++)
                        {
                            if (i == 0)
                            {
                                supplier_Model.type = "12";
                            }
                            else if (i == 1)
                            {
                                supplier_Model.type = "5";
                            }


                            string output = JsonConvert.SerializeObject(supplier_Model);

                            JObject objectSupplier = JObject.Parse(output);

                            suppliers.Add(objectSupplier);
                        }
                        

                       
                    }
                    catch(Exception e)
                    {
                        string step = string.Format(Constant.MODEL_SUPPLIER);
                        resultMapping.Handle_Error_Mapping(code, e.ToString(), step);
                        continue;
                    }                            
                }
               
            }
            return suppliers;
        }
    }
}
