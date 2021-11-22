using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ENTPROG_FINALS.Data;
using ENTPROG_FINALS.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace ENTPROG_FINALS.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }

            var user = _context.Users.Where(i => i.MemberID == id).SingleOrDefault();
            if (user == null)
            {
                return RedirectToAction("Index");
            }

            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(int? id, User record)
        {
            var user = _context.Users.Where(i => i.MemberID == id).SingleOrDefault();
            {
                user.FirstName = record.FirstName;
                user.LastName = record.LastName;
                user.Email = record.Email;
                user.PassWord = record.PassWord;
            }
            _context.Users.Update(user);

            //Transaction Log
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = _context.Users.Where(u => u.Id == userId).SingleOrDefault();
            var transacLog = new Transaction();
            {
                transacLog.Table = "Members";
                transacLog.RecordID = user.MemberID;
                transacLog.Date = DateTime.Now;
                transacLog.User = currentUser.FirstName + currentUser.LastName;
                transacLog.TransactionMade = "UPDATE";
                transacLog.Anonymous = DonationType.Visible;
            }
            _context.Transactions.Add(transacLog);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var user = _context.Users.Where(i => i.MemberID == id).SingleOrDefault();
            if (user == null)
            {
                return RedirectToAction("Index");
            }

            //Transaction Log
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = _context.Users.Where(u => u.Id == userId).SingleOrDefault();
            var transacLog = new Transaction();
            {
                transacLog.Table = "Members";
                transacLog.RecordID = user.MemberID;
                transacLog.Date = DateTime.Now;
                transacLog.User = currentUser.FirstName + currentUser.LastName;
                transacLog.TransactionMade = "DELETE";
                transacLog.Anonymous = DonationType.Visible;
            }
            _context.Transactions.Add(transacLog);

            _context.Users.Remove(user);
            _context.SaveChanges();

            return RedirectToAction();
        }

    }
}
