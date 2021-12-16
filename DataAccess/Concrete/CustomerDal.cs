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
   public class CustomerDal  : OrmRepositoryBase<Customer>, ICustomerDal
   {
       public List<CustomerRatingDto> GetCustomerRatingDto()
       {
           string query = "Select C.CustomerName,CA.CategoryName,P.ProductName,R.Comment,R.Rate from " +
                          "Customers as C join Ratings as R on R.RatingID = C.RatingID join Products as P on " +
                          "P.RatingID = R.RatingID join Categories as CA on P.CategoryID = CA.CategoryID";


           DataListHelper<CustomerRatingDto> custumerDataListHelper = new DataListHelper<CustomerRatingDto>();
           return custumerDataListHelper.GetAllDto(query);
           
        }

       public List<CustomerAddressDetailDto> GetCustomerOpenAddress()
       {
           string query =
               "Select C.CustomerName,C.CustomerSurname,R.RegionName,City.CityName,D.DistrictName,A.BuildingNumber " +
               "from Customers as C join Addresses as A on C.AddessID =A.AddressID " +
               "join Districts as D on A.DistrictID = D.DistrictID " +
               "join Cities as City on City.CityID = A.CityID " +
               "join Regions as R on R.RegionID = A.RegionsID;";

           DataListHelper<CustomerAddressDetailDto> custumerDataListHelper = new DataListHelper<CustomerAddressDetailDto>();
           return custumerDataListHelper.GetAllDto(query);
       }
   }
}
