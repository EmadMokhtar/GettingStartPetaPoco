using System.Collections.Generic;
using GettingStartPetaPoco.Console.Entities;
using GettingStartPetaPoco.Console.Models;

namespace GettingStartPetaPoco.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Database northwindDatabase = new Database("NorthwindConnectionString");
            Customer newCustomer = new Customer();

            //Set Data
            newCustomer.CustomerID = "EMAD";
            newCustomer.CompanyName = "Microsoft";
            newCustomer.ContactName = "Emad Mokhtar";
            newCustomer.ContactTitle = "Developer";

            //Create
            northwindDatabase.Insert(newCustomer);

            //Update
            northwindDatabase.Update<Customer>("Set ContactTitle=@0 WHERE CustomerID=@1",newCustomer.ContactTitle,newCustomer.CustomerID);

            //Delete
            northwindDatabase.Delete<Customer>("WHERE CustomerID=@0",newCustomer.CustomerID);
           
            //Read 
            var allCutomers = northwindDatabase.Query<Customer>("SELECT * FROM Customers");

            DisplayAllCustomers(allCutomers);
        }

        private static void DisplayAllCustomers(IEnumerable<Customer> allCutomers)
        {
            //Display Results
            foreach (var customer in allCutomers)
            {
                System.Console.WriteLine("Customer ID: {0} Company Name: {1} Contact Name: {2} Contact Title: {3}",
                                  customer.CustomerID, customer.CompanyName, customer.ContactName, customer.ContactTitle);
            }

            System.Console.Read();
        }
    }
}
