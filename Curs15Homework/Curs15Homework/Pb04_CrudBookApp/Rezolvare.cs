using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Pb04_CrudBookApp
{
    internal class Rezolvare
    {
        internal static void InsertBook()
        {
            SqlConnection connection = new SqlConnection { ConnectionString = "Data Source=.;Initial Catalog=Curs15BD;Integrated Security=True" };
            connection.Open();

            Console.WriteLine("\n Title of new book?");
            string newTitle = Console.ReadLine();

            Console.WriteLine("\n Year of publish?");
            string newYear = Console.ReadLine();

            Console.WriteLine("\n Price of new book?");
            int newPrice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n Publisher of new book?");
            string PublisherOfNewBook = Console.ReadLine();

            SqlParameter bookTitle = new SqlParameter { Value = newTitle, ParameterName = "bookTitle" };
            SqlParameter bookYear = new SqlParameter { Value = newYear, ParameterName = "bookYear" };
            SqlParameter bookPrice = new SqlParameter { Value = newPrice, ParameterName = "bookPrice" };
            SqlParameter bookPublisher = new SqlParameter { Value = PublisherOfNewBook, ParameterName = "bookPublisher" };

            SqlCommand findPublisherID = new SqlCommand("select PublisherID from Publisher where NameOfPublisher=@bookPublisher");
            findPublisherID.Connection = connection;
            findPublisherID.Parameters.Add(bookPublisher);

            int publisherId = (int)findPublisherID.ExecuteScalar();
            SqlParameter newPublisherID = new SqlParameter { Value = publisherId, ParameterName = "newPublisherID" };

            SqlCommand insertBook = new SqlCommand("INSERT INTO Book(Title, YearOfPublish, Price, PublisherID) " +
                "VALUES(@bookTitle, @bookYear, @bookPrice, @newPublisherID)" +
                "SELECT CAST(scope_identity() AS int)");
            insertBook.Connection = connection;
            insertBook.Parameters.Add(bookTitle);
            insertBook.Parameters.Add(bookYear);
            insertBook.Parameters.Add(bookPrice);
            insertBook.Parameters.Add(newPublisherID);

            int insertedBookId = (int)insertBook.ExecuteScalar();
            Console.WriteLine($"\n\t Inserted BookID: {insertedBookId}");
            Console.WriteLine("\n");

            connection.Close();
        }

        internal static void UpdatePriceOfBook()
        {
            SqlConnection connection = new SqlConnection { ConnectionString = "Data Source=.;Initial Catalog=Curs15BD;Integrated Security=True" };
            connection.Open();

            Console.WriteLine("\n ID of book to update?");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n New price of book?");
            int newPrice = Convert.ToInt32(Console.ReadLine());

            SqlParameter idOfBook = new SqlParameter { Value = id, ParameterName = "idOfBook" };
            SqlParameter priceOfBook = new SqlParameter { Value = newPrice, ParameterName = "priceOfBook" };

            SqlCommand updatePriceOfBook = new SqlCommand("update Book set Price=@priceOfBook where BookID=@idOfBook;");
            updatePriceOfBook.Connection = connection;
            updatePriceOfBook.Parameters.Add(idOfBook);
            updatePriceOfBook.Parameters.Add(priceOfBook);
            updatePriceOfBook.ExecuteNonQuery();

            connection.Close();
        }

        internal static void DeleteFromBook()
        {
            SqlConnection connection = new SqlConnection { ConnectionString = "Data Source=.;Initial Catalog=Curs15BD;Integrated Security=True" };
            connection.Open();

            Console.WriteLine("\n ID of book to delete?");
            int id = Convert.ToInt32(Console.ReadLine());

            SqlParameter idOfBook = new SqlParameter { Value = id, ParameterName = "idOfBook" };
            SqlCommand deleteFromBook = new SqlCommand("delete from Book where BookID=@idOfBook");
            deleteFromBook.Connection = connection;
            deleteFromBook.Parameters.Add(idOfBook);
            deleteFromBook.ExecuteNonQuery();

            connection.Close();
        }

        internal static void PrintBookById()
        {
            SqlConnection connection = new SqlConnection { ConnectionString = "Data Source=.;Initial Catalog=Curs15BD;Integrated Security=True" };
            connection.Open();

            Console.WriteLine("\n ID of book to print?");
            int id = Convert.ToInt32(Console.ReadLine());

            SqlParameter idOfBook = new SqlParameter { Value = id, ParameterName = "idOfBook" };

            SqlCommand printBook = new SqlCommand("select BookID, Title, YearOfPublish, Price, NameOfPublisher " +
                "from Book b inner join Publisher p on b.PublisherID=p.PublisherID " +
                "where BookID=@idOfBook;");
            printBook.Connection = connection;
            printBook.Parameters.Add(idOfBook);

            SqlDataReader reader = printBook.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"\t id: {reader[0]}    title: '{reader[1]}'    year: {reader[2]},    price: {reader[3]} lei,    publisher '{reader[4]}'");
            }
            reader.Close();
            connection.Close();
        }
    }
}
