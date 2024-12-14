using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALOS_Web_Admin.Models.Api.DbModels;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ALOS_Web_Admin.Helpers
{
    public class AlosDbHelper
    {
        public static alosapiContext _context = new alosapiContext();
        public static string GetLastClosingBalanceOfRemiserById(string id)
        {
            return _context.Remisiers.Where(r => r.Uid.Equals(id.ToString())).OrderByDescending(r => r.Id).ToList()[0].ClosingBalance;
        }
        public static Agents GetAgentsUserById(string id)
        {
            return _context.Agents.FirstOrDefault(r => r.Id.Equals(Convert.ToUInt32(id)));
        }
        public static string GetAgentNameById(string id)
        {
            return _context.Agents.FirstOrDefault(r => r.Id.Equals(Convert.ToUInt32(id))).Name;
        }
        public static string GetUserNameById(string id)
        {
            var res = _context.Users.FirstOrDefault(u => u.Id.Equals(Convert.ToUInt32(id)));
            return  res == null ? "" : res.Name;
        }
    }
}
