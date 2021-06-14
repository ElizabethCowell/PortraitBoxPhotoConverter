using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PortraitBoxPhotoConverter
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnection _connection;
        public CustomerRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMdd");
        }
        public void AddOrder(Customer id, string size, DateTime timeStamp, string photo)
        {
            
            string createProduct = "INSERT INTO products (CustomerID, Size, DateOrdered, Image) VALUE (@newCustomerID, @newSize, @newDateOrdered, @newImage)";
            _connection.Execute (createProduct, new { newCustomerID = id, newSize = size, newDateOrdered = timeStamp, newImage = photo});

        }

        public int GetCustomerID()
        {
           var customer = _connection.QuerySingleOrDefault<Customer>("SELECT CustomerID FROM customers ORDER BY CustomerID DESC LIMIT 1;");
            

            return customer.CustomerID; 
        }

        public void AddCustomer(Customer customer)
        {
            Customer id = new Customer();
            string addCustomer = "INSERT INTO customers ( FirstName, LastName, Email, PhoneNumber) VALUE (@newFirstName, @newLastName, @newEmail, @newPhone);";
            //id.CustomerID = Convert.ToInt32(_connection.ExecuteScalar(addCustomer, new { newFirstName = customer.FirstName, newLastName = customer.LastName, newEmail = customer.Email, newPhone = customer.PhoneNumber }));
            
            _connection.Execute(addCustomer, new { newFirstName = customer.FirstName, newLastName = customer.LastName, newEmail = customer.Email, newPhone = customer.PhoneNumber });
        }

        public void AddBilling(Customer id, string address, string city, string state, int zipCode, double price)
        {
            string billingInfo = "INSERT INTO billing (CustomerID, Price, Address, City, State, ZipCode) VALUE (@newCustomerID @newPrice, @newAddress, @newCity, @newState, @newZipCode)";
            _connection.Execute(billingInfo, new { newCustomerID = id, newPrice = price, newAddress = address, newCity = city, newState = state, newZipCode = zipCode});
        }
    }
}
