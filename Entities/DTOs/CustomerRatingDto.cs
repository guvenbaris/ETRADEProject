using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;

namespace Entities.DTOs
{
    public class CustomerRatingDto : IDto
    {
        public string CustomerName { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
    }
}
