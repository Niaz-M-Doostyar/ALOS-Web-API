using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ALOS_Web_Admin.Models.Api.DbModels;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account.Manage;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ALOS_Web_Admin.Controllers
{
    public class CustomManagementController : Controller
    {
        private alosapiContext _context = new alosapiContext();
        public ActionResult Registration()
        {
            ViewBag.roles = _context.Roles.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Registration(IFormCollection collection)
        {
            try
            {
                var userResult = _context.Users.FirstOrDefault(u =>
                    u.Email.Equals(collection["email"].ToString()) &&
                    u.Mobile.Equals(collection["mobile"].ToString()) && u.Name.Equals(collection["name"].ToString()));
                if (userResult != null)
                {
                    ViewBag.roles = _context.Roles.ToList();
                    ModelState.AddModelError("User", "The user is allready registerd  as Client");
                    return View(collection);
                }

                var agentResult = _context.Agents.FirstOrDefault(a =>
                    a.Name.Equals(collection["name"].ToString()) && a.Email.Equals(collection["email"].ToString()) &&
                    a.Mobile.Equals(collection["mobile"].ToString()));
                if (agentResult != null)
                {
                    ModelState.AddModelError("User", "The user is allready registerd  as Agent");
                    ViewBag.roles = _context.Roles.ToList();
                    return View(collection);
                }

                if (Convert.ToInt32(collection["roleId"].ToString()) < 4)
                {
                    Agents agent = new Agents()
                    {
                        Name = collection["name"].ToString(),
                        Mobile = collection["mobile"].ToString(),
                        Email = collection["email"].ToString(),
                        RoleId = Convert.ToInt32(collection["roleId"].ToString()),
                        Pincode = collection["pinCode"].ToString(),
                        Status = collection["status"].ToString(),
                        Password = collection["password"].ToString(),
                        Companyname = collection["companyName"].ToString(),
                        Address = collection["address"].ToString(),
                        City = collection["city"].ToString(),
                        Country = collection["country"].ToString(),
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };
                    _context.Agents.Add(agent);
                    _context.SaveChanges();
                    string agentId = Convert.ToString(_context.Agents.OrderByDescending(a => a.Id).ToList()[0].Id);
                    Adminwallets adminWallet = new Adminwallets()
                    {
                        UserId = agentId,
                        Admin = agentId,
                        Type = "Cr",
                        OpeningBalance = "0",
                        Amount = "0",
                        ClosingBalance = "0",
                        Module = "initial",
                        TrnNo = "",
                        Remark = "",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };
                    _context.Adminwallets.Add(adminWallet);
                    ClientPermissions clientPermission = new ClientPermissions()
                    {
                        UserId = Convert.ToInt32(agentId),
                        Awcc = "1",
                        Roshan = "1",
                        Salaam = "1",
                        Etisalat = "1",
                        Mtn = "1",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };
                    _context.ClientPermissions.Add(clientPermission);
                    _context.SaveChanges();
                    ViewBag.Message = "User Created Successfully";
                    return View();
                }
                else
                {
                    Users user = new Users()
                    {
                        Name = collection["name"].ToString(),
                        Mobile = collection["mobile"].ToString(),
                        Email = collection["email"].ToString(),
                        RoleId = Convert.ToInt32(collection["roleId"].ToString()),
                        Pincode = collection["pinCode"].ToString(),
                        Status = collection["status"].ToString(),
                        Password = collection["password"].ToString(),
                        Companyname = collection["companyName"].ToString(),
                        Address = collection["address"].ToString(),
                        City = collection["city"].ToString(),
                        Country = collection["country"].ToString(),
                        Commission = collection["commission"].ToString(),
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    string userId = _context.Users.OrderByDescending(u => u.Id).ToList()[0].Id.ToString();
                    Remisiers remisier = new Remisiers()
                    {
                        Uid = userId,
                        Type = "Cr",
                        OpeningBalance = "0",
                        Amount = "0",
                        ClosingBalance = "0",
                        Module = "initial",
                        TrnNo = "",
                        Remark = "",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };
                    _context.Remisiers.Add(remisier);
                    ClientPermissions cPermission = new ClientPermissions()
                    {
                        UserId = Convert.ToInt32(userId),
                        Awcc = "1",
                        Roshan = "1",
                        Salaam = "1",
                        Etisalat = "1",
                        Mtn = "1",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };
                    _context.ClientPermissions.Add(cPermission);
                    _context.SaveChanges();
                    ViewBag.Message = "User Created Successfully";
                    return View();
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("User", e.InnerException.Message);
                return View(collection);
            }
        }
        [HttpGet]
        public ActionResult UpdateRegistration(int id,bool isAgent)
        {
            try
            {
                if (isAgent)
                {
                    var agent = _context.Agents.FirstOrDefault(a => a.Id == Convert.ToUInt32(id));
                    ViewBag.user = agent;
                    ViewBag.Roles = _context.Roles.ToList();
                    ViewBag.IsAgent = true;
                    return View();
                }
                else
                {
                    var user = _context.Users.FirstOrDefault(a => a.Id == Convert.ToUInt32(id));
                    ViewBag.user = user;
                    ViewBag.Roles = null;
                    ViewBag.IsAgent = false;
                    return View();
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("User", e.InnerException.Message);
                return View();
            }
        }
        [HttpPost]
        public ActionResult UpdateRegistration(IFormCollection collection)
        {
            try
            {
                if (Convert.ToInt32(collection["roleId"].ToString()) < 4)
                {
                    Agents agent = _context.Agents.Find(Convert.ToUInt32(collection["id"].ToString()));

                    agent.Name = collection["name"].ToString();
                    agent.Mobile = collection["mobile"].ToString();
                    agent.Email = collection["email"].ToString();
                    agent.RoleId = Convert.ToInt32(collection["roleId"].ToString());
                    agent.Pincode = collection["pinCode"].ToString();
                    agent.Status = collection["status"].ToString();
                    agent.Password = collection["password"].ToString();
                    agent.Companyname = collection["companyName"].ToString();
                    agent.Address = collection["address"].ToString();
                    agent.City = collection["city"].ToString();
                    agent.Country = collection["country"].ToString();
                    agent.UpdatedAt = DateTime.Now;
                    _context.Entry(agent).State = EntityState.Modified;
                    _context.SaveChanges();

                    ViewBag.Message = "User Updated Successfully";
                    return View();
                }
                else
                {
                    Users user = _context.Users.Find(Convert.ToUInt32(collection["id"].ToString()));
                    user.Name = collection["name"].ToString();
                    user.Mobile = collection["mobile"].ToString();
                    user.Email = collection["email"].ToString();
                    user.RoleId = Convert.ToInt32(collection["roleId"].ToString());
                    user.Pincode = collection["pinCode"].ToString();
                    user.Status = collection["status"].ToString();
                    user.Password = collection["password"].ToString();
                    user.Companyname = collection["companyName"].ToString();
                    user.Address = collection["address"].ToString();
                    user.City = collection["city"].ToString();
                    user.Country = collection["country"].ToString();
                    user.UpdatedAt = DateTime.Now;
                    user.Commission = collection["commission"].ToString();
                    _context.Entry(user).State = EntityState.Modified;
                    _context.SaveChanges();

                    ViewBag.Message = "User Updated Successfully";
                    return View();
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("User", e.InnerException.Message);
                return View();
            }
        }
        [HttpPost]
        public ActionResult UpdateAllManagementPermissionById(int id,bool isAgent)
        {
            try
            {
                if (/*Convert.ToInt32(collection["roleId"].ToString()) < 4*/ true)
                {
                    

                    ViewBag.Message = "User Updated Successfully";
                    return View();
                }
                else
                {
                    
                    ViewBag.Message = "User Updated Successfully";
                    return View();
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("User", e.InnerException.Message);
                return View();
            }
        }
        [HttpGet]
        public ActionResult ListRegistration()
        {
            ViewBag.roles = _context.Roles.ToList();
            return View();
        }

        public ActionResult AllMemberManagement()
        {
            var userResults = _context.Users.ToList();
            var agentResults = _context.Agents.ToList();
            ViewBag.Users = userResults;
            ViewBag.Agent = agentResults;
            return View();
        }
        [HttpGet]
        public ActionResult ViewAllMemberManagementById(int id, bool isAgent)
        {
            if (isAgent)
            {
                ViewBag.User = _context.Agents.FirstOrDefault(u => u.Id.Equals(Convert.ToUInt32(id)));
                ViewBag.IsAgent = true;
            }

            else
            {
                ViewBag.User = _context.Users.FirstOrDefault(a => a.Id.Equals(Convert.ToUInt32(id)));
                ViewBag.IsAgent = false;
            }

            return View();
        }
        [HttpGet]
        public ActionResult ChangeStatusMemberManagementById(int id, string isAgent)
        {
            var result = isAgent.Split(";");
            result[1] = result[1].Equals("Enable") ? "Disable" : "Enable";
            if (result[0].Equals("True"))
            {
                Agents agent = new Agents()
                {
                    Id = Convert.ToUInt32(id),
                    Status = result[1],
                    UpdatedAt = DateTime.Now
                };
                _context.Agents.Attach(agent).Property(x => x.Status).IsModified = true;
            }
            else
            {
                Users user = new Users()
                {
                    Id = Convert.ToUInt32(id),
                    Status = result[1],
                    UpdatedAt = DateTime.Now
                };
                _context.Users.Attach(user).Property(x => x.Status).IsModified = true;

            }

            _context.SaveChanges();
            return RedirectToAction("ViewAllMemberManagementById","CustomManagement",new{id=id,isAgent = Convert.ToBoolean(result[0])});
        }
        [HttpGet]
        public ActionResult DeleteAgentAllMemberManagement(int id)
        {
            Agents agent = new Agents()
            {
                Id = Convert.ToUInt32(id)
            };
            _context.Agents.Remove(agent);
            _context.SaveChanges();
            return RedirectToAction("AllMemberManagement");
        }
        [HttpGet]
        public ActionResult DeleteUsersAllMemberManagement(int id)
        {
            Users user = new Users()
            {
                Id = Convert.ToUInt32(id)
            };
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("AllMemberManagement");
        }
        public ActionResult ClientMemberManagement()
        {
            var userResults = _context.Users.ToList();
            ViewBag.Users = userResults;
            return View();
        }

    }
}
