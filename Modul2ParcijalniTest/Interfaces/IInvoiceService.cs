using Modul2ParcijalniTest.SqlFacade;
using Modul2ParcijalniTest.ViewModels;
using System.Collections.Generic;

namespace Modul2ParcijalniTest.Interfaces
{
    public interface IInvoiceService
    {
        public void RemoveInvoice(int id);
        public BillViewModel Payments(int billId);
        public BillViewModel Payouts(int billId);
        public void AddInvoice(BillViewModel model);
        public Invoice EditInvoice(int billId, int invoiceId);
        public Invoice EditInvoicePost(Invoice invoice);
        public List<Invoice> SortInvoices(SortInvoicesViewModel model);
    }
}
