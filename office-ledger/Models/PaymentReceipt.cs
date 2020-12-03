using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace office_ledger.Models
{
    public class PaymentReceipt
    {
        public string p_recno { get; set; }
        public string p_recdt { get; set; }
        public string p_paymode { get; set; }
        public string p_payref { get; set; }
        public string p_chequedt { get; set; }
        public string p_totrecamount { get; set; }
        public string p_busunit { get; set; }

        public string p_totwht { get; set; }
        public string p_totnetamount { get; set; }
        public string p_invoiceno { get; set; }

        public string p_invoicedt { get; set; }
        public string p_customerid { get; set; }
        public string p_whtgst { get; set; }
        public string p_user_cd { get; set; }
        public string p_upduser_cd { get; set; }
        public string p_upddate { get; set; }
        public string p_rowid { get; set; }
        public string P_Action { get; set; }

        public string p_dataset { get; set; }



    }



}
