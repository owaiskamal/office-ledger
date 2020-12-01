using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace office_ledger.Models
{
    public class BankAccount
    {
        public String bankNo { get; set; }

        public String bankCode { get; set; }

        public String bankName { get; set; }

        public String userCd { get; set; }

        public String row_id { get; set; }

        public String upUserCd { get; set; }

        public String action { get; set; }

        public String dataset { get; set; }
    }
}
