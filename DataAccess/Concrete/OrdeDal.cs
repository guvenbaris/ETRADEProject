using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Concrete;
using Core.Helper;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete
{
   public class OrdeDal : OrmRepositoryBase<Order>,IOrderDal
    {
        public List<OrdersCityDetailDto> SortTotalSalesByCity()
        {
            string query =
                "Select TOP 10 City.CityName,SUM(OD.Quantity * OD.UnitPrice) AS Total " +
                "From Orders as O join OrderDetails as OD on O.OrderID = OD.OrderID " +
                "join Customers as C on O.CustomerID = C.CustomerID " +
                "join Addresses as A on C.AddessID = A.AddressID " +
                "join Cities as City on A.CityID = City.CityName Group By City.CityName;";


            DataListHelper<OrdersCityDetailDto> orderCityDataListHelper = new DataListHelper<OrdersCityDetailDto>();
            return orderCityDataListHelper.GetAllDto(query);
        }
    }
}
