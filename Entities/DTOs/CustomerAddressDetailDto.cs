using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;

namespace Entities.DTOs
{
    public class CustomerAddressDetailDto : IDto
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public int BuildingNumber { get; set; }

    }
}
