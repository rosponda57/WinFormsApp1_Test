using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.ClassTest
{
    public class plyty
    {
        public int idZbiorPlyty { get; set; }
        public string nazwaAlbumu { get; set; }
        public string nazwaArtysty { get; set; } 
       public int iloscPiosenek { get; set; }
    }

    //tabela płyty, tabela zbiorPlyty, pola: nazwaAlbumu, nazwaArtysty,iloscPiosenek   i pole automatyczne id: idZbiorPlyty
    internal class clsSQLLite
    {
        private string dbPAht = "Data Source=D:\\DB\\hello.db";
        public void initBaze()
        {
            using (var connection = new SqliteConnection(dbPAht))
            {
                connection.Open();  //  <== The database file is created here.

                // stworzenie tabeli jeśli jej nie ma.
                string sql = "Create Table if not exists zbiorPlyty (idZbiorPlyty integer primary key, nazwaAlbumu varchar(255), nazwaArtysty varchar(255), iloscPiosenek int)";
                SqliteCommand command = new SqliteCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }



        public void dodajPlyte(plyty nowaplyta)
        {
            using (var connection = new SqliteConnection(dbPAht))
            {
                connection.Open();  //  <== The database file is created here.
                SqliteCommand command = connection.CreateCommand();
                // stworzenie tabeli jeśli jej nie ma.
                command.CommandText = "insert into zbiorPlyty (nazwaAlbumu, nazwaArtysty, iloscPiosenek) values ($v1, $v2, $v3)";
                command.Parameters.AddWithValue("$v1", nowaplyta.nazwaAlbumu);
                command.Parameters.AddWithValue("$v2", nowaplyta.nazwaArtysty);
                command.Parameters.AddWithValue("$v3", nowaplyta.iloscPiosenek);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public List <plyty> listaPlyt()
        {
            List<plyty> wynik = new();

            using (var connection = new SqliteConnection(dbPAht))
            {
                connection.Open();  //  <== The database file is created here.

                var command = connection.CreateCommand();
                command.CommandText = "select  idZbiorPlyty, nazwaAlbumu, nazwaArtysty, iloscPiosenek from zbiorPlyty";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        plyty plyta = new plyty();
                        plyta.idZbiorPlyty = reader.GetInt32(0);
                        plyta.nazwaAlbumu = reader.GetString(1);
                        plyta.nazwaArtysty= reader.GetString(2);
                        plyta.iloscPiosenek = reader.GetInt32(3);

                        wynik.Add(plyta);   
                    }
                }
            }

            return wynik; 
        }
    }
}
