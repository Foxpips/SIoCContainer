using System;

namespace Shop.Domain.Entities.Customer
{
    public class BillPayCustomer : ICustomer
    {
        public int GetCustomerBalance()
        {
            return new Random().Next(500, 1000);
        }
    }
}