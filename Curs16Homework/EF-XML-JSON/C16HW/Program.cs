using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace C16HW
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("\n\t READING DATA FROM DB AND SERIALIZE IT TO *.XML & *.JSON FILE...");
            CustomerClass.PrintCustomersFromDB("STOREdbconn1");
            SerializationMethods.SaveToXMLFile("STOREdbconn1", "CustomerList.xml");
            SerializationMethods.SaveToJSONFile("STOREdbconn1","CustomerList.json");

            Console.WriteLine("\n\t INSERTING NEW CUSTOMERS...");
            var newCustomer1 = new CustomerClass("STOREdbconn1", "Customer 7", "customer7@wantsome.ro");
            var newCustomer2 = new CustomerClass("STOREdbconn1", "Customer 8", "customer8@gmail.com");

            Console.WriteLine("\n\t READ FROM DB AND OVERWRITE THE PREVIOUS GENERATED *.XML & *.JSON FILE... ");
            CustomerClass.PrintCustomersFromDB("STOREdbconn1");
            SerializationMethods.SaveToXMLFile("STOREdbconn1", "CustomerList.xml");
            SerializationMethods.SaveToJSONFile("STOREdbconn1", "CustomerList.json");

            Console.WriteLine("\n\t LOADING DATA FROM A *.XML FILE (the one generated before, in this case)...");
            SerializationMethods.PrintDataFromXMLFile("CustomerList.xml");

            Console.WriteLine("\n\t LOADING DATA FROM A *.JSON FILE (the one generated before, in this case)...");
            SerializationMethods.PrintDataFromJSONFile("CustomerList.json");

            Console.ReadLine();
        }
    }
}
