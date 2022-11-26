using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=ADCLG1;Initial Catalog=db_Yakob;Integrated Security=True";

            string sqlExpression = "SELECT * FROM Person1";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    // выводим названия столбцов
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3));

                    while (reader.Read()) // построчно считываем данные
                    {
                        int id = reader.GetInt32(0);
                        string Name = reader.GetString(1);
                        string FirstName = reader.GetString(2);
                        int age = reader.GetInt32(3);



                        Console.WriteLine("{0} \t{1} \t{2} \t{3}", id, Name, FirstName, age);
                    }
                }

                reader.Close();
            }

            Console.Read();
        }
    }
}
