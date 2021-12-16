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
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private IRatingDal _ratingDal;

        public ProductManager(IProductDal productDal, IRatingDal ratingDal)
        {
            _productDal = productDal;
            _ratingDal = ratingDal;
        }
        public List<Product> GetAll()
        {
            CheckBlackFriday();
            return _productDal.GetAll();
        }

        public Product Get(int id)
        {
            return _productDal.Get(id);
        }

        public void Add(Product entity)
        {
            if (StockAmountControl(entity.StockAmount) && CheckCategoryCount(entity) && CheckUnitPriceAndStockAmount(entity.UnitPrice, entity.StockAmount))
            {
                CheckRatingRate(entity.RatingID); 
                if (_productDal.Add(entity))
                {
                    Console.WriteLine("Product added");
                }
                else
                {
                    Console.WriteLine("Product eklenemedi");
                }
            }
        }
        public void Update(Product entity)
        {
            if (StockAmountControl(entity.StockAmount) && CheckCategoryCount(entity) && CheckUnitPriceAndStockAmount(entity.UnitPrice, entity.StockAmount))
            {
                CheckRatingRate(entity.RatingID);
                if (_productDal.Update(entity))
                {
                    Console.WriteLine("Product updated");
                }
                else
                {
                    Console.WriteLine("Product güncellenemedi");
                }
            }
        }

        public void Delete(Product entity)
        {
            if (_productDal.Delete(entity))
            {
                Console.WriteLine("Product deleted");
            }
            else
            {
                Console.WriteLine("Product silinemedi");
            }

        }

        public List<ProductDetailsDto> GetProductDetailsDto()
        {
            return _productDal.GetProductDetailsDto();
        }

        private bool StockAmountControl(int stockAmount)
        {
            if (stockAmount <= 10)
            {
                Console.WriteLine("Stock miktarı 10 a eşit veya büyük olmak zorundadır.");
                return false;
            }

            return true;
        }

        private  bool CheckCategoryCount(Product entity)
        {
            int count = 0;

            foreach (var product in _productDal.GetAll())
            {
                if (product.CategoryID == entity.CategoryID)
                {
                    count++;
                }
            }
            if (count <= 100)
            {
                return true;
            }
            Console.WriteLine("Bir kategori de en fazla 100 ürün bulunabilir.");
            return false;
        }

        private bool CheckUnitPriceAndStockAmount(decimal unitPrice,int stockAmount)
        {
            if (unitPrice <= 50 && stockAmount <= 15)
            {
                Console.WriteLine("Ürün fiyatı 50 TL den az ise stock miktarı 15 den fazla olmak zorundadır.");
                return false;
            }
            return true;
        }

        private void CheckBlackFriday()
        {
            if (DateTime.Now.Month == 11)
            {
                foreach (var product in _productDal.GetAll())
                {
                    if (product.PromotionalProducts == true)
                    {
                        product.UnitPrice -=  product.UnitPrice * Convert.ToDecimal(0.3);
                        _productDal.Update(product);
                        Console.WriteLine("Efsane cuma indirimleri uygulandı.");
                    }
                }
            }
        }

        private void CheckRatingRate(int rateId)
        {
            if (_ratingDal.Get(rateId).Rate <= 1)
            {
                //mail attırabiliriz şimdilik böyle dursun
                Console.WriteLine("Satıcıya bilgi verildi.");
            }

           



            
        }

    }
}
