using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using office_ledger.Repositories;

namespace office_ledger.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class CustomerMakerController : ControllerBase
    {
        ICustomerMaster CustomerMaster;
        public CustomerMakerController(ICustomerMaster _customerMaster)
        {
            CustomerMaster = _customerMaster;
        }

        
    }
}