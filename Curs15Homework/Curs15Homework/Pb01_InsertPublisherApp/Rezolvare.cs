﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Pb01_InsertPublisherApp
{
    internal class Rezolvare
    {
        internal static void InsertPublisher(string publisherName)
        {
            SqlConnection connection = new SqlConnection { ConnectionString = "Data Source=.;Initial Catalog=Curs15BD;Integrated Security=True" };
            connection.Open();

            SqlParameter publisherNameParameter = new SqlParameter();
            publisherNameParameter.Value = publisherName;
            publisherNameParameter.ParameterName = "publisherNameParameter";

            SqlCommand insertPublisher = new SqlCommand();
            insertPublisher.Connection = connection;
            insertPublisher.CommandText = "INSERT INTO Publisher(NameOfPublisher) VALUES(@publisherNameParameter);"
                                         + "SELECT CAST(scope_identity() AS int)";

            insertPublisher.Parameters.Add(publisherNameParameter);

            int inserted = (int)insertPublisher.ExecuteScalar();
            Console.WriteLine($"\n\t Inserted PublisherID: {inserted}");

            connection.Close();
        }
    }
}
