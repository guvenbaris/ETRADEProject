using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using Newtonsoft.Json;

namespace ConsoleUI.Console
{
   public class CustomerConsole
    {
        public void GetAll()
        {
            CustomerManager customerManager = new CustomerManager(new CustomerDal());

            foreach (var customer in customerManager.GetAll())
            {
                string json = JsonConvert.SerializeObject(customer, Formatting.Indented);
                System.Console.WriteLine(json);
            }
        }
        public void Get(int id)
        {
            CustomerManager customerManager = new CustomerManager(new CustomerDal());

            string json = JsonConvert.SerializeObject(customerManager.Get(id));
            System.Console.WriteLine(json);
        }

        public void Add(Customer customer)
        {
            CustomerManager customerManager = new CustomerManager(new CustomerDal());

            customerManager.Add(customer);
            string json = JsonConvert.SerializeObject(customerManager.Get(customer.CustomerID));
            System.Console.WriteLine("Eklenen Sipariş Bilgileri");
            System.Console.WriteLine(json);
        }

        public static void Update(Customer customer)
        {
            CustomerManager customerManager = new CustomerManager(new CustomerDal());

            customerManager.Update(customer);
            string json = JsonConvert.SerializeObject(customerManager.Get(customer.CustomerID));
            System.Console.WriteLine("Güncellenen Sipariş Bilgileri");
            System.Console.WriteLine(json);
        }

        public static void Delete(Customer customer)
        {
            CustomerManager customerManager = new CustomerManager(new CustomerDal());

            customerManager.Add(customer);
            string json = JsonConvert.SerializeObject(customerManager.Get(customer.CustomerID));
            System.Console.WriteLine("Silinen Sipariş Bilgileri");
            System.Console.WriteLine(json);
            customerManager.Delete(customer);
        }
    }
}
