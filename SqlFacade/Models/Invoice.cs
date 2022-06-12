using System;
using System.ComponentModel.DataAnnotations;

namespace Modul2ParcijalniTest.SqlFacade
{
    public class Invoice
    {
        public int Id { get; set; }
        public int BillID { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno!")]
        [DataType(DataType.Currency)]
        public decimal PaymentAmount { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno!")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno!")]
        public string PaymentPurpose { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno!")]
        [RegularExpression(@"^([a-zA-Z]{2,}\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\s?([a-zA-Z]{1,})?)", ErrorMessage = "Ovo polje prima samo alfanumericke vrednosti!")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Ovo polje mora imati najmanje 5 karaktera, a najvise 30!")]
        public string Payer { get; set; }
        public bool Urgent { get; set; }
    }
}
