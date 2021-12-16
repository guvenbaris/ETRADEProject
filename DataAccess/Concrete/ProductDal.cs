using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.Concrete;
using Core.Helper;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete
{
    public class ProductDal : OrmRepositoryBase<Product>,IProductDal
    {
        public List<ProductDetailsDto> GetProductDetailsDto()
        {
            string query = "Select B.BrandName,C.CategoryName,P.ProductName,P.UnitPrice,P.StockAmount from Products as P join Categories as C on C.CategoryID = P.CategoryID join Brands as B on B.BrandID = P.BrandID;";


            DataListHelper<ProductDetailsDto> productDataListHelper = new DataListHelper<ProductDetailsDto>();
            return productDataListHelper.GetAllDto(query);

        }
    }
}
