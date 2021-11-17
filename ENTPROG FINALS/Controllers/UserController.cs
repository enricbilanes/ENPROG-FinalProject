using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ENTPROG_FINALS.Data;
using ENTPROG_FINALS.Models;

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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User record)
        {
            var users = new User();
            {
                var list = _context.Users.ToList();
                users.MemberID = "MS" + String.Format("{0:00000000}", (list.Count + 1));
                users.FirstName = record.FirstName;
                users.LastName = record.LastName;
                users.Email = record.Email;
                users.PassWord = record.PassWord;
                users.RoleSetting = RoleType.User;
            }

            _context.Users.Add(users);
            _context.SaveChanges();

            return RedirectToAction("List");
        }

        public IActionResult Edit(string? id)
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
        public IActionResult Edit(string? id, User record)
        {
            var user = _context.Users.Where(i => i.MemberID == id).SingleOrDefault();
    
            user.FirstName = record.FirstName;
            user.LastName = record.LastName;
            user.Email = record.Email;
            user.PassWord = record.PassWord;

            _context.Users.Update(user);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(string? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var user = _context.Users.Where(i => i.MemberID.Equals(id)).SingleOrDefault();
            if (user == null)
            {
                return RedirectToAction("Index");
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return RedirectToAction();
        }

    }
}
