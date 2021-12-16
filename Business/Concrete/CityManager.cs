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
   public class CityManager : ICityService
    {
        private ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }
        public List<City> GetAll()
        {
            return _cityDal.GetAll();
        }

        public City Get(int id)
        {
            return _cityDal.Get(id);
        }

        public void Add(City entity)
        {
            if (_cityDal.Add(entity))
            {
                Console.WriteLine("City added");
            }
            else
            {
                Console.WriteLine("City eklenemdi");
            }
            
        }

        public void Update(City entity)
        {
            if (_cityDal.Update(entity))
            {
                Console.WriteLine("City updated");
            }
            else
            {
                Console.WriteLine("City güncellenemedi");
            }
            
        }

        public void Delete(City entity)
        {
            if (_cityDal.Delete(entity))
            {
                Console.WriteLine("City deleted");
            }
            else
            {
                Console.WriteLine("City silinemedi");
            }
            
        }
    }
}
