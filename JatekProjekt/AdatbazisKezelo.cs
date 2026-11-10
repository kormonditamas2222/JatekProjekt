using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace JatekProjekt
{

    public class AdatbazisKezelo
    {
        private readonly string connectionString;


        public AdatbazisKezelo()
        {

            this.connectionString = "server=localhost;database=jatekdb;uid=root;pwd=;";// Irjuk meg a connectionstringet a megfelelő adatbázisra hivatkozva
        }

   
        /// Beolvassa az összes karaktert az adatbázisból egy List<Karakter>-be.
       
        public List<Karakter> AdatokBetoltese()
        {
            List<Karakter> karakterek = new();
            using(MySqlConnection connection = new(connectionString))
            {
                string query = "SELECT * FROM karakterek";
                using (MySqlCommand command = new(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Karakter karakter = new(reader.GetInt32("Id"), reader.GetString("Nev"), reader.GetString("Osztaly"), reader.GetInt32("Szint"), reader.GetInt32("Arany"), reader.GetString("Szerver"));
                            karakterek.Add(karakter);
                        }
                    }
                }
            }
            return karakterek;
        }
    }
}
