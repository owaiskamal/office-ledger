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
    public class BusinessController : ControllerBase
    {
        IBusinessUnits businessUnits;
       public BusinessController(IBusinessUnits _businessUnits)
        {
            businessUnits = _businessUnits;
        }

        [Route("api/GetBusinesses")]
        public ActionResult GetBussinesses()
        {
            var result = businessUnits.GetBusinessUnits();
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