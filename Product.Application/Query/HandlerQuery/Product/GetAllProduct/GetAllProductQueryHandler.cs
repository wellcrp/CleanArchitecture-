using MediatR;
using Product.Application.Query.CommandQuery.Product.GetAllProduct;
using Product.Application.ViewModel.Product;
using Product.Core.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Application.Query.HandlerQuery.Product.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryCommand, List<ProductViewModel>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductViewModel>> Handle(GetAllProductQueryCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAllAsync();

            var productResult = product.Select(p => new ProductViewModel(p.ProductId, p.ProductName, p.ProductDescription, p.CreateAt)).ToList();

            return productResult;
        }
    }
}
