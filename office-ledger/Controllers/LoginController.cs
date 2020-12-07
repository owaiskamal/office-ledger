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
    public class LoginController : ControllerBase
    {
        IUserLogin userLogin;

        public LoginController(IUserLogin _userLogin)
        {
            userLogin = _userLogin;
        }

        [Route("api/getUserLogin")]
        [HttpPost]
        public ActionResult getLogin([FromBody] UserLogin userLog)
        {
            var result = userLogin.getUserLogin(userLog);
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