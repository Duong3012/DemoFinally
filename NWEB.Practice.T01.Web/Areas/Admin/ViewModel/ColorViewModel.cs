using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NWEB.Practice.T01.Core.Models;

namespace NWEB.Practice.T01.Web.Areas.Admin.ViewModel
{
   public class ColorViewModel
   {
       public int Id  { get; set; }
        public string ColorName { get; set; }
        public virtual IList<FlowerViewModel> FlowersFlowerViewModels { get; set; }
    }
}
