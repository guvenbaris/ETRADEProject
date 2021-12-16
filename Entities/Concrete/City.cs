using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;
using Core.Concrete;

namespace Entities.Concrete
{
    [Table(TableName = "Cities",IdentityColum = "CityID",PrimaryColumn = "CityID")]
   public  class City:IEntity
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
    }
}
