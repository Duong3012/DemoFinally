using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NWEB.Practice.T01.Web.Areas.Admin.ViewModel
{
    public class CategoryFlowerViewModel
    {
        public string FlowerName { get; set; }
        public int CategoryId { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "“You must input Sale Off(percent).")]
        public decimal SaleOff { get; set; }
    }
}