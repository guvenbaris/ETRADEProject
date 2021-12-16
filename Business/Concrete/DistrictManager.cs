using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class DistrictManager : IDistrictService
    {
        private IDistrictDal _districtDal;

        public DistrictManager(IDistrictDal districtDal)
        {
            _districtDal = districtDal;
        }

        public List<District> GetAll()
        {
            return _districtDal.GetAll();
        }

        public District Get(int id)
        {
            return _districtDal.Get(id);
        }

        public void Add(District entity)
        {
            if (_districtDal.Add(entity))
            {
                Console.WriteLine("Disctrict added");
            }
            else
            {
                Console.WriteLine("Disctrict eklenemdi");
            }
            
        }

        public void Update(District entity)
        {
            if (_districtDal.Update(entity))
            {
                Console.WriteLine("District güncellendi");
            }
            else
            {
                Console.WriteLine("District güncellenemedi");
            }
           
        }

        public void Delete(District entity)
        {
            if (_districtDal.Delete(entity))
            {
                Console.WriteLine("District silindi");
            }
            else
            {
                Console.WriteLine("District silinemedi");
            }
            
        }
    }
}
