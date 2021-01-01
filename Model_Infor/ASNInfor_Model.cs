using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM_Project
{
    public class Receiptdetail
    {
        public IList<Href> hrefs { get; set; }
        public string storerkey { get; set; }
        public string sku { get; set; }
        public string receiptkey { get; set; }
        public string addwho { get; set; }
        public string editwho { get; set; }
        public string lottable10 { get; set; }
        public string pokey { get; set; }
        public int qtyexpected { get; set; }
        public string toid { get; set; }
        public string toloc { get; set; }
    }
    class ASNInfor_Model
    {
        public IList<Href> hrefs { get; set; }
        public string receiptkey { get; set; }
        public string addwho { get; set; }
        public string pokey { get; set; }
        public string storerkey { get; set; }
        public string suppliercode { get; set; }
        public string type { get; set; }
        public IList<Receiptdetail> receiptdetails { get; set; }
        public string whseid { get; set; }
    }
}
