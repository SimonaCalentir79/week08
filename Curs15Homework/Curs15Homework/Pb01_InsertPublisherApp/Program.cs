using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using UsefulData;

namespace Pb01_InsertPublisherApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("\n\t Ex.1. Read the name of publishers.");
            Data.PrintPublishers();

            Console.WriteLine("\n\t Ex.2. Insert a new publisher to database, use SQL parameters for that " +
                "and print the inserted id (Execute scalar with select identity).");
            Console.WriteLine("\n\t Please enter the name of the Publisher to insert: ");
            Rezolvare.InsertPublisher(Console.ReadLine());

            Data.PrintPublishers();

            Console.ReadLine();
        }
    }
}
