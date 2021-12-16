using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;
using Core.Concrete;

namespace Entities.Concrete
{
    [Table(TableName = "Sellers", IdentityColum = "SellerID", PrimaryColumn = "SellerID")]
    public class Seller : IEntity
    {
        public int SellerID { get; set; }
        public int ProductID { get; set; }
        public string SellerName { get; set; }
        public string SellerSurname { get; set; }
        public string SellerMail { get; set; }
        public string SellerGsm { get; set; }
        public decimal SellerInCome { get; set; }
        
    }
}
