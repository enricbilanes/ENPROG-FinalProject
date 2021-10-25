using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ENTPROG_FINALS.Data;
using ENTPROG_FINALS.Models;

namespace ENTPROG_FINALS.Controllers
{
    public class BeneficiaryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BeneficiaryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.Beneficiaries.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Beneficiary record)
        {
            var Beneficiary = new Beneficiary();
            {
                Beneficiary.BeneficiaryID = record.BeneficiaryID;
                Beneficiary.Beneficiaries = record.Beneficiaries;
                Beneficiary.Decsription = record.Beneficiaries;
                Beneficiary.DonationSummary = record.DonationSummary;
            };
            _context.Beneficiaries.Add(Beneficiary);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(string? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var Beneficiary = _context.Beneficiaries.Where(i => i.BeneficiaryID.Equals(id)).SingleOrDefault();
            if (Beneficiary == null)
            {
                return RedirectToAction("Index");
            }

            return View(Beneficiary);
        }
        [HttpPost]
        public IActionResult Edit(string? id, Beneficiary record)
        {
            var Beneficiary = _context.Beneficiaries.Where(i => i.BeneficiaryID.Equals(id)).SingleOrDefault();
            {
                Beneficiary.Beneficiaries = record.Beneficiaries;
                Beneficiary.Decsription = record.Beneficiaries;
                Beneficiary.DonationSummary = record.DonationSummary;

                _context.Beneficiaries.Update(Beneficiary);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public IActionResult Delete(string? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var Beneficiary = _context.Beneficiaries.Where(i => i.BeneficiaryID.Equals(id)).SingleOrDefault();
            if (Beneficiary == null)
            {
                return RedirectToAction("Index");
            }

            _context.Beneficiaries.Remove(Beneficiary);
            _context.SaveChanges();

            return RedirectToAction();
        }
    }
}
