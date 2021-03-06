using Modul2ParcijalniTest.SqlFacade;
using System.Collections.Generic;

namespace Modul2ParcijalniTest.ViewModels
{
    public class SortBillsViewModel
    {
        public Bill Bill { get; set; }
        public List<Bill> Bills { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }
        public decimal Price { get; set; }
        public List<Invoice> Invoices { get; set; }
    }
}
