﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortraitBoxPhotoConverter
{
    public interface ICustomerRepository
    {
        public Customer GetCustomerID();
        public String GetTimestamp(DateTime value);
        public void AddCustomer (string firstName, string lastname, string email, string phone);
        public void AddOrder(Customer id, string size, DateTime timeStamp, string photo);
        public void AddBilling(Customer id, string address, string city, string state, int zipCode, double price);
    }
}