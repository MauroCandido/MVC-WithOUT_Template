using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMCVWithoutEF.Models
{
    public class ProductModel
    {
        public int     ProductId { get; set; }

        [DisplayName("Product Name")]
        [Required(ErrorMessage = "Product name is Required .... :")]
        [MaxLength(10, ErrorMessage = "Name cannot be greater than 50")]
        public string  ProductName { get; set; }

        public decimal Price { get; set; }
        public int     Count { get; set; }
    }
}