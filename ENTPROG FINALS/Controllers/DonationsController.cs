using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ENTPROG_FINALS.Data;
using ENTPROG_FINALS.Models;
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
            var list = _context.Donations.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Donation record)
        {
            var donation = new Donation();
            {
                //Name should be auto inputted
                donation.DonationAmount = record.DonationAmount;
                donation.Beneficiary = record.Beneficiary;
                donation.Anonymous = record.Anonymous;
            }

            _context.Donations.Add(donation);
            _context.SaveChanges();

            return RedirectToAction("List");
        }

        public IActionResult Edit(string? id)
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
        public IActionResult Edit(string? id, Donation record)
        {
            var donation = _context.Donations.Where(i => i.DonationID == id).SingleOrDefault();
            {
                //Should name be edited?
                donation.DonationAmount = record.DonationAmount;
                donation.Beneficiary = record.Beneficiary;
                donation.Anonymous = record.Anonymous;
            }

            _context.Donations.Add(donation);
            _context.SaveChanges();

            return RedirectToAction("List");
        }

        public IActionResult Delete(string? id)
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
            _context.SaveChanges();

            return View("List");
        }

    }
}
