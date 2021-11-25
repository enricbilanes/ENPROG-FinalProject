using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ENTPROG_FINALS.Data;
using ENTPROG_FINALS.Models;

using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

using Microsoft.EntityFrameworkCore;



namespace ENTPROG_FINALS.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
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
            if(GetCurrentUser().RoleSetting != RoleType.Admin)
            {
                return RedirectToAction("Index", "Home");
            }
            
            var users = _context.Users.ToList();
            return View(users);
        }

        public IActionResult Edit(Guid? id)
        {
            if (GetCurrentUser().RoleSetting != RoleType.Admin)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var user = _context.Users.Where(i => i.Id == id.ToString()).SingleOrDefault();
            if (user == null)
            {
                return RedirectToAction("Index");
            }

            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(Guid? id, User record)
        {
            if (GetCurrentUser().RoleSetting != RoleType.Admin)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = _context.Users.Where(i => i.Id == id.ToString()).SingleOrDefault();
            {
                user.FirstName = record.FirstName;
                user.LastName = record.LastName;
                user.Email = record.Email;
                user.UserName = record.Email;
            }
            _context.Users.Update(user);
            _context.SaveChanges();


            //Transaction Log
            var currentUser = GetCurrentUser();
            var transacLog = new Transaction();
            {
                transacLog.Table = "Members";
                transacLog.RecordID = user.Email;
                transacLog.Date = DateTime.Now;
                transacLog.User = currentUser.FirstName + currentUser.LastName;
                transacLog.TransactionMade = "UPDATE";
                transacLog.Anonymous = DonationType.Visible;
            }
            _context.Transactions.Add(transacLog);           
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var user = _context.Users.Where(i => i.Id == id.ToString()).SingleOrDefault();
            if (user == null)
            {
                return RedirectToAction("Index");
            }


            //Transaction Log
            var currentUser = GetCurrentUser();
            var transacLog = new Transaction();
            {
                transacLog.Table = "Members";
                transacLog.RecordID = user.Email;
                transacLog.Date = DateTime.Now;
                transacLog.User = currentUser.FirstName + currentUser.LastName;
                transacLog.TransactionMade = "DELETE";
                transacLog.Anonymous = DonationType.Visible;
            }
            _context.Transactions.Add(transacLog);
            _context.SaveChanges();

            _context.Users.Remove(user);
            _context.SaveChanges();

            return RedirectToAction();
        }

    }
}
