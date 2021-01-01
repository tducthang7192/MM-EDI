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
    class ArticlesController_South
    {
        Response_Mapping resultMapping = new Response_Mapping();
        string code = "";
        string token = "";
        DateTime endTime;
        public async void PostToIon()
        {
            IonReponse result = new IonReponse();
            JArray items = new JArray();
            PackController packController = new PackController();
            string url = Constant.ION_SKU_ENTERPRISE_URL_SOUTH;
            items = this.Create_ModelSku();
            DataTable dtToken = DAL.GetNewToken();
            if (dtToken.Rows.Count > 0)
            {
                token = dtToken.Rows[0]["AccessToken"].ToString();
                endTime = DateTime.Parse(dtToken.Rows[0]["EndTime"].ToString());
            }
            foreach (JObject item in items)
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
                string category = "Sku_Interprise_South";
                string sku_code = item.GetValue("sku").ToString().Trim();
                sku_code = DAL.GetString(sku_code, 8);

                bool checkPack = await packController.PostPack_ToIon_South(token, sku_code,"NEW");
                //if (checkPack)
                //{
                    result = await ClientHttpController.Post(item, url, token);
                    if (!result.check)
                    {
                        result.RecordResultAPI(category, sku_code);
                        continue;
                    }
                    else
                    {
                        this.PostToIon_Warehouse(item, token, sku_code);
                    }

                //}
                //else
                //{
                //    DAL.UpdateStatus(sku_code, "ERROR_PACK", "SKU_SOUTH");
                //    continue;
                //}
            }
        }

        public async void PostToIon_Warehouse(JObject model, string token, string sku)
        {
            IonReponse result = new IonReponse();
            JArray altSkus = new JArray();

            string url = Constant.ION_SKU_WAREHOUSE_URL_SOUTH;

            altSkus = this.Create_ModelAltSku(sku);

            model.Add("altSkus", altSkus);

            result = await ClientHttpController.Post(model, url, token);
            string category = "Sku_Warehouse_South";
            if (result.check)
            {
                DAL.UpdateStatus(sku, "OK", "SKU_SOUTH");
            }
            else
            {
                result.RecordResultAPI(category, sku);
                DAL.UpdateStatus(sku, "ERROR_WAREHOUSE", "SKU_SOUTH");
            }

        }

        public async void Post_Update_Sku()
        {
            IonReponse result = new IonReponse();
            JArray items = new JArray();
            PackController packController = new PackController();
            string url = Constant.ION_SKU_ENTERPRISE_URL_SOUTH;
            items = this.Update_ModelSku();
            DataTable dtToken = DAL.GetNewToken();
            if (dtToken.Rows.Count > 0)
            {
                token = dtToken.Rows[0]["AccessToken"].ToString();
                endTime = DateTime.Parse(dtToken.Rows[0]["EndTime"].ToString());
            }
            foreach (JObject item in items)
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
                string category = "Update_Sku_Enterprise_South";
                string sku_code = item.GetValue("sku").ToString().Trim();
                sku_code = DAL.GetString(sku_code, 8);

                bool checkPack = await packController.PostPack_ToIon_South(token, sku_code, "UPDATE");

                result = await ClientHttpController.Post(item, url, token);
                if (!result.check)
                {
                    result.RecordResultAPI(category, sku_code);
                    continue;
                }
                else
                {
                    this.Post_Update_Sku_Warehouse(item, token, sku_code);
                }
            }
        }

        public async void Post_Update_Sku_Warehouse(JObject model, string token, string sku)
        {
            IonReponse result = new IonReponse();
            JArray altSkus = new JArray();

            string url = Constant.ION_SKU_WAREHOUSE_URL_SOUTH;

            result = await ClientHttpController.Post(model, url, token);
            string category = "Update_Sku_Warehouse_South";
            if (result.check)
            {
                DAL.UpdateStatus(sku, "UPDATE", "SKU_SOUTH");
            }
            else
            {
                result.RecordResultAPI(category, sku);
                DAL.UpdateStatus(sku, "ERROR_UPDATE_WAREHOUSE", "SKU_SOUTH");
            }

        }

        public JArray Create_ModelSku()
        {
            JArray items = new JArray();
            string sql = string.Format("exec PR_MM_ARTICLES_INFORMATION '{0}'", "SOUTH");
            DataTable dt = DAL.SELECT_SQL(sql);

            if (dt.Rows.Count > 0)
            {
                int count = dt.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        SkuInfor_Model_South item = new SkuInfor_Model_South();
                        item.storerkey = "OW9600";
                        string sku = dt.Rows[i]["Article_Number"].ToString().Trim();
                        code = dt.Rows[i]["Article_Number"].ToString().Trim();
                        sku = sku.TrimStart('0');

                        int qtyPerCase = DAL.IntReturn(dt.Rows[0]["Number_Mu_Carton"]);
                        decimal carton_grossWeight = DAL.DecimalReturn(dt.Rows[i]["Carton_GrossWeight"]);
                        decimal carton_netWeight = DAL.DecimalReturn(dt.Rows[i]["Carton_NetWeight"]);
                        decimal carton_cube = DAL.DecimalReturn(dt.Rows[i]["Carton_Gross_Volume"]);
                        decimal carton_length = DAL.DecimalReturn(dt.Rows[i]["Carton_Length"]);
                        decimal carton_width = DAL.DecimalReturn(dt.Rows[i]["Carton_Width"]);
                        decimal carton_height = DAL.DecimalReturn(dt.Rows[i]["Carton_Height"]);
                        decimal grossWeight = (carton_grossWeight / qtyPerCase);
                        grossWeight = Math.Round(grossWeight, 5);
                        decimal netWeight = grossWeight;
                        decimal cube_cm3 = ((carton_length*carton_width*carton_height) / qtyPerCase );
                        decimal tareWeight_cm3 = grossWeight - netWeight;
                        item.sku = sku;
                        item.descr = dt.Rows[i]["Desc_Article"].ToString().Trim().Replace("'", "\""); 
                        item.addwho = "addmin";
                        item.editwho = "admin";
                        item.sourceversion = "0";
                        item.susr1 = dt.Rows[i]["susr1"].ToString().Trim().TrimStart('0');
                        item.susr2 = dt.Rows[i]["susr2"].ToString().Trim();
                        item.susr3 = dt.Rows[i]["susr3"].ToString().Trim();
                        item.susr4 = dt.Rows[i]["susr4"].ToString().Trim();
                        item.susr5 = dt.Rows[i]["susr5"].ToString().Trim();
                        item.susr6 = dt.Rows[i]["susr6"].ToString().Trim();
                        item.susr7 = dt.Rows[i]["susr7"].ToString().Trim();
                        item.susr8 = dt.Rows[i]["susr8"].ToString().Trim();
                        item.susr9 = dt.Rows[i]["susr9"].ToString().Trim();
                        item.susr10 = dt.Rows[i]["susr10"].ToString().Trim();
                        item.packkey = sku + "_MMSOUTH";
                        item.rfdefaultpack = sku + "_MMSOUTH";
                        item.itemcharacteristic1 = dt.Rows[i]["Article_Group1"].ToString().Trim();//dt.Rows[i]["Article_Group_Number"].ToString().Trim();
                        item.itemcharacteristic2 = dt.Rows[i]["Article_Group2"].ToString().Trim();//dt.Rows[i]["Artice_Subgroup_Number"].ToString().Trim(); 
                        item.stdgrosswgt = grossWeight.ToString();
                        item.stdnetwgt = netWeight.ToString();
                        item.stdcube = cube_cm3.ToString();
                        item.tare = tareWeight_cm3.ToString();
                        item.onreceiptcopypackkey = "0";
                        item.rotateby = "Lot";
                        string logisticFlow= dt.Rows[i]["Logistic_Flow_Indicator"].ToString().Trim();


                        if (logisticFlow == "19")
                        {
                            item.shelflifeindicator = "Y";
                            item.toexpiredays = dt.Rows[i]["Expiry_Days"].ToString().Trim();
                            item.lottablevalidationkey = "MMSOUTH";
                            item.flowthruitem = "Y";
                            item.cartonizeft = "1";
                            item.groupfteach = "1";
                        }
                        else
                        {
                            item.shelflifeindicator = "N";
                            item.toexpiredays = "0";
                            #region
                            /*nếu shelflifeindicator là N thì phải để shelflife= 0 , nếu không 
                            sẽ báo lỗi localizedMessage internal server*/
                            #endregion
                            item.shelflife = "0";
                            item.lottablevalidationkey = "MMSOUTH";
                            item.flowthruitem = "Y";
                            item.cartonizeft = "1"; // item.cartonizeft = "1";
                            item.groupfteach = "1";
                        }

                        item.odeweight = "1";
                        item.rfdefaultuom = "MU";
                        
                        item.putawaystrategykey = "STD";
                        item.newallocationstrategy = "CS";//CS
                        
                        item.barcodeconfigkey = "";
                        item.collection = "";
                        item.shelflifecodetype = "E"; // M -manufacturing E- expriation
                        item.lottable01label = "Lottable01";
                        item.lottable02label = "Lottable02";
                        item.lottable03label = "Lottable03";
                        item.lottable04label = "Manufacturing Date";
                        item.lottable05label = "Expiration Date";
                        item.lottable06label = "Lottable06";
                        item.lottable07label = "Lottable07";
                        item.lottable08label = "Lottable08";
                        item.lottable09label = "ASN";
                        item.lottable10label = "PO";
                        item.snumlength = "0";
                        item.snumincrlength = "0";
                        item.allowmultilotlpn = "1";

                        string output = JsonConvert.SerializeObject(item);

                        JObject objectitem = JObject.Parse(output);
                        items.Add(objectitem);
                    }
                    catch(Exception e)
                    {
                        string step = string.Format(Constant.MODEL_SKU, "SOUTH");
                        resultMapping.Handle_Error_Mapping(code, e.ToString(), step);
                        continue;
                    }                  
                }
            }
            return items;

        }

        public JArray Create_ModelAltSku(string sku)
        {
            JArray altSkus = new JArray();
            string sql = string.Format("PR_MM_BARCODE_ARTICLES_INFORMATION '{0}' , '{1}' ", "SOUTH",sku);
            DataTable dt = DAL.SELECT_SQL(sql);
            if (dt.Rows.Count > 0)
            {
                code = sku;
                sku = sku.TrimStart('0');
                int count = DAL.IntReturn(dt.Rows.Count);
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        AltSku altSku = new AltSku();
                        altSku.altsku = dt.Rows[i]["Barcode"].ToString();
                        altSku.storerkey = "OW9600";
                        altSku.sku = sku;
                        string output = JsonConvert.SerializeObject(altSku);
                        JObject objectAltSku = JObject.Parse(output);
                        altSkus.Add(objectAltSku);
                    }
                    catch(Exception e)
                    {
                        string step = string.Format(Constant.MODEL_ALTSKU, "SOUTH");
                        resultMapping.Handle_Error_Mapping(code, e.ToString(), step);
                        continue;
                    }
                    
                }
            }

            return altSkus;
        }

        public JArray Update_ModelSku()
        {
            JArray items = new JArray();
            string sql = string.Format("exec [PP_MM_UPDATE_ARTICLES] '{0}'", "SOUTH");
            DataTable dt = DAL.SELECT_SQL(sql);

            if (dt.Rows.Count > 0)
            {
                int count = dt.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        SkuInfor_Model_Update_South item = new SkuInfor_Model_Update_South();
                        item.storerkey = "OW9600";
                        string sku = dt.Rows[i]["Article_Number"].ToString().Trim();
                        code = dt.Rows[i]["Article_Number"].ToString().Trim();
                        sku = sku.TrimStart('0');

                        int qtyPerCase = DAL.IntReturn(dt.Rows[0]["Number_Mu_Carton"]);
                       // decimal carton_grossWeight = DAL.DecimalReturn(dt.Rows[i]["Carton_GrossWeight"]);
                       // decimal carton_netWeight = DAL.DecimalReturn(dt.Rows[i]["Carton_NetWeight"]);
                       // decimal grossWeight = (carton_grossWeight / qtyPerCase);
                        //grossWeight = Math.Round(grossWeight, 5);
                        //decimal netWeight = grossWeight;
                       //decimal cube_cm3 = DAL.DecimalReturn(dt.Rows[i]["STDCUBE_NEW"]);                       
                       // decimal tareWeight_cm3 = grossWeight - netWeight;
                       
                        //cube_cm3 =    Math.Round(cube_cm3, 5);

                        item.sku = sku;
                        item.descr = dt.Rows[i]["Desc_Article"].ToString().Trim().Replace("'", "\"");
                        item.addwho = "addmin";
                        item.editwho = "admin";
                        item.susr1 = dt.Rows[i]["susr1"].ToString().Trim().TrimStart('0');
                        item.susr3 = dt.Rows[i]["susr3"].ToString().Trim();

                        item.packkey = sku + "_MMSOUTH";
                        //item.stdgrosswgt = grossWeight.ToString();
                        //item.stdnetwgt = netWeight.ToString();
                        //item.stdcube = cube_cm3.ToString();
                        //item.tare = tareWeight_cm3.ToString();
                        string logisticFlow = dt.Rows[i]["Logistic_Flow_Indicator"].ToString().Trim();
                        item.shelflifecodetype = "E";


                        if (logisticFlow == "19")
                        {
                            item.shelflifeindicator = "Y";
                            item.toexpiredays = dt.Rows[i]["Expiry_Days"].ToString().Trim();
                        }
                        else
                        {
                            item.shelflifeindicator = "N";
                            item.toexpiredays = "0";
                            #region
                            /*nếu shelflifeindicator là N thì phải để shelflife= 0 , nếu không 
                            sẽ báo lỗi localizedMessage internal server*/
                            #endregion
                            item.shelflife = "0";
                        }

                        string output = JsonConvert.SerializeObject(item);

                        JObject objectitem = JObject.Parse(output);
                        items.Add(objectitem);
                    }
                    catch (Exception e)
                    {
                        string step = string.Format(Constant.MODEL_SKU, "SOUTH");
                        resultMapping.Handle_Error_Mapping(code, e.ToString(), step);
                        continue;
                    }
                }
            }
            return items;

        }
    }
}
