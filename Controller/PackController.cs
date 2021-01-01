using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;

namespace MM_Project
{
    class PackController
    {
        Response_Mapping resultMapping = new Response_Mapping();

        public async Task<bool> PostPack_ToIon(string token,string sku)
        {
            IonReponse result = new IonReponse();
            JObject pack = new JObject();

            string url = Constant.ION_PACK_URL_NORTH;
            string category = "Pack_North";

            pack = this.Create_ModelPack(sku);
            result = await ClientHttpController.Post(pack, url, token);
           if (!result.check)
           {
           result.RecordResultAPI(category, sku);
           }
           return result.check;
        }

        public JObject Create_ModelPack(string sku)
        {
            JObject pack = new JObject();
            try
            {
                PackInfor_Model packModel = new PackInfor_Model();
                string sql = string.Format("[PR_MM_PACK_INFORMATION_NORTH]'{0}'", sku);
                DataTable dt = DAL.SELECT_SQL(sql);
                sku = sku.TrimStart('0');
                packModel.packkey = sku;
                int qtyPerPallet = DAL.IntReturn(dt.Rows[0]["Number_Mu_Pallet"]);
                packModel.pallet = qtyPerPallet.ToString();
                packModel.packuom4 = "PL";
                packModel.packdescr = qtyPerPallet + " PC per pallet";
                packModel.packuom1 = "CS";

                int qtyInCnt = DAL.IntReturn(dt.Rows[0]["Number_Mu_Carton"].ToString());
                int qtyPerLayer = DAL.IntReturn(dt.Rows[0]["Number_Mu_Layer"].ToString());
                int casecntPerLayer = qtyPerLayer / qtyInCnt;

                packModel.palletti = casecntPerLayer.ToString();
                packModel.pallethi = dt.Rows[0]["Number_Layer_Pallet"].ToString();

                packModel.casecnt = dt.Rows[0]["Number_Mu_Carton"].ToString();
                packModel.packuom3 = "MU";
                packModel.cartonizeuom3 = "N";

                decimal carton_lenght = DAL.DecimalReturn(dt.Rows[0]["Carton_Length"]);
                decimal carton_width = DAL.DecimalReturn(dt.Rows[0]["Carton_Width"]);
                decimal carton_height = DAL.DecimalReturn(dt.Rows[0]["Carton_Height"]);
                decimal carton_grossWeight = DAL.DecimalReturn(dt.Rows[0]["Carton_GrossWeight"]);

                packModel.lengthuom1 = carton_lenght.ToString();
                packModel.widthuom1 = carton_width.ToString();
                packModel.heightuom1 = carton_height.ToString();
                packModel.weightuom1 = carton_grossWeight.ToString();

                packModel.ext_udf_str1 = dt.Rows[0]["susr1"].ToString();
                packModel.whseid = "wmwhse3";
                packModel.addwho = "Admin";
                packModel.editwho = "Admin";
                string output = JsonConvert.SerializeObject(packModel);
                pack = JObject.Parse(output);
            }
            catch (Exception e)
            {
                string step = string.Format(Constant.MODEL_PACK, "NORTH");
                resultMapping.Handle_Error_Mapping(sku, e.ToString(), step);
            }
            return pack;
        }

        public async Task<bool> PostPack_ToIon_South(string token, string sku, string type)
        {
            IonReponse result = new IonReponse();
            JObject pack = new JObject();

            string url = Constant.ION_PACK_URL_SOUTH;

            if (type == "NEW")
            {
                pack = this.Create_ModelPack_South(sku);
            }
            else
            {
                pack = this.Update_Model_South(sku);
            }

            
            result = await ClientHttpController.Post(pack, url, token);
            if (!result.check)
            {
                //result.RecordResultAPI(category, sku);
            }
            return result.check;
        }

        public JObject Create_ModelPack_South(string sku)
        {
            JObject pack = new JObject();
            try
            {
                PackInfor_Model_South packModel = new PackInfor_Model_South();
                string sql = string.Format("select * from MM_Articles where Article_Number='{0}' and Warehouse_Number='90071'", sku);
                DataTable dt = DAL.SELECT_SQL(sql);
                sku = sku.TrimStart('0');

                packModel.packkey = sku + "_MMSOUTH";
                int qtyPerPallet = DAL.IntReturn(dt.Rows[0]["Number_Mu_Pallet"]);
                packModel.packdescr = sku + "_MMSOUTH";
                packModel.packuom1 = "CS";
                int qtyPerCase= DAL.IntReturn(dt.Rows[0]["Number_Mu_Carton"]);
                packModel.casecnt = qtyPerCase.ToString();
                packModel.packuom3 = "MU";
                packModel.cartonizeuom3 = "N";

                decimal carton_lenght1 = DAL.DecimalReturn(dt.Rows[0]["Carton_Length"]);
                decimal carton_width1 = DAL.DecimalReturn(dt.Rows[0]["Carton_Width"]);
                decimal carton_height1 = DAL.DecimalReturn(dt.Rows[0]["Carton_Height"]);
                packModel.lengthuom1 = carton_lenght1.ToString();
                packModel.widthuom1 = carton_width1.ToString();
                packModel.heightuom1 = carton_height1.ToString();


                decimal carton_lenght3 = DAL.DecimalReturn(dt.Rows[0]["Selling_Unit_Length"]);
                decimal carton_width3 = DAL.DecimalReturn(dt.Rows[0]["Selling_Unit_Width"]);
                decimal carton_height3 = DAL.DecimalReturn(dt.Rows[0]["Selling_Unit_Height"]);
                packModel.lengthuom3 = carton_lenght3.ToString();
                packModel.widthuom3 = carton_width3.ToString();
                packModel.heightuom3 = carton_height3.ToString();

                packModel.whseid = "wmwhse10";
                packModel.addwho = "Admin";
                packModel.editwho = "Admin";
                string output = JsonConvert.SerializeObject(packModel);
                pack = JObject.Parse(output);
            }
            catch(Exception e)
            {
                string step = string.Format(Constant.MODEL_PACK, "SOUTH");
                resultMapping.Handle_Error_Mapping(sku, e.ToString(), step);
            }
            return pack;
        }

        public JObject Update_Model_South(string sku)
        {
            JObject pack = new JObject();
            try
            {
                PackInfor_Model_Update_South packModel = new PackInfor_Model_Update_South();
                string sql = string.Format("[PP_MM_UPDATE_PACK]'SOUTH','{0}'", sku);
                DataTable dt = DAL.SELECT_SQL(sql);
                string sku_current = sku.TrimStart('0');

                packModel.packkey = sku_current + "_MMSOUTH";
                int qtyPerPallet = DAL.IntReturn(dt.Rows[0]["PALLET_NEW"]);
                packModel.packdescr = sku_current + "_MMSOUTH";
                packModel.packuom1 = "CS";
                int qtyPerCase = DAL.IntReturn(dt.Rows[0]["Number_Mu_Carton"]);
                packModel.casecnt = qtyPerCase.ToString();
                packModel.packuom3 = "MU";
                packModel.cartonizeuom3 = "N";
                packModel.pallet = qtyPerPallet.ToString();



                int qtyInnerPack= DAL.IntReturn(dt.Rows[0]["INNERPACK_NEW"]);
                packModel.innerpack = qtyInnerPack.ToString();

                decimal carton_lenght1 = DAL.DecimalReturn(dt.Rows[0]["Carton_Length"]);
                decimal carton_width1 = DAL.DecimalReturn(dt.Rows[0]["Carton_Width"]);
                decimal carton_height1 = DAL.DecimalReturn(dt.Rows[0]["Carton_Height"]);
                packModel.lengthuom1 = carton_lenght1.ToString();
                packModel.widthuom1 = carton_width1.ToString();
                packModel.heightuom1 = carton_height1.ToString();


                decimal carton_lenght3 = DAL.DecimalReturn(dt.Rows[0]["Selling_Unit_Length"]);
                decimal carton_width3 = DAL.DecimalReturn(dt.Rows[0]["Selling_Unit_Width"]);
                decimal carton_height3 = DAL.DecimalReturn(dt.Rows[0]["Selling_Unit_Height"]);
                packModel.lengthuom3 = carton_lenght3.ToString();
                packModel.widthuom3 = carton_width3.ToString();
                packModel.heightuom3 = carton_height3.ToString();

                packModel.whseid = "wmwhse10";
                packModel.addwho = "Admin";
                packModel.editwho = "Admin";
                string output = JsonConvert.SerializeObject(packModel);
                pack = JObject.Parse(output);
            }
            catch (Exception e)
            {
                string step = string.Format(Constant.MODEL_PACK, "SOUTH");
                resultMapping.Handle_Error_Mapping(sku, e.ToString(), step);
            }
            return pack;
        }

    }
}
