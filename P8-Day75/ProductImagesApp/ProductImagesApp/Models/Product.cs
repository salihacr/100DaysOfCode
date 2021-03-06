using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductImagesApp.Models
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public string MainImage { get; set; }
        public IEnumerable<ProductImage> ProductImages { get; set; }
    }
}
