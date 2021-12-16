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
    public class RegionManager :IRegionService
    {
        private IRegionDal _regionDal;

        public RegionManager(IRegionDal regionDal)
        {
            _regionDal = regionDal;
        }
        public List<Region> GetAll()
        {
            return _regionDal.GetAll();
        }

        public Region Get(int id)
        {
            return _regionDal.Get(id);
        }

        public void Add(Region entity)
        {
            if (_regionDal.Add(entity))
            {
                Console.WriteLine("Region added");
            }
            else
            {
                Console.WriteLine("Region eklenemedi");
            }
           
        }

        public void Update(Region entity)
        {
            if (_regionDal.Update(entity))
            {
                Console.WriteLine("Region updated");
            }
            else
            {
                Console.WriteLine("Region güncellenemedi");
            }
           
        }

        public void Delete(Region entity)
        {
            if (_regionDal.Delete(entity))
            {
                Console.WriteLine("Region deleted");
            }
            else
            {
                Console.WriteLine("Region silinemedi");

            }
           
        }
    }
}
