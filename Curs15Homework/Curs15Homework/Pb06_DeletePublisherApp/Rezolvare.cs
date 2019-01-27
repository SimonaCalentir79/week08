using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Pb06_DeletePublisherApp
{
    internal class Rezolvare
    {
        internal static void DeleteFromBookAndPublisher()
        {
            SqlConnection connection = new SqlConnection { ConnectionString = "Data Source=.;Initial Catalog=Curs15BD;Integrated Security=True" };
            connection.Open();

            Console.WriteLine("ID of publisher to delete?");
            int id = Convert.ToInt32(Console.ReadLine());

            SqlCommand deletePublisher = new SqlCommand("DeletePublisher", connection);
            deletePublisher.CommandType = CommandType.StoredProcedure;

            SqlParameter idParam;
            idParam = deletePublisher.Parameters.Add("@PublisherID", SqlDbType.Int);
            idParam.Value = id;

            deletePublisher.ExecuteNonQuery();
            connection.Close();
        }
        internal static void PrintBooks()
        {
            SqlConnection connection = new SqlConnection { ConnectionString = "Data Source=.;Initial Catalog=Curs15BD;Integrated Security=True" };
            connection.Open();

            SqlCommand printBooks = new SqlCommand("select BookID, Title, YearOfPublish, Price, NameOfPublisher from Book b inner join Publisher p on b.PublisherID=p.PublisherID;");
            printBooks.Connection = connection;
            SqlDataReader reader = printBooks.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"\t id: {reader[0]}    title: '{reader[1]}'    year: {reader[2]},    price: {reader[3]} lei,    publisher '{reader[4]}'");
            }
            reader.Close();

            connection.Close();
        }
        internal static void PrintPublishers()
        {
            SqlConnection connection = new SqlConnection { ConnectionString = "Data Source=.;Initial Catalog=Curs15BD;Integrated Security=True" };
            connection.Open();

            string printPublishers = "select PublisherID, NameOfPublisher from Publisher";
            SqlCommand showPublishers = new SqlCommand(printPublishers);
            showPublishers.Connection = connection;

            SqlDataReader reader = showPublishers.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"\t {reader["PublisherID"]} - {reader["NameOfPublisher"]}");
            }
            reader.Close();
            connection.Close();
        }
    }
}
