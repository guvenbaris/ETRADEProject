using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;

namespace Entities.DTOs
{
    public class ProductDetailsDto:IDto
    {
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int StockAmount { get; set; }
    }
}
