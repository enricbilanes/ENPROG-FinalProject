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
    //Added authorize, make sure this entire class is for admins only
    [Authorize]
    public class TransactionLogController : Controller 
    {
        private readonly ApplicationDbContext _context;

        public TransactionLogController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var log = _context.Transactions.ToList();
            return View(log);
        }
    }
}
