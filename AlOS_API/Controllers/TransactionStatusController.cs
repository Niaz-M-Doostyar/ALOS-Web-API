using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlOS_API.Models;
using ALOS_API.Models.Authentication;
using AlOS_API.Models.DbModels;
using AlOS_API.Models.TransactionStatus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AlOS_API.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class TransactionStatusController : ControllerBase
    {
        private alosapiContext _context;
        private readonly IConfiguration _configuration;

        public TransactionStatusController(alosapiContext context, IConfiguration configuration)
        {
            this._context = context;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("Transaction_status")]
        public async Task<IActionResult> TransactionStatus([FromQuery]TransactionsStatus model)
        {

            var user = _context.Users.FirstOrDefault(u => u.Name.Equals(model.UserName));
            if (user != null)
            {
                try
                {

                    if (LoginModel.LoginCheckViaMobileAndPinCode(user.Mobile, model.Mobile, user.Pincode, model.PinCode))
                    {
                        var transactionStatus = _context.Transactions.FirstOrDefault(r => Convert.ToString(r.TrnNo).Equals(model.UniquerId));
                        if (transactionStatus != null)
                        {
                            var rem = new
                            {
                                customer_No = string.Concat("", transactionStatus.CustomerNo),
                                Amount = transactionStatus.Amount,
                                Txn_Date = transactionStatus.TrnDate,
                                Status = "Success"
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

                    return Unauthorized(new{
                        Status_message = "Failed",
                        Status_Code = "0",
                        data = "Pincode or Mobile Number Not Matching"
                    });
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