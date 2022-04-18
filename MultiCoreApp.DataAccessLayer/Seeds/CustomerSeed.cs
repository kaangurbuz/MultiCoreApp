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
    public class CustomerSeed:IEntityTypeConfiguration<Customer>
    {
        
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Kaan Gurbuz",
                    Address = "Bayrampasa",
                    Phone = "05555555555",
                    Email = "kaang@gmail.com",
                    City = "Istanbul"

                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Lidia Mazur",
                    Address = "Rzeszow",
                    Phone = "05552255555",
                    Email = "lid@gmail.com",
                    City = "Krakow"
                }
            );
        }
    }
}
