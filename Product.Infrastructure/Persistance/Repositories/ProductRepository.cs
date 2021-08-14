using Microsoft.EntityFrameworkCore;
using Product.Core.Entities;
using Product.Core.Repository;
using Product.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _productContext;

        public ProductRepository(ProductDbContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            return await _productContext.Product.ToListAsync();
        }

        public async Task<ProductModel> GetByIdAsync(int id)
        {
            return await _productContext.Product.SingleOrDefaultAsync(x => x.ProductId.Equals(id));
        }

        public async Task CreateAsync(ProductModel product)
        {
            await _productContext.Product.AddAsync(product);
            await _productContext.SaveChangesAsync();
        }
    }
}
