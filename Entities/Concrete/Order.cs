using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;
using Core.Concrete;

namespace Entities.Concrete
{
    [Table(TableName = "Orders", IdentityColum = "OrderID", PrimaryColumn = "OrderID")]

    public class Order : IEntity
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public int SellerID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public int Discount { get; set; }
    }
}
