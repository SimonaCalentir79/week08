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
    public class SerializationMethods
    {
        public static void SaveToXMLFile(string connName, string fileName)
        {
            using (var writer = new StreamWriter(fileName))
            {
                var serializer = new XmlSerializer(CustomerClass.CreateListOfCustomerObjects(connName).GetType());
                serializer.Serialize(writer, CustomerClass.CreateListOfCustomerObjects(connName));
                writer.Flush();
            }
        }

        public static List<CustomerClass> LoadFromXMLFile(string fileName)
        {
            using (var stream = File.OpenRead(fileName))
            {
                var serializer = new XmlSerializer(typeof(List<CustomerClass>));
                return serializer.Deserialize(stream) as List<CustomerClass>;
            }
        }

        public static void PrintDataFromXMLFile(string fileName)
        {
            var listFromXMLFile = LoadFromXMLFile(fileName);
            foreach (var customer in listFromXMLFile)
                Console.WriteLine($"\t XML => id: '{customer.CustomerID}', name:'{customer.CustomerName}', email:'{customer.CustomerEmail}'");
        }

        public static void SaveToJSONFile(string connName, string fileName)
        {
            string collectionResult = JsonConvert.SerializeObject(CustomerClass.CreateListOfCustomerObjects(connName));
            File.WriteAllText(fileName, collectionResult);
        }

        public static void PrintDataFromJSONFile(string fileName)
        {
            var listFromJSONFile = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(fileName));
            foreach (var customer in listFromJSONFile)
                Console.WriteLine($"\t JSON => id: '{customer.CustomerID}', name:'{customer.CustomerName}', email:'{customer.CustomerEmail}'");
        }
    }
}
