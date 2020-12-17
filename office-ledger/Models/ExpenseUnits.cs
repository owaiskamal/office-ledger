using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace office_ledger.Models
{
    public class ExpenseUnits
    {
        public String p_buunit { get; set; }
        public String p_EXPTRANSNO { get; set; }
        public String p_EXPDATE { get; set; }
        public String p_PARTICULARS { get; set; }
        public String p_AMOUNT { get; set; }
        public String p_VOCHNO { get; set; }
        public String p_CHQREFNO { get; set; }

        public String p_CHQREFDT { get; set; }

        public String p_USER_CD { get; set; }
        public String p_INSDATE { get; set; }

        public String p_UPDUSER_CD { get; set; }
        public String p_UPDDATE { get; set; }
        public String p_rowid { get; set; }


    }
}
