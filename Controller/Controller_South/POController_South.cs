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
    class POController_South
    {
        Response_Mapping resultMapping = new Response_Mapping();
        string code = "";
        string token = "";
        DateTime endTime;


        public async void PostToIon()
        {
            IonReponse result = new IonReponse();
            JArray Pos = new JArray();

            string category = "PO";
            string url = Constant.ION_PO_URL_SOUTH;

            Pos = this.Create_ModelPo();
            DataTable dtToken = DAL.GetNewToken();
            if (dtToken.Rows.Count > 0)
            {
                token = dtToken.Rows[0]["AccessToken"].ToString();
                endTime = DateTime.Parse(dtToken.Rows[0]["EndTime"].ToString());
            }
           
            foreach (JObject po in Pos)
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
                var pokey_mm = po.GetValue("externpokey").ToString().Trim();
                var pokey_infor = po.GetValue("pokey").ToString().Trim();

                result = await ClientHttpController.Post(po, url, token);
                if (result.check)
                {
                    DAL.UpdateStatus(pokey_mm, pokey_infor, category);
                }
                else
                {
                    //DAL.UpdateStatus(pokey_mm, "ERROR", category);
                    result.RecordResultAPI("PO_SOUTH", pokey_mm);
                }
            }
        }

        public JArray Create_ModelPo()
        {
            JArray pos = new JArray();
            string sqlHeader = string.Format("select * from MM_PO_HEADER where  STATUS = '' and Warehouse_Number='90071'");
            DataTable dt = DAL.SELECT_SQL(sqlHeader);

            int count = dt.Rows.Count;


            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        POInfor_Model_South po = new POInfor_Model_South();
                        IList<Podetail> podetails = new List<Podetail>();
                        string pokey_mm = dt.Rows[i]["Order_Number"].ToString().Trim();
                        code = pokey_mm;
                        string pokey_infor = dt.Rows[i]["Order_Number"].ToString().Trim().TrimStart('0');
                        string type = dt.Rows[i]["Order_Type"].ToString().Trim();
                        string category = "";

                        if (type == "19" || type == "6")
                        {
                            category = "Central Stock";
                            
                        }
                        else if (type == "02")
                        {
                            category = "RTV";

                        }
                        else
                        {
                            category = "XDOCK";
                            
                        }
                        po.susr1 = category;
                        po.potype = "0";
                        po.pokey = pokey_infor;
                        po.storerkey = "OW9600";
                        po.externpokey = pokey_mm;
                        po.externalpokey2 = dt.Rows[i]["Warehouse_Number"].ToString().Trim();
                        po.expectedreceiptdate = DateTime.Parse(dt.Rows[i]["Plan_Delivery_Date"].ToString().Trim());
                        po.podate = DateTime.Parse(dt.Rows[i]["Order_Date"].ToString().Trim());
                        po.sellername = dt.Rows[i]["Supplier_Number"].ToString().Trim().TrimStart('0');
                        po.whseid = "wmwhse10";
                        po.addwho = "wmsadmin";
                        po.editwho = "wmsadmin";
                        podetails = this.Create_PoDetail(pokey_mm, pokey_infor);
                        po.podetails = podetails;
                        string output = JsonConvert.SerializeObject(po);
                        JObject objectPo = JObject.Parse(output);
                        pos.Add(objectPo);
                    }
                    catch (Exception e)
                    {
                        string step = string.Format(Constant.MODEL_PO, "SOUTH");
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
            string sql = string.Format("MM_GET_INFORMATION_PODETAIL '{0}'", pokey_mm);
            DataTable dt = DAL.SELECT_SQL(sql);

            int count = DAL.IntReturn(dt.Rows.Count);

            for (int i = 0; i < count; i++)
            {
                try
                {
                    Podetail poDetail = new Podetail();
                    poDetail.pokey = pokey_infor;
                    poDetail.storerkey = "OW9600";
                    string sku = dt.Rows[i]["Article_Number"].ToString().Trim().TrimStart('0');
                    poDetail.sku = sku;
                    poDetail.qtyordered = DAL.IntReturn(dt.Rows[i]["Order_Quantity"]);
                    poDetail.susr1= dt.Rows[i]["Order_Quantity"].ToString();
                    poDetail.whseid = "wmwhse10";
                    poDetail.addwho = "wmsadmin";
                    poDetail.editwho = "wmsadmin";

                    poDetails.Add(poDetail);
                }
                catch (Exception e)
                {
                    string step = string.Format(Constant.MODEL_PODETAIL, "SOUTH");
                    resultMapping.Handle_Error_Mapping(code, e.ToString(), step);
                    continue;
                }

            }
            return poDetails;
        }

    }
}
