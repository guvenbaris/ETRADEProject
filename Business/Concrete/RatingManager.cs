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
   public class RatingManager : IRatingService
   {
       private IRatingDal _ratingDal;

       public RatingManager(IRatingDal ratingDal)
       {
           _ratingDal = ratingDal;
       }
       public List<Rating> GetAll()
       {
           return _ratingDal.GetAll();
       }

        public Rating Get(int id)
        {
            return _ratingDal.Get(id);
        }

        public void Add(Rating entity)
        {
            if (_ratingDal.Add(entity))
            {
                Console.WriteLine("Rating added");
            }
            else
            {
                Console.WriteLine("Rating eklenemedi");
            }
            
        }

        public void Update(Rating entity)
        {
            if (_ratingDal.Update(entity))
            {
                Console.WriteLine("Rating updated");
            }
            else
            {
                Console.WriteLine("Rating güncellenemedi");
            }
            
        }

        public void Delete(Rating entity)
        {
            if (_ratingDal.Delete(entity))
            {
                Console.WriteLine("Rating deleted");
            }
            else
            {
                Console.WriteLine("Rating silinemedi");
            }

            
        }
    }
}
