using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerService : IServiceRepository<Customer>
    {
        List<CustomerRatingDto> GetCustomerRatingDto();
        List<CustomerAddressDetailDto> GetCustomerOpenAddress();
    }
}
