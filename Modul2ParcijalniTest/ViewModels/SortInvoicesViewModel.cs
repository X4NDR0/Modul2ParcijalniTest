using Modul2ParcijalniTest.SqlFacade;
using System.Collections.Generic;

namespace Modul2ParcijalniTest.ViewModels
{
    public class SortInvoicesViewModel
    {
        public Invoice Invoice { get; set; }
        public List<Invoice> Invoices { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }
    }
}
