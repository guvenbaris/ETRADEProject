using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;
using Core.Concrete;

namespace Entities.Concrete
{
    [Table(TableName = "Brands", IdentityColum = "BrandID", PrimaryColumn = "BrandID")]
    public class Brand:IEntity
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }

    }
}
