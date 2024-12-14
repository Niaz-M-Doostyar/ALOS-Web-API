using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ALOS_API.Helpers;
using AlOS_API.Models;
using ALOS_API.Models.Authentication;
using AlOS_API.Models.DbModels;
using AlOS_API.Models.Recharges;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AlOS_API.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class RechargeController : ControllerBase
    {
        private string  _successStatus = "Success";
        private string  _failedStatus = "Failed";

        private alosapiContext _context;
        private readonly IConfiguration _configuration;

        public static object LinksLock = new object();
        public RechargeController(alosapiContext context, IConfiguration configuration)
        {
            this._context = context;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("debit_balance")]
        public IActionResult RechargeDebits([FromQuery]RechargeModel model)
        {
            lock (LinksLock)
            {
                var user = _context.Users.FirstOrDefault(u => u.Name.Equals(model.Username));
             
                if (user != null)
                {
                    try
                    {
                        ApiLogs dbLogs = new ApiLogs()
                        {
                            TrnDate = DateTime.Now,
                            RechargeId = model.UniquerId,
                            Cid = Convert.ToInt32(user.Id),
                            Cname = user.Name,
                            Provider = model.Operator_Code,
                            Amount = model.Amount,
                            CustomerNo = Convert.ToString(model.Msisdn)
                        };
                
                        Requestlogs requestTbleDbLogs = new Requestlogs();
                        
                        if (LoginModel.LoginCheckViaMobileAndPinCode(user.Mobile, Convert.ToString(model.Msisdn), user.Pincode, model.PinCode))
                        {

                            if (user.Status.Equals("Disable"))
                            {
                                var response = new
                                {
                                    Status_message = "Faild",
                                    Status_Code = 0,
                                    Message = "User is Disable"
                                };

                                dbLogs.Request = JsonConvert.SerializeObject(model);
                                dbLogs.Status = this._failedStatus;
                                requestTbleDbLogs.Request = JsonConvert.SerializeObject(model);
                        
                                _context.ApiLogs.Add(dbLogs);
                                _context.Requestlogs.Add(requestTbleDbLogs);
                                _context.SaveChanges();
                                
                                return NotFound(response);
                            }

                            Object validatedOperator = RechargeModel.ValidateMobileNumberWithOperatorsCodes(Convert.ToString(model.Msisdn), model.Operator_Code, _context.ClientPermissions.FirstOrDefault(u => u.UserId == Convert.ToInt32(user.Id)));
                            
                            if (validatedOperator != null)
                            {
                                requestTbleDbLogs.Request = JsonConvert.SerializeObject(model);
                            
                                _context.Requestlogs.Add(requestTbleDbLogs);
                                _context.SaveChanges();
                                
                                return NotFound(validatedOperator);
                            }

                            var remiser = _context.Remisiers.Where(r => r.Uid.Equals(Convert.ToString(user.Id))).ToList().LastOrDefault();
                            
                            if (remiser != null)
                            {
                                if ((Convert.ToInt32(remiser.ClosingBalance) < Convert.ToInt32(model.Amount)) || (Convert.ToInt32(remiser.ClosingBalance) < 10))
                                {
                            
                                    var r = JsonConvert.SerializeObject(new
                                    {
                                        Status_message = "Faild",
                                        Status_Code = 0,
                                        Message = "You have insuffinet amount in your account"
                                    });
                                    
                                    dbLogs.Response = r;
                                    dbLogs.Request = JsonConvert.SerializeObject(model);
                                    dbLogs.Status = this._failedStatus;
                                    requestTbleDbLogs.Request = JsonConvert.SerializeObject(model);
                                    
                                    _context.ApiLogs.Add(dbLogs);
                                    _context.Requestlogs.Add(requestTbleDbLogs);
                                    _context.SaveChanges();
                                    
                                    return Ok(r);
                                }

                                if (model.Operator_Code.Equals("1") && (Convert.ToInt32(model.Amount) < 25))
                                {
                                    var r = Responses.RemiserValidatation("1");
                                    
                                    dbLogs.Response = r.ToString();
                                    dbLogs.Request = JsonConvert.SerializeObject(model);
                                    dbLogs.Status = this._failedStatus;
                                    requestTbleDbLogs.Request = JsonConvert.SerializeObject(model);
                                    
                                    _context.ApiLogs.Add(dbLogs);
                                    _context.Requestlogs.Add(requestTbleDbLogs);
                                    _context.SaveChanges();
                                    
                                    return Ok(r);
                                }

                                if (model.Operator_Code.Equals("2") && (Convert.ToInt32(model.Amount) < 10))
                                {
                                    var r = Responses.RemiserValidatation("2");
                                    
                                    dbLogs.Response = r.ToString();
                                    dbLogs.Request = JsonConvert.SerializeObject(model);
                                    dbLogs.Status = this._failedStatus;
                                    requestTbleDbLogs.Request = JsonConvert.SerializeObject(model);
                                    
                                    _context.ApiLogs.Add(dbLogs);
                                    _context.Requestlogs.Add(requestTbleDbLogs);
                                    _context.SaveChanges();
                                    
                                    return Ok(r);
                                }

                                if (model.Operator_Code.Equals("3") && (Convert.ToInt32(model.Amount) < 10))
                                {
                                    var r = Responses.RemiserValidatation("3");
                                    
                                    dbLogs.Response = r.ToString();
                                    dbLogs.Request = JsonConvert.SerializeObject(model);
                                    dbLogs.Status = this._failedStatus;
                                    requestTbleDbLogs.Request = JsonConvert.SerializeObject(model);
                                    
                                    _context.ApiLogs.Add(dbLogs);
                                    _context.Requestlogs.Add(requestTbleDbLogs);
                                    _context.SaveChanges();
                                    
                                    return Ok(r);
                                }

                                if (model.Operator_Code.Equals("4") && (Convert.ToInt32(model.Amount) < 10))
                                {
                                    var r = Responses.RemiserValidatation("4");
                                    
                                    dbLogs.Response = r.ToString();
                                    dbLogs.Request = JsonConvert.SerializeObject(model);
                                    dbLogs.Status = this._failedStatus;
                                    requestTbleDbLogs.Request = JsonConvert.SerializeObject(model);
                                    
                                    _context.ApiLogs.Add(dbLogs);
                                    _context.Requestlogs.Add(requestTbleDbLogs);
                                    _context.SaveChanges();
                                    
                                    return Ok(r);
                                }

                                if (model.Operator_Code.Equals("5") && (Convert.ToInt32(model.Amount) < 10))
                                {
                                    var r = Responses.RemiserValidatation("5");
                                    
                                    dbLogs.Response = r.ToString();
                                    dbLogs.Request = JsonConvert.SerializeObject(model);
                                    dbLogs.Status = this._failedStatus;
                                    requestTbleDbLogs.Request = JsonConvert.SerializeObject(model);
                                    
                                    _context.ApiLogs.Add(dbLogs);
                                    _context.Requestlogs.Add(requestTbleDbLogs);
                                    _context.SaveChanges();
                                    
                                    return Ok(r);
                                }

                                var validateUniquerIdForTransation = _context.Transactions.FirstOrDefault(t => t.TrnNo == long.Parse(model.UniquerId));
                                
                                if(validateUniquerIdForTransation!=null)
                                {
                                    var i = new
                                    {
                                        Status_message = "Faild",
                                        Status_Code = 0,
                                        Message = "Duplicate  Uniquerid"
                                    };
                                
                                    dbLogs.Response = JsonConvert.SerializeObject(i);
                                    dbLogs.Request = JsonConvert.SerializeObject(model);
                                    dbLogs.Status = this._failedStatus;
                                    requestTbleDbLogs.Request = JsonConvert.SerializeObject(model);
                                    
                                    _context.ApiLogs.Add(dbLogs);
                                    _context.Requestlogs.Add(requestTbleDbLogs);
                                    _context.SaveChanges();
                                    
                                    return Ok(i);
                                }
                                long totalBalance = long.Parse(remiser.ClosingBalance) - long.Parse(model.Amount);
                                
                                Remisiers remiserForSavingRecords = new Remisiers()
                                {
                                    Uid = Convert.ToString(user.Id),
                                    Amount = model.Amount,
                                    Remark = "Amount Debit by USSD",
                                    OpeningBalance = remiser.ClosingBalance,
                                    ClosingBalance = Convert.ToString(totalBalance),
                                    Module = "Recharged",
                                    Type = "Dr",
                                    TrnNo = model.UniquerId
                                };

                                Apis apiLogsForSavingRecords = new Apis()
                                {
                                    ClientOrderId = model.UniquerId,
                                    Status = "Pending"
                                };

                                Transactions transactionsForSavingRecords = new Transactions()
                                {
                                    Uid = Convert.ToInt32(user.Id),
                                    TrnNo = long.Parse(model.UniquerId),
                                    TrnDate = DateTime.Now.ToString(),
                                    Name = user.Name,
                                    Provider = model.Operator_Code,
                                    CustomerNo = Convert.ToString(model.Msisdn),
                                    Amount = model.Amount,
                                    Status = "Pending"
                                };
                               
                                dbLogs.Status = "Pending";
                                dbLogs.Request = JsonConvert.SerializeObject(model);

                                _context.Apis.Add(apiLogsForSavingRecords);
                                _context.ApiLogs.Add(dbLogs);
                                _context.Remisiers.Add(remiserForSavingRecords);
                                _context.Transactions.Add(transactionsForSavingRecords);
                                _context.SaveChanges();

                                //Request To Remote Server
                                var transferData = new
                                {
                                    mobile = model.Msisdn,
                                    amount = model.Amount,
                                    uniquerID = model.UniquerId,
                                    pass = "password"
                                };
                                string url = "https://alos.af/getRecharge.php";
                                string data = JsonConvert.SerializeObject(transferData);
                                
                                WebRequest myReq = WebRequest.Create(url);
                                myReq.Method = "POST";
                                myReq.ContentLength = data.Length;
                                myReq.ContentType = "application/json; charset=UTF-8";
                                
                                UTF8Encoding enc = new UTF8Encoding();
                                myReq.Headers.Remove("auth-token");
                                using (Stream ds = myReq.GetRequestStream())
                                {
                                    ds.Write(enc.GetBytes(data), 0, data.Length);
                                }
                                
                                WebResponse wr = myReq.GetResponse();
                                Stream receiveStream = wr.GetResponseStream();
                                StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
                                var co = reader.ReadToEnd();
                                var serverResponseData = JObject.Parse(co);

                                string serverStatus = serverResponseData["status_code"].ToString();
                                string serverTransactionId = serverResponseData["transaction_id"].ToString();
                                string serverResponseApi = serverResponseData["responseApi"].ToString();
                                
                                Transactions transactionForRemoteServer = _context.Transactions.FirstOrDefault(t => t.TrnNo == long.Parse(serverTransactionId));
                                ApiLogs apilogForRemoteServer = _context.ApiLogs.FirstOrDefault(a => a.RechargeId.Equals(serverTransactionId));
                                
                                string statusMessage = string.Empty;
                                
                                if (serverStatus.Equals("1"))
                                {
                                    transactionForRemoteServer.Status = "Success";
                                    apilogForRemoteServer.Status = "Success";
                                    statusMessage = "Recharge success!";
                                }
                                else if (serverStatus.Equals("0"))
                                {
                                    transactionForRemoteServer.Status = "Failed";
                                    apilogForRemoteServer.Status = "Failed";
                                    statusMessage = "Recharge Failed!";

                                    Remisiers remisiersUser = _context.Remisiers.Where(r => r.Uid.Equals(Convert.ToString(user.Id))).ToList().LastOrDefault();
                                    Remisiers rem = new Remisiers()
                                    {
                                        Uid = Convert.ToString(user.Id),
                                        Amount = model.Amount,
                                        Remark = "The Amount is Refund",
                                        OpeningBalance = remisiersUser.ClosingBalance,
                                        ClosingBalance = Convert.ToString(Convert.ToInt32(remisiersUser.ClosingBalance) + Convert.ToInt32(model.Amount)),
                                        Module = "Refund",
                                        Type = "Cr",
                                        TrnNo = model.UniquerId,
                                    };
                                    _context.Remisiers.Add(rem);
                                    apilogForRemoteServer.Response = serverResponseApi;
                                    _context.ApiLogs.Update(apilogForRemoteServer);
                                    _context.Transactions.Update(transactionForRemoteServer);
                                
                                    serverResponseApi = "Success";
                                    
                                    requestTbleDbLogs.Request = JsonConvert.SerializeObject(model);
                                    _context.Requestlogs.Add(requestTbleDbLogs);
                                    _context.SaveChanges();
                                    
                                    return Ok(new
                                    {
                                        status_code = serverStatus,
                                        status_message = serverResponseData["status_message"].ToString(),
                                        customer_num = model.Msisdn,
                                        amount = Convert.ToInt32(model.Amount),
                                        transaction_id = long.Parse(serverTransactionId),
                                        responseApi = statusMessage,
                                    });
                                }
                            }
                            else
                            {
                                return NotFound(new
                                {
                                    Status_message = "Faild",
                                    Status_Code = 0,
                                    Message = "Remiser Record Not Found"
                                });
                            }
                        }
                        else
                        {
                            dbLogs.Request = JsonConvert.SerializeObject(model);
                            dbLogs.Status = this._failedStatus;
                            requestTbleDbLogs.Request = JsonConvert.SerializeObject(model);
                            
                            _context.ApiLogs.Add(dbLogs);
                            _context.Requestlogs.Add(requestTbleDbLogs);
                            _context.SaveChanges();
                            
                            return NotFound(new
                            {
                                Status_message = "Faild",
                                Status_Code = 0,
                                Message = "Not Found User"
                            });
                        }
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
}