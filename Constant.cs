using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM_Project
{
   public static class Constant
    {
        public const string ION_TOKEN_URL = @"https://ion.cjgmd.corp:9443/InforIntSTS/connect/token";
        public const string ION_SUPPLIER_URL = @"https://ion.cjgmd.corp:6443/infor/CustomerApi/DEV/wmwebservice_rest/INFOR_ENTERPRISE/storers?access_token={0}";
        public const string ION_SKU_WAREHOUSE_URL = @"https://ion.cjgmd.corp:6443/infor/CustomerApi/DEV/wmwebservice_rest/INFOR_SCPRD_wmwhse7/items?access_token={0}";
        public const string ION_SKU_ENTERPRISE_URL = @"https://ion.cjgmd.corp:6443/infor/CustomerApi/DEV/wmwebservice_rest/INFOR_ENTERPRISE/items?access_token={0}";
        public const string ION_ALTSKU_URL = @"https://ion.cjgmd.corp:6443/infor/CustomerApi/DEV/wmwebservice_rest/INFOR_SCPRD_wmwhse7/altskus?access_token={0}";
        public const string ION_SO_URL = @"https://ion.cjgmd.corp:6443/infor/CustomerApi/DEV/wmwebservice_rest/INFOR_SCPRD_wmwhse7/shipments?access_token={0}";
        public const string ION_PO_URL = @"https://ion.cjgmd.corp:6443/infor/CustomerApi/DEV/wmwebservice_rest/INFOR_SCPRD_wmwhse7/purchaseorders?access_token={0}";
        public const string ION_PACK_URL = @"https://ion.cjgmd.corp:6443/infor/CustomerApi/DEV/wmwebservice_rest/INFOR_ENTERPRISE/packs?access_token={0}";
   
        public const string ION_SUPPLIER_URL_NORTH = @"https://ion.cjgmd.corp:6443/infor/CustomerApi/V1/SCE01/INFOR_ENTERPRISE/storers?access_token={0}";
        public const string ION_SKU_WAREHOUSE_URL_NORTH = @"https://ion.cjgmd.corp:6443/infor/CustomerApi/V1/SCE01/INFOR_SCPRD_wmwhse3/items?access_token={0}";
        public const string ION_SKU_ENTERPRISE_URL_NORTH = @"https://ion.cjgmd.corp:6443/infor/CustomerApi/V1/SCE01/INFOR_ENTERPRISE/items?access_token={0}";
        public const string ION_ALTSKU_URL_NORTH = @"https://ion.cjgmd.corp:6443/infor/CustomerApi/V1/SCE01/INFOR_SCPRD_wmwhse3/altskus?access_token={0}";
        public const string ION_SO_URL_NORTH = @"https://ion.cjgmd.corp:6443/infor/CustomerApi/V1/SCE01/INFOR_SCPRD_wmwhse3/shipments?access_token={0}";
        public const string ION_PO_URL_NORTH = @"https://ion.cjgmd.corp:6443/infor/CustomerApi/V1/SCE01/INFOR_SCPRD_wmwhse3/purchaseorders?access_token={0}";
        public const string ION_PACK_URL_NORTH = @"https://ion.cjgmd.corp:6443/infor/CustomerApi/V1/SCE01/INFOR_ENTERPRISE/packs?access_token={0}";
        public const string ION_ASN_URL_NORTH = @"https://ion.cjgmd.corp:6443/infor/CustomerApi/V1/SCE01/INFOR_SCPRD_wmwhse3/advancedshipnotice?access_token={0}";

        public const string ION_SUPPLIER_URL_SOUTH = @"https://ion.cjgmd.corp:6443/infor/CustomerApi/WMSAPI/wms09Apis/INFOR_ENTERPRISE/storers?access_token={0}";
        public const string ION_SKU_WAREHOUSE_URL_SOUTH = @"https://ion.cjgmd.corp:6443/infor/CustomerApi/WMSAPI/wms09Apis/INFOR_SCPRD_wmwhse10/items?access_token={0}";
        public const string ION_SKU_ENTERPRISE_URL_SOUTH = @"https://ion.cjgmd.corp:6443/infor/CustomerApi/WMSAPI/wms09Apis/INFOR_ENTERPRISE/items?access_token={0}";
        public const string ION_ALTSKU_URL_SOUTH = @"https://ion.cjgmd.corp:6443/infor/CustomerApi/WMSAPI/wms09Apis/INFOR_SCPRD_wmwhse10/altskus?access_token={0}";
        public const string ION_SO_URL_SOUTH = @"https://ion.cjgmd.corp:6443/infor/CustomerApi/WMSAPI/wms09Apis/INFOR_SCPRD_wmwhse10/shipments?access_token={0}";
        public const string ION_PO_URL_SOUTH = @"https://ion.cjgmd.corp:6443/infor/CustomerApi/WMSAPI/wms09Apis/INFOR_SCPRD_wmwhse10/purchaseorders?access_token={0}";
        public const string ION_PACK_URL_SOUTH = @"https://ion.cjgmd.corp:6443/infor/CustomerApi/WMSAPI/wms09Apis/INFOR_ENTERPRISE/packs?access_token={0}";
        public const string ION_ASN_URL_SOUTH = @"https://ion.cjgmd.corp:6443/infor/CustomerApi/WMSAPI/wms09Apis/INFOR_SCPRD_wmwhse10/advancedshipnotice?access_token={0}";


        public const string PATH_GETFILE_SFTP = "/SCM/LSP/GMD/Production/OUTBOUND/DOWN";
        public const string PATH_MOVEFILE_SFTP = @"/SCM/LSP/GMD/Production/OUTBOUND/SAVED/{0}";
        public const string PATH_MOVEFILE_ERROR_SFTP = @"/SCM/LSP/GMD/Production/OUTBOUND/DOWN/ERROR/{0}";

        public const string PATH_MASTERDATA = @"D:\MasterData";      
        public const string PATH_HISTORY_MASTERDATA = @"D:\History_MasterData";
        public const string PATH_SO = @"D:\SO";
        public const string PATH_HISTORY_SO = @"D:\History_SO";
        public const string PATH_PO = @"D:\PO";
        public const string PATH_HISTORY_PO = @"D:\History_PO";
        public const string PATH_BACKUP = @"E:\Software\MMVN\BACKUPFILE\{0}";

        public const string INFORM_START_MD= @"Start Post Master Data {0} Site To ION...";
        public const string INFORM_END_MD = @"Done Post Master Data {0} Site To ION....";

        public const string INFORM_START_PO = @"Start Post PO {0} Site To ION...";
        public const string INFORM_END_PO = @"Done Post PO {0} Site To ION...";

        public const string INFORM_START_ASN = @"Start Post ASN {0} Site To ION...";
        public const string INFORM_END_ASN = @"Done Post ASN {0} Site To ION...";

        public const string INFORM_START_SO = @"Start Post SO {0} Site To ION....";
        public const string INFORM_END_SO = @"Done Post SO {0} Site To ION...";

        public const string MODEL_SKU = "@CREATE_MODEL_SKU {0}";
        public const string MODEL_ALTSKU = "@CREATE_MODEL_ALTSKU {0}";
        public const string MODEL_SUPPLIER = "CREATE_MODEL_SUPPLIER";
        public const string MODEL_PACK = "@CREATE_MODEL_PACK {0}";
        public const string MODEL_PO= "@CREATE_MODEL_PO {0}";
        public const string MODEL_PODETAIL = "@CREATE_MODEL_PO_DETAIL {0}";
        public const string MODEL_SO = "@CREATE_MODEL_SO {0}";
        public const string MODEL_SODETAIL = "@CREATE_MODEL_SO_DETAIL {0}";
        public const string MODEL_ASN = "@CREATE_MODEL_ASN {0}";
        public const string MODEL_ASN_DETAIL = "@CREATE_MODEL_ASN_DETAIL {0}";

        public const string PO_HEADER = "@select * from MM_PO_HEADER where  STATUS = '' and Warehouse_Number='{0}'";
        public const string PO_DETAIL = "@select * from MM_PO_DETAIL where  STATUS = '' and Warehouse_Number='{0}'";



    }

}
