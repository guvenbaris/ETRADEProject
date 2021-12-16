using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
   public interface IBrandDal : IOrmRepository<Brand>
    {

    }
}
