using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using MM_EDI;
using System.Threading.Tasks;

namespace MM_Project
{
    public class ArticlesController_North
    {
        Response_Mapping resultMapping = new Response_Mapping();
        string code = "";
        string token = "";
        DateTime endTime;
        public ResultDatabase_Model InsertDatabase(string text, int indicator, string fileName)
        {   bool check = false;
            ResultDatabase_Model result = new ResultDatabase_Model();
            Response_ReadFile error = new Response_ReadFile();
            if (indicator == 3)
            {
                Articles_Model article = new Articles_Model();
                try
                {
                    article.Table_Indicator = DAL.IntReturn(text.Substring(0, 1));
                    article.Action_Code = text.Substring(1, 1);

                    article.Lsp_Identification = text.Substring(2, 4);

                    string sku = text.Substring(6, 20);
                    article.Article_Number = sku.Substring(12, 8);

                    string shipFrom = text.Substring(26, 20);
                    article.Supplier_Code = shipFrom.Substring(14, 6);

                    int buyingUnit = DAL.IntReturn(text.Substring(58, 7));
                    article.Buying_Unit = DAL.DecimalReturn(DAL.ChangeValue(3, buyingUnit));

                    article.Selling_Unit = DAL.IntReturn(text.Substring(65, 4));

                    string orderUnit = text.Substring(69, 4);
                    article.Ordering_Unit = orderUnit.Substring(1, 3);


                    article.Article_Type = DAL.IntReturn(text.Substring(73, 1));
                    article.Article_Status = DAL.IntReturn(text.Substring(75, 1));
                    article.Buyer_User_Id = text.Substring(93, 6);
                    article.Desc_Article = text.Substring(99, 33).Replace("'", "\"");
                    article.Packing_Type = text.Substring(132, 2);


                    article.Article_Related = DAL.IntReturn(text.Substring(134, 20));


                    article.EAN_Code = text.Substring(154, 14);

                    string supplierArticle = text.Substring(168, 14);
                    article.Supplier_Article_Number = supplierArticle.Substring(0, 8);


                    article.Article_Desc = text.Substring(182, 33);
                    article.Number_Mu_Carton = DAL.IntReturn(text.Substring(215, 6));
                    article.Number_Mu_Layer = DAL.IntReturn(text.Substring(221, 6));
                    article.Number_Mu_Pallet = DAL.IntReturn(text.Substring(227, 6));

                    int cartonLength = DAL.IntReturn(text.Substring(233, 8));
                    article.Carton_Length = DAL.DecimalReturn(DAL.ChangeValue(2, cartonLength));

                    int cartonGrossweight = DAL.IntReturn(text.Substring(241, 9));
                    article.Carton_GrossWeight = DAL.DecimalReturn(DAL.ChangeValue(2, cartonGrossweight));

                    int cartonNetweight = DAL.IntReturn(text.Substring(250, 9));
                    article.Carton_NetWeight = DAL.DecimalReturn(DAL.ChangeValue(2, cartonNetweight));


                    article.Warehouse_Number = text.Substring(259, 5);

                    string dateRecord = text.Substring(264, 8);
                    int year = DAL.IntReturn(dateRecord.Substring(0, 4));
                    int month = DAL.IntReturn(dateRecord.Substring(4, 2));
                    int day = DAL.IntReturn(dateRecord.Substring(6, 2));
                    article.Date_Record = new DateTime(year, month, day);
                    article.Logistic_Deposit_Type = DAL.IntReturn(text.Substring(272, 1));
                    article.Logistic_Flow_Indicator = DAL.IntReturn(text.Substring(273, 2));
                    article.Ordering_Indicator = DAL.IntReturn(text.Substring(275, 1));

                    article.Link_Logistic_Deposit = DAL.IntReturn(text.Substring(276, 20));

                    article.Expiry_Days = DAL.IntReturn(text.Substring(296, 3));
                    article.Expiry_Days_Checking_Indicator = DAL.IntReturn(text.Substring(299, 1));
                    article.Minimum_Expiry_Days = DAL.IntReturn(text.Substring(300, 5));
                    article.Pallet_Indicator = DAL.IntReturn(text.Substring(305, 1));
                    article.Number_Layer_Pallet = DAL.IntReturn(text.Substring(306, 2));
                    article.Number_Units_Inbox = DAL.IntReturn(text.Substring(308, 5));

                    int grossVolumSelling = DAL.IntReturn(text.Substring(314, 15));
                    article.Gross_Volume = DAL.DecimalReturn(DAL.ChangeValue(3, grossVolumSelling));

                    article.Measure_Unit_GrossVolume = text.Substring(329, 3);
                    article.Packing_Type = text.Substring(332, 2);

                    int cartonWidth = DAL.IntReturn(text.Substring(334, 8));
                    article.Carton_Width = DAL.DecimalReturn(DAL.ChangeValue(2, cartonWidth));

                    int cartonHeight = DAL.IntReturn(text.Substring(342, 8));
                    article.Carton_Height = DAL.DecimalReturn(DAL.ChangeValue(2, cartonHeight));


                    article.UOM_Carton_Size = text.Substring(350, 3);
                    article.UOM_Carton_Weight = text.Substring(353, 3);

                    int cartonGrossVolume = DAL.IntReturn(text.Substring(356, 15));
                    article.Carton_Gross_Volume = DAL.DecimalReturn(DAL.ChangeValue(3, cartonGrossVolume));


                    article.UOM_Carton_Volume = text.Substring(371, 3);
                    article.Selling_Unit_Length = DAL.IntReturn(text.Substring(374, 6));
                    article.Selling_Unit_Width = DAL.IntReturn(text.Substring(380, 6));
                    article.Selling_Unit_Height = DAL.IntReturn(text.Substring(386, 6));
                    article.UOM_Selling_Size = text.Substring(392, 3);



                    int grossweightSelling = DAL.IntReturn(text.Substring(395, 9));
                    article.Grossweight_Selling = DAL.DecimalReturn(DAL.ChangeValue(2, grossweightSelling));


                    int netwweightSelling = DAL.IntReturn(text.Substring(404, 9));
                    article.Netweight_Selling = DAL.DecimalReturn(DAL.ChangeValue(2, netwweightSelling));



                    article.UOM_Selling_Weight = text.Substring(413, 3);
                    article.Article_Group_Number = DAL.IntReturn(text.Substring(416, 3)); ;
                    article.Artice_Subgroup_Number = DAL.IntReturn(text.Substring(419, 3));
                    article.Excise_Tax_Indicator = DAL.IntReturn(text.Substring(422, 1));

                    int exciseTaxAmount = DAL.IntReturn(text.Substring(423, 15));
                    article.Excise_Tax_Amount = DAL.DecimalReturn(DAL.ChangeValue(3, exciseTaxAmount));


                    article.High_Value_Indicator = DAL.IntReturn(text.Substring(438, 1));
                    article.Storage_Temperature_Desc = text.Substring(439, 25);
                    article.Remark = text.Substring(464, 33);
                    article.FILENAME = fileName;

                    string sql = string.Format("select * from MM_Articles where Article_Number='{0}' and Warehouse_Number= '{1}' and Supplier_Code='{2}'", article.Article_Number,article.Warehouse_Number,article.Supplier_Code);
                    DataTable skuTable = DAL.SELECT_SQL(sql);
                   int count = DAL.IntReturn(skuTable.Rows.Count);

                    if (count > 0 )
                    {
                        article.EditDate = DateTime.Now;

                        check = article.Update(fileName, text);
                        result.result(check, article.Article_Status.ToString(), article.Article_Number);
                    }
                    else if (count == 0 )
                    {
                        article.EditDate = DateTime.Now;
                        article.AddDate = DateTime.Now;
                        check = article.Add(fileName, text);
                        result.result(check, article.Article_Status.ToString(), article.Article_Number);
                    }
                    else
                    {
                        check = false;
                        result.result(check, article.Article_Status.ToString(), article.Article_Number);
                    }
                }
                catch(Exception e)
                {
                    string category = "article";
                    error.HandleError(fileName, text, e.Message.ToString(), category);
                    check = false;
                    result.result(check, article.Article_Status.ToString(), article.Article_Number);
                }
                  
            }
            else if (indicator == 4)
            {
                BarcodeArticles_Model barcodeArticle = new BarcodeArticles_Model();
                try
                {
                    barcodeArticle.Table_Indicator = DAL.IntReturn(text.Substring(0, 1));
                    barcodeArticle.Action_Code = text.Substring(1, 1);
                    barcodeArticle.Lsp_Identification = text.Substring(2, 4);

                    string sku = text.Substring(6, 20);
                    barcodeArticle.Article_Number = sku.Substring(12, 8);

                    string barcode = text.Substring(26, 20);
                    barcodeArticle.Barcode = barcode.Substring(0, 14);

                    barcodeArticle.Warehouse_Number = text.Substring(56, 5);

                    string dateRecord = text.Substring(61, 8);
                    int year = DAL.IntReturn(dateRecord.Substring(0, 4));
                    int month = DAL.IntReturn(dateRecord.Substring(4, 2));
                    int day = DAL.IntReturn(dateRecord.Substring(6, 2));
                    barcodeArticle.Date_Record = new DateTime(year, month, day);

                    barcodeArticle.Barcode_Sequence_Number = DAL.IntReturn(text.Substring(69, 3));
                    barcodeArticle.FILENAME = fileName;

                    string sql = string.Format("select * from MM_Barcode_Articles where Article_Number='{0}' and Barcode ='{1}' and Warehouse_Number= '{2}' ", barcodeArticle.Article_Number, barcodeArticle.Barcode,barcodeArticle.Warehouse_Number);
                    DataTable altSkuTable = DAL.SELECT_SQL(sql);
                    int count = DAL.IntReturn(altSkuTable.Rows.Count);
                    if (count > 0)
                    {
                        barcodeArticle.Editdate = DateTime.Now;
                        check = barcodeArticle.Update(fileName, text);
                        result.result(check, "U", barcodeArticle.Article_Number);
                    }
                    else
                    {
                        barcodeArticle.AddDate = DateTime.Now;
                        barcodeArticle.Editdate = DateTime.Now;
                        check = barcodeArticle.Add(fileName, text);
                        result.result(check, "I", barcodeArticle.Article_Number);
                    }
                }
                catch (Exception e)
                {
                    string category = "barcodeArticle";
                    error.HandleError(fileName, text, e.Message.ToString(), category);
                    check = false;
                    result.result(check, "", barcodeArticle.Article_Number);
                }
        }
            return result;
        }

        public async void PostToIon()
        {
            IonReponse result = new IonReponse();            
            JArray items = new JArray();
            PackController packController = new PackController();
            string url = Constant.ION_SKU_ENTERPRISE_URL_NORTH;
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
                string category = "Sku_Interprise_North";
                string sku_code = item.GetValue("sku").ToString().Trim();              
                sku_code = DAL.GetString(sku_code, 8);

                bool checkPack=await packController.PostPack_ToIon(token, sku_code);
                if (checkPack)
                {
                    result = await ClientHttpController.Post(item, url, token);
                    if (!result.check)
                    {
                        result.RecordResultAPI(category,sku_code);
                        DAL.UpdateStatus(sku_code, "ERROR_ENTERPRISE", "SKU_NORTH");
                        continue;
                    }
                    else
                    {
                        this.PostToIon_Warehouse(item, token, sku_code);
                    }

                }
                else
                {
                    DAL.UpdateStatus(sku_code, "ERROR_PACK", "SKU_NORTH");
                    continue;
                }                                       
            }           
        }

        public async void PostToIon_Warehouse(JObject model,string token,string sku)
        {
            IonReponse result = new IonReponse();
            JArray altSkus = new JArray();

            string url = Constant.ION_SKU_WAREHOUSE_URL_NORTH;

            altSkus = this.Create_ModelAltSku(sku);

            model.Add("altSkus", altSkus);
            
            result = await ClientHttpController.Post(model, url, token);
            string category = "Sku_Warehouse_North";
            if (result.check)
            {
                DAL.UpdateStatus(sku, "OK", "SKU_NORTH");
            }
            else
            {
                result.RecordResultAPI(category,sku);
                DAL.UpdateStatus(sku, "ERROR_WAREHOUSE", "SKU_NORTH");
            }

        }

        public async void Post_Update_Sku()
        {
            IonReponse result = new IonReponse();
            JArray items = new JArray();
            PackController packController = new PackController();
            string url = Constant.ION_SKU_ENTERPRISE_URL_NORTH;
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
                string category = "Update_Sku_Enterprise_North";
                string sku_code = item.GetValue("sku").ToString().Trim();
                sku_code = DAL.GetString(sku_code, 8);

                bool checkPack = await packController.PostPack_ToIon(token, sku_code);
                this.Post_Update_Sku_Warehouse(item, token, sku_code);
                //result = await ClientHttpController.Post(item, url, token);
                //if (!result.check)
                //{
                //    result.RecordResultAPI(category, sku_code);
                //    continue;
                //}
                //else
                //{
                //    this.Post_Update_Sku_Warehouse(item, token, sku_code);
                //}
            }
        }

        public async void Post_Update_Sku_Warehouse(JObject model, string token, string sku)
        {
            IonReponse result = new IonReponse();
            JArray altSkus = new JArray();

            string url = Constant.ION_SKU_WAREHOUSE_URL_NORTH;

            result = await ClientHttpController.Post(model, url, token);
            string category = "Update_Sku_Warehouse_North";
            if (result.check)
            {
                DAL.UpdateStatus(sku, "UPDATE", "SKU_NORTH");
            }
            else
            {
                result.RecordResultAPI(category, sku);
                DAL.UpdateStatus(sku, "ERROR_UPDATE_WAREHOUSE", "SKU_NORTH");
            }

        }

        public JArray Create_ModelSku()
        {
            JArray items = new JArray();
            string sql = string.Format("exec PR_MM_ARTICLES_INFORMATION {0}", "NORTH");         
            DataTable dt = DAL.SELECT_SQL(sql);

            if (dt.Rows.Count > 0)
            {
                int count = dt.Rows.Count;
                for( int i = 0; i < count; i++)
                {
                    try
                    {
                        SkuInfor_Model item = new SkuInfor_Model();
                        string sku = dt.Rows[i]["Article_Number"].ToString().Trim();
                        code = dt.Rows[i]["Article_Number"].ToString().Trim();
                        sku = sku.TrimStart('0');

                        item.storerkey = "N0528";
                        item.sku = sku;
                        item.descr = dt.Rows[i]["Desc_Article"].ToString().Trim().Replace("'", "\""); 
                        item.addwho = "addmin";
                        item.editwho = "admin";
                        item.sourceversion = "0";
                        item.susr1 = dt.Rows[i]["susr1"].ToString().Trim().TrimStart('0');
                        item.susr2 = dt.Rows[i]["susr2"].ToString().Trim();
                        item.susr3 = dt.Rows[i]["Supplier_Article_Number"].ToString().Trim();
                        item.susr4 = dt.Rows[i]["ARTICLE_GROUP1"].ToString().Trim();
                        item.susr5 = dt.Rows[i]["ARTICLE_GROUP2"].ToString().Trim();
                        item.susr6 = "";
                        item.susr7 = "";
                        item.susr8 = "";
                        item.susr9 = "";
                        item.susr10 = "";
                        item.packkey = sku;
                        item.rfdefaultpack = sku;
                        item.stdgrosswgt = "0";
                        item.stdnetwgt = "0";
                        item.stdcube = "0";
                        item.tare = "0";
                        item.onreceiptcopypackkey = "1";
                        item.rotateby = "Lottable04";
                        item.odeweight = "1";
                        item.rfdefaultuom = "MU";
                        item.lottablevalidationkey = "MM";
                        item.putawaystrategykey = "STD";
                        item.newallocationstrategy = "MM";
                        item.flowthruitem = "Y";
                        item.barcodeconfigkey = "GLCMB";
                        item.collection = "Local";
                        item.shelflifecodetype = "M"; // M -manufacturing E- expriation
                        item.lottable01label = "Khong can nhap";
                        item.lottable02label = "Khong can nhap";
                        item.lottable03label = "So Batch";
                        item.lottable04label = "Ngay San Xuat";
                        item.lottable05label = "Ngay Het Han";
                        item.lottable06label = "Khong can nhap";
                        item.lottable07label = "Khong can nhap";
                        item.lottable08label = "Khong can nhap";
                        item.lottable09label = "Khong can nhap";
                        item.lottable10label = "Khong can nhap";
                        item.snumlength = "0";
                        item.snumincrlength = "0";
                        item.allowmultilotlpn = "1";
                        string logisticFlow = dt.Rows[i]["Logistic_Flow_Indicator"].ToString().Trim();
                        if (logisticFlow == "19")
                        {
                            item.shelflifeindicator = "Y";
                            item.toexpiredays = dt.Rows[i]["Expiry_Days"].ToString().Trim();
                            item.shelflife = "0";
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
                    catch(Exception e)
                    {
                        string step = string.Format(Constant.MODEL_SKU, "NORTH");
                        resultMapping.Handle_Error_Mapping(code, e.ToString(), step);
                        continue;
                    }
                   
                }
            }
            return items;
            
        }
       
        public JArray Create_ModelAltSku(string  sku)
        {
            JArray altSkus = new JArray();
            string sql = string.Format("PR_MM_BARCODE_ARTICLES_INFORMATION '{0}' , '{1}' ", "NORTH", sku);
            DataTable dt= DAL.SELECT_SQL(sql);
            code = sku;
            if (dt.Rows.Count > 0)
            {
                int count = DAL.IntReturn(dt.Rows.Count);
                sku = sku.TrimStart('0');
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        AltSku altSku = new AltSku();

                        altSku.altsku = dt.Rows[i]["Barcode"].ToString();
                        altSku.storerkey = "N0528";
                        altSku.sku = sku;
                       // altSku.udf1 = dt.Rows[i]["Warehouse_Number"].ToString();

                        string output = JsonConvert.SerializeObject(altSku);
                        JObject objectAltSku = JObject.Parse(output);
                        altSkus.Add(objectAltSku);
                    }
                    catch (Exception e)
                    {
                        string step = string.Format(Constant.MODEL_ALTSKU, "NORTH");
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
            string sql = string.Format("exec [PP_MM_UPDATE_ARTICLES] '{0}'", "NORTH");
            DataTable dt = DAL.SELECT_SQL(sql);

            if (dt.Rows.Count > 0)
            {
                int count = dt.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        SkuInfor_Model_Update_North item = new SkuInfor_Model_Update_North();
                        item.storerkey = "N0528";
                        string sku = dt.Rows[i]["Article_Number"].ToString().Trim();
                        code = dt.Rows[i]["Article_Number"].ToString().Trim();
                        sku = sku.TrimStart('0');
                        item.sku = sku;
                        item.descr = dt.Rows[i]["Desc_Article"].ToString().Trim().Replace("'", "\"");
                        item.susr4= dt.Rows[i]["Artice_Subgroup_Number"].ToString().Trim();
                        item.addwho = "addmin";
                        item.editwho = "admin";
                        item.susr1 = dt.Rows[i]["susr1"].ToString().Trim().TrimStart('0');

                        //string logisticFlow = dt.Rows[i]["Logistic_Flow_Indicator"].ToString().Trim();
                        string output = JsonConvert.SerializeObject(item);

                        JObject objectitem = JObject.Parse(output);
                        items.Add(objectitem);
                    }
                    catch (Exception e)
                    {
                        string step = string.Format(Constant.MODEL_SKU, "North");
                        resultMapping.Handle_Error_Mapping(code, e.ToString(), step);
                        continue;
                    }
                }
            }
            return items;

        }
    }
}
