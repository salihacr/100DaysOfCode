using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductImagesApp.Models
{
    public class ProductImage
    {
        public int ProductImageId { get; set; }
        public string ImagePath { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
