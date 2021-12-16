using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;
using Core.Concrete;

namespace Entities.Concrete
{
    [Table(TableName = "Addresses", IdentityColum = "AddressID", PrimaryColumn = "AddressID")]
    public class Address : IEntity
    {
        public int AddressesID { get; set; }
        public int RegionsID { get; set; }
        public int CityID { get; set; }
        public int DistinctID { get; set; }
        public int BuildingNumber { get; set; }
    }
}
