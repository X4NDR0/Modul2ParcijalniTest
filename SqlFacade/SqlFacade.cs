using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Modul2ParcijalniTest.SqlFacade
{
    public class SqlFacade : ISqlFacade
    {
        private string _connectionString = "Data Source=DESKTOP-QS7CCGF\\SQLEXPRESS;Initial Catalog=Modul2Test;Integrated Security=true";

        public int AddBill(Bill bill)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                int id = 0;
                connection.Open();
                string command = "insert into dbo.Racun(nosilacRacuna,brojRacuna,aktivanRacun,onlineBanking) values(@nosilacRacuna,@brojRacuna,@aktivanRacun,@onlineBanking) SELECT Scope_Identity()";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@nosilacRacuna", bill.AccountHolder);
                sqlCommand.Parameters.AddWithValue("@brojRacuna", bill.AccountNumber);
                sqlCommand.Parameters.AddWithValue("@aktivanRacun", bill.ActiveAccount);
                sqlCommand.Parameters.AddWithValue("@onlineBanking", bill.OnlineBanking);
                id = Convert.ToInt32(sqlCommand.ExecuteScalar());
                return id;
            }
        }

        public void EditInvoice(Invoice invoice)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                string command = "update dbo.Uplatnica set idRacuna=@idRacuna,iznosUplate=@iznosUplate,datumPrometa=@datumPrometa,svrhaUplate=@svrhaUplate,uplatilac=@uplatilac,hitno=@hitno where idUplatnice=@id";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", invoice.Id);
                sqlCommand.Parameters.AddWithValue("@idRacuna", invoice.BillID);
                sqlCommand.Parameters.AddWithValue("@iznosUplate", invoice.PaymentAmount);
                sqlCommand.Parameters.AddWithValue("@datumPrometa", invoice.Date);
                sqlCommand.Parameters.AddWithValue("@svrhaUplate", invoice.PaymentPurpose);
                sqlCommand.Parameters.AddWithValue("@uplatilac", invoice.Payer);
                sqlCommand.Parameters.AddWithValue("@hitno", invoice.Urgent);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public List<Bill> GetAllBills()
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                bool isBillActive = false;
                bool isOnlineBanking = false;
                List<Bill> billList = new List<Bill>();
                sqlConnection.Open();
                string command = "select * from dbo.Racun";
                SqlCommand cmd = new SqlCommand(command, sqlConnection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = int.Parse(reader["idRacuna"].ToString());
                        string accountHolder = reader["nosilacRacuna"].ToString();
                        string accountNumber = reader["brojRacuna"].ToString();
                        isBillActive = reader.GetBoolean(reader.GetOrdinal("aktivanRacun"));
                        isOnlineBanking = reader.GetBoolean(reader.GetOrdinal("onlineBanking"));

                        Bill bill = new Bill { Id = id, AccountHolder = accountHolder, AccountNumber = accountNumber, ActiveAccount = isBillActive, OnlineBanking = isOnlineBanking };
                        billList.Add(bill);
                    }
                }
                return billList;
            }
        }

        public void RemoveBill(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                string command = "delete from dbo.Racun where idRacuna=@id";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void EditBill(Bill bill)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                string command = "update dbo.Racun set nosilacRacuna=@nosilacRacuna,brojRacuna=@brojRacuna,aktivanRacun=@aktivanRacun,onlineBanking=@onlineBanking where idRacuna=@id";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", bill.Id);
                sqlCommand.Parameters.AddWithValue("@nosilacRacuna", bill.AccountHolder);
                sqlCommand.Parameters.AddWithValue("@brojRacuna", bill.AccountNumber);
                sqlCommand.Parameters.AddWithValue("@aktivanRacun", bill.ActiveAccount);
                sqlCommand.Parameters.AddWithValue("@onlineBanking", bill.OnlineBanking);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public int AddInvoice(Invoice invoice)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                int id = 0;
                connection.Open();
                string command = "insert into dbo.Uplatnica(idRacuna,iznosUplate,datumPrometa,svrhaUplate,uplatilac,hitno) values(@idRacuna,@iznosUplate,@datumPrometa,@svrhaUplate,@uplatilac,@hitno) SELECT Scope_Identity()";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@idRacuna", invoice.BillID);
                sqlCommand.Parameters.AddWithValue("@iznosUplate", invoice.PaymentAmount);
                sqlCommand.Parameters.AddWithValue("@datumPrometa", invoice.Date);
                sqlCommand.Parameters.AddWithValue("@svrhaUplate", invoice.PaymentPurpose);
                sqlCommand.Parameters.AddWithValue("@uplatilac", invoice.Payer);
                sqlCommand.Parameters.AddWithValue("@hitno", invoice.Urgent);
                id = Convert.ToInt32(sqlCommand.ExecuteScalar());
                return id;
            }
        }

        public void RemoveInvoice(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                string command = "delete from dbo.Uplatnica where idUplatnice=@id";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public List<Invoice> GetAllInvoices()
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                List<Invoice> invoiceList = new List<Invoice>();
                sqlConnection.Open();
                string command = "select * from dbo.Uplatnica";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int invoiceId = int.Parse(reader["idUplatnice"].ToString());
                        int billId = int.Parse(reader["idRacuna"].ToString());
                        decimal paymentAmount = decimal.Parse(reader["iznosUplate"].ToString());
                        DateTime dateTime = DateTime.Parse(reader["datumPrometa"].ToString());
                        string paymentPurpose = reader["svrhaUplate"].ToString();
                        string payer = reader["uplatilac"].ToString();
                        bool urgent = reader.GetBoolean(reader.GetOrdinal("hitno"));

                        Invoice uplatnica = new Invoice { Id = invoiceId, BillID = billId, PaymentAmount = paymentAmount, Date = dateTime, PaymentPurpose = paymentPurpose, Payer = payer, Urgent = urgent };
                        invoiceList.Add(uplatnica);
                    }
                }
                return invoiceList;
            }
        }
    }
}