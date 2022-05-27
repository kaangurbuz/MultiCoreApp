using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiCoreApp.Core.Models;

namespace MultiCoreApp.DataAccessLayer.Configurations
{
    public class CustomerConfiguration:IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.City).HasMaxLength(50);
            builder.Property(c => c.Phone).HasMaxLength(12);
            builder.Property(c => c.Email).HasMaxLength(100);
            builder.Property(c => c.Address).HasMaxLength(300);
            builder.ToTable("tblCustomers");
        }
    }
}
