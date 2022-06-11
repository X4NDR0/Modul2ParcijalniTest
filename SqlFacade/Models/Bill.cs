using System.ComponentModel.DataAnnotations;

namespace Modul2ParcijalniTest.SqlFacade
{
    public class Bill
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ovo je obavezno polje!")]
        [RegularExpression(@"^([a-zA-Z]{2,}\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\s?([a-zA-Z]{1,})?)", ErrorMessage = "Ovo polje prima samo alfanumericke vrednosti!")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Ovo polje mora imati najmanje 5 karaktera, a najvise 30!")]
        public string AccountHolder { get; set; }
        [Required(ErrorMessage = "Ovo je obavezno polje!")]
        [RegularExpression(@"\d{3}-\d{3}-\d{4}", ErrorMessage = "Broj racuna mora biti u formatu (123-456-7890)")]
        public string AccountNumber { get; set; }
        public bool ActiveAccount { get; set; }
        public bool OnlineBanking { get; set; }
    }
}
