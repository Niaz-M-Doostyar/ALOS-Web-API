using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ALOS_Web_Admin.Models.Api.DbModels;

namespace ALOS_Web_Admin.Controllers
{
    public class RechargeReportController : Controller
    {
        private alosapiContext _context = new alosapiContext();
        public ActionResult ListViewRechargeReconsiliation()
        {
            var transactions  = (from item in _context.Transactions
                where item.CreatedAt >= DateTime.Now.Date &&
                      item.CreatedAt <= DateTime.Now.AddDays(1).Date
                select item).ToList().OrderByDescending(t=>t.Id);
            ViewBag.Transactions = transactions;
            return View();
        }
        
        public ActionResult CreateRechargeReconsiliation()
        {
            var clients = _context.Users.ToList();
            ViewBag.Users = clients;
            return View();
        }
        [HttpPost]
        public ActionResult CreateRechargeReconsiliation(IFormCollection collection)
        {
            try
            {
                string provider = collection["provider"].ToString();
                string status = collection["status"].ToString();
                string rechId = collection["rech_id"].ToString();
                string memberType = collection["memberType"].ToString();
                string startDate = collection["start_date"].ToString();
                string endDate = collection["end_date"].ToString();
                string endTime = collection["end_time"].ToString();
                string strTime = collection["str_time"].ToString();
                string customerNo = collection["customerNo"].ToString();
                string member = collection["member"].ToString();
            
                if (string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate))
                {
                    ModelState.AddModelError("User","Correct Empty Fields");
                    ViewBag.Users = _context.Users.ToList();
                    return View(collection);
                }
                
                var user = _context.Users.FirstOrDefault(u => u.Id.Equals(Convert.ToUInt32(member)));
                var transaction = _context.Transactions.ToList().Where(t=> DateTime.Parse(t.TrnDate) >= DateTime.Parse(startDate) &&
                                                                           DateTime.Parse(t.TrnDate) <= DateTime.Parse(endDate));
                if (!string.IsNullOrEmpty(provider))
                    transaction = transaction.Where(t => t.Provider.Equals(provider)).ToList();
                if (!string.IsNullOrEmpty(status))
                    transaction = transaction.Where(t => t.Status.Equals(status)).ToList();
                if (!string.IsNullOrEmpty(member))
                    transaction = transaction.Where(t => t.Uid.Equals(Convert.ToInt32(user.Id))).ToList();
                if (!string.IsNullOrEmpty(customerNo))
                    transaction = transaction.Where(t => t.CustomerNo.Equals(customerNo)).ToList();
                //var transaction = _context.Transactions.Where(
                //    t => t.Uid.Equals(Convert.ToInt32(user.Id)) &&
                //         t.Status.Equals(status) &&
                //         t.Provider.Equals(provider) ||
                //         t.CustomerNo.Equals(customerNo)).ToList();

                ViewBag.Transactions = transaction;
                ViewBag.UserName = user.Name; 
                ViewBag.Users = _context.Users.ToList();
                return View();
            }
            catch(Exception exception)
            {
                ModelState.AddModelError("User", "Exception"+exception.Message);
                return View(collection);
            }
        }
        public ActionResult CreateFundTransferRechargeReconsiliation()
        {
            var clients = _context.Users.ToList();
            ViewBag.Users = clients;
            return View();
        }
        [HttpPost]
        public ActionResult CreateFundTransferRechargeReconsiliation(IFormCollection collection)
        {
            try
            {
                string startDate = collection["start_date"].ToString();
                string endDate = collection["end_date"].ToString(); 
                string member = collection["member"].ToString();
                if (string.IsNullOrEmpty(member) || string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate))
                {
                    ModelState.AddModelError("User", "Correct Empty Fields");
                    ViewBag.Users = _context.Users.ToList();
                    return View(collection);
                }

                var remiser = _context.Remisiers.ToList().Where(r =>
                    r.Uid.Equals(member) && r.CreatedAt >= DateTime.Parse(startDate) &&
                    r.CreatedAt <= DateTime.Parse(endDate)).ToList();

                var clients = _context.Users.ToList();
                if (remiser != null && remiser.Count > 0)
                    ViewBag.Remiser = remiser;
                var user = _context.Users.FirstOrDefault(u => u.Id.Equals(Convert.ToUInt32(member)));
                ViewBag.UserName = user.Name;
                ViewBag.Mobile = user.Mobile;
                ViewBag.Users = clients;
                return View();
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("User", "Exception" + exception.Message);
                return View(collection);
            }
            
        }
        public ActionResult CreateApiLogsRechargeReconsiliation()
        {
            var clients = _context.Users.ToList();
            ViewBag.Users = clients;
            return View();
        }
        [HttpPost]
        public ActionResult CreateApiLogsRechargeReconsiliation(IFormCollection collection)
        {
            try
            {
                string provider = collection["provider"].ToString();
                
                string startDate = collection["start_date"].ToString();
                string endDate = collection["end_date"].ToString();

                string endTime = collection["end_time"].ToString();
                string strTime = collection["str_time"].ToString();

                string member = collection["member"].ToString();

                if (string.IsNullOrEmpty(member) || 
                    string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate))
                {
                    ModelState.AddModelError("User", "Correct Empty Fields");
                    ViewBag.Users = _context.Users.ToList();
                    return View(collection);
                }
                var user = _context.Users.FirstOrDefault(u => u.Id.Equals(Convert.ToUInt32(member)));
                var logs = _context.ApiLogs.Where(
                    t => t.Cid.Equals(Convert.ToInt32(user.Id))).ToList();
                if (!string.IsNullOrEmpty(provider))
                {
                    logs=logs.Where(
                        t => t.Cid.Equals(Convert.ToInt32(user.Id)) &&
                             t.Provider.Equals(provider)).ToList();
                }

                ViewBag.Logs = logs.ToList().Where(t =>
                    t.TrnDate >= DateTime.Parse(startDate) &&
                    t.TrnDate <= DateTime.Parse(endDate));
                ViewBag.Provider = provider;
                ViewBag.UserName = user.Name;
                ViewBag.Users = _context.Users.ToList();
                return View();


            }
            catch (Exception exception)
            {
                ModelState.AddModelError("User", "Exception" + exception.Message);
                return View(collection);
            }
            
        }
        public ActionResult CreateRequestApiLogsRechargeReconsiliation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRequestApiLogsRechargeReconsiliation(IFormCollection collection)
        {
            try
            {

                string startDate = collection["start_date"].ToString();
                string endDate = collection["end_date"].ToString();
                
                if (string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate))
                {
                    ModelState.AddModelError("User", "Correct Empty Fields");
                    return View(collection);
                }
                
                ViewBag.Logs = _context.Requestlogs.Where(t =>
                    t.CreatedAt >= DateTime.Parse(startDate) &&
                                    t.CreatedAt <= DateTime.Parse(endDate)).ToList();
                return View();

                
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("User", "Exception" + exception.Message);
                return View(collection);
            }
        }
    }
}
