using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;

namespace ShoppingDALLibrary
{
    public class CustomerRepository : AbstractRepository<int, Customer>
    {
        private List<Customer> items = new List<Customer>();

        public override Customer Delete(int key)
        {
            Customer customerToDelete = items.Find(customer => customer.Id == key);

            if (customerToDelete != null)
            {
                items.Remove(customerToDelete);
                return customerToDelete;
            }
            else
            {
                return null;
            }
        }


        public override Customer GetByKey(int key)
        {
            return items.Find(customer => customer.Id == key);
        }

        public override Customer Update(Customer item)
        {
            try
            {
                Customer existingCustomer = GetByKey(item.Id);
                if (existingCustomer != null)
                {
                    existingCustomer.Name = item.Name;
                    existingCustomer.Email = item.Email;
                    return existingCustomer;
                }
                else
                {
                    throw new NoCustomerWithGivenIdException();
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it according to your application's requirements
                throw; // Re-throw the exception to propagate it up the call stack
            }
        }
    }

}
