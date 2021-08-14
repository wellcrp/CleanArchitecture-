using MediatR;

namespace Product.Application.Command.Product.Create
{
    public class CreateProductCommand : IRequest<int>
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
    }
}
