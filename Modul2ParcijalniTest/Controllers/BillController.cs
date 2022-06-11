using Microsoft.AspNetCore.Mvc;
using Modul2ParcijalniTest.Interfaces;
using Modul2ParcijalniTest.SqlFacade;
using Modul2ParcijalniTest.ViewModels;
using System.Collections.Generic;

namespace Modul2ParcijalniTest.Controllers
{
    public class BillController : Controller
    {
        private IBillService _IBillService;
        public BillController(IBillService IBillService)
        {
            _IBillService = IBillService;
        }

        public IActionResult Index()
        {
            IndexViewModel model = _IBillService.Index();
            return View(model);
        }

        public IActionResult SortBills()
        {
            SortBillsViewModel model = new SortBillsViewModel { BillList = new List<Bill>() };
            return View(model);
        }

        [HttpPost]
        public IActionResult SortBills(SortBillsViewModel model)
        {
            model = _IBillService.SortBills(model);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(Bill bill)
        {
            IndexViewModel model = _IBillService.Index();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            bill = _IBillService.EditDefaultBillValues(bill);
            _IBillService.AddBill(bill);
            return RedirectToAction("Index", "Bill");
        }

        public IActionResult EditBill(int id)
        {
            Bill bill = _IBillService.EditBill(id);
            return View(bill);
        }

        [HttpPost]
        public IActionResult EditBill(Bill bill)
        {
            IndexViewModel model = _IBillService.Index();
            if (!ModelState.IsValid)
            {
                return View(bill);
            }
            _IBillService.EditBillPost(bill);
            return RedirectToAction("Index", "Bill");
        }

        public IActionResult OpenBill(int id)
        {
            BillViewModel model = _IBillService.OpenBill(id);
            return View(model);
        }

        public IActionResult DeactivateAccount(int id)
        {
            _IBillService.DeactivateAccount(id);
            return RedirectToAction("Index", "Bill");
        }

        public IActionResult ActivateAccount(int id)
        {
            _IBillService.ActivateAccount(id);
            return RedirectToAction("Index", "Bill");
        }

        public IActionResult RemoveBill(int id)
        {
            _IBillService.RemoveBill(id);
            return RedirectToAction("Index", "Bill");
        }
    }
}
