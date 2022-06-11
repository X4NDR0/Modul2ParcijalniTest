﻿using Modul2ParcijalniTest.SqlFacade;
using System.Collections.Generic;

namespace Modul2ParcijalniTest.ViewModels
{
    public class IndexViewModel
    {
        public Bill Bill { get; set; }
        public List<Bill> AllBills { get; set; }
        public List<Invoice> InvoiceList { get; set; }
        public decimal Price { get; set; }
    }
}
