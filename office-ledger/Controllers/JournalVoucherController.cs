using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using office_ledger.Models;
using office_ledger.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace office_ledger.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class JournalVoucherController : ControllerBase
    {
        IJournalVoucher journal;

        public JournalVoucherController(IJournalVoucher _journal)
        {
            journal = _journal;
        }

     [Route("api/insertJournalVoucher")]
     [HttpPost]
     public ActionResult insertJournalVoucher([FromBody] JournalVoucher voucher)
        {
            JObject RequestBody = JObject.FromObject(voucher);
            string json = RequestBody.ToString();

            //JArray a = JArray.Parse(json);

            XmlDocument doc1 = JsonConvert.DeserializeXmlNode(json, "root");
            string xml = doc1.InnerXml;

            var result = journal.insertJorunalVoucher(xml);

            return Ok(result);
        }

        [Route("api/selectJournalVoucher")]
        [HttpPost]

        public ActionResult selectJournalVoucher( JournalVoucherMaster voucherMaster)
        {
            var key = voucherMaster.vochno.ToString();
            var result = journal.selectJournalVoucherByFile(key);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [Route("api/getJournalVoucher")]
        [HttpGet]

        public ActionResult getJournalVoucher()
        {
            var result = journal.getJournalVoucher();
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

       [Route("api/getVochChartOfAccount")]
       [HttpGet]
       public ActionResult getVochChartOfAccount()
        {
            var result = journal.getVochChartOfAccount();
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
