using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALOS_Web_Admin.Models.Api.DbModels;

namespace ALOS_Web_Admin.Controllers
{
    public class ReportsController : Controller
    {
        private alosapiContext _context = new alosapiContext();
        public ActionResult CreateVirtualBalance()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult CreateVirtualBalance(IFormCollection collection)
        {
            try
            {
                var startDate = Convert.ToDateTime(collection["start_date"].ToString());
                var endDate = Convert.ToDateTime(collection["end_date"].ToString());

                var adminWallet = _context.Adminwallets.Where(a => a.CreatedAt.Value.Date >= startDate.Date &&
                                                                   a.CreatedAt.Value.Date <= endDate.Date)
                    .OrderByDescending(a => a.Id).ToList();

                if (adminWallet.Count > 0)
                {
                    ViewBag.AdminWallet = adminWallet; 
                    return View();
                }

                ViewBag.Message = "Cannot found Records";
                return View();
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("User", "Exception " + ex.Message);
                return View();
            }
        }
    }
}
