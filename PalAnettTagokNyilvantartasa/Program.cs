using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalAnettTagokNyilvantartasa
{
    internal class Program
    {
        static List<Tag> tagList = new List<Tag>();
        static MySqlConnection connection = null;
        static MySqlCommand command = null;
        static void Main(string[] args)
        {
            beolvasas();
            tagokListazasa();
            //ujTagFelvetele();
            //tagTorlese();

            Console.WriteLine("\nProgram vége");
            Console.ReadLine ();
        }

        private static void tagokListazasa()
        {
            foreach (Tag item in tagList)
            {
                Console.WriteLine(item);
            }
        }

        private static void beolvasas()
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Clear();
            sb.Server = "localhost";
            sb.UserID = "anett";
            sb.Password = "7112";
            sb.Database = "tagdij";
            sb.CharacterSet = "utf8";
            connection = new MySqlConnection(sb.ConnectionString);
            command = connection.CreateCommand();
            try
            {
                connection.Open();
                command.CommandText = "SELECT * FROM `ugyfel`";
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Tag uj = new Tag(dr.GetInt32("azon"), dr.GetString("nev"), dr.GetInt32("szulev"), dr.GetInt32("iszam"), dr.GetString("orsz"));
                        tagList.Add(uj);
                    }
                }
                connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }
    }
}
