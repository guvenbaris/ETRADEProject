using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService : IServiceRepository<Product>
    {
        List<ProductDetailsDto> GetProductDetailsDto();
    }
}
