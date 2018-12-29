namespace WorkingWithAzureDB
{
    public abstract class IDemo
    {
        public abstract void ShowAllCustomers(int customerID = 0);

        public abstract void InsertNewCustomer(Customer givenCustomer);

        public abstract void UpdateCustomerName(int customerID, string firstName, string lastName);

        public abstract void DeleteCustomer(int customerID);

        public virtual void RunDemo(Customer newCustomer)
        {
            // What am I doing Here
            ShowAllCustomers();
            System.Console.WriteLine("SELECTED EVERYTHING..." + System.Environment.NewLine);

            // What am I doing Here
            System.Console.WriteLine("Adding myself" + System.Environment.NewLine);
            ShowAllCustomers(newCustomer.CustomerID);
            InsertNewCustomer(newCustomer);
            System.Console.WriteLine("Added Myself..." + System.Environment.NewLine);

            // What am I doing Here
            ShowAllCustomers(newCustomer.CustomerID);
            System.Console.WriteLine("Updating myself..." + System.Environment.NewLine);
            UpdateCustomerName(newCustomer.CustomerID, newCustomer.LastName, newCustomer.FirstName);
            ShowAllCustomers(newCustomer.CustomerID);

            // What am I doing Here
            System.Console.WriteLine("Erasing myself..." + System.Environment.NewLine);
            DeleteCustomer(newCustomer.CustomerID);
            ShowAllCustomers(newCustomer.CustomerID);
        }

    }
}
