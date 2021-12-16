using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class SellerManager : ISellerService
    {
        private ISellerDal _sellerDal;

        public SellerManager(ISellerDal sellerDal)
        {
            _sellerDal = sellerDal;
        }

        public List<Seller> GetAll()
        {
            return _sellerDal.GetAll();
        }

        public Seller Get(int id)
        {
            return _sellerDal.Get(id);
        }

        public void Add(Seller entity)
        {
            if (_sellerDal.Add(entity))
            {
                Console.WriteLine("Seller added");
            }
            else
            {
                Console.WriteLine("Seller eklenemedi");
            }
           
        }

        public void Update(Seller entity)
        {
            if (_sellerDal.Update(entity))
            {
                Console.WriteLine("Seller updated");
            }
            else
            {
                Console.WriteLine("Seller güncellenemedi");
            }
          
        }

        public void Delete(Seller entity)
        {
            if (_sellerDal.Delete(entity))
            {
                Console.WriteLine("Seller deleted");
            }
            else
            {
                Console.WriteLine("Seller silinemedi");
            }
            
        }
    }
}
