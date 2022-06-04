namespace Modul2ParcijalniTest.SqlFacade;

public interface ISqlFacade
{
    public void AddBill(Racun racun);
    public List<Racun> GetAllBills();
    public void RemoveBill(int id);
    public void EditBill(Racun racun);
    public void DodajUplatnicu(Uplatnica uplatnica);
}
