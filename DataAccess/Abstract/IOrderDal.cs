using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
     public interface IOrderDal :IOrmRepository<Order>
     {
         List<OrdersCityDetailDto> SortTotalSalesByCity();
     }
}
