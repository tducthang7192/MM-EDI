using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM_Project
{
    public class Orderdetail
    {
        public IList<Href> hrefs { get; set; }
        public string orderkey { get; set; }
        public string addwho { get; set; }
        public string editwho { get; set; }
        public string newallocationstrategy { get; set; }
        public int openqty { get; set; }
        public int originalqty { get; set; }
        public string sku { get; set; }
        public string storerkey { get; set; }
        public string lottable02 { get; set; }
        public string lottable03 { get; set; }
        public string lottable10 { get; set; }

        public string susr2 { get; set; }
        public string whseid { get; set; }
    }

    public class SOInfor_Model
    {
        public IList<Href> hrefs { get; set; }
        public string orderkey { get; set; }
        public string addwho { get; set; }
        public string apportion { get; set; }
        public string consigneekey { get; set; }
        public string editwho { get; set; }
        public string externalorderkey2 { get; set; }
        public string externorderkey { get; set; }
        public string notes2 { get; set; }
        public DateTime orderdate { get; set; }
        public DateTime planneddelvdate { get; set; }
        public string pokey { get; set; }
        public DateTime promiseddelvdate { get; set; }
        public string stage { get; set; }
        public string storerkey { get; set; }
        public string type { get; set; }
        public string whseid { get; set; }
        public IList<Orderdetail> orderdetails { get; set; }
    }

    public class SOInfor_Model_South
    {
        public IList<Href> hrefs { get; set; }
        public string orderkey { get; set; }
        public string addwho { get; set; }
        public string consigneekey { get; set; }
        public DateTime deliverydate { get; set; }
        public string editwho { get; set; }
        public string externalorderkey2 { get; set; }
        public string externorderkey { get; set; }
        public string notes2 { get; set; }
        public DateTime orderdate { get; set; }
        public DateTime requestedshipdate { get; set; }
        public string pokey { get; set; }
        public string storerkey { get; set; }
        public string susr1 { get; set; }
        public string susr2 { get; set; }
        public string type { get; set; }
        public string whseid { get; set; }
        public IList<Orderdetail_South> orderdetails { get; set; }
    }

    public class Orderdetail_South
    {
        public IList<Href> hrefs { get; set; }
        public string orderkey { get; set; }
        public string addwho { get; set; }      
        public string editwho { get; set; }
        public string lottable10 { get; set; }    
        public string newallocationstrategy { get; set; }
        public int openqty { get; set; }
        public int originalqty { get; set; }
        public string sku { get; set; }
        public string storerkey { get; set; }
        public string susr2 { get; set; }
        public string uom { get; set; }
        public string whseid { get; set; }
    }

}
