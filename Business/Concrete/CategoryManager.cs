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
    public class CategoryManager :ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public List<Category> GetAll()
        {
            return  _categoryDal .GetAll();
        }

        public Category Get(int id)
        {
            return _categoryDal.Get(id);
        }

        public void Add(Category entity)
        {
            if (_categoryDal.Add(entity))
            {
                Console.WriteLine("Category added");
            }
            else
            {
                Console.WriteLine("Category eklenemdi");
            }
     
        }

        public void Update(Category entity)
        {
            if (_categoryDal.Update(entity))
            {
                Console.WriteLine("Category updated");
            }
            else
            {
                Console.WriteLine("Category güncellenemedi");
            }
          
        }

        public void Delete(Category entity)
        {
            if (_categoryDal.Delete(entity))
            {
                Console.WriteLine("Category deleted");
            }
            else
            {
                Console.WriteLine("Category silinemedi");
            }
            
        }
    }
}
