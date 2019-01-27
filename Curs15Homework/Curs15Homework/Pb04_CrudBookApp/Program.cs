using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using UsefulData;

namespace Pb04_CrudBookApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("\n Ex.1. Insert new book using SQL Parameter for that and print the inserted id (Execute scalar with select identity).");
            Rezolvare.InsertBook();
            Console.WriteLine("\n");
            Data.PrintBooks();

            Console.WriteLine("\n Ex.2. Update a book (read id from console).");
            Rezolvare.UpdatePriceOfBook();
            Console.WriteLine("\n");
            Data.PrintBooks();

            Console.WriteLine("\n Ex.3. Delete a book (read id from console).");
            Rezolvare.DeleteFromBook();
            Console.WriteLine("\n");
            Data.PrintBooks();

            Console.WriteLine("\n Ex.4. Select a book (read id from console).");
            Rezolvare.PrintBookById();

            Console.ReadLine();
        }
    }
}
