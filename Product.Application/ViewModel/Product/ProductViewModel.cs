using System;

namespace Product.Application.ViewModel.Product
{
    public class ProductViewModel
    {
        public ProductViewModel(int productId, string productName, string productDescription, DateTime createdAt)
        {
            ProductId = productId;
            ProductName = productName;
            ProductDescription = productDescription;
            CreatedAt = createdAt;
        }

        public int ProductId { get; private set; }
        public string ProductName { get; private set; }
        public string ProductDescription { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
