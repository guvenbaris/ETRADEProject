using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstract
{
   public  interface IOrmRepository <T> where T : class, new()
    {
        List<T> GetAll();
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        T Get(int id);
    }

}
