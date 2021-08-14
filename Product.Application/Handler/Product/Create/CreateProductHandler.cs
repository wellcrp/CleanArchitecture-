using MediatR;
using Product.Application.Command.Product.Create;
using Product.Core.Repository;
using System.Threading;
using System.Threading.Tasks;
using Product.Core.Entities;

namespace Product.Application.Handler.Product.Create
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new ProductModel(request.ProductName, request.ProductDescription);

            await _productRepository.CreateAsync(product);

            return product.ProductId;
        }
    }
}
