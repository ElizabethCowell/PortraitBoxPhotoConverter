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
        public void DeleteOrder(Customer id)
        {
            throw new NotImplementedException();
        }

        public Customer GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertOrder(string firstName, string lastName, string email, string phone, string size, string address, string city, string state, int zipCode, double price)
        {
            string addCustomer = "INSERT INTO customers ( FirstName, LastName, Email, PhoneNumber) VALUE (@newFirstName, @newLastName, @newEmail, @newPhone);";
            string billingInfo = "INSERT INTO billing (Price, FirstName, LastName, Address, City, State, ZipCode, PhoneNumber) VALUE (@newPrice, @newFirstName, @newLastName, @newAddress, @newCity, @newState, @newZipCode, @newPhone)";
            string createProduct = "INSERT INTO products (LastName, Size) VALUE (@newLastName, @newSize)";

            //_connection.Open();
            //using (var transaction = _connection.BeginTransaction())
            //{
                _connection.Execute(addCustomer, new { newFirstName = firstName, newLastName = lastName, newEmail = email, newPhone = phone });
                _connection.Execute(billingInfo, new { newPrice = price, newFirstName = firstName, newLastName = lastName, newAddress = address, newCity = city, newState = state, newZipCode = zipCode, newPhone = phone });
                _connection.Execute (createProduct, new { newLastName = lastName, newSize = size });

            //    transaction.Commit();

            //}       

        }

        public void UpdateOrder(Customer id)
        {
            throw new NotImplementedException();
        }
    }
}
