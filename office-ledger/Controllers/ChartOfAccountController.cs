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
    public class ChartOfAccountController : ControllerBase
    {
        IChartOfAccount chartOfAccount;

        public ChartOfAccountController(IChartOfAccount _chartOfAccount)
        {
            chartOfAccount = _chartOfAccount;
        }

        [Route("api/getChartOfAccount")]
        [HttpGet]

        public ActionResult getChartOfAccount()
        {
            var result = chartOfAccount.getChartOfAccount();
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [Route("api/insertChartOfAccount")]
        [HttpPost]

        public ActionResult insertChartOFAccount([FromBody] ChartOfAccount chart)
        {
            var result = chartOfAccount.insertChartOfAccount(chart);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [Route("api/updateChartoFAccount")]
        [HttpPost]

        public ActionResult updateChartOfAccount([FromBody] ChartOfAccount chart)
        {
            var result = chartOfAccount.updateChartOfAccount(chart);
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