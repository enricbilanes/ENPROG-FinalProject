using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENTPROG_FINALS.Data;
using ENTPROG_FINALS.Models;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Authentication;

//authorization
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ENTPROG_FINALS.Controllers
{
    public class DonationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Added authorize, everything that has authorize requires login to do the action
        [Authorize]
        public IActionResult List()
        {
            var list = _context.Donations.Include(p => p.Beneficiary).ToList();
            return View(list);
        }

        //Added authorize, everything that has authorize requires login to do the action
        [Authorize]
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

            var beneficiary = selectedBeneficiary;
            {
                beneficiary.DonationSummary += donation.DonationAmount;
            }
            _context.Beneficiaries.Update(beneficiary);
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

        //Added authorize, make sure this is for admins only
        [Authorize]
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

            var beneficiary = _context.Beneficiaries.Where(b => b.BeneficiaryID == donation.Beneficiary.BeneficiaryID).SingleOrDefault();
            {
                beneficiary.DonationSummary -= donation.DonationAmount;
            }
            _context.Beneficiaries.Update(beneficiary);
            _context.SaveChanges();

            donation.DonationAmount = record.DonationAmount;
            donation.Beneficiary = selectedBeneficiary;
            donation.Anonymous = record.Anonymous;
            _context.Donations.Update(donation);
            _context.SaveChanges();

            selectedBeneficiary.DonationSummary += donation.DonationAmount;
            _context.Beneficiaries.Update(selectedBeneficiary);
            _context.SaveChanges();

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

        //Added authorize, make sure this is for admins only
        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("List");
            }

            //To include the contents of the beneficiary to line 152 (var beneficiary)
            var donation = _context.Donations.Include(b => b.Beneficiary).Where(i => i.DonationID == id).SingleOrDefault();

            //var donation = _context.Donations.Where(i => i.DonationID == id).SingleOrDefault();


            if (donation == null)
            {
                return RedirectToAction("List");
            }

            var beneficiary = _context.Beneficiaries.Where(b => b.BeneficiaryID == donation.Beneficiary.BeneficiaryID).SingleOrDefault();
            {
                beneficiary.DonationSummary -= donation.DonationAmount;
            }
            _context.Beneficiaries.Update(beneficiary);
            _context.SaveChanges();

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

            _context.Donations.Remove(donation);
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

    }
}
