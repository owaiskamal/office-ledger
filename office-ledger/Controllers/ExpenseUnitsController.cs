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
    public class ExpenseUnitsController : ControllerBase
    {
        IExpenseUnit expenseUnit;

        public ExpenseUnitsController(IExpenseUnit _unit)
        {
            expenseUnit = _unit;
        }
        [Route("api/getExpenseUnit")]
        [HttpPost]
        public ActionResult getExpenseUnit([FromBody] ExpenseUnits expense) 
        {
            try
            {
                var result = expenseUnit.getExpenseUnits(expense);
                if(result  == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [Route("api/getExpBusinessUnit")]
        [HttpGet]

        public ActionResult getExpBusinessUnits()
        {
            try
            {
                var result = expenseUnit.getExpBusinessUnits();
                if(result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }

            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("api/insertExpenseUnit")]
        [HttpPost]
        public  ActionResult insertExpenseUnit([FromBody] ResponseModel ReqBody)
        { 
        try
            {

                JObject RequestBody = JObject.FromObject(ReqBody);
                string json = RequestBody.ToString();

                //JArray a = JArray.Parse(json);

                XmlDocument doc1 = JsonConvert.DeserializeXmlNode(json, "root");
                string xml = doc1.InnerXml;


                //ExpenseUnits data = new ExpenseUnits(); 
                // var result = expenseUnit.insertExpenseUnit(data);
                //  if(result == null)
                // {
                //     return NotFound();
                // }
                //  else
                // {
                     return Ok();
                // }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }


    public class TransRequest
    {
        public JObject TransactionRequest;
    }

}
