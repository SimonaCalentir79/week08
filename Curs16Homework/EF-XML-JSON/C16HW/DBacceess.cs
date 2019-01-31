using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace C16HW
{
    public static class DBacceess
    {
        public static SqlConnection OpenConnectionToDB(string connName)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connName].ConnectionString;
            connection.Open();
            return connection;
        }

        public static void CloseConnectionToDB(SqlConnection connName)
        {
            connName.Close();
        }

        public static void ExecuteReader(SqlConnection connName, string commandText)
        {
            SqlCommand command = new SqlCommand(commandText);
            command.Connection = connName;

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"\t {reader[i]} ");
                }
                Console.WriteLine();
            }
            reader.Close();
        }

        public static SqlDataReader GetObjectFromReader(SqlConnection connName, string commandText)
        {
            SqlCommand command = new SqlCommand(commandText);
            command.Connection = connName;

            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }

        public static void CloseReader(SqlDataReader readerName)
        {
            readerName.Close();
        }

        public static SqlParameter newParam(string paramName, object paramValue)
        {
            SqlParameter parameter = new SqlParameter { Value = paramValue, ParameterName = paramName};
            return parameter;
        }
    }
}
