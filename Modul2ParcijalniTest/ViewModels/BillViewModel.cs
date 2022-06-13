using Modul2ParcijalniTest.SqlFacade;
using System.Collections.Generic;

namespace Modul2ParcijalniTest.ViewModels
{
    public class BillViewModel
    {
        public Bill Bill { get; set; }
        public Invoice Invoice { get; set; }
        public List<Invoice> Invoices { get; set; }
        public decimal Price { get; set; }
    }
}
