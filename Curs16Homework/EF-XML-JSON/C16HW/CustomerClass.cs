using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace C16HW
{
    public class CustomerClass
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }

        private CustomerClass() { }

        public CustomerClass(string connName, string newCustomerName, string newCustomerEmail)
        {
            this.CustomerID = this.InsertCustomer(connName, newCustomerName, newCustomerEmail);

            Console.WriteLine($"\t Customer '{newCustomerName}' with e-mail '{newCustomerEmail}' has been inserted with ID: '{this.CustomerID.ToString()}'");
        }

        private int InsertCustomer(string connName, string customerName, string customerEmail)
        {
            SqlConnection conn = DBacceess.OpenConnectionToDB(connName);

            SqlParameter customerNameParam = DBacceess.newParam("customerNameParam", customerName);
            SqlParameter customerEmailParam = DBacceess.newParam("customerEmailParam", customerEmail);

            SqlCommand insertNewCustomer = new SqlCommand(
                    "insert into Customer (CustomerName, CustomerEmail) values (@customerNameParam,@customerEmailParam)" +
                    "select cast(SCOPE_IDENTITY() as int)");
            insertNewCustomer.Connection = conn;
            insertNewCustomer.Parameters.Add(customerNameParam);
            insertNewCustomer.Parameters.Add(customerEmailParam);

            return (int)insertNewCustomer.ExecuteScalar();
        }

        public static void PrintCustomersFromDB(string connName)
        {
            SqlConnection conn = DBacceess.OpenConnectionToDB(connName);

            DBacceess.ExecuteReader(conn, "select CustomerID, CustomerName, CustomerEmail from Customer");

            DBacceess.CloseConnectionToDB(conn);
        }

        public static List<CustomerClass> CreateListOfCustomerObjects(string connName)
        {
            SqlConnection conn = DBacceess.OpenConnectionToDB(connName);
            SqlDataReader newReader = DBacceess.GetObjectFromReader(conn, "select CustomerID, CustomerName, CustomerEmail from Customer");

            var customerList = new List<CustomerClass>();
            while (newReader.Read())
            {
                customerList.Add(new CustomerClass { CustomerID = (int)newReader[0], CustomerName = (string)newReader[1], CustomerEmail = (string)newReader[2] });
            }
            DBacceess.CloseConnectionToDB(conn);
            return customerList;
        }
    }
}
