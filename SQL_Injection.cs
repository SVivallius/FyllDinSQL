using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flood_Labb1_SQL
{
    public class SQL_Injection
    {
        private static string GenerateQuery(string firstName, string lastName)
        {
            Random rand = new Random();

            string genSSID =
                rand.Next(1950, 2000).ToString() +
                rand.Next(1, 12).ToString() +
                rand.Next(1, 30).ToString() +
                rand.Next(1111, 9999).ToString();

            string genDept = rand.Next(1, 5).ToString();

            string Query =
                "INSERT INTO [Employees] (Surname, Lastname, SSID, DepartmentID) " +
                "VALUES " +
                $"('{firstName}', '{lastName}', {genSSID}, {genDept})";

            return Query;
        }

        public static void ConnectAndInsert(int selection, List<string> firstNames, List<string> lastNames)
        {
            Random rand = new Random();
            string connectionString = @"Data Source=DESKTOP-E9173A7\SQLEXPRESS;Initial Catalog=Client_Company;Integrated Security=True";
            string query;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                for (int i = 0; i < selection; i++)
                {
                    string firstName, lastName;

                    int firstIndex = rand.Next(0, 18239);
                    int lastIndex = rand.Next(0, 1000);
                    firstName = firstNames[firstIndex];
                    lastName = lastNames[lastIndex];

                    query = GenerateQuery(firstName, lastName);

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        try
                        {
                            if (command.ExecuteNonQuery() == 1)
                            {
                                Console.WriteLine($"Successful injection - using indecies {firstIndex} and {lastIndex}" + command.CommandText);
                            }
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine($"Failed injection (firstName index: {firstIndex}, lastName index: {lastIndex}.\n" +
                                error.Message);
                        }
                    }
                }
            }
        }
    }
}
