using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;

namespace Entities.DTOs
{
   public class OrdersCityDetailDto :IDto
    {
        public string CityName { get; set; }
        public double Total { get; set; }

    }
}
