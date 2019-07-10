using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstWithDb_POCOGen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** NorthWind ***");

            using (var con = new MyDbContext("Data Source=.;Initial Catalog=Northwind;Integrated Security=True;"))
            {
                foreach (var e in con.Employees.ToList())
                {
                    Console.WriteLine($"{e.LastName}");
                }
            }


            Console.WriteLine("Ende");
            Console.ReadKey();
        }
    }
}
