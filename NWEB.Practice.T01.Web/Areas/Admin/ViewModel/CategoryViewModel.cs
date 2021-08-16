using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NWEB.Practice.T01.Core.Models;

namespace NWEB.Practice.T01.Web.Areas.Admin.ViewModel
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100,ErrorMessage = "Category is required 100 character")]
        public string CategoryName { get; set; }
        [DefaultValue(1)]
        public int Order { get; set; }
        public string Notes { get; set; }
        public ICollection<FlowerViewModel> FlowerViewModels { get; set; }
    }
}
