using Microsoft.AspNetCore.Mvc;
using Modul2ParcijalniTest.SqlFacade;
using Modul2ParcijalniTest.ViewModels;

namespace Modul2ParcijalniTest.Controllers
{
    public class BillController : Controller
    {
        private ISqlFacade _sqlFacade;
        public BillController(ISqlFacade sqlFacade)
        {
            _sqlFacade = sqlFacade;
        }

        public IActionResult Index()
        {
            List<Racun> billList = _sqlFacade.GetAllBills();
            IndexViewModel model = new IndexViewModel { AllBills = billList, Bill = null};
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel racun)
        {
            _sqlFacade.AddBill(racun.Bill);
            return RedirectToAction("Index", "Bill");
        }

        public IActionResult EditBill(int id)
        {
            List<Racun> billList = _sqlFacade.GetAllBills();
            Racun racun = billList.FirstOrDefault(x => x.Id == id);
            return View(racun);
        }

        [HttpPost]
        public IActionResult EditBill(Racun racun)
        {
            _sqlFacade.EditBill(racun);
            return RedirectToAction("Index", "Bill");
        }

        public IActionResult OpenBill(int id)
        {
            List<Racun> billList = _sqlFacade.GetAllBills();
            Racun racun = billList.FirstOrDefault(x => x.Id == id);
            BillViewModel billViewModel = new BillViewModel { Racun = racun,Uplatnica = null};
            return View(billViewModel);
        }

        [HttpPost]
        public IActionResult OpenBill(BillViewModel billViewModel)
        {
            _sqlFacade.DodajUplatnicu(billViewModel.Uplatnica);
            return View();
        }


        public IActionResult RemoveBill(int id)
        {
            _sqlFacade.RemoveBill(id);
            return RedirectToAction("Index","Bill");
        }

    }
}
