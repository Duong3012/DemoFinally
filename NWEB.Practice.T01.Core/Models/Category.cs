using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB.Practice.T01.Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100,ErrorMessage = "Category is required 100 character")]
        public string CategoryName { get; set; }
        [DefaultValue(1)]
        public int Order { get; set; }
        public string Notes { get; set; }
        public ICollection<Flower> Flowers { get; set; }
    }
}
