using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace office_ledger.Models
{
    public class UserLogin
    {
        public String user_cd { get; set; }
        public String password { get; set; }
        public String user_ip { get; set; }
        public String data { get; set; }
    }
}
