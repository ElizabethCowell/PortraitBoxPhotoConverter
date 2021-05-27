using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortraitBoxPhotoConverter
{
    interface ICustomerRepository
    {
        public Customer GetOrder(int id);
        public void InsertOrder (Customer order);
        public void UpdateOrder(Customer id);
        public void DeleteOrder(Customer id);
    }
}
