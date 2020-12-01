using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace office_ledger.Models
{
    public class ChartOfAccount
    {
        public String p_coano { get; set; }

        public String p_acc_code { get; set; }
        public String p_acc_type { get; set; }
        public String p_acc_name { get; set; }


        public String p_user_cd { get; set; }
        public String p_upduser_cd { get; set; }

        public String p_rowid { get; set; }
        public String p_action { get; set; }

        public String p_dataset { get; set; }

    }
}
