using Business.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Concrete;
using Entities.Concrete;
using Newtonsoft.Json;

namespace ConsoleUI.Console
{
    class ProductConsole 
    {
        public void GetAll()
        {
            ProductManager productManager =
                new ProductManager(new ProductDal(),new RatingDal());

            foreach (var product in productManager.GetAll())
            {
                string json = JsonConvert.SerializeObject(product, Formatting.Indented);
                System.Console.WriteLine(json);
            }
        }
        public void Get(int id)
        {
            ProductManager productManager =
                new ProductManager(new ProductDal(), new RatingDal());

            string json = JsonConvert.SerializeObject(productManager.Get(id));
            System.Console.WriteLine(json);
        }

        public void Add(Product product)
        {
            ProductManager productManager =
                new ProductManager(new ProductDal(), new RatingDal());

            productManager.Add(product);
            string json = JsonConvert.SerializeObject(productManager.Get(product.ProductID));
            System.Console.WriteLine("Eklenen Sipariş Bilgileri");
            System.Console.WriteLine(json);
        }

        public static void Update(Product product)
        {
            ProductManager productManager =
                new ProductManager(new ProductDal(), new RatingDal());

            productManager.Update(product);
            string json = JsonConvert.SerializeObject(productManager.Get(product.ProductID));
            System.Console.WriteLine("Güncellenen Sipariş Bilgileri");
            System.Console.WriteLine(json);
        }

        public static void Delete(Product product)
        {
            ProductManager productManager =
                new ProductManager(new ProductDal(), new RatingDal());
            string json = JsonConvert.SerializeObject(productManager.Get(product.ProductID));
            System.Console.WriteLine("Silinen Sipariş Bilgileri");
            System.Console.WriteLine(json);
            productManager.Delete(product);
        }

    }
}
