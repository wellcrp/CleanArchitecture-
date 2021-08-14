using Bogus;
using Product.Application.Command.Product.Create;
using Product.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Product.Tests.Product.Core
{
    [CollectionDefinition(nameof(ProductCollection))]
    public class ProductCollection : ICollectionFixture<ProductTestsFixture> { }
    public class ProductTestsFixture : IDisposable
    {
        public IEnumerable<ProductModel> ObterProdutos(int qtd)
        {
            var produtos = new List<ProductModel>();

            produtos.AddRange(GerarProdutos(qtd).ToList());

            return produtos;
        }

        public IEnumerable<ProductModel> GerarProdutos(int quantidade)
        {
            var product = new Faker<ProductModel>("pt_BR")
                .CustomInstantiator(f =>
                    new ProductModel(
                        f.Name.JobTitle(),
                        f.Name.JobDescriptor()
                    ));

            return product.Generate(quantidade);
        }

        public CreateProductCommand GenerateObjectInsertProductCommand()
        {
            // strictMode => geraração de valores necessarias para todas as propriedades do objeto
            var product = new Faker<CreateProductCommand>("pt_BR")
                    .StrictMode(true)
                    .RuleFor(p => p.ProductName, f => f.Company.CompanyName())
                    .RuleFor(p => p.ProductDescription, f => f.Company.CompanyName());

            return product;
        }

        public void Dispose() { }
    }
}
