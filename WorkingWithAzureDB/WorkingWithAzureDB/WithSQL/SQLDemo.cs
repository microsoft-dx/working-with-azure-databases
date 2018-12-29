using System.Data;
using System.Data.SqlClient;
using WorkingWithAzureDB.Properties;

namespace WorkingWithAzureDB.WithSQL
{
    public class SQLDemo : IDemo
    {
        private readonly Settings _settingsData = new Settings();

        public override void ShowAllCustomers(int customerID = 0)
        {
            string selectCommand = "SELECT * FROM [SalesLT].[Customer] "
                + (customerID == 0 ? ";" : $"WHERE CustomerID = {customerID};");
            // What could this be?
            using (DataTable allCustomers = new DataTable())
            using (SqlConnection linkToDatabase = new SqlConnection(_settingsData.DBConnection))
            using (SqlDataAdapter tableFiller = new SqlDataAdapter(selectCommand, linkToDatabase))
            {
                tableFiller.Fill(allCustomers);

                foreach (DataRow currentCustomer in allCustomers.Rows)
                {
                    System.Console.WriteLine(currentCustomer.Present());
                }
            }
        }

        public override void InsertNewCustomer(Customer givenCustomer)
        {
            // What could this be?
            using (SqlConnection linkToDatabase = new SqlConnection(_settingsData.DBConnection))
            using (SqlCommand insertCommand = new SqlCommand(
                "INSERT INTO [SalesLT].[Customer](" +
                //"CustomerID, " + // Can we do this?
                "FirstName, LastName, Title, PasswordHash, PasswordSalt) " +
                $"VALUES(" +
                //$"{givenCustomer.CustomerID}, " + // Can we do this?
                $"'{givenCustomer.FirstName}', " +
                $"'{givenCustomer.LastName}', " +
                $"'{givenCustomer.Title}', " +
                $"'{givenCustomer.PasswordHash}', " +
                $"'{givenCustomer.PasswordSalt}'" +
                $");", linkToDatabase))
            {
                linkToDatabase.Open();
                if (insertCommand.ExecuteNonQuery() == 1)
                {
                    //OK, time to get my real ID
                    using (SqlDataReader dataReader = new SqlCommand(
                        "SELECT CustomerID FROM [SalesLT].[Customer] " +
                        $"WHERE FirstName = '{givenCustomer.FirstName}' AND " +
                        $"LastName = '{givenCustomer.LastName}' AND " +
                        $"Title = '{givenCustomer.Title}';",
                        linkToDatabase).ExecuteReader()) {
                        dataReader.Read();

                        givenCustomer.CustomerID = (int)dataReader.GetValue(0);
                    }
                   
                };
            }
        }

        public override void UpdateCustomerName(int customerID, string firstName, string lastName)
        {
            // What could this be?
            using (SqlConnection linkToDatabase = new SqlConnection(_settingsData.DBConnection))
            using (SqlCommand insertCommand = new SqlCommand(
                "UPDATE [SalesLT].[Customer] " +
                $"SET FirstName = '{firstName}', LastName = '{lastName}' " +
                $"WHERE CustomerID = {customerID};",
                linkToDatabase))
            {
                linkToDatabase.Open();
                if (insertCommand.ExecuteNonQuery() == 1)
                {
                    //OK
                };
            }
        }

        public override void DeleteCustomer(int customerID)
        {
            // What could this be?
            using (SqlConnection linkToDatabase = new SqlConnection(_settingsData.DBConnection))
            using (SqlCommand insertCommand = new SqlCommand(
                "DELETE FROM [SalesLT].[Customer] " +
                $"WHERE CustomerID = {customerID};",
                linkToDatabase))
            {
                linkToDatabase.Open();
                if (insertCommand.ExecuteNonQuery() == 1)
                {
                    //OK
                };
            }
        }

        public override void RunDemo(Customer newCustomer)
        {
            System.Console.WriteLine("SQLDemo Demo Starting...");
            base.RunDemo(newCustomer);
            System.Console.WriteLine("SQLDemo Demo Done!");
        }

    }
}
