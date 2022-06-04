using System.Data.SqlClient;

namespace Modul2ParcijalniTest.SqlFacade
{
    public class SqlFacade : ISqlFacade
    {
        private string _connectionString = "Data Source=DESKTOP-QS7CCGF\\SQLEXPRESS;Initial Catalog=Modul2Test;Integrated Security=true";

        public void AddBill(Racun racun)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string command = "insert into dbo.Racun(Nosilac_racuna,Broj_racuna,Aktivan_racun,Online_banking) values(@nosilacRacuna,@brojRacuna,@aktivanRacun,@onlineBanking)";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@nosilacRacuna", racun.NosilacRacuna);
                sqlCommand.Parameters.AddWithValue("@brojRacuna", racun.BrojRacuna);
                sqlCommand.Parameters.AddWithValue("@aktivanRacun", racun.AktivanRacun);
                sqlCommand.Parameters.AddWithValue("@onlineBanking", racun.OnlineBanking);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public List<Racun> GetAllBills()
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                bool isBillActive = false;
                bool isOnlineBanking = false;
                List<Racun> billList = new List<Racun>();
                sqlConnection.Open();
                string command = "select * from dbo.Racun";
                SqlCommand cmd = new SqlCommand(command, sqlConnection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = int.Parse(reader["id"].ToString());
                        string nosilacRacuna = reader["Nosilac_racuna"].ToString();
                        string brojRacuna = reader["Broj_racuna"].ToString();
                        isBillActive = reader.GetBoolean(reader.GetOrdinal("Aktivan_racun"));
                        isOnlineBanking = reader.GetBoolean(reader.GetOrdinal("Online_banking"));

                        Racun racun = new Racun { Id = id, NosilacRacuna = nosilacRacuna, BrojRacuna = brojRacuna, AktivanRacun = isBillActive, OnlineBanking = isOnlineBanking };
                        billList.Add(racun);
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
                string command = "delete from dbo.Racun where id=@id";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void EditBill(Racun racun)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                string command = "update dbo.Racun set Nosilac_racuna=@nosilacRacuna,Broj_racuna=@brojRacuna,Aktivan_racun=@aktivanRacun,Online_banking=@onlineBanking where id=@id";
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", racun.Id);
                sqlCommand.Parameters.AddWithValue("@nosilacRacuna", racun.NosilacRacuna);
                sqlCommand.Parameters.AddWithValue("@brojRacuna", racun.BrojRacuna);
                sqlCommand.Parameters.AddWithValue("@aktivanRacun", racun.AktivanRacun);
                sqlCommand.Parameters.AddWithValue("@onlineBanking", racun.OnlineBanking);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void DodajUplatnicu(Uplatnica uplatnica)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string command = "insert into dbo.Uplatnica(id,id_racuna,Iznos_uplate,Datum_prometa,Svrha_uplate,Uplatilac,Hitno) values(@id,@idRacuna,@iznosUplate,@datumPrometa,@svrhaUplate,@uplatilac,@hitno)";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@idRacuna", uplatnica.IdRacuna);
                sqlCommand.Parameters.AddWithValue("@iznosUplate", uplatnica.IznosUplate);
                sqlCommand.Parameters.AddWithValue("@datumPrometa", uplatnica.DatumPrometa);
                sqlCommand.Parameters.AddWithValue("@svrhaUplate", uplatnica.SvrhaUplate);
                sqlCommand.Parameters.AddWithValue("@uplatilac", uplatnica.Uplatilac);
                sqlCommand.Parameters.AddWithValue("@hitno", uplatnica.Hitno);
                sqlCommand.ExecuteNonQuery();
            }
        }

    }
}