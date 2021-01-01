using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM_Project
{
    public class Podetail
    {
        public IList<Href> hrefs { get; set; }
        public string pokey { get; set; }
        public string addwho { get; set; }
        public string editwho { get; set; }
        public int qtyordered { get; set; }
        public string susr1 { get; set; }
        public string whseid { get; set; }
        public string sku { get; set; }
        public string storerkey { get; set; }
    }

    public class POInfor_Model
    {
        public IList<Href> hrefs { get; set; }
        public string pokey { get; set; }
        public string addwho { get; set; }
        public string editwho { get; set; }
        public DateTime  expectedreceiptdate { get; set; }
        public string externalpokey2 { get; set; }
        public string externpokey { get; set; }
        public DateTime podate { get; set; }
        public string potype { get; set; }
        public string sellername { get; set; }
        public string storerkey { get; set; }
        public string whseid { get; set; }
        public IList<Podetail> podetails { get; set; }
    }

    public class POInfor_Model_South
    {
        public IList<Href> hrefs { get; set; }
        public string pokey { get; set; }
        public string addwho { get; set; }
        public string editwho { get; set; }
        public DateTime expectedreceiptdate { get; set; }
        public string externalpokey2 { get; set; }
        public string externpokey { get; set; }
        public DateTime podate { get; set; }
        public string potype { get; set; }
        public string sellername { get; set; }
        public string storerkey { get; set; }
        public string susr1 { get; set; }
        public string whseid { get; set; }
        public IList<Podetail> podetails { get; set; }
    }
}
