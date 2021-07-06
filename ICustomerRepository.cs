using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortraitBoxPhotoConverter
{
    public interface ICustomerRepository
    {
        public int GetCustomerID();
        public String GetTimestamp(DateTime value);
        public void AddCustomer (Customer customer);
        public void AddOrder(Customer id, string size, DateTime timeStamp, string photo);
        public void AddBilling(Customer customer);
    }
}
