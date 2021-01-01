using MM_EDI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM_Project
{
    class POController_North
    {
        Response_Mapping resultMapping = new Response_Mapping();
        string code = "";
        string token = "";
        DateTime endTime;

        public ResultDatabase_Model InsertDatabase(string text, int indicator, string fileName)
        {
            ResultDatabase_Model result = new ResultDatabase_Model();
            Response_ReadFile error = new Response_ReadFile();
            bool check = false;
            if (indicator == 1)
            {
              MM_PO_Header poHeader = new MM_PO_Header();
                try
                {
                    poHeader.Table_Indicator = DAL.IntReturn(text.Substring(0, 1));
                    poHeader.Lsp_Identification = text.Substring(1, 4);

                    string orderNumber = text.Substring(5, 20);
                    poHeader.Order_Number = orderNumber.Substring(3, 17);

                    poHeader.Order_Type = text.Substring(25, 4);

                    string supplier = text.Substring(29, 10);
                    poHeader.Supplier_Number = supplier.Substring(4, 6);

                    string deliveryDate = text.Substring(39, 8);
                    int year = DAL.IntReturn(deliveryDate.Substring(0, 4));
                    int month = DAL.IntReturn(deliveryDate.Substring(4, 2));
                    int day = DAL.IntReturn(deliveryDate.Substring(6, 2));
                    poHeader.Plan_Delivery_Date = new DateTime(year, month, day);

                    string warehouse = text.Substring(47, 20);
                    poHeader.Warehouse_Number = warehouse.Substring(15, 5);

                    string email = text.Substring(67, 20);
                    poHeader.MM_Email_Number = email.Substring(0, 5);

                    poHeader.Memo_Field = text.Substring(87, 255);

                    string dateRecord = text.Substring(342, 8);
                    int year1 = DAL.IntReturn(dateRecord.Substring(0, 4));
                    int month1 = DAL.IntReturn(dateRecord.Substring(4, 2));
                    int day1 = DAL.IntReturn(dateRecord.Substring(6, 2));
                    poHeader.Date_Record = new DateTime(year1, month1, day1);

                    poHeader.Action_Type = text.Substring(350, 1);

                    string commercialSupplier = text.Substring(351, 10);
                    poHeader.Commercial_Supplier_Number = commercialSupplier.Substring(4, 6);

                    string orderDate = text.Substring(361, 8);
                    int year3 = DAL.IntReturn(orderDate.Substring(0, 4));
                    int month3 = DAL.IntReturn(orderDate.Substring(4, 2));
                    int day3 = DAL.IntReturn(orderDate.Substring(6, 2));
                    poHeader.Order_Date = new DateTime(year3, month3, day3);

                    poHeader.Free_Text1 = text.Substring(369, 20);
                    poHeader.Free_Text2 = text.Substring(389, 20);
                    poHeader.FILENAME = fileName;

                    string sql = string.Format("select * from MM_PO_HEADER where Order_Number = '{0}'", poHeader.Order_Number);
                    DataTable dt = DAL.SELECT_SQL(sql);
                    int count = DAL.IntReturn(dt.Rows.Count);

                    if (count == 0)
                    {
                        poHeader.ADDDATE = DateTime.Now;
                        poHeader.EDITDATE = DateTime.Now;
                        check=poHeader.Add(fileName, text);
                        result.result(check, poHeader.Action_Type, poHeader.Order_Number);
                    }
                    else
                    {
                        poHeader.EDITDATE = DateTime.Now;
                        check = poHeader.Update(fileName, text);
                        result.result(check, poHeader.Action_Type, poHeader.Order_Number);
                    }
                }
                catch (Exception e)
                {
                    string Category = "poHeader";
                    error.HandleError(fileName, text, e.Message.ToString(), Category);
                    check = false;
                    result.result(check, poHeader.Action_Type, poHeader.Order_Number);
                }
            }
            else if (indicator == 2)
            {
                MM_PO_Detail poDetail = new MM_PO_Detail();
                try
                {
                    poDetail.Table_Indicator = DAL.IntReturn(text.Substring(0, 1));
                    poDetail.Lsp_Identification = text.Substring(1, 4);

                    string orderNumber = text.Substring(5, 20);
                    poDetail.Order_Number = orderNumber.Substring(3, 17);

                    string sku = text.Substring(81, 10);
                    poDetail.Article_Number = sku.Substring(2, 8);

                    int qty = DAL.IntReturn(text.Substring(91, 10));
                    poDetail.Order_Quantity = DAL.DecimalReturn(DAL.ChangeValue(3, qty));

                    string dateRecord = text.Substring(101, 8);
                    int year = DAL.IntReturn(dateRecord.Substring(0, 4));
                    int month = DAL.IntReturn(dateRecord.Substring(4, 2));
                    int day = DAL.IntReturn(dateRecord.Substring(6, 2));
                    poDetail.Date_Record = new DateTime(year, month, day);

                    poDetail.Action_Type = text.Substring(109, 1);
                    string warehouse = text.Substring(110, 20);
                    poDetail.Warehouse_Number = warehouse.Substring(15, 5);
                    poDetail.Orderline = text.Substring(130, 20);
                    string email = text.Substring(150, 20);
                    poDetail.MM_Email_Number = email.Substring(0, 5);

                    poDetail.FILENAME = fileName;
                    string sql = string.Format("select * from MM_PO_DETAIL where Order_Number = '{0}' and Article_Number= '{1}'", poDetail.Order_Number, poDetail.Article_Number);
                    DataTable supplierHeaderTable = DAL.SELECT_SQL(sql);
                    int count = DAL.IntReturn(supplierHeaderTable.Rows.Count);

                    if (count==0)
                    {
                        poDetail.ADDDATE = DateTime.Now;
                        poDetail.EDITDATE = DateTime.Now;
                        check = poDetail.Add(fileName, text);
                        result.result(check, poDetail.Action_Type, poDetail.Order_Number);
                    }
                    else
                    {
                        poDetail.EDITDATE = DateTime.Now;
                        check = poDetail.Update(fileName, text);
                        result.result(check, poDetail.Action_Type, poDetail.Order_Number);
                    }
                   
                }
                catch (Exception e)
                {
                    string Category = "poDetail";
                    error.HandleError(fileName, text, e.Message.ToString(), Category);
                    check = false;
                    result.result(check, poDetail.Action_Type, poDetail.Order_Number);
                }
            }
            else if (indicator == 3)
            {
                MM_PO_Detail_XD poDetailXd = new MM_PO_Detail_XD();
                try
                {
                    poDetailXd.Table_Indicator = DAL.IntReturn(text.Substring(0, 1));
                    poDetailXd.Lsp_Identification = text.Substring(1, 4);

                    string orderNumber = text.Substring(5, 20);
                    poDetailXd.Order_Number = orderNumber.Substring(3, 17);

                    string sku = text.Substring(63, 10);
                    poDetailXd.Article_Number = sku.Substring(2, 8);

                    string storeNumber = text.Substring(73, 10);
                    poDetailXd.Store_Number = storeNumber.Substring(5, 5);

                    int qty = DAL.IntReturn(text.Substring(83, 10));
                    poDetailXd.Order_Quantity = DAL.DecimalReturn(DAL.ChangeValue(3, qty));

                    string warehouse = text.Substring(93, 20);
                    poDetailXd.Warehouse_Number = warehouse.Substring(15, 5);

                    string saleOrder = text.Substring(121, 20);
                    poDetailXd.Sale_Order = saleOrder.Substring(3, 17);


                    string mail = text.Substring(141, 20);
                    poDetailXd.Metro_Mail = mail.Substring(0, 5);

                    string articleNumber = text.Substring(161, 10);
                    poDetailXd.Buying_Article_Number = articleNumber.Substring(0, 7);

                    poDetailXd.FILENAME = fileName;
                    string sql = string.Format("select * from MM_PO_DETAIL_XD where Order_Number = '{0}' and Sale_Order='{1}' and Article_Number='{2}'", poDetailXd.Order_Number,poDetailXd.Sale_Order,poDetailXd.Article_Number);
                    DataTable supplierHeaderTable = DAL.SELECT_SQL(sql);
                    int count = DAL.IntReturn(supplierHeaderTable.Rows.Count);

                    if (count == 0)
                    {
                        poDetailXd.ADDDATE = DateTime.Now;
                        poDetailXd.EDITDATE = DateTime.Now;
                        check = poDetailXd.Add(fileName, text);
                        result.result(check, "", poDetailXd.Order_Number);
                    }
                    else
                    {
                        poDetailXd.EDITDATE = DateTime.Now;
                        check = poDetailXd.Update(fileName, text);
                        result.result(check, "", poDetailXd.Order_Number);
                    }
                }
                catch (Exception e)
                {
                    string Category = "poDetailXd";
                    error.HandleError(fileName, text, e.Message.ToString(), Category);
                    check = false;
                    result.result(check,"", poDetailXd.Order_Number);
                }
            }
            return result;
        }

        public async void PostToIon()
        {
            IonReponse result = new IonReponse();
            JArray pos = new JArray();

            string url = Constant.ION_PO_URL_NORTH;
            string category = "PO";
            pos = this.Create_ModelPo();
            DataTable dtToken = DAL.GetNewToken();
            if (dtToken.Rows.Count > 0)
            {
                token = dtToken.Rows[0]["AccessToken"].ToString();
                endTime = DateTime.Parse(dtToken.Rows[0]["EndTime"].ToString());
            }

            foreach (JObject po in pos)
            {
                DateTime now = DateTime.Now;
                int resDate = DateTime.Compare(endTime, now);
                if (resDate < 0 || resDate == 0)
                {
                    dtToken = DAL.GetNewToken();
                    if (dtToken.Rows.Count > 0)
                    {
                        token = dtToken.Rows[0]["AccessToken"].ToString();
                        endTime = DateTime.Parse(dtToken.Rows[0]["EndTime"].ToString());
                    }
                }
                System.Threading.Thread.Sleep(3000);
                var pokey_mm = po.GetValue("externpokey").ToString().Trim();
                var pokey_infor = po.GetValue("pokey").ToString().Trim();
              
                result = await ClientHttpController.Post(po, url, token);
                if (result.check)
                {                 
                    DAL.UpdateStatus(pokey_mm, pokey_infor, category);                                                   
                }
                else
                {
                    result.RecordResultAPI("PO_NORTH", pokey_mm);
                }
            }
        }

        public JArray Create_ModelPo()
        {
            JArray pos = new JArray();
            string sqlHeader = string.Format("select * from MM_PO_HEADER where  STATUS = '' and Warehouse_Number='90072'");
            DataTable dt = DAL.SELECT_SQL(sqlHeader);

            int count = dt.Rows.Count;

            if (count > 0)
            {                                     
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        POInfor_Model po = new POInfor_Model();
                        IList<Podetail> podetails = new List<Podetail>();
                        string pokey_mm = dt.Rows[i]["Order_Number"].ToString().Trim();
                        code = pokey_mm;
                        string pokey_infor = dt.Rows[i]["Order_Number"].ToString().Trim().TrimStart('0');
                        string type = dt.Rows[i]["Order_Type"].ToString().Trim();

                        switch (type)
                        {
                            case "19":
                                po.potype = "0";
                                break;
                            case "6":
                                po.potype = "0";
                                break;
                            case "20":
                                po.potype = "1";
                                break;
                            case " ":
                                po.potype = "1";
                                break;
                            case "02":
                                po.potype = "3";
                                break;
                            default:
                                po.potype = "1";
                                break;
                        }
                        po.pokey = pokey_infor;
                        po.storerkey = "N0528";
                        po.externpokey = pokey_mm;
                        po.externalpokey2 = dt.Rows[i]["Warehouse_Number"].ToString().Trim();
                        po.expectedreceiptdate = DateTime.Parse(dt.Rows[i]["Plan_Delivery_Date"].ToString().Trim());
                        po.podate = DateTime.Parse(dt.Rows[i]["Order_Date"].ToString().Trim());
                        po.sellername = dt.Rows[i]["Supplier_Number"].ToString().Trim().TrimStart('0');
                        po.whseid = "wmwhse3";
                        po.addwho = "wmsadmin";
                        po.editwho = "wmsadmin";
                        podetails = this.Create_PoDetail(pokey_mm, pokey_infor);
                        po.podetails = podetails;

                        string output = JsonConvert.SerializeObject(po);
                        JObject objectPo = JObject.Parse(output);
                        pos.Add(objectPo);
                    }
                    catch(Exception e)
                    {
                        string step = string.Format(Constant.MODEL_PO, "NORTH");
                        resultMapping.Handle_Error_Mapping(code, e.ToString(), step);
                        continue;
                    }
                    
                }                                                                                                          
            }          
            return pos; 
        }

        public IList<Podetail> Create_PoDetail(string pokey_mm, string pokey_infor)
        {
            IList<Podetail> poDetails = new List<Podetail>();
            string sql = string.Format("select * from MM_PO_DETAIL where Order_Number = '{0}' and STATUS='' and Warehouse_Number='90072'  order by Article_Number asc", pokey_mm);
            DataTable dt = DAL.SELECT_SQL(sql);

            int count = DAL.IntReturn(dt.Rows.Count);

            for (int i = 0; i < count; i++)
            {
                try
                {
                    Podetail poDetail = new Podetail();
                    poDetail.pokey = pokey_infor;
                    poDetail.storerkey = "N0528";
                    string sku = dt.Rows[i]["Article_Number"].ToString().Trim().TrimStart('0');
                    poDetail.sku = sku;
                    poDetail.qtyordered = DAL.IntReturn(dt.Rows[i]["Order_Quantity"]);
                    poDetail.whseid = "wmwhse3";
                    poDetail.addwho = "wmsadmin";
                    poDetail.editwho = "wmsadmin";

                    poDetails.Add(poDetail);
                }
                catch(Exception e)
                {
                    string step = string.Format(Constant.MODEL_PODETAIL, "NORTH");
                    resultMapping.Handle_Error_Mapping(code, e.ToString(), step);
                    continue;
                }
                
            }
            return poDetails;
        }

    }
}
