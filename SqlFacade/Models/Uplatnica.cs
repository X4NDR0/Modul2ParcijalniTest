namespace Modul2ParcijalniTest.SqlFacade
{
    public class Uplatnica
    {
        public int Id { get; set; }
        public int IdRacuna { get; set; }
        public int IznosUplate { get; set; }
        public DateTime DatumPrometa { get; set; }
        public string SvrhaUplate { get; set; }
        public string Uplatilac { get; set; }
        public bool Hitno { get; set; }
    }
}
