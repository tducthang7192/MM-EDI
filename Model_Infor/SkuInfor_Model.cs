using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM_Project
{

    public class Href
{
    public string reference { get; set; }
    public string url { get; set; }
}

    public class Userdatatranslation
{
    public IList<Href> hrefs { get; set; }
    public string columnname { get; set; }
    public string joinkey1 { get; set; }
    public string joinkey2 { get; set; }
    public string joinkey3 { get; set; }
    public string joinkey4 { get; set; }
    public string joinkey5 { get; set; }
    public string locale { get; set; }
    public string tablename { get; set; }
    public string translation { get; set; }
}

    public class Substitutesku
{
    public IList<Href> hrefs { get; set; }
    public string storerkey { get; set; }
    public string sku { get; set; }
    public string packkey { get; set; }
    public string uom { get; set; }
    public string uomqty { get; set; }
    public string qty { get; set; }
    public string subpackkey { get; set; }
    public string subuom { get; set; }
    public string subuomqty { get; set; }
    public string subqty { get; set; }
    public string status { get; set; }
    public string adddate { get; set; }
    public string addwho { get; set; }
    public string editdate { get; set; }
    public string editwho { get; set; }
    public string sequence { get; set; }
    public string serialkey { get; set; }
    public string whseid { get; set; }
    public string subsititutesku { get; set; }
}

    public class Billofmaterial
{
    public IList<Href> hrefs { get; set; }
    public string adddate { get; set; }
    public string addwho { get; set; }
    public string editdate { get; set; }
    public string editwho { get; set; }
    public string serialkey { get; set; }
    public string whseid { get; set; }
    public string storerkey { get; set; }
    public string sku { get; set; }
    public string componentsku { get; set; }
    public string sequence { get; set; }
    public string bomonly { get; set; }
    public string notes { get; set; }
    public string qty { get; set; }
}

    public class AltSku
{
    public JArray hrefs { get; set; }
    public string udf1 { get; set; }
    public string udf2 { get; set; }
    public string udf3 { get; set; }
    public string udf4 { get; set; }
    public string udf5 { get; set; }
    public string type { get; set; }
    public string altsku { get; set; }
    public string vendor { get; set; }
    public string defaultuom { get; set; }
    public string adddate { get; set; }
    public string addwho { get; set; }
    public string editdate { get; set; }
    public string editwho { get; set; }
    public string serialkey { get; set; }
    public string whseid { get; set; }
    public string storerkey { get; set; }
    public string sku { get; set; }
    public string packkey { get; set; }
}

    public class SkuInfor_Model
    {
        public JArray hrefs { get; set; }
        public string storerkey { get; set; }
        public string sku { get; set; }
        public string addwho { get; set; }
        public string allowmultilotlpn { get; set; }
        public string barcodeconfigkey { get; set; }
        public string collection { get; set; }
        public string descr { get; set; }
        public string editwho { get; set; }
        public string flowthruitem { get; set; }
        public string lottable01label { get; set; }
        public string lottable02label { get; set; }
        public string lottable03label { get; set; }
        public string lottable04label { get; set; }
        public string lottable05label { get; set; }
        public string lottable06label { get; set; }
        public string lottable07label { get; set; }
        public string lottable08label { get; set; }
        public string lottable09label { get; set; }
        public string lottable10label { get; set; }
        public string lottablevalidationkey { get; set; }
        public string newallocationstrategy { get; set; }
        public string odeweight { get; set; }
        public string onreceiptcopypackkey { get; set; }
        public string packkey { get; set; }
        public string putawaystrategykey { get; set; }
        public string rfdefaultpack { get; set; }
        public string rfdefaultuom { get; set; }
        public string rotateby { get; set; }
        public string shelflife { get; set; }
        public string shelflifecodetype { get; set; }
        public string shelflifeindicator { get; set; }
        public string snumincrlength { get; set; }
        public string snumlength { get; set; }
        public string sourceversion { get; set; }
        public string stdcube { get; set; }
        public string stdgrosswgt { get; set; }
        public string stdnetwgt { get; set; }
        public string style { get; set; }
        public string susr1 { get; set; }
        public string susr10 { get; set; }
        public string susr2 { get; set; }
        public string susr3 { get; set; }
        public string susr4 { get; set; }
        public string susr5 { get; set; }
        public string susr6 { get; set; }
        public string susr7 { get; set; }
        public string susr8 { get; set; }
        public string susr9 { get; set; }
        public string tare { get; set; }
        public string toexpiredays { get; set; }
    }

    public class SkuInfor_Model_South
    {
        public JArray hrefs { get; set; }
        public string storerkey { get; set; }
        public string sku { get; set; }    
        public string addwho { get; set; }
        public string allowmultilotlpn { get; set; }
        public string barcodeconfigkey { get; set; }
        public string cartonizeft { get; set; }
        public string collection { get; set; }
        public string descr { get; set; }
        public string editwho { get; set; }
        public string flowthruitem { get; set; }
        public string groupfteach { get; set; }
        public string itemcharacteristic1 { get; set; }
        public string itemcharacteristic2 { get; set; }
        public string lottable01label { get; set; }
        public string lottable02label { get; set; }
        public string lottable03label { get; set; }
        public string lottable04label { get; set; }
        public string lottable05label { get; set; }
        public string lottable06label { get; set; }
        public string lottable07label { get; set; }
        public string lottable08label { get; set; }
        public string lottable09label { get; set; }
        public string lottable10label { get; set; }
        public string lottablevalidationkey { get; set; }
        public string newallocationstrategy { get; set; }
        public string notes1 { get; set; }
        public string odeweight { get; set; }
        public string onreceiptcopypackkey { get; set; }   
        public string packkey { get; set; }
        public string putawaystrategykey { get; set; }
        public string rfdefaultpack { get; set; }
        public string rfdefaultuom { get; set; }
        public string rotateby { get; set; }
        public string shelflife { get; set; }
        public string shelflifecodetype { get; set; }
        public string shelflifeindicator { get; set; }
        public string snumincrlength { get; set; } 
        public string snumlength { get; set; }
        public string sourceversion { get; set; }  
        public string stdcube { get; set; }
        public string stdgrosswgt { get; set; }  
        public string stdnetwgt { get; set; }
        public string style { get; set; }
        public string susr1 { get; set; }
        public string susr10 { get; set; }
        public string susr2 { get; set; }
        public string susr3 { get; set; }
        public string susr4 { get; set; }
        public string susr5 { get; set; }
        public string susr6 { get; set; }
        public string susr7 { get; set; }
        public string susr8 { get; set; }
        public string susr9 { get; set; }
        public string tare { get; set; }
        public string toexpiredays { get; set; }
    }

    public class SkuInfor_Model_Update_South
    {
        public JArray hrefs { get; set; }
        public string storerkey { get; set; }
        public string sku { get; set; }
        public string addwho { get; set; }
        public string descr { get; set; }
        public string editwho { get; set; }     
        public string packkey { get; set; }  
        public string shelflife { get; set; }
        public string shelflifecodetype { get; set; }
        public string shelflifeindicator { get; set; }
       // public string stdcube { get; set; }
        //public string stdgrosswgt { get; set; }
        //public string stdnetwgt { get; set; }
        public string susr1 { get; set; }
        public string susr3 { get; set; }
        //public string tare { get; set; }
        public string toexpiredays { get; set; }
    }

    public class SkuInfor_Model_Update_North
    {
        public JArray hrefs { get; set; }
        public string storerkey { get; set; }
        public string sku { get; set; }
        public string addwho { get; set; }
        public string descr { get; set; }
        public string editwho { get; set; }
        public string susr1 { get; set; }
        public string susr4 { get; set; }
    }


}
