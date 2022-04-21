﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiCoreApp.Core.IntRepository;
using MultiCoreApp.Core.IntService;
using MultiCoreApp.Core.IntUnitOfWork;
using MultiCoreApp.Core.Models;

namespace MultiCoreApp.Service.Services
{
    public class ProductService:Service<Product>,IProductService
    {
        public ProductService(IUnitOfWork unit, IRepository<Product> repo) : base(unit, repo)
        {
        }

        public async Task<Product> GetProductsByCategory(Guid proId)
        {
            return await _unit.Product.GetProductWithCategoryAsync(proId);
        }

        public async Task<IEnumerable<Product>> GetAllWithCategoryAsync()
        {
            return await _unit.Product.GetAllWithCategoryAsync();
        }
    }
}
