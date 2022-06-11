using System.Collections.Generic;

namespace Modul2ParcijalniTest.SqlFacade;

public interface ISqlFacade
{
    public int AddBill(Bill racun);
    public List<Bill> GetAllBills();
    public void RemoveBill(int id);
    public void EditBill(Bill racun);
    public int AddInvoice(Invoice uplatnica);
    public List<Invoice> GetAllInvoices();
    public void RemoveInvoice(int id);
    public void EditInvoice(Invoice uplatnica);
}
