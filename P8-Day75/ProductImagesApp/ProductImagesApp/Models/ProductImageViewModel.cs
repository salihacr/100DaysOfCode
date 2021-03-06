using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductImagesApp.Models
{
    public class ProductImageViewModel
    {
        public Product Product { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
