using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace office_ledger.Models
{
    public class InvoiceStatement
    {
        public String custID { get; set; }
        public String invoiceNo { get; set; }
        public String invoiceDate { get; set; }
        public String crfNo { get; set; }
        public String orderNo { get; set; }
        public String invoiceAmount { get; set; }
        public String gstAmount { get; set; }
        public String totalAmount { get; set; }
        public String recAmount { get; set; }
        public String busUnit { get; set; }
        public String costID { get; set; }
        public String remarks { get; set; }
        public String userCD { get; set; }
        public String upUserCD { get; set; }
    }
    public class InvBusinessUnits
    {
        public String busUnit { get; set; }
        public String busName { get; set; }
    }
}
