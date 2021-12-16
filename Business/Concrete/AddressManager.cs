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
    public class AddressManager : IAddressService
    {
        private IAddressDal _addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }
        public List<Address> GetAll()
        {

           return _addressDal.GetAll();
        }

        public Address Get(int id)
        {
            return _addressDal.Get(id);
        }

        public void Add(Address entity)
        {
            if (_addressDal.Add(entity))
            {
                Console.WriteLine("Address added");
            }
            else
            {
                Console.WriteLine("Address eklenemedi");
            }
        }

        public void Update(Address entity)
        {
            if (_addressDal.Update(entity))
            {
                Console.WriteLine("Address updated");
            }
            else
            {
                Console.WriteLine("Address güncellenemedi");
            }
        }

        public void Delete(Address entity)
        {
            if (_addressDal.Delete(entity))
            {
                Console.WriteLine("Address deleted");
            }
            else
            {
                Console.WriteLine("Address silinemedi");
            }
        
        }
    }
}
