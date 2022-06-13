using Microsoft.AspNetCore.Mvc;
using Modul2ParcijalniTest.Interfaces;
using Modul2ParcijalniTest.SqlFacade;
using Modul2ParcijalniTest.ViewModels;
using System.Collections.Generic;

namespace Modul2ParcijalniTest.Controllers
{
    public class InvoiceController : Controller
    {
        private IInvoiceService _IInvoiceService;

        public InvoiceController(IInvoiceService IInvoiceService)
        {
            _IInvoiceService = IInvoiceService;
        }

        public IActionResult RemoveInvoice(int invoiceId, int billId)
        {
            _IInvoiceService.RemoveInvoice(invoiceId);
            return RedirectToAction("OpenBill", "Bill", new { id = billId });
        }

        public IActionResult SortInvoices()
        {
            SortInvoicesViewModel model = new SortInvoicesViewModel { Invoices = new List<Invoice>() };
            return View(model);
        }

        [HttpPost]
        public IActionResult SortInvoices(SortInvoicesViewModel model)
        {
            model.Invoices = _IInvoiceService.SortInvoices(model);
            return View(model);
        }

        public IActionResult Payments(int billId)
        {
            BillViewModel model = _IInvoiceService.DisplayAllPayments(billId);
            return View(model);
        }

        [HttpPost]
        public IActionResult AddInvoice(BillViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Bill/OpenBill.cshtml", model);
            }
            _IInvoiceService.AddInvoice(model);
            return RedirectToAction("OpenBill", "Bill", new { id = model.Bill.Id });
        }

        public IActionResult EditInvoice(int billId, int invoiceId)
        {
            Invoice invoice = _IInvoiceService.EditInvoice(billId, invoiceId);
            return View(invoice);
        }

        [HttpPost]
        public IActionResult EditInvoice(Invoice invoice)
        {
            if (!ModelState.IsValid)
            {
                return View(invoice);
            }
            _IInvoiceService.EditInvoicePost(invoice);
            return RedirectToAction("OpenBill", "Bill", new { id = invoice.BillID });
        }

        public IActionResult Payouts(int billId)
        {
            BillViewModel model = _IInvoiceService.DisplayAllPayouts(billId);
            return View(model);
        }
    }
}
