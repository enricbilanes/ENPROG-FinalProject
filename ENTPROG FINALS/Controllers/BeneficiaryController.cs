using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ENTPROG_FINALS.Data;
using ENTPROG_FINALS.Models;

using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ENTPROG_FINALS.Controllers
{

    [Authorize]
    public class BeneficiaryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BeneficiaryController(ApplicationDbContext context)
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

            var list = _context.Beneficiaries.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            if (GetCurrentUser().RoleSetting != RoleType.Admin)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        [HttpPost]
        public IActionResult Create(Beneficiary record)
        {
            var Beneficiary = new Beneficiary();
            {
                Beneficiary.Beneficiaries = record.Beneficiaries;
                Beneficiary.Decsription = record.Decsription;
                Beneficiary.DonationSummary = "0";
            };
            _context.Beneficiaries.Add(Beneficiary);
            _context.SaveChanges();

            //Transaction Log
            var transacLog = new Transaction();
            {
                transacLog.Table = "Beneficiary";
                transacLog.RecordID = Beneficiary.BeneficiaryID.ToString();
                transacLog.Date = DateTime.Now;
                transacLog.User = GetCurrentUser().FirstName + GetCurrentUser().LastName;
                transacLog.TransactionMade = "CREATE";
                transacLog.Anonymous = DonationType.Visible;
            }
            _context.Transactions.Add(transacLog);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (GetCurrentUser().RoleSetting != RoleType.Admin)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var Beneficiary = _context.Beneficiaries.Where(i => i.BeneficiaryID == id).SingleOrDefault();
            if (Beneficiary == null)
            {
                return RedirectToAction("Index");
            }

            return View(Beneficiary);
        }
        [HttpPost]
        public IActionResult Edit(int? id, Beneficiary record)
        {
            var Beneficiary = _context.Beneficiaries.Where(i => i.BeneficiaryID == id).SingleOrDefault();
            {
                Beneficiary.Beneficiaries = record.Beneficiaries;
                Beneficiary.Decsription = record.Decsription;
                Beneficiary.DonationSummary = record.DonationSummary;
            }
            _context.Beneficiaries.Update(Beneficiary);
            _context.SaveChanges();

            //Transaction Log
            var transacLog = new Transaction();
            {
                transacLog.Table = "Beneficiary";
                transacLog.RecordID = Beneficiary.BeneficiaryID.ToString();
                transacLog.Date = DateTime.Now;
                transacLog.User = GetCurrentUser().FirstName + GetCurrentUser().LastName;
                transacLog.TransactionMade = "UPDATE";
                transacLog.Anonymous = DonationType.Visible;
            }
            _context.Transactions.Add(transacLog);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (GetCurrentUser().RoleSetting != RoleType.Admin)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var Beneficiary = _context.Beneficiaries.Where(i => i.BeneficiaryID == id).SingleOrDefault();
            if (Beneficiary == null)
            {
                return RedirectToAction("Index");
            }

            //Transaction Log
            var transacLog = new Transaction();
            {
                transacLog.Table = "Beneficiary";
                transacLog.RecordID = Beneficiary.BeneficiaryID.ToString();
                transacLog.Date = DateTime.Now;
                transacLog.User = GetCurrentUser().FirstName + GetCurrentUser().LastName;
                transacLog.TransactionMade = "DELETE";
                transacLog.Anonymous = DonationType.Visible;
            }
            _context.Transactions.Add(transacLog);
            _context.SaveChanges();

            _context.Beneficiaries.Remove(Beneficiary);
            _context.SaveChanges();

            return RedirectToAction();
        }

        public IActionResult Summary(int? id)
        {
            if (GetCurrentUser().RoleSetting != RoleType.Admin)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var Beneficiary = _context.Beneficiaries.Where(i => i.BeneficiaryID == id).SingleOrDefault();
            if (Beneficiary == null)
            {
                return RedirectToAction("Index");
            }

            return View(Beneficiary);
        }
    }
}

