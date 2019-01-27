using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using UsefulData;

namespace Pb05_SummaryBookApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("\n LIST OF BOOKS:");
            Data.PrintBooks();

            Console.WriteLine("\n Ex.1. Print books by entered year.");
            Rezolvare.PrintBooksByYear();

            Console.WriteLine("\n Ex.2. Print books by maximum year.");
            Rezolvare.PrintBooksByMaxYear();

            Console.WriteLine("\n Ex.3. Print top 5 books.");
            Rezolvare.PrintTop5Books();

            Console.ReadLine();
        }
    }
}
