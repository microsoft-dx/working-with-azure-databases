using System;
using System.Data;

namespace WorkingWithAzureDB
{
    public static class ExtensionMethods
    {
        public static string Present(this Customer givenCustomer)
        {
            return (givenCustomer.Title ?? "The").Trim()
                + " "
                + (givenCustomer.LastName ?? "Amazing").Trim()
                + " "
                + (givenCustomer.FirstName ?? "Person").Trim();
        }

        public static string Present(this DataRow givenCustomer)
        {
            return (givenCustomer[2] != DBNull.Value ? givenCustomer["Title"] : "The")
                .ToString().Trim()
                + " "
                + (givenCustomer[5] != DBNull.Value ? givenCustomer["LastName"] : "Amazing")
                .ToString().Trim()
                + " "
                + (givenCustomer[3] != DBNull.Value ? givenCustomer["FirstName"] : "Person")
                .ToString().Trim();
        }
    }
}
