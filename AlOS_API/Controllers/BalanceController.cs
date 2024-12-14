using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ALOS_API.Helpers;
using AlOS_API.Models;
using ALOS_API.Models.Authentication;
using AlOS_API.Models.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic.CompilerServices;

namespace AlOS_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/client")]
    public class BalanceController : ControllerBase
    {
        private alosapiContext _context;
        private readonly IConfiguration _configuration;

        public BalanceController(alosapiContext context, IConfiguration configuration)
        {
            this._context = context;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("checkBalance")]
        public async Task<IActionResult> CheckBalance([FromQuery]LoginModel model)
        {

            var user = _context.Users.FirstOrDefault(u => u.Name.Equals(model.Username));
            if (user != null)
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        if (model.Mobile == null)
                            return NotFound(new
                            {
                                Status_message = "Failed",
                                Status_Code = 0,
                                data = "Mobile Number Required"
                            });
                        if (model.PinCode == null)
                        {
                            return NotFound(new
                            {
                                Status_message = "Failed",
                                Status_Code = 0,
                                data = "Pin code Number Required"
                            });
                        }
                        if(model.Username == null)
                            return NotFound(new
                            {
                                Status_message = "Failed",
                                Status_Code = 0,
                                data = "Username Required"
                            });
                    }

                    if (LoginModel.LoginCheckViaMobileAndPinCode(user.Mobile, model.Mobile, user.Pincode, model.PinCode))
                    {
                        var remisier = _context.Remisiers.Where(r => r.Uid.Equals(Convert.ToString(user.Id))).ToList().LastOrDefault();
                        if (remisier != null)
                        {
                            var rem = new
                            {
                                name = string.Concat("", user.Name),
                                Mobile = user.Mobile,
                                Closing_balance = remisier.ClosingBalance
                            };
                            return Ok(new
                            {
                                Status_message = "Success",
                                Status_Code = 1,
                                data = rem
                            });
                        }
                        else
                        {
                            return NotFound(new
                            {
                                Status_message = "Failed",
                                Status_Code = "0"
                            });
                        }
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