using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;

namespace MM_Project
{
    class ASNController_North
    {
        Response_Mapping resultMapping = new Response_Mapping();
        string code = "";
        string token = "";
        DateTime endTime;

        public async void PostToIon(string token)
        {
            IonReponse result = new IonReponse();
            JArray asns = new JArray();

            string category = "ASN";
            string url = Constant.ION_ASN_URL_NORTH;

            asns = this.Create_ModelAsn();
            DataTable dtToken = DAL.GetNewToken();
            if (dtToken.Rows.Count > 0)
            {
                token = dtToken.Rows[0]["AccessToken"].ToString();
                endTime = DateTime.Parse(dtToken.Rows[0]["EndTime"].ToString());
            }

            foreach (JObject asn in asns)
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
                var pokey_mm = asn.GetValue("susr1").ToString().Trim();
                var receiptkey = asn.GetValue("receiptkey").ToString().Trim();

                result = await ClientHttpController.Post(asn, url, token);
                if (result.check)
                {
                    DAL.UpdateStatus(pokey_mm, receiptkey, category);
                }
                else
                {
                    result.RecordResultAPI("ASN_NORTH", pokey_mm);
                }
            }
        }

        public JArray Create_ModelAsn()
        {
            JArray asns = new JArray();
            string sqlHeader = string.Format("select * from MM_PO_HEADER where  STATUS_ASN = '' and Warehouse_Number='90072' and Order_Number='00000202072040416'");
            DataTable dt = DAL.SELECT_SQL(sqlHeader);

            int count = dt.Rows.Count;
            DataTable dtReceiptkey = this.Get_Receiptkey(count,"90072", "ASN");


            if (count > 0 && dtReceiptkey.Rows.Count == count)
            {
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        ASNInfor_Model asn = new ASNInfor_Model();
                        IList<Receiptdetail> receiptdetails = new List<Receiptdetail>();
                        string pokey_mm = dt.Rows[i]["Order_Number"].ToString().Trim();
                        string pokey_infor = dt.Rows[i]["Order_Number"].ToString().Trim().TrimStart('0');

                        code = pokey_mm;

                        string receiptkey = dtReceiptkey.Rows[i][0].ToString();
                        asn.receiptkey = receiptkey;
                        asn.addwho = "wmsadmin";
                        asn.storerkey = "N0528";
                        asn.type = "7";
                        asn.pokey = pokey_infor;
                        asn.whseid = "wmwhse3";
                        receiptdetails = this.Create_ReceiptDetail(pokey_infor, pokey_mm, receiptkey);
                        asn.receiptdetails = receiptdetails;
                        string output = JsonConvert.SerializeObject(asn);
                        JObject objectAsn = JObject.Parse(output);
                        asns.Add(objectAsn);
                    }
                    catch (Exception e)
                    {
                        string step = string.Format(Constant.MODEL_ASN, "NORTH");
                        resultMapping.Handle_Error_Mapping(code, e.ToString(), step);
                        continue;
                    }

                }
            }

            return asns;
        }

        public IList<Receiptdetail> Create_ReceiptDetail(string pokey_infor, string pokey_mm, string receiptkey)
        {
            IList<Receiptdetail> receiptdetails = new List<Receiptdetail>();
            string sql = string.Format("select * from MM_PO_DETAIL where Order_Number = '{0}' and STATUS_ASN='' and Warehouse_Number='90072' and Order_Number='00000202072040416' ", pokey_mm);
            DataTable dt = DAL.SELECT_SQL(sql);

            int count = DAL.IntReturn(dt.Rows.Count);

            for (int i = 0; i < count; i++)
            {
                try
                {
                    Receiptdetail receiptdetail = new Receiptdetail();
                    receiptdetail.receiptkey = receiptkey;
                    receiptdetail.storerkey = "N0528";
                    string sku = dt.Rows[i]["Article_Number"].ToString().Trim().TrimStart('0');
                    receiptdetail.sku = sku;
                    receiptdetail.qtyexpected = DAL.IntReturn(dt.Rows[i]["Order_Quantity"]);
                    receiptdetail.pokey = pokey_infor;
                    receiptdetail.addwho = "wmsadmin";
                    receiptdetail.editwho = "wmsadmin";

                    receiptdetails.Add(receiptdetail);
                }
                catch (Exception e)
                {
                    string step = string.Format(Constant.MODEL_ASN_DETAIL, "NORTH");
                    resultMapping.Handle_Error_Mapping(code, e.ToString(), step);
                    continue;
                }

            }
            return receiptdetails;
        }

        public DataTable Get_Receiptkey(int count,string warehouse, string type)
        {
            string sql = string.Format("Exec [PP_MM_CREATE_RECEIPTKEY] {0} ,'{1}','{2}'", count,warehouse,type);
            DataTable dt = DAL.SELECT_SQL(sql);
            return dt;

        }
    }
}
