using MediatR;
using Product.Application.ViewModel.Product;
using System.Collections.Generic;

namespace Product.Application.Query.CommandQuery.Product.GetAllProduct
{
    public class GetAllProductQueryCommand : IRequest<List<ProductViewModel>>
    {
        public GetAllProductQueryCommand(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
