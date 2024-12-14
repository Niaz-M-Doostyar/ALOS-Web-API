using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlOS_API.Helpers;
using Newtonsoft.Json;

namespace ALOS_API.Helpers
{
    public class Responses
    {

        public string StatusCode { get; set; }
        public string Status { get; set; }
        public string Data { get; set; }

        public static Object RemiserValidatation(string operator_)
        {
            var response = new object();
            switch (operator_)
            {
                case "1":
                    response = new
                    {
                        Status_message = "Failed",
                        Status_Code = 0,
                        Message = Messages.Operator1AmountMessage
                    };
                    return response;
                case "2":
                    response = new
                    {
                        Status_message = "Failed",
                        Status_Code = 0,
                        Message = Messages.Operator2AmountMessage
                    };
                    return response;
                case "3":
                    response = new
                    {
                        Status_message = "Failed",
                        Status_Code = 0,
                        Message = Messages.Operator3AmountMessage
                    };
                    return response;
                case "4":
                    response = new
                    {
                        Status_message = "Failed",
                        Status_Code = 0,
                        Message = Messages.Operator4AmountMessage
                    };
                    return response;
                case "5":
                    response = new
                    {
                        Status_message = "Failed",
                        Status_Code = 0,
                        Message = Messages.Operator5AmountMessage
                    };
                    return response;
                default: return null;
            }
        }
    }
}
