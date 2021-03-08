using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _categoryIds;
        public ProductSeed(int[] categoryIds)
        {
            _categoryIds = categoryIds;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Pilot Kalem", Price = 12.50m, Stock = 100, CategoryId = _categoryIds[0] },
                new Product { Id = 2, Name = "Kursun Kalem", Price = 3.50m, Stock = 500, CategoryId = _categoryIds[0] },
                new Product { Id = 3, Name = "Tükenmez Kalem", Price = 5.50m, Stock = 400, CategoryId = _categoryIds[0] },
                new Product { Id = 4, Name = "Küçük Boy Defter", Price = 8.50m, Stock = 50, CategoryId = _categoryIds[1] },
                new Product { Id = 5, Name = "Orta Boy Defter", Price = 10.50m, Stock = 40, CategoryId = _categoryIds[1] },
                new Product { Id = 6, Name = "Büyük Boy Defter", Price = 12.50m, Stock = 30, CategoryId = _categoryIds[1] }
                );
        }
    }
}
