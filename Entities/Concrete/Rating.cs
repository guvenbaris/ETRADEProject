using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;
using Core.Concrete;

namespace Entities.Concrete
{
    [Table(TableName = "Ratings", IdentityColum = "RatingID", PrimaryColumn = "RatingID")]
    public class Rating : IEntity
    {
        public int RatingID { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
        public DateTime RateDate { get; set; }
    }
}
