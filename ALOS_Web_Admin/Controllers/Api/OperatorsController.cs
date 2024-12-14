﻿using System;
using System.Linq;
using System.Threading.Tasks;
using ALOS_Web_Admin.Models.Api.Authentication;
using ALOS_Web_Admin.Models.Api.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ALOS_Web_Admin.Controllers.Api
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