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
    }
}
