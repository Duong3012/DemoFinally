using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NWEB.Practice.T01.Core.Models;

namespace NWEB.Practice.T01.Web.Areas.Admin.ViewModel
{
    public class FlowerViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public CategoryViewModel CategoryViewModel { get; set; }
        [Required]
        [StringLength(255,ErrorMessage = "Can not than 255 characters.")]
        public string FlowerName { get; set; }
        public string Description { get; set; }
        public int ColorId { get; set; }
        public ColorViewModel ColorViewModel{ get; set; }
        public string Image { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        [Required]
        public DateTime StoreDate { get; set; }
        [Required]
        public int StoreInventory { get; set; }
    }
}
