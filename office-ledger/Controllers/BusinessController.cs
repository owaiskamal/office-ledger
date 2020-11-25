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
    public class BusinessController : ControllerBase
    {
        IBusinessUnits businessUnits;
       public BusinessController(IBusinessUnits _businessUnits)
        {
            businessUnits = _businessUnits;
        }

        [Route("api/GetBusinesses")]
        [HttpGet]
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
        [Route("api/GetBusinessById")]
        [HttpPost]

        public ActionResult GetBusinessById([FromBody] BusinessUnits busUnits)
        {
            var result = businessUnits.GetBusinessUnitById(busUnits);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [Route ("api/InsertBusinessUnits")]
        [HttpPost]
        public ActionResult InserBusinessUnits([FromBody] BusinessUnits busUnits)
        {
            
            var result = businessUnits.InsertBusinessUnits(busUnits);
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