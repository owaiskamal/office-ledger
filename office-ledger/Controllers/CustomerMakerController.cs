using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using office_ledger.Models;
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

        [Route("api/getCustChartOfAccount")]
        [HttpGet]
        public ActionResult getCustChartOfAccount()
        {

            var result = CustomerMaster.getCustChartOfAccount();
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }

        }

        [Route("api/getCustomerMaster")]
        [HttpGet]

        public ActionResult getCustomerMaster()
        {
            var result = CustomerMaster.getCustomerMaster();
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [Route("api/insertCustomerMaster")]
        [HttpPost]

        public ActionResult insertCustomerMaster([FromBody] CustomerMaster customerMaster)
        {
            var result = CustomerMaster.insertCustomerMaster(customerMaster);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [Route("api/updateCustomerMaster")]
        [HttpPost]

        public ActionResult updateCustomerMaster([FromBody] CustomerMaster customer)
        {
            var result = CustomerMaster.updateCustomerMaster(customer);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        
    }
}