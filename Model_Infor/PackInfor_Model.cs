using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM_Project
{
    public class PackInfor_Model
    {
        public IList<Href> hrefs { get; set; }
        public string pallethi { get; set; }
        public string palletti { get; set; }
        public string addwho { get; set; }
        public string cartonizeuom3 { get; set; }
        public string editwho { get; set; }
        public string packdescr { get; set; }
        public string packkey { get; set; }
        public string packuom1 { get; set; }
        public string packuom3 { get; set; }
        public string packuom4 { get; set; }
        public string whseid { get; set; }
        public string casecnt { get; set; }       
        public string heightuom1 { get; set; }
        public string lengthuom1 { get; set; }
        public string pallet { get; set; }
        public string weightuom1 { get; set; }
        public string widthuom1 { get; set; }
        public string ext_udf_str1 { get; set; }
        public string ext_udf_str2 { get; set; }
        public string ext_udf_str3 { get; set; }
        public string ext_udf_str4 { get; set; }

    }

    public class PackInfor_Model_South
    {
        public IList<Href> hrefs { get; set; }
        public string addwho { get; set; }
        public string cartonizeuom3 { get; set; }
        public string editwho { get; set; }
        public string packdescr { get; set; }
        public string packkey { get; set; }
        public string packuom1 { get; set; }
        public string packuom3 { get; set; }
        public string whseid { get; set; }
        public string casecnt { get; set; }
        public string heightuom1 { get; set; }
        public string heightuom3 { get; set; }
        public string lengthuom1 { get; set; }
        public string lengthuom3 { get; set; }
        public string widthuom1 { get; set; }
        public string widthuom3 { get; set; }
    }
    public class PackInfor_Model_Update_South
    {
        public IList<Href> hrefs { get; set; }
        public string addwho { get; set; }
        public string cartonizeuom3 { get; set; }
        public string editwho { get; set; }
        public string packdescr { get; set; }
        public string packkey { get; set; }
        public string packuom1 { get; set; }
       // public string packuom2 { get; set; }
        public string packuom3 { get; set; }
        public string whseid { get; set; }
        public string casecnt { get; set; }
        public string heightuom1 { get; set; }
        public string heightuom3 { get; set; }
        public string innerpack { get; set; }
        public string lengthuom1 { get; set; }
        public string lengthuom3 { get; set; }
        public string pallet { get; set; }
        public string widthuom1 { get; set; }
        public string widthuom3 { get; set; }


    }

}
