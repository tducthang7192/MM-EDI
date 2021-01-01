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
    public class SOController
    {
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

                    string sql = string.Format("select * from MM_ORDERS_DETAIL where Order_Number = '{0}'", orderDetail.Order_Number);
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

        public async void PostToIon(string token )
        {
            IonReponse result = new IonReponse();
            JArray jArray = new JArray();
            
            string url = Constant.ION_SO_URL_NORTH;
            string category = "SO";

            jArray = this.Create_ModelSO();

            foreach (JObject so in jArray)
            {
               
                var orderkey_infor= so.GetValue("orderkey").ToString().Trim();
                var orderkey_mm = orderkey_infor;
                result = await ClientHttpController.Post(so, url, token);
                if (result.check)
                {
                    this.Update_Satatus(orderkey_infor, orderkey_mm,category);
                }
                else
                { 
                    this.HandleError(result, orderkey_mm,category);
                }               
            }
        }

        public JArray Create_ModelSO()
        {
            JArray orders = new JArray();
            string sqlHeader= string.Format("select * from MM_ORDERS_HEADER where STATUS='' ");
            DataTable dt = DAL.SELECT_SQL(sqlHeader);
            int count = dt.Rows.Count;

            if (count > 0)
            {                              
                for (int i=0; i < count; i++)
                {
                        string type = dt.Rows[i]["Order_Type"].ToString().Trim();
                        SOInfor_Model so = new SOInfor_Model();
                        IList<Orderdetail> orderDetail = new List<Orderdetail>();
                        string orderkey_MM= dt.Rows[i]["Order_Number"].ToString();
                        string po = "";

                        switch (type)
                        {
                            case "20":
                            so.type = "91";
                            po = string.Format("select Order_Number from MM_PO_DEATIL_XD WHERE Sale_Order='{0}'", orderkey_MM);
                            DataTable xdocTable = DAL.SELECT_SQL(po);
                            if (xdocTable.Rows.Count > 0)
                            {
                                so.pokey= xdocTable.Rows[0][0].ToString();
                            }
                            else
                            {
                                continue;
                            }
                            break;

                            case " ":

                            so.type = "91";
                            po = string.Format("select Order_Number from MM_PO_DEATIL_XD WHERE Sale_Order='{0}'", orderkey_MM);
                            DataTable xdocTable2 = DAL.SELECT_SQL(po);
                            if (xdocTable2.Rows.Count > 0)
                            {
                                so.pokey = xdocTable2.Rows[0][0].ToString();
                            }
                            else
                            {
                                continue;
                            }
                            break;

                        case "19":
                                so.type = "0";
                                break;                
                        }
                        string orderkey_Infor = orderkey_MM;
                        so.orderkey = orderkey_Infor;
                        so.storerkey = "OW0094";
                        so.consigneekey = "STD"; //dt.Rows[0]["Store_Number"].ToString();
                        so.externalorderkey2 = "";
                        so.externorderkey = dt.Rows[i]["Warehouse_Number"].ToString().Trim();
                        so.notes2 = dt.Rows[i]["Memo_Field"].ToString().Trim();
                        so.pokey = "";
                        so.stage = "" ; //dt.Rows[0]["Store_Number"].ToString();

                        so.planneddelvdate = DateTime.Parse(dt.Rows[i]["Plan_Delivery_Date"].ToString());
                        so.promiseddelvdate = DateTime.Parse(dt.Rows[i]["Plan_Delivery_To_Warehouse"].ToString());
                        so.orderdate= DateTime.Parse(dt.Rows[i]["Order_Date"].ToString());

                        so.addwho = "wmsadmin";
                        so.editwho = "wmsadmin";
                        so.whseid = "wmwhse3";

                        so.apportion = "1";
                        orderDetail = this.Create_OrderDetail(orderkey_MM, orderkey_Infor);
                        so.orderdetails = orderDetail;
                        string output = JsonConvert.SerializeObject(so);
                        JObject objectSO = JObject.Parse(output);
                        orders.Add(objectSO);
                    
                        
                    }                                 
            }
            return orders;                   
        }

        public IList<Orderdetail> Create_OrderDetail(string orderkey_MM, string orderkey_Infor)
        {
            IList<Orderdetail> orderDetails = new List<Orderdetail>();
            string sql = string.Format("select * from MM_ORDERS_DETAIL where Order_Number = '{0}' and STATUS=''", orderkey_MM);
            DataTable dt = DAL.SELECT_SQL(sql);

            int count = DAL.IntReturn(dt.Rows.Count);

            for (int i = 0; i < count; i++)
            {
                Orderdetail orderDetail = new Orderdetail();
                orderDetail.orderkey = orderkey_Infor;
                orderDetail.storerkey = "OW0094";
                orderDetail.sku= dt.Rows[i]["Article_Number"].ToString();
                orderDetail.openqty =DAL.IntReturn(dt.Rows[i]["Order_Quantity"]);
                orderDetail.originalqty = DAL.IntReturn(dt.Rows[i]["Order_Quantity"]);
                orderDetail.newallocationstrategy = "N01";
                orderDetail.susr2= dt.Rows[i]["Article_Selling_Price"].ToString();

                orderDetail.whseid = "wmwhse3";
                orderDetail.addwho = "wmsadmin";
                orderDetail.editwho = "wmsadmin";

                 orderDetails.Add(orderDetail);
            }
            return orderDetails;
        }

        public DataTable Get_Orderkey(int count)
        {
            string sql = string.Format("Exec PP_Create_Orderkey_MM {0}", count);
            DataTable dt = DAL.SELECT_SQL(sql);
            return dt;
        }



        public async void PostToIon_South(string token)
        {
            IonReponse result = new IonReponse();
            JArray jArray = new JArray();

            string category = "SO";
            string url = Constant.ION_SO_URL;

            jArray = this.Create_ModelSO_South();
           
            foreach (JObject so in jArray)
            {
                var orderkey_mm = so.GetValue("externorderkey").ToString().Trim();
                var orderkey_infor = so.GetValue("orderkey").ToString().Trim();

                result = await ClientHttpController.Post(so, url, token);
                if (result.check)
                {
                    this.Update_Satatus(orderkey_infor, orderkey_mm, category);
                }
                else
                {
                    this.HandleError(result, orderkey_mm, category);
                }

            }

        }

        public JArray Create_ModelSO_South()
        {
            JArray orders = new JArray();
            string sqlHeader = string.Format("select * from MM_ORDERS_HEADER where STATUS='' and Warehouse_Number='090071'");
            DataTable dt = DAL.SELECT_SQL(sqlHeader);
            int count = dt.Rows.Count;

            DataTable dtOrderkey = this.Get_Orderkey(count);

            if (count > 0 && dtOrderkey.Rows.Count == count)
            {
                for (int i = 0; i < count; i++)
                {
                    string type = dt.Rows[i]["Order_Type"].ToString().Trim();
                    SOInfor_Model so = new SOInfor_Model();
                    IList<Orderdetail> orderDetail = new List<Orderdetail>();
                    string orderkey_MM = dt.Rows[i]["Order_Number"].ToString();
                    switch (type)
                    {
                        case "19":
                            so.type = "91";
                            string po = string.Format("select Order_Number from MM_PO_DEATIL_XD WHERE Sale_Order='{0}'", orderkey_MM);
                            DataTable xdocTable = DAL.SELECT_SQL(po);
                            if (xdocTable.Rows.Count > 0)
                            {
                                //so.purchase=poTable.Rows[0][0];
                            }
                            else
                            {
                                continue;
                            }
                            break;
                        case "20":
                            so.type = "0";
                            break;
                        case "21":
                            so.type = "100";
                            break;
                    }
                    string orderkey_Infor = dtOrderkey.Rows[i][0].ToString();
                    so.orderkey = orderkey_Infor;
                    so.externorderkey = orderkey_MM;
                    so.storerkey = "ow9305";
                    so.consigneekey = "STD";//dt.Rows[0]["Store_Number"].ToString();
                    so.externorderkey = dt.Rows[i]["Order_Number"].ToString();
                    so.externalorderkey2 = "";
                    so.whseid = "wmwhse3";
                    so.pokey = "test";

                    // so.deliverydate = Convert.ToDateTime(dt.Rows[0]["Order_Number"]);
                    so.addwho = "wmsadmin";
                    so.editwho = "wmsadmin";
                    orderDetail = this.Create_OrderDetail_South(so.externorderkey, orderkey_Infor);
                    so.orderdetails = orderDetail;
                    string output = JsonConvert.SerializeObject(so);
                    JObject objectSO = JObject.Parse(output);
                    orders.Add(objectSO);


                }
            }
            return orders;
        }

        public IList<Orderdetail> Create_OrderDetail_South(string orderkey_MM, string orderkey_Infor)
        {
            IList<Orderdetail> orderDetails = new List<Orderdetail>();
            string sql = string.Format("select * from MM_ORDERS_DETAIL where Order_Number = '{0}' and STATUS='' and Warehouse_Number='090071'", orderkey_MM);
            DataTable dt = DAL.SELECT_SQL(sql);
            int count = DAL.IntReturn(dt.Rows.Count);

            for (int i = 0; i < count; i++)
            {
                Orderdetail orderDetail = new Orderdetail();
                orderDetail.orderkey = orderkey_Infor;
                orderDetail.storerkey = "ow9305";
                orderDetail.sku = dt.Rows[i]["Article_Number"].ToString();
                orderDetail.openqty = DAL.IntReturn(dt.Rows[i]["Order_Quantity"]);
                orderDetail.originalqty = DAL.IntReturn(dt.Rows[i]["Order_Quantity"]);
                orderDetail.newallocationstrategy = "N01";
                orderDetail.whseid = "wmwhse3";
                orderDetail.addwho = "wmsadmin";
                orderDetail.editwho = "wmsadmin";

                orderDetails.Add(orderDetail);
            }
            return orderDetails;
        }

        public DataTable Get_Orderkey_South(int count)
        {
            string sql = string.Format("Exec PP_Create_Orderkey_MM {0}", count);
            DataTable dt = DAL.SELECT_SQL(sql);
            return dt;
        }



        public void HandleError(IonReponse result, string orderkey_mm, string type)
        {
            if (result.check == false)
            {
                result.RecordResultAPI(type, orderkey_mm);
            }
        }

        public void Update_Satatus(string orderkey_infor, string orderkey_mm, string category)
        {
            string sql = string.Format(" exec [MM_UPDATE_STATUS] '{0}','{1}','{2}'", orderkey_mm, orderkey_infor, category);
            DAL.SELECT_SQL(sql);
        }

    }
}
