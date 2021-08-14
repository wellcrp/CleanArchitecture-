using MediatR;
using Product.Application.ViewModel.Product;

namespace Product.Application.Query.CommandQuery.Product.GetById
{
    public class GetByIdProductQueryCommand : IRequest<ProductDetaisViewModel>
    {
        public GetByIdProductQueryCommand(int id)
        {
            ProductId = id;
        }

        public int ProductId { get; private set; }
    }
}
