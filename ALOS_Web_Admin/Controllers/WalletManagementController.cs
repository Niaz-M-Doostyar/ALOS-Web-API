using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALOS_Web_Admin.Models.Api.DbModels;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account.Manage;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ALOS_Web_Admin.Controllers
{
    public class WalletManagementController : Controller
    {
        private alosapiContext _context = new alosapiContext();

        public ActionResult TopUpTransfer(int id, bool isAgent)
        {
            if (isAgent == false && id == 0)
            {
                ViewBag.UserDetails = null;
                ViewBag.GRemiserDetails = null;
            }
            else
            {
                var res = (from u in _context.Users.ToList().Where(u => u.Id.Equals(Convert.ToUInt32(id)))
                    join r in _context.Remisiers.ToList() on u.Id.ToString() equals r.Uid into urg
                    from r in urg.DefaultIfEmpty()
                    select new {Users = u, GroupedRemiser = r}).ToList().LastOrDefault();
                ViewBag.UserDetails = res.Users;
                ViewBag.GRemiserDetails = res.GroupedRemiser;
            }

            ViewBag.Users = _context.Users.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult TopUpTransfer(IFormCollection collection)
        {
            try
            {
                Agents agent =
                    _context.Agents.FirstOrDefault(a => a.Name.Equals(HttpContext.Session.GetString("User")));
                Adminwallets adminwallet = _context.Adminwallets.Where(a => a.Admin.Equals(agent.Id.ToString()))
                    .ToList().LastOrDefault();
                if (Convert.ToDouble(adminwallet.ClosingBalance) >= Convert.ToDouble(collection["amount"].ToString()))
                {
                    var r = Convert.ToDouble(collection["amount"].ToString());
                    Topuptransfers topuptransfer = new Topuptransfers()
                    {
                        User = collection["memberId"].ToString(),
                        Amount = string.Format("{0}", r),
                        Remarks = collection["remarks"].ToString(),
                        Stutus = "Pending",
                        PaymentMode = collection["PaymentMode"].ToString(),
                        UpdatedAt = DateTime.Now,
                        CreatedAt = DateTime.Now
                    };
                    _context.Topuptransfers.Add(topuptransfer);
                    _context.SaveChanges();
                    ViewBag.Users = _context.Users.ToList();
                    ViewBag.Message = "Successfully Top up Transfer " + r + " amount";
                    return View();
                }

                ViewBag.Users = _context.Users.ToList();
                ViewBag.Message = "Amount is Greater then Balance";
                return View();

            }
            catch (Exception exception)
            {
                ViewBag.Users = _context.Users.ToList();
                ViewBag.Message = "Exception" + exception.Message;
                return View();
            }
        }

        public ActionResult TopUpDelivery()
        {
            ViewBag.TopUpTransfer = null;
            ViewBag.Users = null;

            return View();
        }

        [HttpPost]
        public ActionResult TopUpDelivery(IFormCollection collection)
        {
            try
            {
                if (collection["topupandfund"].ToString().Equals("topup"))
                {
                    ViewBag.TopUpTransfer = _context.Topuptransfers.Where(t => t.Stutus.Equals("pending")).ToList();
                }
                else
                {
                    ViewBag.TopUpTransfer = null;
                }

                return View();

            }
            catch (Exception e)
            {
                ViewBag.Message = "Exception " + e.Message;
                return View();
            }
        }

        public ActionResult ViewTopUpTransferById(int id)
        {
            var result = _context.Topuptransfers.FirstOrDefault(t => t.Id.Equals(Convert.ToUInt32(id)));
            ViewBag.Topup = result;
            return View();
        }

        [HttpPost]
        public ActionResult ViewTopUpTransferById(IFormCollection collection)
        {
            try
            {
                string topUpId = collection["toptransfer_id"].ToString();
                string userId = collection["user"].ToString();
                string amount = collection["amount"].ToString();
                string updatedAt = collection["updated_at"].ToString();
                string remarks = collection["remarks"].ToString();
                string status = collection["status"].ToString();
                string paymentMode = collection["PaymentMode"].ToString();

                if (collection["submitbutton"].ToString().Equals("Add"))
                {
                    var statusSuccss = "success";
                    long lastClosingBalance = 0;
                    long lastOpeningBalance = 0;
                    var topUpTransfer =
                        _context.Topuptransfers.FirstOrDefault(t => t.Id.Equals(Convert.ToUInt32(topUpId)));

                    var remisier = _context.Remisiers.Where(r => r.Uid.Equals(userId)).ToList().LastOrDefault();
                    var user = _context.Users.FirstOrDefault(u => u.Id.Equals(Convert.ToUInt32(userId)));
                    var all = _context.Remisiers.Where(a => a.Uid.Equals(userId)).ToList();
                    if (all.Count >= 1)
                    {

                        lastClosingBalance = Convert.ToInt64(remisier.ClosingBalance);
                        lastOpeningBalance = Convert.ToInt64(remisier.OpeningBalance);
                    }

                    TopupDeliveries topUpDelivery = new TopupDeliveries();
                    Remisiers rem = new Remisiers();

                    Agents authUser =
                        _context.Agents.FirstOrDefault(aut => aut.Name.Equals(HttpContext.Session.GetString("User")));
                    topUpDelivery.FirmName = userId;
                    topUpDelivery.TopupAmount = amount;
                    topUpDelivery.Remarks = remarks;
                    topUpDelivery.Status = statusSuccss;
                    topUpDelivery.UpdatedBy = authUser.Id.ToString();
                    topUpDelivery.PaymentMode = paymentMode;
                    topUpDelivery.UpdatedAt = DateTime.Now;
                    topUpDelivery.CreatedAt = DateTime.Now;

                    topUpTransfer.Stutus = statusSuccss;
                    topUpTransfer.UpdatedAt = DateTime.Now;

                    long totalBalance = lastClosingBalance + Convert.ToInt64(amount);
                    rem.Uid = userId;
                    rem.Amount = amount;
                    rem.Remark = remarks;
                    rem.OpeningBalance = string.Format("{0}", lastClosingBalance);
                    rem.ClosingBalance = string.Format("{0}", totalBalance);
                    rem.Module = "Fund Recived";
                    rem.Type = "Cr";
                    rem.TrnNo = "";
                    rem.UpdatedAt = DateTime.Now;
                    rem.CreatedAt = DateTime.Now;
                    _context.Remisiers.Add(rem);
                    _context.TopupDeliveries.Add(topUpDelivery);
                    _context.Entry(topUpTransfer).State = EntityState.Modified;

                    lastClosingBalance = 0;
                    lastOpeningBalance = 0;

                    var adminWallet = _context.Adminwallets.Where(a => a.Admin.Equals(authUser.Id.ToString())).ToList()
                        .LastOrDefault();
                    var allWallets = _context.Adminwallets.Where(a => a.Admin.Equals(authUser.Id.ToString())).ToList();
                    if (allWallets.Count >= 1)
                    {
                        lastClosingBalance = Convert.ToInt64(adminWallet.ClosingBalance);
                        lastOpeningBalance = Convert.ToInt64(adminWallet.OpeningBalance);

                    }

                    totalBalance = lastClosingBalance - Convert.ToInt64(amount);
                    var trn = new Random().Next(1000000, 90000000);

                    adminWallet = new Adminwallets();
                    adminWallet.UserId = userId;
                    adminWallet.Admin = authUser.Id.ToString();
                    adminWallet.Amount = amount;
                    adminWallet.Remark = remarks;
                    adminWallet.OpeningBalance = string.Format("{0}", lastClosingBalance);
                    adminWallet.ClosingBalance = string.Format("{0}", totalBalance);
                    adminWallet.Module = "Topup Transfer";
                    adminWallet.Type = "Dr";
                    adminWallet.TrnNo = trn.ToString();
                    adminWallet.UpdatedAt = DateTime.Now;
                    adminWallet.CreatedAt = DateTime.Now;
                    _context.Adminwallets.Add(adminWallet);
                    _context.SaveChanges();
                    return View("TopUpDelivery");

                }

                Topuptransfers topuptransfer =
                    _context.Topuptransfers.FirstOrDefault(t => t.Id.Equals(Convert.ToUInt32(topUpId)));
                topuptransfer.Stutus = "rejected";
                topuptransfer.UpdatedAt = DateTime.Now;
                _context.Entry(topuptransfer).State = EntityState.Modified;
                _context.SaveChanges();
                return View("TopUpDelivery");
            }
            catch (Exception e)
            {
                ViewBag.Message = "Exception " + e.Message;
                return View();
            }
        }

        public ActionResult SelfOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SelfOrder(IFormCollection collection)
        {
            try
            {
                var amount = collection["amount"].ToString();
                var remark = collection["remark"].ToString();
                Selforders selfOrder = new Selforders();
                int adminId = Convert.ToInt32(_context.Agents
                    .FirstOrDefault(a => a.Name.Equals(HttpContext.Session.GetString("User"))).Id);
                selfOrder.AdminId = adminId;
                selfOrder.Amount = amount;
                selfOrder.Remark = remark;
                selfOrder.Status = "Pending";
                selfOrder.UpdatedBy = adminId;
                selfOrder.Wallet = "";
                selfOrder.CreatedAt = DateTime.Now;
                selfOrder.UpdatedAt = DateTime.Now;
                _context.Selforders.Add(selfOrder);
                _context.SaveChanges();
                ViewBag.Message = "Self Order Added Successfully";
                return View();
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("User", "Exception " + exception.Message);
                return View();
            }
        }

        public ActionResult SelfDelivery()
        {
            ViewBag.Users = _context.Agents.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult SelfDelivery(IFormCollection collection)
        {
            try
            {
                var fromDate = Convert.ToDateTime(collection["fromdate"].ToString());
                var toDate = Convert.ToDateTime(collection["todate"].ToString());
                var agent = collection["agent"].ToString();
                var status = collection["status"].ToString();
                var agents = _context.Agents.ToList();
                var Selforders = _context.Selforders.Where(s=>
                                                                s.CreatedAt.Value.Date >= fromDate.Date &&
                                                                s.CreatedAt.Value.Date <= toDate.Date).ToList();
                if (!string.IsNullOrEmpty(status))
                    Selforders = Selforders.Where(s => s.Status.Equals(status)).ToList();
                if (!string.IsNullOrEmpty(agent))
                    Selforders = Selforders.Where(s => s.UpdatedBy.Equals(Convert.ToInt32(agent))).ToList();
                
                ViewBag.SelfDelivery = Selforders;
                ViewBag.Users = agents;
                return View();
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("User", "Exception " + exception.Message);
                return View();
            }
        }

        public ActionResult ViewSelfDeliveryById(int id)
        {
            try
            {
                var Selforders = _context.Selforders.FirstOrDefault(s => s.Id.Equals(Convert.ToUInt32(id)));
                ViewBag.SelfDelivery = Selforders;
                return View();
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("User", "Exception " + exception.Message);
                return View();
            }
        }

        [HttpPost]
        public ActionResult ViewSelfDeliveryById(IFormCollection collection)
        {
            try
            {
                string dilId = collection["delivery_id"].ToString();
                string adminId = collection["user"].ToString();
                string amount = collection["amount"].ToString();
                string updatedAt = collection["updated_at"].ToString();
                string remark = collection["remark"].ToString();
                string status = collection["status"].ToString();

                if (collection["submitbutton"].ToString().Equals("Add"))
                {

                    long lastClosingBalance = 0;
                    long lastOpeningBalance = 0;

                    var agent = _context.Agents.ToList();
                    var admin = _context.Agents.FirstOrDefault(
                        a => a.Name.Equals(HttpContext.Session.GetString("User")));
                    var adminWallet = _context.Adminwallets.Where(u => u.UserId.Equals(admin.Id.ToString())).ToList()
                        .LastOrDefault();
                    var all = _context.Adminwallets.Where(a => a.UserId.Equals(admin.Id.ToString())).ToList();
                    if (all.Count >= 1)
                    {
                        lastClosingBalance = Convert.ToInt64(adminWallet.ClosingBalance);
                        // $last_opening_balance=$admin_wallet->opening_balance;
                    }

                    long totalBalance = lastClosingBalance + Convert.ToInt64(amount);
                    var trn = new Random().Next(100000, 900000000);
                    var admin_wallet = new Adminwallets();
                    admin_wallet.UserId = admin.Id.ToString();
                    admin_wallet.Admin = admin.Id.ToString();
                    admin_wallet.Amount = amount;
                    admin_wallet.Remark = remark;
                    admin_wallet.OpeningBalance = string.Format("{0}", lastClosingBalance);
                    admin_wallet.ClosingBalance = totalBalance.ToString();
                    admin_wallet.Module = "Self Delivery";
                    admin_wallet.Type = "Cr";
                    admin_wallet.TrnNo = trn.ToString();
                    _context.Adminwallets.Add(admin_wallet);

                    var selforder = this._context.Selforders.FirstOrDefault(s => s.Id.Equals(Convert.ToUInt32(dilId)));
                    selforder.AdminId = Convert.ToInt32(admin.Id);
                    selforder.Amount = amount;
                    selforder.Remark = remark;
                    selforder.Status = "Success";
                    selforder.UpdatedBy = Convert.ToInt32(admin.Id);
                    selforder.Wallet = "";
                    selforder.UpdatedAt = DateTime.Now;
                    _context.Entry(selforder).State = EntityState.Modified;

                    _context.SaveChanges();
                    return View("SelfDelivery");

                }

                Selforders selfOrder = _context.Selforders.FirstOrDefault(s => s.Id.Equals(Convert.ToUInt32(dilId)));
                selfOrder.UpdatedAt = DateTime.Now;
                selfOrder.Status = "Rejected";
                _context.Entry(selfOrder).State = EntityState.Modified;
                _context.SaveChanges();
                return View("SelfDelivery");

            }
            catch (Exception exception)
            {
                ModelState.AddModelError("User", "Exception " + exception.Message);
                return View();
            }
        }

        public ActionResult MemberDebit(int id, bool isAgent)
        {
            if (isAgent == false && id == 0)
            {
                ViewBag.UserDetails = null;
                ViewBag.GRemiserDetails = null;
            }
            else
            {
                var res = (from u in _context.Users.ToList().Where(u => u.Id.Equals(Convert.ToUInt32(id)))
                    join r in _context.Remisiers.ToList() on u.Id.ToString() equals r.Uid into urg
                    from r in urg.DefaultIfEmpty()
                    select new {Users = u, GroupedRemiser = r}).ToList().LastOrDefault();
                ViewBag.UserDetails = res.Users;
                ViewBag.GRemiserDetails = res.GroupedRemiser;
            }

            ViewBag.Users = _context.Users.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult MemberDebit(IFormCollection collection)
        {
            try
            {
                string memberId = collection["memberId"].ToString();
                string customerNo = collection["customer_no"].ToString();
                string amount = collection["amount"].ToString();
                string provider = collection["providers"].ToString();
                string remarks = collection["remark"].ToString();

                var statusSuccss = "success";
                long lastClosingBalance = 0;
                long lastOpeningBalance = 0;

                var rem = _context.Remisiers.Where(r => r.Uid.Equals(memberId)).ToList().LastOrDefault();
                var all = _context.Remisiers.Where(r => r.Uid.Equals(memberId)).ToList();

                if (all.Count >= 1)
                {
                    lastClosingBalance = Convert.ToInt64(rem.ClosingBalance);
                    lastOpeningBalance = Convert.ToInt64(rem.OpeningBalance);
                }
                var rand = new Random().Next(100000, 90000000);
                var transaction = new Transactions();
                var userName = _context.Users.FirstOrDefault(u => u.Id.Equals(Convert.ToUInt32(memberId))).Name;
                transaction.Uid = Convert.ToInt32(memberId);
                transaction.TrnDate = string.Format("{0}", DateTime.Now);
                transaction.TrnNo = rand;
                transaction.Name = userName;
                transaction.Provider = provider;
                transaction.CustomerNo = customerNo;
                transaction.Amount = amount;
                transaction.Status = "Success";
                transaction.Remarks = remarks;
                transaction.CreatedAt = DateTime.Now;
                transaction.UpdatedAt = DateTime.Now;
                _context.Transactions.Add(transaction);

                var remisier = new Remisiers();
                remisier.Uid = memberId;
                remisier.Amount = amount;
                remisier.TrnNo = rand.ToString();
                remisier.Remark = remarks;
                remisier.OpeningBalance = string.Format("{0}", lastClosingBalance);
                remisier.ClosingBalance = string.Format("{0}", lastClosingBalance - Convert.ToInt64(amount));
                remisier.Module = "Fund Transfer";
                remisier.Type = "Dr";
                remisier.TrnNo = "";
                remisier.CreatedAt = DateTime.Now;
                remisier.UpdatedAt = DateTime.Now;
                _context.Remisiers.Add(remisier);
                _context.SaveChanges();

                ViewBag.Users = _context.Users.ToList();
                ViewBag.Message = "Successfully Debited " + amount + " amount";
                return View();
            }
            catch (Exception exception)
            {
                ViewBag.Users = _context.Users.ToList();
                ViewBag.Message = "Exception" + exception.Message;
                return View();
            }
        }
    }
}
