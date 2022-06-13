using Modul2ParcijalniTest.SqlFacade;
using Modul2ParcijalniTest.ViewModels;

namespace Modul2ParcijalniTest.Services.Interfaces
{
    public interface IBillService
    {
        public IndexViewModel Index();
        public Bill EditDefaultBillValues(Bill bill);
        public void AddBill(Bill racun);
        public Bill EditBill(int id);
        public void EditBillPost(Bill racun);
        public BillViewModel OpenBill(int id);
        public void ActivateAccount(int id);
        public void DeactivateAccount(int id);
        public void RemoveBill(int id);
        public SortBillsViewModel SortBills(SortBillsViewModel model);
        public decimal GetBillPrice(int billId);
    }
}
