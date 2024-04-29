using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using ShoppingDALLibrary;

namespace ShoppingBLLibrary
{
    internal class CustomerBL
    {
        private CustomerRepository customerRepository;

        public CustomerBL()
        {
            customerRepository = new CustomerRepository();
        }

        public async Customer AddCustomer(string name, string email)
        {
            // You can add additional validation logic here if needed
            Customer newCustomer = new Customer { Id = GenerateCustomerId(), Name = name, Email = email };
            customerRepository.Add(newCustomer);
            return newCustomer;
        }

        public async Customer GetCustomerById(int id)
        {
            return customerRepository.GetByKey(id);
        }

        public async Customer UpdateCustomer(int id, string name, string email)
        {
            // You can add additional validation logic here if needed
            Customer updatedCustomer = new Customer { Id = id, Name = name, Email = email };
            return customerRepository.Update(updatedCustomer);
        }

        public async bool DeleteCustomer(int id)
        {
            Customer deletedCustomer = customerRepository.Delete(id);
            return deletedCustomer != null;
        }

        private async int GenerateCustomerId()
        {
            Random random = new Random();
            return random.Next(1000, 9999);
        }
    }
}
