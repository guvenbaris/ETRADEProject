using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;
using Core.Concrete;

namespace Entities.Concrete
{
    [Table(TableName = "Customers", IdentityColum = "CustomerID", PrimaryColumn = "CustomerID")]
    public class Customer : IEntity
    {
        public int CustomerID { get; set; }
        public int AddressID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerMail  { get; set; }
        public string CustomerPassword { get; set; }
        public decimal CustomerWallet { get; set; }
        public int RatingID { get; set; }
        
    }
}
