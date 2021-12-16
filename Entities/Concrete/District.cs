using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;
using Core.Concrete;

namespace Entities.Concrete
{
    [Table(TableName = "Districts", IdentityColum = "DistrictID", PrimaryColumn = "DistrictID")]
    public class District : IEntity
    {
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }

    }
}
