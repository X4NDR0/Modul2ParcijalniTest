using Modul2ParcijalniTest.Services;
using Modul2ParcijalniTest.SqlFacade;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Modul2ParcijalniTestUnitTest
{
    public class Modul2UnitTest
    {
        private SqlFacade _sqlFacade;
        private BillService _billService;
        public Modul2UnitTest()
        {
            _sqlFacade = new SqlFacade();
            _billService = new BillService(_sqlFacade);
        }

        [Test]
        public void CalculatePriceSum()
        {
            //Arrange
            decimal result = 0;
            decimal expectedPrice = 200;
            Bill bill = new Bill { AccountNumber = "111-222-3333", AccountHolder = "Bogdan", ActiveAccount = true, OnlineBanking = true };

            //Act
            int billId = _sqlFacade.AddBill(bill);
            Invoice invoice1 = new Invoice { BillID = billId, Date = DateTime.Now, Payer = "Vojin", PaymentAmount = 100, PaymentPurpose = "UnitTest", Urgent = true };
            Invoice invoice2 = new Invoice { BillID = billId, Date = DateTime.Now, Payer = "Mateja", PaymentAmount = 100, PaymentPurpose = "UnitTest", Urgent = true };
            _sqlFacade.AddInvoice(invoice1);
            _sqlFacade.AddInvoice(invoice2);
            List<Invoice> invoiceList = _sqlFacade.GetAllInvoices();
            result = _billService.GetBillPrice(billId);

            //Assert
            Assert.AreEqual(expectedPrice, result);
        }

        [Test]
        public void CalculatePriceWhenAmountIsNegative()
        {
            //Arrange
            decimal result = 0;
            decimal expectedPrice = -400;
            Bill bill = new Bill { AccountNumber = "111-222-3333", AccountHolder = "Bogdan", ActiveAccount = true, OnlineBanking = true };

            //Act
            int billId = _sqlFacade.AddBill(bill);
            Invoice invoice1 = new Invoice { BillID = billId, Date = DateTime.Now, Payer = "Vojin", PaymentAmount = -200, PaymentPurpose = "UnitTest", Urgent = true };
            Invoice invoice2 = new Invoice { BillID = billId, Date = DateTime.Now, Payer = "Mateja", PaymentAmount = -200, PaymentPurpose = "UnitTest", Urgent = true };
            _sqlFacade.AddInvoice(invoice1);
            _sqlFacade.AddInvoice(invoice2);
            List<Invoice> invoiceList = _sqlFacade.GetAllInvoices();
            result = _billService.GetBillPrice(billId);

            //Assert
            Assert.AreEqual(expectedPrice, result);
        }

        [Test]
        public void CalculatePriceWithBadBillId()
        {
            //Arrange
            decimal result = 0;
            decimal expectedPrice = 0;
            Bill bill = new Bill { AccountNumber = "111-222-3333", AccountHolder = "Bogdan", ActiveAccount = true, OnlineBanking = true };

            //Act
            int billId = _sqlFacade.AddBill(bill);
            Invoice invoice1 = new Invoice { BillID = billId, Date = DateTime.Now, Payer = "Vojin", PaymentAmount = -200, PaymentPurpose = "UnitTest", Urgent = true };
            Invoice invoice2 = new Invoice { BillID = billId, Date = DateTime.Now, Payer = "Mateja", PaymentAmount = -200, PaymentPurpose = "UnitTest", Urgent = true };
            _sqlFacade.AddInvoice(invoice1);
            _sqlFacade.AddInvoice(invoice2);
            List<Invoice> invoiceList = _sqlFacade.GetAllInvoices();
            result = _billService.GetBillPrice(0);

            //Assert
            Assert.AreEqual(expectedPrice, result);
        }

        [Test]
        public void IfPriceIsBiggerThanZero()
        {
            //Arrange
            decimal result = 0;
            decimal expectedPrice = 1;
            Bill bill = new Bill { AccountNumber = "111-222-3333", AccountHolder = "Bogdan", ActiveAccount = true, OnlineBanking = true };

            //Act
            int billId = _sqlFacade.AddBill(bill);
            Invoice invoice1 = new Invoice { BillID = billId, Date = DateTime.Now, Payer = "Vojin", PaymentAmount = 1, PaymentPurpose = "UnitTest", Urgent = true };
            Invoice invoice2 = new Invoice { BillID = billId, Date = DateTime.Now, Payer = "Mateja", PaymentAmount = 0, PaymentPurpose = "UnitTest", Urgent = true };
            _sqlFacade.AddInvoice(invoice1);
            _sqlFacade.AddInvoice(invoice2);
            List<Invoice> invoiceList = _sqlFacade.GetAllInvoices();
            result = _billService.GetBillPrice(billId);

            //Assert
            Assert.AreEqual(expectedPrice, result);
        }

    }
}