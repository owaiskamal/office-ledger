using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace office_ledger.Models
{


    public class JournalVoucher
    {

         public JournalVoucher()
        {
            this.Master = new JournalVoucherMaster();
            this.Details = new List<JournalVoucherDetails>();
        }
        public virtual JournalVoucherMaster Master { get; set; }
        public virtual List<JournalVoucherDetails> Details { get; set; }

    }
    public class JournalVoucherMaster
    {

       

        public String vochno { get; set; }
        public String busunit { get; set; }

        public String vochcode { get; set; }
        public String insdate { get; set; }

        public String vochtype { get; set; }

        public String particulars { get; set; }
        public String user_cd { get; set; }
        public String upduser_cd { get; set; }

    
        

        



    }
    





    public class JournalVoucherDetails
    {
        public String coano { get; set; }
        public String costid { get; set; }
        public String chqrefno { get; set; }
        public String chqrefdt { get; set; }
        public String dr_amount { get; set; }
        public String cr_amount { get; set; }
      

    }
}
