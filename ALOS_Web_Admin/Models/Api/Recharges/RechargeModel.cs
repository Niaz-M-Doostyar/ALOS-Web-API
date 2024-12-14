using System;
using System.IO;
using System.Net;
using System.Text;
using ALOS_Web_Admin.Models.Api.DbModels;
using Newtonsoft.Json;

namespace ALOS_Web_Admin.Models.Api.Recharges
{
    public class RechargeModel
    {
        public string Msisdn { get; set; }
        public string Operator_Code { get; set; }
 
        public string Amount { get; set; }
    
        public string Username { get; set; }
   
        public string UniquerId { get; set; }
     
        public string PinCode { get; set; }
        public static Object ValidateMobileNumberWithOperatorsCodes(string mobile,string operatorCode, ClientPermissions client)
        {
            mobile = mobile.Substring(0, 3);
            if (operatorCode.Equals("1") && !(mobile.Equals("070")) && !(mobile.Equals("071")))
                return InvalidOperators();
            if (operatorCode.Equals("2") && !(mobile.Equals("079")) && !(mobile.Equals("072")))
                return InvalidOperators();
            if (operatorCode.Equals("3") && !(mobile.Equals("074")))
                return InvalidOperators();
            if (operatorCode.Equals("4") && !(mobile.Equals("078")) && !(mobile.Equals("073")))
                return InvalidOperators();
            if (operatorCode.Equals("5") && !(mobile.Equals("076")) && !(mobile.Equals("077")))
                return InvalidOperators();
            if (operatorCode.Equals("1") && client.Awcc.Equals("0"))
                return ServiceDisable("AWCC");
            if (operatorCode.Equals("2") && client.Awcc.Equals("0"))
                return ServiceDisable("Roshan");
            if (operatorCode.Equals("3") && client.Awcc.Equals("0"))
                return ServiceDisable("Salaam");
            if (operatorCode.Equals("4") && client.Awcc.Equals("0"))
                return ServiceDisable("Etisalat");
            if (operatorCode.Equals("5") && client.Awcc.Equals("0"))
                return ServiceDisable("MTN");
            return null;
        }
        public static object GetRemoteServerRequestData(string mobile,string amount,string uniquerId,string pass)
        {
            var transferData = new
            {
                mobile = mobile,
                amount = amount,
                uniquerID = uniquerId,
                pass = pass
            };

            string url = "http://localhost:8081/apialos/getRecharge1.php";
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
            var content = JsonConvert.DeserializeObject(reader.ReadToEnd());
            return content;
        }

        public static Object InvalidOperators()
        {
            var response = new
            {
                Status_message = "Faild",
                Status_Code = 0,
                Message = "Your Operator code is wrong with number"
            };

            return response;
        }
        public static Object ServiceDisable(string operatorName)
        {
            var response = new
            {
                Status_message = "Faild",
                Status_Code = 0,
                Message = "Your " + operatorName + " service is disable Or your Operator code is wrong with number"
            };

            return response;
        }
    }
}
