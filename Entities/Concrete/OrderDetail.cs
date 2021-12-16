using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;
using Core.Concrete;

namespace Entities.Concrete
{
    [Table(TableName = "OrderDetails", IdentityColum = "ID", PrimaryColumn = "ID")]
    public class OrderDetail : IEntity
    {
        public int OrderID { get; set; }
        public int ProductID  { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
