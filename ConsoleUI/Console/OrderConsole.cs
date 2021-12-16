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
    public class OrderConsole 
    {
        public void GetAll()
        {
            OrderManager orderManager =
                new OrderManager(new OrdeDal(), new OrderDetailDal(), new CustomerDal(), new SellerDal());

            foreach (var order in orderManager.GetAll())
            {
                string json = JsonConvert.SerializeObject(order, Formatting.Indented);
                System.Console.WriteLine(json);
            }
        }
        public void Get(int id)
        {
            OrderManager orderManager =
                new OrderManager(new OrdeDal(), new OrderDetailDal(), new CustomerDal(), new SellerDal());

            string json = JsonConvert.SerializeObject(orderManager.Get(id));
            System.Console.WriteLine(json);
        }

        public void Add(Order order)
        {
            OrderManager orderManager =
                new OrderManager(new OrdeDal(), new OrderDetailDal(), new CustomerDal(), new SellerDal());
            orderManager.Add(order);
            string json = JsonConvert.SerializeObject(orderManager.Get(order.OrderID));
            System.Console.WriteLine("Eklenen Sipariş Bilgileri");
            System.Console.WriteLine(json);
        }

        public static void Update(Order order)
        {
            OrderManager orderManager =
                new OrderManager(new OrdeDal(), new OrderDetailDal(), new CustomerDal(), new SellerDal());
            orderManager.Update(order);
            string json = JsonConvert.SerializeObject(orderManager.Get(order.OrderID));
            System.Console.WriteLine("Güncellenen Sipariş Bilgileri");
            System.Console.WriteLine(json);
        }

        public static void Delete(Order order)
        {
            OrderManager orderManager =
                new OrderManager(new OrdeDal(), new OrderDetailDal(), new CustomerDal(), new SellerDal());
            string json = JsonConvert.SerializeObject(orderManager.Get(order.OrderID));
            System.Console.WriteLine("Silinen Sipariş Bilgileri");
            System.Console.WriteLine(json);
            orderManager.Delete(order);
        }

    }
}
