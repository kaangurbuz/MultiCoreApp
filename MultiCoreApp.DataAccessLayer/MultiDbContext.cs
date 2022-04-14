﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MultiCoreApp.Core.Models;

namespace MultiCoreApp.DataAccessLayer
{
    public class MultiDbContext : DbContext
    {
        public MultiDbContext(DbContextOptions<MultiDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
