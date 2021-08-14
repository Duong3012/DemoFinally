using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NWEB.Practice.T01.Web.Areas.Admin.ViewModel
{
    public class SaleOfViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public virtual CategoryViewModel Category { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Can not than 255 characters.")]
        public string FlowerName { get; set; }
        [Range(1, 100)]
        public int SaleOff { get; set; }
    }
}