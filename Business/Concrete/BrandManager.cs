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
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand Get(int id)
        {
            return _brandDal.Get(id);
        }

        public void Add(Brand entity)
        {
            if (_brandDal.Add(entity))
            {
                Console.WriteLine("Brand added");
            }
            else
            {
                Console.WriteLine("Brand eklenemedi");
            }
          
        }

        public void Update(Brand entity)
        {
            if (_brandDal.Update(entity))
            {
                Console.WriteLine("Brand updated");
            }
            else
            {
                Console.WriteLine("Brand güncellenemedi");
            }
           
        }

        public void Delete(Brand entity)
        {
            if (_brandDal.Delete(entity))
            {
                Console.WriteLine("Brand deleted");
            }
            else
            {
                Console.WriteLine("Brand silinemedi");
            }
            
        }
    }
}
