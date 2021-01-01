using MM_EDI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MM_Project
{
    public class SOController_North
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
                ClsMM_Orders_Header orderHeader = new ClsMM_Orders_Header();
                try
                {
                    orderHeader.Table_Indicator = DAL.IntReturn(text.Substring(0, 1));
                    orderHeader.Lsp_Identification = text.Substring(1, 4);

                    string orderNumber = text.Substring(5, 20);
                    orderHeader.Order_Number = orderNumber.Substring(3, 17);

                    orderHeader.Order_Type = text.Substring(25, 4);

                    string storeNumber = text.Substring(29, 10);
                    orderHeader.Store_Number = storeNumber.Substring(5, 5);

                    string deliveryDate = text.Substring(39, 8);
                    int year = DAL.IntReturn(deliveryDate.Substring(0, 4));
                    int month = DAL.IntReturn(deliveryDate.Substring(4, 2));
                    int day = DAL.IntReturn(deliveryDate.Substring(6, 2));
                    orderHeader.Plan_Delivery_Date = new DateTime(year, month, day);

                    string warehouse = text.Substring(47, 20);
                    orderHeader.Warehouse_Number = warehouse.Substring(15, 5);

                    string email = text.Substring(67, 20);
                    orderHeader.MM_Email_Number = email.Substring(15, 5);

                    string memoField = text.Substring(87, 255);
                    orderHeader.Memo_Field = memoField.Substring(0, 59);

                    string dateRecord = text.Substring(342, 8);
                    int year1 = DAL.IntReturn(dateRecord.Substring(0, 4));
                    int month1 = DAL.IntReturn(dateRecord.Substring(4, 2));
                    int day1 = DAL.IntReturn(dateRecord.Substring(6, 2));
                    orderHeader.Date_Record = new DateTime(year1, month1, day1);

                    orderHeader.Action_Type = text.Substring(350, 1);

                    string commercial = text.Substring(351, 10);
                    orderHeader.Commercial_Supplier_Number = commercial.Substring(4, 5);

                    string dateToWarehouse = text.Substring(361, 8);
                    int year2 = DAL.IntReturn(dateToWarehouse.Substring(0, 4));
                    int month2 = DAL.IntReturn(dateToWarehouse.Substring(4, 2));
                    int day2 = DAL.IntReturn(dateToWarehouse.Substring(6, 2));
                    orderHeader.Plan_Delivery_To_Warehouse = new DateTime(year2, month2, day2);

                    string orderDate = text.Substring(369, 8);
                    int year3 = DAL.IntReturn(orderDate.Substring(0, 4));
                    int month3 = DAL.IntReturn(orderDate.Substring(4, 2));
                    int day3 = DAL.IntReturn(orderDate.Substring(6, 2));
                    orderHeader.Order_Date = new DateTime(year3, month3, day3);


                    orderHeader.Free_Text1 = text.Substring(377, 20);
                    orderHeader.Free_Text2 = text.Substring(397, 20);

                    orderHeader.Order_Logistic_Type = DAL.IntReturn(text.Substring(417, 2));
                    orderHeader.Customer_Store_Number = DAL.IntReturn(text.Substring(419, 2));
                    orderHeader.Customer_Number = text.Substring(421, 6);
                    orderHeader.FILENAME = fileName;
                    string sql = string.Format("select * from MM_ORDERS_HEADER where Order_Number = '{0}'", orderHeader.Order_Number);
                    DataTable orderHeaderTable = DAL.SELECT_SQL(sql);
                    int count = DAL.IntReturn(orderHeaderTable.Rows.Count);
                    if (count > 0 && (orderHeader.Action_Type == "I" || orderHeader.Action_Type == "D"))
                    {
                        orderHeader.EDITDATE = DateTime.Now;
                        check = orderHeader.Update(fileName, text);
                        result.result(check, orderHeader.Action_Type, orderHeader.Order_Number);

                    }
                    else if (count == 0 && orderHeader.Action_Type == "I")
                    {
                        orderHeader.ADDDATE = DateTime.Now;
                        orderHeader.EDITDATE = DateTime.Now;
                        check = orderHeader.Add(fileName, text);
                        result.result(check, orderHeader.Action_Type, orderHeader.Order_Number);
                    }
                    else
                    {
                        check = false;
                        result.result(check, orderHeader.Action_Type, orderHeader.Order_Number);
                    }

                }
                catch(Exception e)
                {
                    string category = "orderHeader";
                    error.HandleError(fileName,text,e.Message.ToString(), category);
                    check = false;
                    result.result(check, orderHeader.Action_Type, orderHeader.Order_Number);
                }
                
                
                
            }
            else if (indicator == 2)
            {
                ClsMM_Orders_Detail orderDetail = new ClsMM_Orders_Detail();
                try
                {
                    orderDetail.Table_Indicator = DAL.IntReturn(text.Substring(0, 1));
                    orderDetail.Lsp_Identification = text.Substring(1, 4);

                    string orderNumber = text.Substring(5, 20);
                    orderDetail.Order_Number = orderNumber.Substring(3, 17);

                    string storeNumber = text.Substring(63, 10);
                    orderDetail.Store_Number = storeNumber.Substring(5, 5);

                    string sku = text.Substring(91, 10);
                    orderDetail.Article_Number = sku.Substring(2, 8);


                    int quantity = DAL.IntReturn(text.Substring(101, 10));
                    orderDetail.Order_Quantity = DAL.DecimalReturn(DAL.ChangeValue(3, quantity));

                    string dateRecord = text.Substring(111, 8);
                    int year = DAL.IntReturn(dateRecord.Substring(0, 4));
                    int month = DAL.IntReturn(dateRecord.Substring(4, 2));
                    int day = DAL.IntReturn(dateRecord.Substring(6, 2));
                    orderDetail.Date_Record = new DateTime(year, month, day);

                    orderDetail.Action_Code = text.Substring(119, 1);

                    string warehouse = text.Substring(120, 20);
                    orderDetail.Warehouse_Number = warehouse.Substring(15, 5);

                    orderDetail.Orderline_Fretext = text.Substring(140, 15);

                    string po = text.Substring(155, 20);
                    orderDetail.Purchase_Order = po.Substring(0, 12);

                    string email = text.Substring(175, 20);
                    orderDetail.MM_Mail_Number = email.Substring(0, 5);

                    string article = text.Substring(195, 10);
                    orderDetail.Buying_Article_Number = article.Substring(2, 8);

                    int price = DAL.IntReturn(text.Substring(205, 13));
                    orderDetail.Article_Selling_Price = DAL.DecimalReturn(DAL.ChangeValue(2, price));

                    orderDetail.FILENAME = fileName;

                    string sql = string.Format("select * from MM_ORDERS_DETAIL where Order_Number = '{0}' and Article_Number='{1}'", orderDetail.Order_Number,orderDetail.Article_Number);
                    DataTable orderHeaderTable = DAL.SELECT_SQL(sql);
                    int count = DAL.IntReturn(orderHeaderTable.Rows.Count);
                    if (count > 0 && (orderDetail.Action_Code == "I" || orderDetail.Action_Code == "D"))
                    {
                        orderDetail.EDITDATE = DateTime.Now;
                        check = orderDetail.Update(fileName, text);
                        result.result(check, orderDetail.Action_Code, orderDetail.Order_Number);

                    }
                    else if (count == 0 && orderDetail.Action_Code == "I")
                    {
                        orderDetail.ADDDATE = DateTime.Now;
                        orderDetail.EDITDATE = DateTime.Now;
                        check = orderDetail.Add(fileName, text);
                        result.result(check, orderDetail.Action_Code, orderDetail.Order_Number);
                    }
                    else
                    {
                        check = false;
                        result.result(check, orderDetail.Action_Code, orderDetail.Order_Number);
                    }

                }
                catch(Exception e)
                {

                    string category = "orderDetail";
                    error.HandleError(fileName, text, e.Message.ToString(), category);
                    check = false;
                    result.result(check, orderDetail.Action_Code, orderDetail.Order_Number);
                }
               
                
            }
            return result;
        }

        #region SO CS
        public async void PostToIon()
        {
            IonReponse result = new IonReponse();
            JArray jArray = new JArray();
            
            string url = Constant.ION_SO_URL_NORTH;
            string category = "SO";

            jArray = this.Create_ModelSO();

            DataTable dtToken = DAL.GetNewToken();
            if (dtToken.Rows.Count > 0)
            {
                token = dtToken.Rows[0]["AccessToken"].ToString();
                endTime = DateTime.Parse(dtToken.Rows[0]["EndTime"].ToString());
            }

            foreach (JObject so in jArray)
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
                var orderkey_infor= so.GetValue("orderkey").ToString().Trim();
                var orderkey_mm = DAL.GetString(orderkey_infor, 17);

                result = await ClientHttpController.Post(so, url, token);
                if (result.check)
                {
                    DAL.UpdateStatus(orderkey_mm, orderkey_infor,category);
                }
                else
                {
                    result.RecordResultAPI("SO_CS_NORTH", orderkey_mm);
                }               
            }
        }

        public JArray Create_ModelSO()
        {
            JArray orders = new JArray();
            string sqlHeader= string.Format("select * from MM_ORDERS_HEADER where STATUS='' and Warehouse_Number='90072' ");
            DataTable dt = DAL.SELECT_SQL(sqlHeader);
            int count = dt.Rows.Count;

            if (count > 0)
            {                              
                for (int i=0; i < count; i++)
                {
                    try
                    {
                        SOInfor_Model so = new SOInfor_Model();
                        IList<Orderdetail> orderDetail = new List<Orderdetail>();

                        string type = dt.Rows[i]["Order_Type"].ToString().Trim();
                        string orderkey_mm = dt.Rows[i]["Order_Number"].ToString().Trim();
                        code = orderkey_mm;
                        string orderkey_infor = orderkey_mm.Trim().TrimStart('0');
                        string store= dt.Rows[i]["Store_Number"].ToString().Trim().TrimStart('0'); 
                        so.type = "14";
                        so.orderkey = orderkey_infor;
                        so.storerkey = "N0528";
                        so.consigneekey = store;
                        so.externalorderkey2 = orderkey_mm;
                        so.externorderkey = dt.Rows[i]["Warehouse_Number"].ToString().Trim();
                        so.notes2 = dt.Rows[i]["Memo_Field"].ToString().Trim();
                        so.pokey = "";
                        so.stage = store.Substring(3, 2); 
                        so.apportion = "1";
                        so.planneddelvdate = DateTime.Parse(dt.Rows[i]["Plan_Delivery_Date"].ToString());
                        so.promiseddelvdate = DateTime.Parse(dt.Rows[i]["Plan_Delivery_To_Warehouse"].ToString());
                        so.orderdate = DateTime.Parse(dt.Rows[i]["Order_Date"].ToString());
                        so.addwho = "wmsadmin";
                        so.editwho = "wmsadmin";
                        so.whseid = "wmwhse3";

                        orderDetail = this.Create_OrderDetail(orderkey_mm, orderkey_infor);
                        so.orderdetails = orderDetail;
                        string output = JsonConvert.SerializeObject(so);
                        JObject objectSO = JObject.Parse(output);
                        orders.Add(objectSO);
                    }
                    catch(Exception e)
                    {
                        string step = string.Format(Constant.MODEL_SO, "CS_NORTH");
                        resultMapping.Handle_Error_Mapping(code, e.ToString(), step);
                        continue;
                    }
                                                                
                }                                 
            }
            return orders;                   
        }

        public IList<Orderdetail> Create_OrderDetail(string orderkey_mm, string orderkey_infor)
        {
            IList<Orderdetail> orderDetails = new List<Orderdetail>();
            string sql = string.Format("select * from MM_ORDERS_DETAIL where Order_Number = '{0}' and STATUS='' and Warehouse_Number='90072' ", orderkey_mm);
            DataTable dt = DAL.SELECT_SQL(sql);

            int count = DAL.IntReturn(dt.Rows.Count);

            for (int i = 0; i < count; i++)
            {
                try
                {
                    Orderdetail orderDetail = new Orderdetail();
                    string sku = dt.Rows[i]["Article_Number"].ToString().Trim().TrimStart('0');

                    orderDetail.orderkey = orderkey_infor;
                    orderDetail.storerkey = "N0528";
                    orderDetail.sku = sku;
                    orderDetail.openqty = DAL.IntReturn(dt.Rows[i]["Order_Quantity"]);
                    orderDetail.originalqty = DAL.IntReturn(dt.Rows[i]["Order_Quantity"]);
                    orderDetail.newallocationstrategy = "N01";
                    orderDetail.susr2 = dt.Rows[i]["Article_Selling_Price"].ToString().Trim();
                    orderDetail.whseid = "wmwhse3";
                    orderDetail.addwho = "wmsadmin";
                    orderDetail.editwho = "wmsadmin";

                    orderDetails.Add(orderDetail);
                }
                catch(Exception e)
                {
                    string step = string.Format(Constant.MODEL_SODETAIL, "CS_NORTH");
                    resultMapping.Handle_Error_Mapping(code, e.ToString(), step);
                    continue;
                }
                
            }
            return orderDetails;
        }
        #endregion

        #region SO Xdock
        public async void PostToIon_Xdock()
        {
            IonReponse result = new IonReponse();
            JArray jArray = new JArray();

            string url = Constant.ION_SO_URL_NORTH;
            string category = "XDOCK";

            jArray = this.Create_ModelSO_Xdock();

            DataTable dtToken = DAL.GetNewToken();
            if (dtToken.Rows.Count > 0)
            {
                token = dtToken.Rows[0]["AccessToken"].ToString();
                endTime = DateTime.Parse(dtToken.Rows[0]["EndTime"].ToString());
            }

            foreach (JObject so in jArray)
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
                var orderkey_mm = so.GetValue("orderkey").ToString().Trim();
                var pokey_mm = so.GetValue("pokey").ToString().Trim();

                orderkey_mm = DAL.GetString(orderkey_mm,17);
                pokey_mm= DAL.GetString(pokey_mm, 17);

                result = await ClientHttpController.Post(so, url, token);
                if (result.check)
                {
                    DAL.UpdateStatus(pokey_mm, orderkey_mm, category);
                }
                else
                {
                    result.RecordResultAPI("XDOCK_NORTH", orderkey_mm);
                }
            }
        }

        public JArray Create_ModelSO_Xdock()
        {
            JArray orders = new JArray();
            string sqlHeader = string.Format("select * from V_MM_SO_XDOCK_HEADER_NORTH");
            DataTable dt = DAL.SELECT_SQL(sqlHeader);
            int count = dt.Rows.Count;

            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        SOInfor_Model so = new SOInfor_Model();
                        IList<Orderdetail> orderDetail = new List<Orderdetail>();

                        string orderkey_mm = dt.Rows[i]["SO"].ToString();
                        string pokey_MM = dt.Rows[i]["PO"].ToString();
                        code = pokey_MM + "_" + orderkey_mm;
                        string store= dt.Rows[i]["Store"].ToString().Trim().TrimStart('0');
                        so.type = "91";
                        so.orderkey = orderkey_mm.TrimStart('0');
                        so.storerkey = "N0528";
                        so.consigneekey = store;
                        so.externalorderkey2 = orderkey_mm;
                        so.externorderkey = dt.Rows[i]["Warehouse_Number"].ToString().Trim();
                        so.pokey = pokey_MM.TrimStart('0');
                        so.stage = store.Substring(3,2);
                        so.apportion = "0";
                        so.planneddelvdate = DateTime.Parse(dt.Rows[i]["Plan_Delivery_Date"].ToString().Trim()); //DateTime.Now.ToString('yyyy-MM-dd');
                        so.promiseddelvdate = DateTime.Parse(dt.Rows[i]["Plan_Delivery_Date"].ToString().Trim());
                        so.orderdate = DateTime.Parse(dt.Rows[i]["Plan_Delivery_Date"].ToString().Trim());

                        so.addwho = "wmsadmin";
                        so.editwho = "wmsadmin";
                        so.whseid = "wmwhse3";

                        orderDetail = this.Create_OrderDetail_Xdock(orderkey_mm, pokey_MM);
                        so.orderdetails = orderDetail;
                        string output = JsonConvert.SerializeObject(so);
                        JObject objectSO = JObject.Parse(output);
                        orders.Add(objectSO);
                    }
                    catch(Exception e)
                    {
                        string step = string.Format(Constant.MODEL_SO, "XDOCK_NORTH");
                        resultMapping.Handle_Error_Mapping(code, e.ToString(), step);
                        continue;
                    }
                    

                }
            }
            return orders;
        }

        public IList<Orderdetail> Create_OrderDetail_Xdock(string orderkey_mm, string pokey_MM)
        {
            IList<Orderdetail> orderDetails = new List<Orderdetail>();
            string sql = string.Format("select * from [V_MM_SO_XDOCK_DETAIL] where Order_Number = '{0}' and Sale_Order='{1}'", pokey_MM, orderkey_mm);
            DataTable dt = DAL.SELECT_SQL(sql);

            int count = DAL.IntReturn(dt.Rows.Count);

            for (int i = 0; i < count; i++)
            {
                try
                {
                    Orderdetail orderDetail = new Orderdetail();
                    string sku = dt.Rows[i]["Article_Number"].ToString().Trim().TrimStart('0');

                    orderDetail.orderkey = orderkey_mm.TrimStart('0');
                    orderDetail.storerkey = "N0528";
                    orderDetail.sku = sku;
                    orderDetail.openqty = DAL.IntReturn(dt.Rows[i]["Order_Quantity"]);
                    orderDetail.originalqty = DAL.IntReturn(dt.Rows[i]["Order_Quantity"]);
                    orderDetail.newallocationstrategy = "MM";
                    orderDetail.susr2 = "";
                    orderDetail.lottable02 = "BBXD";
                    orderDetail.lottable03 = pokey_MM.TrimStart('0');
                    orderDetail.lottable10 = orderkey_mm.TrimStart('0');
                    orderDetail.whseid = "wmwhse3";
                    orderDetail.addwho = "wmsadmin";
                    orderDetail.editwho = "wmsadmin";

                    orderDetails.Add(orderDetail);
                }
                catch(Exception e)
                {

                    string step = string.Format(Constant.MODEL_SODETAIL, "XDOCK_NORTH");
                    resultMapping.Handle_Error_Mapping(code, e.ToString(), step);
                    continue;
                }
                
            }
            return orderDetails;
        }
        #endregion

        #region SO Return
        public async void PostToIon_Return()
        {
            IonReponse result = new IonReponse();
            JArray jArray = new JArray();

            string url = Constant.ION_SO_URL_NORTH;
            string category = "SO_RETURN";

            jArray = this.Create_ModelSO_Return();

            DataTable dtToken = DAL.GetNewToken();
            if (dtToken.Rows.Count > 0)
            {
                token = dtToken.Rows[0]["AccessToken"].ToString();
                endTime = DateTime.Parse(dtToken.Rows[0]["EndTime"].ToString());
            }

            foreach (JObject so in jArray)
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
                var orderkey_infor = so.GetValue("orderkey").ToString().Trim();
                var pokey_mm = so.GetValue("externalorderkey2").ToString().Trim();
                

                result = await ClientHttpController.Post(so, url, token);
                if (result.check)
                {
                    DAL.UpdateStatus(pokey_mm, orderkey_infor, category);
                }
                else
                {
                    result.RecordResultAPI("SO_RETURN_NORTH", pokey_mm);
                }
            }
        }

        public JArray Create_ModelSO_Return()
        {
            JArray orders = new JArray();
            string sqlHeader = string.Format("select * from [V_MM_SO_RETURN_HEADER_NORTH]");
            DataTable dt = DAL.SELECT_SQL(sqlHeader);
            int count = dt.Rows.Count;

            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        SOInfor_Model so = new SOInfor_Model();
                        IList<Orderdetail> orderDetail = new List<Orderdetail>();

                        string po_MM = dt.Rows[i]["Order_Number"].ToString().Trim();
                        string supplier = dt.Rows[i]["Supplier_Number"].ToString().TrimStart('0');
                        code = po_MM;
                        so.type = "150";
                        string orderkey_infor = po_MM.TrimStart('0');
                        so.orderkey = "RT_" + orderkey_infor;
                        so.storerkey = "N0528";
                        so.consigneekey = "STD"; //dt.Rows[0]["Store_Number"].ToString();
                        so.externalorderkey2 = po_MM;
                        so.externorderkey = supplier;
                        so.notes2 = "";
                        so.pokey = "";
                        //so.stage = dt.Rows[0]["Store_Number"].ToString();

                        so.planneddelvdate = DateTime.Parse(dt.Rows[i]["Plan_Delivery_Date"].ToString());
                        so.promiseddelvdate = DateTime.Parse(dt.Rows[i]["Plan_Delivery_Date"].ToString());
                        so.orderdate = DateTime.Parse(dt.Rows[i]["Order_Date"].ToString());

                        so.addwho = "wmsadmin";
                        so.editwho = "wmsadmin";
                        so.whseid = "wmwhse3";

                        so.apportion = "0";
                        orderDetail = this.Create_OrderDetail_Return(po_MM, orderkey_infor);
                        so.orderdetails = orderDetail;
                        string output = JsonConvert.SerializeObject(so);
                        JObject objectSO = JObject.Parse(output);
                        orders.Add(objectSO);
                    }
                    catch(Exception e)
                    {
                        string step = string.Format(Constant.MODEL_SO, "RETURN_NORTH");
                        resultMapping.Handle_Error_Mapping(code, e.ToString(), step);
                        continue;
                    }                 
                }
            }
            return orders;
        }

        public IList<Orderdetail> Create_OrderDetail_Return(string po_mm, string orderkey_infor)
        {
            IList<Orderdetail> orderDetails = new List<Orderdetail>();
            string sql = string.Format("select * from V_MM_SO_RETURN_DETAIL_NORTH where Order_Number = '{0}'", po_mm);
            DataTable dt = DAL.SELECT_SQL(sql);

            int count = DAL.IntReturn(dt.Rows.Count);

            for (int i = 0; i < count; i++)
            {
                try
                {
                    Orderdetail orderDetail = new Orderdetail();
                    orderDetail.orderkey = "RT_" + orderkey_infor;
                    orderDetail.storerkey = "N0528";
                    string sku = dt.Rows[i]["Article_Number"].ToString().Trim().TrimStart('0');
                    orderDetail.sku = sku;
                    orderDetail.openqty = DAL.IntReturn(dt.Rows[i]["Order_Quantity"]);
                    orderDetail.originalqty = DAL.IntReturn(dt.Rows[i]["Order_Quantity"]);
                    orderDetail.newallocationstrategy = "MM";
                    orderDetail.susr2 = dt.Rows[i]["SUPPLIER"].ToString().Trim();
                    orderDetail.lottable02 = "BBXD";
                    orderDetail.lottable03 = po_mm.TrimStart('0');
                    orderDetail.lottable10 = "RT_" + orderkey_infor;
                    orderDetail.whseid = "wmwhse3";
                    orderDetail.addwho = "wmsadmin";
                    orderDetail.editwho = "wmsadmin";

                    orderDetails.Add(orderDetail);
                }
                catch(Exception e)
                {
                    string step = string.Format(Constant.MODEL_SODETAIL, "RETURN_NORTH");
                    resultMapping.Handle_Error_Mapping(code, e.ToString(), step);
                    continue;
                }
                
            }
            return orderDetails;
        }
        #endregion

        public DataTable Get_Orderkey(int count)
        {
            string sql = string.Format("Exec PP_MM_Create_orderkey {0}", count);
            DataTable dt = DAL.SELECT_SQL(sql);
            return dt;
        }

    }
}
