﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Pb06_DeletePublisherApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("\n LIST OF PUBLISHERS:");
            Rezolvare.PrintPublishers();
            Console.WriteLine("\n LIST OF BOOKS:");
            Rezolvare.PrintBooks();
            Console.WriteLine("\n\n ");

            Rezolvare.DeleteFromBookAndPublisher();
            Console.WriteLine("\n\n ");

            Console.WriteLine("\n LIST OF PUBLISHERS:");
            Rezolvare.PrintPublishers();
            Console.WriteLine("\n LIST OF BOOKS:");
            Rezolvare.PrintBooks();

            Console.ReadLine();
        }
    }
}
