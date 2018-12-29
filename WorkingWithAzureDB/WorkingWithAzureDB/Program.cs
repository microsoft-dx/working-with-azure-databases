using System;
using System.Collections.Generic;
using WorkingWithAzureDB.WithEF;
using WorkingWithAzureDB.WithSQL;

namespace WorkingWithAzureDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer myself = new Customer
            {
                CustomerID = 555, // Can we do this? Why?
                FirstName = "Alexandru",
                LastName = "Petrescu",
                Title = "Prof. ",
                PasswordHash = "WeKindOfNeedToDoThis",
                PasswordSalt = "ThisAlso",
                ModifiedDate = DateTime.Now
            };

            List<IDemo> toShow = new List<IDemo> { new EFDemo(), new SQLDemo() };

            foreach (IDemo currentDemo in toShow)
            {
                currentDemo.RunDemo(myself);

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
