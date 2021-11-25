using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ENTPROG_FINALS.Data;
using ENTPROG_FINALS.Models;

using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ENTPROG_FINALS.Controllers
{
    [Authorize]
    public class TransactionLogController : Controller 
    {
        private readonly ApplicationDbContext _context;

        public TransactionLogController(ApplicationDbContext context)
        {
            _context = context;
        }

        public User GetCurrentUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(u => u.Id == userId).SingleOrDefault();
            return user;
        }

        public IActionResult Index()
        {
            if (GetCurrentUser().RoleSetting != RoleType.Admin)
            {
                return RedirectToAction("Index", "Home");
            }

            var log = _context.Transactions.ToList();
            return View(log);
        }
    }
}
