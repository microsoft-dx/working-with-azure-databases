using System.Linq;

namespace WorkingWithAzureDB.WithEF
{
    public class EFDemo : IDemo
    {
        public override void ShowAllCustomers(int customerID = 0) {
            // What could this be?
            using (DBModel linkToDatabase =  new DBModel())
            {
                foreach (Customer currentCustomer in 
                    linkToDatabase.Customers.Where(x => customerID == 0 || x.CustomerID == customerID))
                {
                    // Where did this come from?
                    System.Console.WriteLine(currentCustomer.Present());
                }
            }
        }

        public override void InsertNewCustomer(Customer givenCustomer)
        {
            using (DBModel linkToDatabase = new DBModel())
            {
                linkToDatabase.Customers.Add(givenCustomer);

                // Why do we do this?
                linkToDatabase.SaveChanges();
            }
        }

        public override void UpdateCustomerName(int customerID, string firstName, string lastName)
        {
            using (DBModel linkToDatabase = new DBModel())
            {
                // We can do this more hardcore with pure LINQ
                Customer desiredCustomer =
                    linkToDatabase.Customers.FirstOrDefault(x => x.CustomerID == customerID);

                // Why if?
                if (desiredCustomer != null)
                {
                    desiredCustomer.FirstName = firstName;
                    desiredCustomer.LastName = lastName;

                    linkToDatabase.SaveChanges();
                }
            }
        }

        public override void DeleteCustomer(int customerID)
        {
            using (DBModel linkToDatabase = new DBModel())
            {
                // We can do this more hardcore with pure LINQ
                Customer desiredCustomer =
                    linkToDatabase.Customers.FirstOrDefault(x => x.CustomerID == customerID);

                // Why if?
                if (desiredCustomer != null)
                {
                    linkToDatabase.Customers.Remove(desiredCustomer);

                    linkToDatabase.SaveChanges();
                }
            }
        }

        public override void RunDemo(Customer newCustomer)
        {
            System.Console.WriteLine("EF Demo Starting...");
            base.RunDemo(newCustomer);
            System.Console.WriteLine("EF Demo Done!");
        }

    }
}
