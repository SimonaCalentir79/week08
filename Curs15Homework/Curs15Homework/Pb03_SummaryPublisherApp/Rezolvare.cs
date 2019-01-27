using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Pb03_SummaryPublisherApp
{
    internal class Rezolvare
    {
        internal static void PrintPublisherNoOfRows()
        {
            SqlConnection connection = new SqlConnection { ConnectionString = "Data Source=.;Initial Catalog=Curs15BD;Integrated Security=True" };
            connection.Open();

            try
            {
                SqlCommand countPublisherRows = new SqlCommand("select count(*) from Publisher;");
                countPublisherRows.Connection = connection;
                int rowNr = (int)countPublisherRows.ExecuteScalar();
                Console.WriteLine($"\n\t Number of rows in Publisher table: {rowNr}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                connection.Close();
            }
        }

        internal static void PrintTop5Publishers()
        {
            SqlConnection connection = new SqlConnection { ConnectionString = "Data Source=.;Initial Catalog=Curs15BD;Integrated Security=True" };
            connection.Open();

            SqlCommand top5Publishers = new SqlCommand("select top 5* from Publisher order by PublisherID;");
            top5Publishers.Connection = connection;

            SqlDataReader reader = top5Publishers.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"\t {reader[0]} - {reader[1]}");
            }
            reader.Close();

            connection.Close();
        }

        internal static void PrintNumberOfBooksPerPublisher()
        {
            SqlConnection connection = new SqlConnection { ConnectionString = "Data Source=.;Initial Catalog=Curs15BD;Integrated Security=True" };
            connection.Open();

            SqlCommand numberOfBooksPerPublisher = new SqlCommand("select COUNT(b.BookID), p.NameOfPublisher " +
                "from Book b inner join Publisher p on b.PublisherID=p.PublisherID " +
                "group by p.NameOfPublisher;");
            numberOfBooksPerPublisher.Connection = connection;

            SqlDataReader reader = numberOfBooksPerPublisher.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"\t Publisher '{reader[1]}' - {reader[0]} book(s)");
            }
            reader.Close();
            connection.Close();
        }

        internal static void PrintSumPriceOfBooksPerPublisher()
        {
            SqlConnection connection = new SqlConnection { ConnectionString = "Data Source=.;Initial Catalog=Curs15BD;Integrated Security=True" };
            connection.Open();

            SqlCommand sumPriceOfBooksPerPublisher = new SqlCommand("select SUM(b.Price), p.NameOfPublisher " +
                "from Book b inner join Publisher p on b.PublisherID=p.PublisherID " +
                "group by p.NameOfPublisher;");
            sumPriceOfBooksPerPublisher.Connection = connection;

            SqlDataReader reader = sumPriceOfBooksPerPublisher.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"\t Publisher '{reader[1]}' - total price: {reader[0]} lei");
            }
            reader.Close();
            connection.Close();
        }
    }
}
