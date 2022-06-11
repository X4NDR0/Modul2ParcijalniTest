using Modul2ParcijalniTest.Interfaces;
using Modul2ParcijalniTest.SqlFacade;
using Modul2ParcijalniTest.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Modul2ParcijalniTest.Services
{
    public class InvoiceService : IInvoiceService
    {
        private ISqlFacade _ISqlFacade;
        public InvoiceService(ISqlFacade ISqlFacade)
        {
            _ISqlFacade = ISqlFacade;
        }

        public void RemoveInvoice(int id)
        {
            _ISqlFacade.RemoveInvoice(id);
        }

        public BillViewModel Payments(int billId)
        {
            List<Invoice> invoiceList = _ISqlFacade.GetAllInvoices();
            List<Bill> billList = _ISqlFacade.GetAllBills();
            Bill bill = billList.FirstOrDefault(x => x.Id == billId);
            BillViewModel model = new BillViewModel { InvoiceList = invoiceList, Bill = bill };
            return model;
        }

        public List<Invoice> SortInvoices(SortInvoicesViewModel model)
        {
            List<Invoice> allInvoices = _ISqlFacade.GetAllInvoices();
            List<Invoice> sortedInvoices = new List<Invoice>();
            foreach (Invoice findInvoice in allInvoices)
            {
                if (findInvoice.Payer == model.Invoice.Payer || findInvoice.PaymentAmount == model.Invoice.PaymentAmount || findInvoice.Date.Date == model.Invoice.Date.Date || findInvoice.PaymentAmount >= model.PriceFrom && findInvoice.PaymentAmount <= model.PriceTo)
                {
                    sortedInvoices.Add(findInvoice);
                }
            }
            return sortedInvoices;
        }

        public Invoice EditInvoice(int billId, int invoiceId)
        {
            List<Invoice> invoiceList = _ISqlFacade.GetAllInvoices();
            List<Bill> billList = _ISqlFacade.GetAllBills();
            Invoice invoice = invoiceList.FirstOrDefault(x => x.Id == invoiceId);
            return invoice;
        }

        public Invoice EditInvoicePost(Invoice invoice)
        {
            _ISqlFacade.EditInvoice(invoice);
            return invoice;
        }

        public void AddInvoice(BillViewModel model)
        {
            model.Invoice.BillID = model.Bill.Id;
            List<Invoice> invoiceList = _ISqlFacade.GetAllInvoices();
            model.InvoiceList = invoiceList;
            _ISqlFacade.AddInvoice(model.Invoice);
        }

        public BillViewModel Payouts(int billId)
        {
            List<Invoice> invoiceList = _ISqlFacade.GetAllInvoices();
            List<Bill> billList = _ISqlFacade.GetAllBills();
            Bill bill = billList.FirstOrDefault(x => x.Id == billId);
            BillViewModel model = new BillViewModel { InvoiceList = invoiceList, Bill = bill };
            return model;
        }
    }
}
