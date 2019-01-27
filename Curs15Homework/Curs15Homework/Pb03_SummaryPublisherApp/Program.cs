using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Pb03_SummaryPublisherApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("\n\t Ex.1. Number of rows from the Publisher table (Execute scalar).");
            Rezolvare.PrintPublisherNoOfRows();

            Console.WriteLine("\n\t Ex.2. Top 5 publishers (Id, Name) (SQL Data Reader).");
            Rezolvare.PrintTop5Publishers();

            Console.WriteLine("\n\t Ex.3. Number of books for each publisher (Publiher Name, Number of Books).");
            Rezolvare.PrintNumberOfBooksPerPublisher();

            Console.WriteLine("\n\t Ex.4. The total price for books for a publisher.");
            Rezolvare.PrintSumPriceOfBooksPerPublisher();

            Console.ReadLine();
        }
    }
}
