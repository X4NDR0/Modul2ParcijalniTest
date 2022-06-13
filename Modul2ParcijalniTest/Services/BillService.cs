using Modul2ParcijalniTest.Services.Interfaces;
using Modul2ParcijalniTest.SqlFacade;
using Modul2ParcijalniTest.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Modul2ParcijalniTest.Services
{
    public class BillService : IBillService
    {
        private ISqlFacade _ISqlFacade;
        public BillService(ISqlFacade ISqlFacade)
        {
            _ISqlFacade = ISqlFacade;
        }

        public IndexViewModel Index()
        {
            List<Bill> billList = _ISqlFacade.GetAllBills();
            List<Invoice> invoiceList = _ISqlFacade.GetAllInvoices();
            IndexViewModel model = new IndexViewModel { AllBills = billList, Bill = null, Invoices = invoiceList };
            return model;
        }

        public Bill EditDefaultBillValues(Bill bill)
        {
            bill.ActiveAccount = true;
            return bill;
        }

        public decimal GetBillPrice(int billId)
        {
            List<Invoice> invoiceList = _ISqlFacade.GetAllInvoices();
            decimal price = 0;
            foreach (Invoice invoice in invoiceList)
            {
                if (invoice.BillID == billId)
                {
                    price += invoice.PaymentAmount;
                }
            }
            return price;
        }

        public SortBillsViewModel SortBills(SortBillsViewModel model)
        {
            List<Bill> allBills = _ISqlFacade.GetAllBills();
            List<Bill> sortedBills = new List<Bill>();

            decimal price = 0;

            foreach (Bill findBill in allBills)
            {
                price = GetBillPrice(findBill.Id);
                if (model.Bill.AccountHolder == findBill.AccountHolder || model.Bill.AccountNumber == findBill.AccountNumber || model.Bill.ActiveAccount == findBill.ActiveAccount || model.Bill.OnlineBanking == findBill.OnlineBanking || price >= model.PriceFrom && price <= model.PriceTo)
                {
                    sortedBills.Add(findBill);
                }
            }
            SortBillsViewModel sortBillsViewModel = new SortBillsViewModel { Bills = sortedBills, Invoices = _ISqlFacade.GetAllInvoices() };
            return sortBillsViewModel;
        }

        public BillViewModel OpenBill(int id)
        {
            List<Bill> billList = _ISqlFacade.GetAllBills();
            List<Invoice> invoiceList = _ISqlFacade.GetAllInvoices();
            Bill bill = billList.FirstOrDefault(x => x.Id == id);
            BillViewModel billViewModel = new BillViewModel { Bill = bill, Invoices = invoiceList };
            return billViewModel;
        }

        public Bill EditBill(int id)
        {
            List<Bill> billList = _ISqlFacade.GetAllBills();
            Bill bill = billList.FirstOrDefault(x => x.Id == id);
            return bill;
        }

        public void ActivateAccount(int id)
        {
            List<Bill> billList = _ISqlFacade.GetAllBills();
            Bill bill = billList.FirstOrDefault(x => x.Id == id);
            bill.ActiveAccount = true;
            _ISqlFacade.EditBill(bill);
        }

        public void DeactivateAccount(int id)
        {
            List<Bill> billList = _ISqlFacade.GetAllBills();
            Bill bill = billList.FirstOrDefault(x => x.Id == id);
            bill.ActiveAccount = false;
            _ISqlFacade.EditBill(bill);
        }

        public void EditBillPost(Bill bill)
        {
            _ISqlFacade.EditBill(bill);
        }

        public void AddBill(Bill bill)
        {
            _ISqlFacade.AddBill(bill);
        }

        public void RemoveBill(int id)
        {
            _ISqlFacade.RemoveBill(id);
        }
    }
}
