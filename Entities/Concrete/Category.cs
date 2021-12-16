using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;
using Core.Concrete;

namespace Entities.Concrete
{
    [Table(TableName = "Categories", IdentityColum = "CategoryID", PrimaryColumn = "CategoryID")]
    public class Category : IEntity
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

    }
}
