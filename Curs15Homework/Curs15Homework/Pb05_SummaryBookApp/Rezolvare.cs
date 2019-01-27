using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Pb05_SummaryBookApp
{
    internal class Rezolvare
    {
        internal static void PrintBooksByYear()
        {
            SqlConnection connection = new SqlConnection { ConnectionString = "Data Source=.;Initial Catalog=Curs15BD;Integrated Security=True" };
            connection.Open();

            Console.WriteLine("\n Year of books to print?");
            int year = Convert.ToInt32(Console.ReadLine());

            SqlParameter yearOfBook = new SqlParameter { Value = year, ParameterName = "yearOfBook" };

            SqlCommand printBook = new SqlCommand("select BookID, Title, YearOfPublish, Price, NameOfPublisher " +
                "from Book b inner join Publisher p on b.PublisherID=p.PublisherID " +
                "where b.YearOfPublish=@yearOfBook;");
            printBook.Connection = connection;
            printBook.Parameters.Add(yearOfBook);

            SqlDataReader reader = printBook.ExecuteReader();
            if (reader.Read())
            {
                do
                {
                    Console.WriteLine($"\t id: {reader[0]}    title: '{reader[1]}'    year: {reader[2]},    price: {reader[3]} lei,    publisher '{reader[4]}'");
                } while (reader.Read());
            }
            else
            {
                Console.WriteLine($"\n There are no books published in {year}.");
            }
            reader.Close();
            connection.Close();
        }

        internal static void PrintBooksByMaxYear()
        {
            SqlConnection connection = new SqlConnection { ConnectionString = "Data Source=.;Initial Catalog=Curs15BD;Integrated Security=True" };
            connection.Open();

            SqlCommand printMaxYear = new SqlCommand("select MAX(YearOfPublish) from Book;");
            printMaxYear.Connection = connection;
            int maxYear = (int)printMaxYear.ExecuteScalar();
            Console.WriteLine($"\n Maximum year of published books is: {maxYear}");

            SqlParameter maxYearParameter = new SqlParameter { Value = maxYear, ParameterName = "maxYearParameter" };
            SqlCommand printBooksByYear = new SqlCommand("select BookID, Title, YearOfPublish, Price, NameOfPublisher " +
                "from Book b inner join Publisher p on b.PublisherID=p.PublisherID " +
                "where b.YearOfPublish=@maxYearParameter;");
            printBooksByYear.Connection = connection;
            printBooksByYear.Parameters.Add(maxYearParameter);

            SqlDataReader reader = printBooksByYear.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"\t id: {reader[0]}    title: '{reader[1]}'    year: {reader[2]},    price: {reader[3]} lei,    publisher '{reader[4]}'");
            }
            reader.Close();
            connection.Close();
        }
        internal static void PrintTop5Books()
        {
            SqlConnection connection = new SqlConnection { ConnectionString = "Data Source=.;Initial Catalog=Curs15BD;Integrated Security=True" };
            connection.Open();

            SqlCommand top5Books = new SqlCommand("select top 5* from Book order by BookID;");
            top5Books.Connection = connection;

            SqlDataReader reader = top5Books.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"\t title: '{reader[1]}', year: {reader[2]}, price: {reader[3]}");
            }
            reader.Close();
            connection.Close();
        }
    }
}
