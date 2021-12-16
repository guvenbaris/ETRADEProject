using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();
            foreach (var customer in _customerDal.GetAll())
            {
                customer.CustomerPassword = "**********";
                customers.Add(customer);
            }
            return customers;
        }

        public Customer Get(int id)
        {
            Customer customer = _customerDal.Get(id);
            customer.CustomerPassword = "********";
            return customer;
        }

        public void Add(Customer entity)
        {
            if (_customerDal.Add(entity))
            {
                Console.WriteLine("Customer added");
            }
            else
            {
                Console.WriteLine("Customer eklenemdi");
            }

        }

        public void Update(Customer entity)
        {
            if (_customerDal.Update(entity))
            {
                Console.WriteLine("Customer updated");
            }
            else
            {
                Console.WriteLine("Customer silinemedi");
            }

        }

        public void Delete(Customer entity)
        {
            if (_customerDal.Delete(entity))
            {
                Console.WriteLine("Customer silindi");
            }
            else
            {
                Console.WriteLine("Customer silinemedi");
            }

        }

        public List<CustomerRatingDto> GetCustomerRatingDto()
        {
            return _customerDal.GetCustomerRatingDto();
        }

        public List<CustomerAddressDetailDto> GetCustomerOpenAddress()
        {
           return _customerDal.GetCustomerOpenAddress();
        }

    }
}
