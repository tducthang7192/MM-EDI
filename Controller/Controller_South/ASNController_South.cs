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
    class ASNController_South
    {
        Response_Mapping resultMapping = new Response_Mapping();
        string code = "";
        string token = "";
        DateTime endTime;

        public async void PostToIon()
        {
            IonReponse result = new IonReponse();
            JArray asns = new JArray();

            string category = "ASN_SOUTH";
            string url = Constant.ION_ASN_URL_SOUTH;

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
                var pokey_mm = asn.GetValue("pokey").ToString().Trim();
                pokey_mm = DAL.GetString(pokey_mm,17);
                var receiptkey = asn.GetValue("receiptkey").ToString().Trim();

                result = await ClientHttpController.Post(asn, url, token);
                if (result.check)
                {
                    DAL.UpdateStatus(pokey_mm, receiptkey, category);
                }
                else
                {
                    result.RecordResultAPI(category, pokey_mm);
                }
            }
        }

        public JArray Create_ModelAsn()
        {
            JArray asns = new JArray();
            string sqlHeader = string.Format("select * from MM_PO_HEADER where  STATUS_ASN = '' and Warehouse_Number='90071' and Order_Type='02'");   
            DataTable dt = DAL.SELECT_SQL(sqlHeader);

            int count = dt.Rows.Count;
            DataTable dtReceiptkey = this.Get_Receiptkey(count,"90071", "ASN");


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
                        string supplier= dt.Rows[i]["Supplier_Number"].ToString().Trim().TrimStart('0');
                        asn.receiptkey = receiptkey;
                        asn.addwho = "wmsadmin";
                        asn.storerkey = "OW9600";

                        asn.suppliercode = "RTV-" + supplier;
                        asn.type = "RTV-BBXD";
                        asn.pokey = pokey_infor;
                        asn.whseid = "wmwhse10";
                        receiptdetails = this.Create_ReceiptDetail(pokey_infor, pokey_mm, receiptkey);
                        asn.receiptdetails = receiptdetails;
                        string output = JsonConvert.SerializeObject(asn);
                        JObject objectAsn = JObject.Parse(output);
                        asns.Add(objectAsn);
                    }
                    catch (Exception e)
                    {
                        string step = string.Format(Constant.MODEL_ASN, "SOUTH");
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
            string sql = string.Format("select * from MM_PO_DETAIL where Order_Number = '{0}' and STATUS_ASN='' and Warehouse_Number='90071' ", pokey_mm);
            DataTable dt = DAL.SELECT_SQL(sql);

            int count = DAL.IntReturn(dt.Rows.Count);

            for (int i = 0; i < count; i++)
            {
                try
                {
                    Receiptdetail receiptdetail = new Receiptdetail();
                    receiptdetail.receiptkey = receiptkey;
                    receiptdetail.storerkey = "OW9600";
                    string sku = dt.Rows[i]["Article_Number"].ToString().Trim().TrimStart('0');
                    receiptdetail.sku = sku;
                    receiptdetail.qtyexpected = DAL.IntReturn(dt.Rows[i]["Order_Quantity"]);
                    receiptdetail.pokey = pokey_infor;
                    receiptdetail.lottable10 = pokey_infor;
                    receiptdetail.toloc = "RTV";
                    receiptdetail.toid = "R"+pokey_infor;
                    receiptdetail.addwho = "wmsadmin";
                    receiptdetail.editwho = "wmsadmin";

                    receiptdetails.Add(receiptdetail);
                }
                catch (Exception e)
                {
                    string step = string.Format(Constant.MODEL_ASN_DETAIL, "SOUTH");
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
