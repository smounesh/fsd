using NUnit.Framework;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;

namespace Tests
{
    public class CustomerRepositoryTests
    {
        private CustomerRepository customerRepository;
        private Customer sampleCustomer;

        [SetUp]
        public void Setup()
        {
            customerRepository = new CustomerRepository();
            sampleCustomer = new Customer { Id = 1, Name = "John Doe", Email = "john@example.com" };
            customerRepository.Add(sampleCustomer);
        }

        [Test]
        public void GetByKey_InvalidId_ReturnsNull()
        {
            Customer retrievedCustomer = customerRepository.GetByKey(2);
            Assert.IsNull(retrievedCustomer);
        }

        [Test]
        public void Delete_NonexistentCustomer_ReturnsNull()
        {
            Customer deletedCustomer = customerRepository.Delete(2);
            Assert.IsNull(deletedCustomer);
        }
    }
}
