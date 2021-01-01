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
    class SOController_South
    {
        Response_Mapping resultMapping = new Response_Mapping();
        string code = "";
        string token = "";
        DateTime endTime;

        #region SO CS
        public async void PostToIon()
        {
            IonReponse result = new IonReponse();
            JArray jArray = new JArray();

            string url = Constant.ION_SO_URL_SOUTH;
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
                if (resDate<0 || resDate==0)
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
                var orderkey_mm = so.GetValue("externalorderkey2").ToString().Trim();

                result = await ClientHttpController.Post(so, url, token);
                if (result.check)
                {
                    DAL.UpdateStatus(orderkey_mm, orderkey_infor, category);
                }
                else
                {
                   // DAL.UpdateStatus(orderkey_mm, "ERROR", category);
                    result.RecordResultAPI("SO_CS_SOUTH", orderkey_mm);
                }
            }
        }

        public JArray Create_ModelSO()
        {
            JArray orders = new JArray();
            string sqlHeader = string.Format("select * from MM_ORDERS_HEADER where STATUS='' and Warehouse_Number='90071' ");
            DataTable dt = DAL.SELECT_SQL(sqlHeader);
            int count = dt.Rows.Count;
            DataTable dtOrderkey = this.Get_Orderkey_South(count, "90071", "CS");
            if (count > 0 && dtOrderkey.Rows.Count == count)
            {
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        SOInfor_Model_South so = new SOInfor_Model_South();
                        IList<Orderdetail_South> orderDetail = new List<Orderdetail_South>();

                        string type = dt.Rows[i]["Order_Type"].ToString().Trim();
                        string orderkey_infor = dtOrderkey.Rows[i][0].ToString();
                        string orderkey_mm= dt.Rows[i]["Order_Number"].ToString().Trim();
                        string storer = dt.Rows[i]["Store_Number"].ToString().Trim().TrimStart('0');
                        string externorderkey = "S" + storer.Substring(3, 2);

                        code = orderkey_mm;
                        

                        so.type = "9602";
                        so.orderkey = orderkey_infor;
                        so.storerkey = "OW9600";
                        so.consigneekey = storer;
                        so.externalorderkey2 = orderkey_mm;
                        so.externorderkey = externorderkey;
                        so.notes2 = dt.Rows[i]["Memo_Field"].ToString().Trim();
                        so.pokey = "";
                        so.requestedshipdate = DateTime.Parse(dt.Rows[i]["Plan_Delivery_Date"].ToString());
                        so.deliverydate = DateTime.Parse(dt.Rows[i]["Plan_Delivery_To_Warehouse"].ToString());
                        so.orderdate = DateTime.Parse(dt.Rows[i]["Order_Date"].ToString());
                        so.addwho = "wmsadmin";
                        so.editwho = "wmsadmin";
                        so.whseid = "wmwhse10";

                        orderDetail = this.Create_OrderDetail(orderkey_mm, orderkey_infor);
                        so.orderdetails = orderDetail;
                        string output = JsonConvert.SerializeObject(so);
                        JObject objectSO = JObject.Parse(output);
                        orders.Add(objectSO);
                    }
                    catch(Exception e)
                    {
                        string step = string.Format(Constant.MODEL_SO, "CS_SOUTH");
                        resultMapping.Handle_Error_Mapping(code, e.ToString(), step);
                        continue;
                    }                 
                }
            }
            return orders;
        }

        public IList<Orderdetail_South> Create_OrderDetail(string orderkey_mm, string orderkey_infor)
        {
            IList<Orderdetail_South> orderDetails = new List<Orderdetail_South>();
            string sql = string.Format("select * from MM_ORDERS_DETAIL where Order_Number = '{0}' and STATUS='' and Warehouse_Number='90071' ", orderkey_mm);
            DataTable dt = DAL.SELECT_SQL(sql);

            int count = DAL.IntReturn(dt.Rows.Count);

            for (int i = 0; i < count; i++)
            {
                try
                {
                    Orderdetail_South orderDetail = new Orderdetail_South();
                    string sku = dt.Rows[i]["Article_Number"].ToString().Trim().TrimStart('0');

                    orderDetail.orderkey = orderkey_infor;
                    orderDetail.storerkey = "OW9600";
                    orderDetail.sku = sku;
                    orderDetail.uom = "MU";
                    orderDetail.openqty = DAL.IntReturn(dt.Rows[i]["Order_Quantity"]);
                    orderDetail.originalqty = DAL.IntReturn(dt.Rows[i]["Order_Quantity"]);
                    orderDetail.newallocationstrategy = "INPROCESS";
                    orderDetail.susr2 = dt.Rows[i]["Article_Selling_Price"].ToString().Trim();
                    orderDetail.whseid = "wmwhse10";
                    orderDetail.addwho = "wmsadmin";
                    orderDetail.editwho = "wmsadmin";

                    orderDetails.Add(orderDetail);
                }
                catch(Exception e)
                {
                    string step = string.Format(Constant.MODEL_SODETAIL, "CS_SOUTH");
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

            string url = Constant.ION_SO_URL_SOUTH;
            string category = "XDOCK_SOUTH";

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
                var orderkey_mm = so.GetValue("susr1").ToString().Trim();
                var orderkey_infor = so.GetValue("orderkey").ToString().Trim();

                orderkey_mm = DAL.GetString(orderkey_mm, 17);

                result = await ClientHttpController.Post(so, url, token);
                if (result.check)
                {
                    DAL.UpdateStatus(orderkey_mm,orderkey_infor,category);
                }
                else
                {
                    //DAL.UpdateStatus(orderkey_mm, "ERROR", category);
                    result.RecordResultAPI("SO_XDOCK_SOUTH", orderkey_mm);
                }
            }
        }

        public JArray Create_ModelSO_Xdock()
        {
            JArray orders = new JArray();
            string sqlHeader = string.Format("select * from V_MM_SO_XDOCK_HEADER_SOUTH ");
            DataTable dt = DAL.SELECT_SQL(sqlHeader);
            int count = dt.Rows.Count;
            DataTable dtOrderkey = this.Get_Orderkey_South(count,"90071","XD");

            if (count > 0 && dtOrderkey.Rows.Count == count)
            {
                for (int i = 0; i < count; i++)
                {
                    try
                    {

                        SOInfor_Model_South so = new SOInfor_Model_South();
                        IList<Orderdetail_South> orderDetail = new List<Orderdetail_South>();
                        string orderkey_infor= dtOrderkey.Rows[i][0].ToString();
                        string orderkey_mm = dt.Rows[i]["SO"].ToString();

                        code = orderkey_mm;
                        string storer= dt.Rows[i]["Store"].ToString();
                        string externorderkey = "S" + storer.Substring(3, 2);
                        so.type = "0";
                        so.orderkey = orderkey_infor;
                        so.storerkey = "OW9600";
                        so.consigneekey = dt.Rows[i]["Store"].ToString();
                        so.externalorderkey2 = orderkey_mm;
                        so.externorderkey = externorderkey;
                        so.susr1 = orderkey_mm;
                        
                        so.requestedshipdate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")); //DateTime.Parse(dt.Rows[i]["Plan_Delivery_Date"].ToString().Trim()); 
                        so.deliverydate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                        so.orderdate = DateTime.Parse(dt.Rows[i]["Order_Date"].ToString().Trim());

                        so.addwho = "wmsadmin";
                        so.editwho = "wmsadmin";
                        so.whseid = "wmwhse10";

                        orderDetail = this.Create_OrderDetail_Xdock(orderkey_infor, orderkey_mm);
                        so.orderdetails = orderDetail;
                        string output = JsonConvert.SerializeObject(so);
                        JObject objectSO = JObject.Parse(output);
                        orders.Add(objectSO);
                    }
                    catch(Exception e)
                    {
                        string step = string.Format(Constant.MODEL_SO, "XDOCK_SOUTH");
                        resultMapping.Handle_Error_Mapping(code, e.ToString(), step);
                        continue;
                    }
                   

                }
            }
            return orders;
        }

        public IList<Orderdetail_South> Create_OrderDetail_Xdock(string orderkey_infor, string orderkey_mm)
        {
            IList<Orderdetail_South> orderDetails = new List<Orderdetail_South>();
            string sql = string.Format("select * from [V_MM_SO_XDOCK_DETAIL] where  Sale_Order='{0}'", orderkey_mm);
            DataTable dt = DAL.SELECT_SQL(sql);

            int count = DAL.IntReturn(dt.Rows.Count);

            for (int i = 0; i < count; i++)
            {
                try
                {
                    Orderdetail_South orderDetail = new Orderdetail_South();
                    string sku = dt.Rows[i]["Article_Number"].ToString().Trim().TrimStart('0');
                    string pokey_mm= dt.Rows[i]["Order_Number"].ToString().Trim();
                    orderDetail.orderkey = orderkey_infor;
                    orderDetail.storerkey = "OW9600";
                    orderDetail.sku = sku;
                    orderDetail.uom = "MU";
                    orderDetail.openqty = DAL.IntReturn(dt.Rows[i]["Order_Quantity"]);
                    orderDetail.originalqty = DAL.IntReturn(dt.Rows[i]["Order_Quantity"]);
                    orderDetail.newallocationstrategy = "X_DOCKING";
                    orderDetail.lottable10 = pokey_mm.TrimStart('0');
                    orderDetail.whseid = "wmwhse10";
                    orderDetail.addwho = "wmsadmin";
                    orderDetail.editwho = "wmsadmin";

                    orderDetails.Add(orderDetail);
                }
                catch(Exception e)
                {
                    string step = string.Format(Constant.MODEL_SODETAIL, "XDOCK_SOUTH");
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

            string url = Constant.ION_SO_URL_SOUTH;
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
                    //DAL.UpdateStatus(pokey_mm, "ERROR", category);
                    result.RecordResultAPI("SO_RETURN_SOUTH", pokey_mm);
                }
            }
        }

        public JArray Create_ModelSO_Return()
        {
            JArray orders = new JArray();
            string sqlHeader = string.Format("select * from [V_MM_SO_RETURN_HEADER_SOUTH] ");
            DataTable dt = DAL.SELECT_SQL(sqlHeader);
            int count = dt.Rows.Count;
            DataTable dtOrderkey = this.Get_Orderkey_South(count, "90071", "RT");

            if (count > 0 && dtOrderkey.Rows.Count == count)
            {
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        SOInfor_Model_South so = new SOInfor_Model_South();
                        IList<Orderdetail_South> orderDetail = new List<Orderdetail_South>();
                        string orderkey_infor = dtOrderkey.Rows[i][0].ToString();
                        string po_MM = dt.Rows[i]["Order_Number"].ToString().Trim();
                        string supplier = dt.Rows[i]["Supplier_Number"].ToString().TrimStart('0');
                        string externorderkey = supplier;
                        code = po_MM;

                        so.type = "9603";                      
                        so.orderkey = orderkey_infor;
                        so.storerkey = "OW9600";
                        so.consigneekey = "STD";
                        so.externalorderkey2 = po_MM;
                        so.externorderkey = externorderkey;
                        so.susr2 = "";
                        so.notes2 = "";
                        so.pokey = "";

                        so.requestedshipdate = DateTime.Parse(dt.Rows[i]["Plan_Delivery_Date"].ToString());
                        so.deliverydate = DateTime.Parse(dt.Rows[i]["Plan_Delivery_Date"].ToString());
                        so.orderdate = DateTime.Parse(dt.Rows[i]["Order_Date"].ToString());

                        so.addwho = "wmsadmin";
                        so.editwho = "wmsadmin";
                        so.whseid = "wmwhse10";

                        orderDetail = this.Create_OrderDetail_Return(po_MM, orderkey_infor);
                        so.orderdetails = orderDetail;
                        string output = JsonConvert.SerializeObject(so);
                        JObject objectSO = JObject.Parse(output);
                        orders.Add(objectSO);
                    }
                    catch(Exception e)
                    {
                        string step = string.Format(Constant.MODEL_SO, "RETURN_SOUTH");
                        resultMapping.Handle_Error_Mapping(code, e.ToString(), step);
                        continue;
                    }                 
                }
            }
            return orders;
        }

        public IList<Orderdetail_South> Create_OrderDetail_Return(string po_mm, string orderkey_infor)
        {
            IList<Orderdetail_South> orderDetails = new List<Orderdetail_South>();
            string sql = string.Format("select * from V_MM_SO_RETURN_DETAIL_SOUTH where Order_Number = '{0}'", po_mm);
            DataTable dt = DAL.SELECT_SQL(sql);

            int count = DAL.IntReturn(dt.Rows.Count);

            for (int i = 0; i < count; i++)
            {
                try
                {
                    Orderdetail_South orderDetail = new Orderdetail_South();
                    orderDetail.orderkey = orderkey_infor;
                    orderDetail.storerkey = "OW9600";
                    string sku = dt.Rows[i]["Article_Number"].ToString().Trim().TrimStart('0');
                    orderDetail.sku = sku;
                    orderDetail.uom = "MU";
                    orderDetail.openqty = DAL.IntReturn(dt.Rows[i]["Order_Quantity"]);
                    orderDetail.originalqty = DAL.IntReturn(dt.Rows[i]["Order_Quantity"]);
                    orderDetail.susr2 = dt.Rows[i]["SUPPLIER"].ToString().Trim();
                    orderDetail.lottable10 = po_mm.TrimStart('0');
                    orderDetail.newallocationstrategy = "RTV";
                    orderDetail.whseid = "wmwhse10";
                    orderDetail.addwho = "wmsadmin";
                    orderDetail.editwho = "wmsadmin";

                    orderDetails.Add(orderDetail);
                }
                catch(Exception e)
                {
                    string step = string.Format(Constant.MODEL_SODETAIL, "RETURN_SOUTH");
                    resultMapping.Handle_Error_Mapping(code, e.ToString(), step);
                    continue;
                }
                
            }
            return orderDetails;
        }
        #endregion

        public DataTable Get_Orderkey_South(int count,string warehouse, string type)
        {
            string sql = string.Format("Exec PP_MM_Create_Orderkey {0} ,'{1}', '{2}'", count,warehouse,type);
            DataTable dt = DAL.SELECT_SQL(sql);
            return dt;
        }

    }
}
