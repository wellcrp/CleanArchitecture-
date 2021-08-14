using Product.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Core.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductModel>> GetAllAsync();
        Task<ProductModel> GetByIdAsync(int id);
        Task CreateAsync(ProductModel product);
    }
}
