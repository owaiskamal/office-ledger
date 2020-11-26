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
    public class CostCentersController : ControllerBase
    {
        ICostCenter iCostCenter;

      

        public CostCentersController(ICostCenter _costCenter)
        {
            iCostCenter = _costCenter;
        }

        [Route("api/GetCostCenters")]
        [HttpGet]
        public ActionResult GetCostCenters()
        {
            var result = iCostCenter.GetCostCenters();
            if(result == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(result);
            }
        }

        [Route("api/GetCostCentersById")]
        [HttpPost]
        public ActionResult GetCostCentersById([FromBody] CostCenter costCenter)
        {
            var result = iCostCenter.GetCostCentersById(costCenter);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [Route("api/InsertCostCenters")]
        [HttpPost]
        public ActionResult InsertCostCenters([FromBody] CostCenter costCenter)
        {
            var result = iCostCenter.InsertCostCenters(costCenter);
            if(result == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(result);
            }
        }

        [Route("api/UpdateCostCenters")]
        [HttpPost]

        public ActionResult UpdataCostCenters([FromBody] CostCenter costCenter)
        {
            var result = iCostCenter.UpdateCostCenter(costCenter);
            if (result == null)
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