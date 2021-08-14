using Product.Core.Enums;
using System;

namespace Product.Core.Entities
{
    public class ProductModel
    {
        public ProductModel(){ }
        public ProductModel(string name, string description)
        {
            ProductName = name;
            ProductDescription = description;
            CreateAt = DateTime.Now;
            ProductStatus = ProductEnum.Active;
        }
        
        public int ProductId { get; private set; }
        public string ProductName { get; private set; }
        public string ProductDescription { get; private set; }
        public ProductEnum ProductStatus { get; private set; }
        public DateTime CreateAt { get; private set; }

        public void Deactive()
        {
            if(ProductStatus.Equals(ProductEnum.Active))  ProductStatus = ProductEnum.Deactive;
        }

        public void Update(string name, string description)
        {
            ProductName = name;
            ProductDescription = description;
        }
    }
}
