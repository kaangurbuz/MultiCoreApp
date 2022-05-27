using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiCoreApp.Core.Models;

namespace MultiCoreApp.DataAccessLayer.Seeds
{
    public class ProductSeed:IEntityTypeConfiguration<Product>
    {
        private readonly Guid[] _guids;

        public ProductSeed(Guid[] guids)
        {
            _guids = guids;
        }
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Dolma Kalem",
                    Price = 122.53m,
                    Stock = 100,
                    CategoryId = _guids[0]
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Tukenmez Kalem",
                    Price = 18.06m,
                    Stock = 100,
                    CategoryId = _guids[0]
                },
            new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Kursun Kalem",
                    Price = 62.19m,
                    Stock = 100,
                    CategoryId = _guids[0]
                },/////////
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Cizgili Defter",
                    Price = 22.53m,
                    Stock = 100,
                    CategoryId = _guids[1]
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Kareli Defter",
                    Price = 28.06m,
                    Stock = 100,
                    CategoryId = _guids[1]
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Dumduz Defter",
                    Price = 12.19m,
                    CategoryId = _guids[1]
                }

            );
        }
    }
}
