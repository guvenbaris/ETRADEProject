using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;
using Core.Concrete;

namespace Entities.Concrete
{
    [Table(TableName = "Regions", IdentityColum = "RegionID", PrimaryColumn = "RegionID")]
    public class Region:IEntity
    {
        public int RegionID { get; set; }
        public string RegionName { get; set; }

    }
}
