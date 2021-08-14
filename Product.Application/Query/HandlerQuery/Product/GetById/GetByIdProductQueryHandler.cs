using MediatR;
using Product.Application.Query.CommandQuery.Product.GetById;
using Product.Application.ViewModel.Product;
using Product.Core.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Application.Query.HandlerQuery.Product.GetById
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryCommand, ProductDetaisViewModel>
    {
        private readonly IProductRepository _product;

        public GetByIdProductQueryHandler(IProductRepository product)
        {
            _product = product;
        }

        public async Task<ProductDetaisViewModel> Handle(GetByIdProductQueryCommand request, CancellationToken cancellationToken)
        {
            var prodResult = await _product.GetByIdAsync(request.ProductId);

            if (prodResult == null) return null;

            var projectResult = new ProductDetaisViewModel(prodResult.ProductId, prodResult.ProductName, prodResult.ProductDescription, prodResult.CreateAt);

            return projectResult;
        }
    }
}
