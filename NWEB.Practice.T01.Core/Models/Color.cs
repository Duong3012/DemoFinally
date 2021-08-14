using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB.Practice.T01.Core.Models
{
   public class Color
   {
        public int Id  { get; set; }
        public string ColorName { get; set; }
        public virtual IList<Flower> Flowers { get; set; }
    }
}
