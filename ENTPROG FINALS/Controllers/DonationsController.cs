using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENTPROG_FINALS.Data;
using ENTPROG_FINALS.Models;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ENTPROG_FINALS.Controllers
{
    [Authorize]
    public class DonationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public User GetCurrentUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(u => u.Id == userId).SingleOrDefault();
            return user;
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
            var selectedBeneficiary = _context.Beneficiaries.Where(c => c.BeneficiaryID == record.Beneficiary.BeneficiaryID).SingleOrDefault();

            var donation = new Donation();
            {
                donation.Role = GetCurrentUser().RoleSetting.ToString();
                donation.DonationAmount = record.DonationAmount;
                donation.Beneficiary = selectedBeneficiary;
                donation.Anonymous = record.Anonymous;             
                donation.FirstName = GetCurrentUser().FirstName;
                donation.LastName = GetCurrentUser().LastName;
                donation.Date = DateTime.Now;
                donation.Remarks = record.Remarks;
                donation.UserId = Guid.Parse(GetCurrentUser().Id);
            }
            _context.Donations.Add(donation);
            _context.SaveChanges();

            var beneficiary = selectedBeneficiary;
            {
                beneficiary.DonationSummary = (decimal.Parse(beneficiary.DonationSummary) + decimal.Parse(donation.DonationAmount)).ToString();
            }
            _context.Beneficiaries.Update(beneficiary);
            _context.SaveChanges();

            //Transaction Log
            var transacLog = new Transaction();
            {
                transacLog.Table = "Donations";
                transacLog.RecordID = donation.DonationID.ToString();
                transacLog.Date = DateTime.Now;
                transacLog.User = donation.FirstName + donation.LastName;
                transacLog.TransactionMade = "CREATE";
                transacLog.Anonymous = donation.Anonymous;
            }
            _context.Transactions.Add(transacLog);
            _context.SaveChanges();

            return RedirectToAction("List");
        }


        public IActionResult Edit(int? id)
        {
            if (GetCurrentUser().RoleSetting != RoleType.Admin)
            {
                return RedirectToAction("Index", "Home");
            }

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
            var donation = _context.Donations.Include(b => b.Beneficiary).Where(i => i.DonationID == id).SingleOrDefault();

            var beneficiary = _context.Beneficiaries.Where(b => b.BeneficiaryID == donation.Beneficiary.BeneficiaryID).SingleOrDefault();
            if(beneficiary != null)
            {
                beneficiary.DonationSummary =  (decimal.Parse(beneficiary.DonationSummary) - decimal.Parse(donation.DonationAmount)).ToString();            
                _context.Beneficiaries.Update(beneficiary);
                _context.SaveChanges();
            }

            donation.DonationAmount = record.DonationAmount;
            donation.Beneficiary = selectedBeneficiary;
            donation.Remarks = record.Remarks;
            donation.Anonymous = record.Anonymous;
            _context.Donations.Update(donation);
            _context.SaveChanges();


            selectedBeneficiary.DonationSummary = (decimal.Parse(selectedBeneficiary.DonationSummary) + donation.DonationAmount);
            _context.Beneficiaries.Update(selectedBeneficiary);
            _context.SaveChanges();

            //Transaction Log
            var transacLog = new Transaction();
            {
                transacLog.Table = "Donations";
                transacLog.RecordID = donation.DonationID.ToString();
                transacLog.Date = DateTime.Now;
                transacLog.User = GetCurrentUser().FirstName + GetCurrentUser().LastName;
                transacLog.TransactionMade = "UPDATE";
                transacLog.Anonymous = donation.Anonymous;
            }
            _context.Transactions.Add(transacLog);
            _context.SaveChanges();

            return RedirectToAction("List");
        }

        public IActionResult Delete(int? id)
        {
            if (GetCurrentUser().RoleSetting != RoleType.Admin)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return RedirectToAction("List");
            }

            var donation = _context.Donations.Include(b => b.Beneficiary).Where(i => i.DonationID == id).SingleOrDefault();
            if (donation == null)
            {
                return RedirectToAction("List");
            }

            var beneficiary = _context.Beneficiaries.Where(b => b.BeneficiaryID == donation.Beneficiary.BeneficiaryID).SingleOrDefault();
            if (beneficiary != null)
            {
                beneficiary.DonationSummary = (decimal.Parse(beneficiary.DonationSummary) - decimal.Parse(donation.DonationAmount)).ToString();
                _context.Beneficiaries.Update(beneficiary);
                _context.SaveChanges();
            }

            //Transaction Log
            var transacLog = new Transaction();
            {
                transacLog.Table = "Donations";
                transacLog.RecordID = donation.DonationID.ToString();
                transacLog.Date = DateTime.Now;
                transacLog.User = GetCurrentUser().FirstName + GetCurrentUser().LastName;
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
