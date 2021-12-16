using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;
using Core.Concrete;

namespace Entities.Concrete
{
    [Table(TableName = "Products",IdentityColum = "ProductID",PrimaryColumn = "ProductID")]
    public class Product : IEntity
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public int BrandID { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockAmount { get; set; }
        public bool PromotionalProducts { get; set; }
        public DateTime ProductAddedDate { get; set; }
        public int RatingID { get; set; }
    }
}
