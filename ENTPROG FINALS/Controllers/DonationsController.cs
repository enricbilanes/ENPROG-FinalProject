using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ENTPROG_FINALS.Data;
using ENTPROG_FINALS.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace ENTPROG_FINALS.Controllers
{
    public class DonationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult List()
        {
            var list = _context.Donations.Include(p => p.Beneficiary).ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Donation record)
        {
            //To capture the user, userid, and object (to check if logged in or not)
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(u => u.Id == userId).SingleOrDefault();

            var selectedBeneficiary = _context.Beneficiaries.Where(c => c.BeneficiaryID == record.Beneficiary.BeneficiaryID).SingleOrDefault();

            var donation = new Donation();
            {
                donation.Role = user.RoleSetting.ToString();
                donation.DonationAmount = record.DonationAmount;
                donation.Beneficiary = selectedBeneficiary;
                donation.Anonymous = record.Anonymous;             
                donation.FirstName = user.FirstName;
                donation.LastName = user.LastName;
                donation.UserId = Guid.Parse(userId);
            }
             _context.Donations.Add(donation);
            _context.SaveChanges();

            //Transaction Log
            var transacLog = new Transaction();
            {
                transacLog.Table = "Donations";
                transacLog.RecordID = donation.DonationID.ToString();
                transacLog.Date = DateTime.Now;
                transacLog.User = user.FirstName + user.LastName;
                transacLog.TransactionMade = "CREATE";
                transacLog.Anonymous = donation.Anonymous;
            }
            _context.Transactions.Add(transacLog);
            _context.SaveChanges();

            return RedirectToAction("List");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("List");
            }

            var donation = _context.Donations.Where(i => i.DonationID == id).SingleOrDefault();
            if (donation == null)
            {
                return RedirectToAction("List");
            }

            return View(donation);
        }      
        [HttpPost]
        public IActionResult Edit(int? id, Donation record)
        {
            var selectedBeneficiary = _context.Beneficiaries.Where(c => c.BeneficiaryID == record.Beneficiary.BeneficiaryID).SingleOrDefault();
            var donation = _context.Donations.Where(i => i.DonationID == id).SingleOrDefault();
            {
                donation.DonationAmount = record.DonationAmount;
                donation.Beneficiary = selectedBeneficiary;
                donation.Anonymous = record.Anonymous;
            }

            _context.Donations.Update(donation);

            //Transaction Log
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(u => u.Id == userId).SingleOrDefault();
            var transacLog = new Transaction();
            {
                transacLog.Table = "Donations";
                transacLog.RecordID = donation.DonationID.ToString();
                transacLog.Date = DateTime.Now;
                transacLog.User = user.FirstName + user.LastName;
                transacLog.TransactionMade = "UPDATE";
                transacLog.Anonymous = donation.Anonymous;
            }
            _context.Transactions.Add(transacLog);
            _context.SaveChanges();

            return RedirectToAction("List");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("List");
            }

            var donation = _context.Donations.Where(i => i.DonationID == id).SingleOrDefault();
            if (donation == null)
            {
                return RedirectToAction("List");
            }

            _context.Donations.Remove(donation);

            //Transaction Log
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(u => u.Id == userId).SingleOrDefault();
            var transacLog = new Transaction();
            {
                transacLog.Table = "Donations";
                transacLog.RecordID = donation.DonationID.ToString();
                transacLog.Date = DateTime.Now;
                transacLog.User = user.FirstName + user.LastName;
                transacLog.TransactionMade = "DELETE";
                transacLog.Anonymous = donation.Anonymous;
            }
            _context.Transactions.Add(transacLog);
            _context.SaveChanges();

            return RedirectToAction("List");
        }
        public IActionResult Certificate(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("List");
            }

            var donation = _context.Donations.Where(i => i.DonationID == id).SingleOrDefault();
            if (donation == null)
            {
                return RedirectToAction("List");
            }

            return View(donation);
        }
        /*
        [HttpPost]
        public IActionResult Certificate(int? id, Donation record)
        {
            var selectedBeneficiary = _context.Beneficiaries.Where(c => c.BeneficiaryID == record.Beneficiary.BeneficiaryID).SingleOrDefault();
            var donation = _context.Donations.Where(i => i.DonationID == id).SingleOrDefault();
            {
                donation.FirstName = record.FirstName;
                donation.DonationAmount = record.DonationAmount;
                donation.Beneficiary = selectedBeneficiary;
            }

            _context.Donations.Update(donation);

            //Transaction Log
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(u => u.Id == userId).SingleOrDefault();
            var transacLog = new Transaction();
            {
                transacLog.Table = "Donations";
                transacLog.RecordID = donation.DonationID.ToString();
                transacLog.Date = DateTime.Now;
                transacLog.User = user.FirstName + user.LastName;
                transacLog.TransactionMade = "UPDATE";
                transacLog.Anonymous = donation.Anonymous;
            }
            _context.Transactions.Add(transacLog);
            _context.SaveChanges();

            return RedirectToAction("List");
        }
        */

    }
}
