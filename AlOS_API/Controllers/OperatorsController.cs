using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlOS_API.Models;
using ALOS_API.Models.Authentication;
using AlOS_API.Models.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AlOS_API.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class OperatorsController : ControllerBase
    {
        private alosapiContext _context;
        private readonly IConfiguration _configuration;

        public OperatorsController(alosapiContext context, IConfiguration configuration)
        {
            this._context = context;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("operator_list")]
        public async Task<IActionResult> OperatorsList([FromQuery]LoginModel model)
        {

            var user = _context.Users.FirstOrDefault(u => u.Name.Equals(model.Username));
            if (user != null)
            {
                try
                {

                    if (LoginModel.LoginCheckViaMobileAndPinCode(user.Mobile, model.Mobile, user.Pincode, model.PinCode))
                    {
                        var operators = new
                        {
                            AWCC = 1,
                            ROSHAN = 2,
                            ETISALAT = 3,
                            SALAAM = 4,
                            MTN = 5
                        };
                        return Ok(new
                        {
                            Status_message = "Success",
                            Status_Code = 1,
                            data = operators
                        });

                    }

                    return Unauthorized();
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return Unauthorized();
        }

    }
}