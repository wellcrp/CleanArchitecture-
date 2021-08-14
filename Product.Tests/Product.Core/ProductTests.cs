using MediatR;
using Moq;
using Product.Application.Handler.Product.Create;
using Product.Application.Query.CommandQuery.Product.GetAllProduct;
using Product.Application.Query.HandlerQuery.Product.GetAllProduct;
using Product.Core.Entities;
using Product.Core.Repository;
using System.Linq;
using System.Threading;
using Xunit;

namespace Product.Tests.Product.Core
{
    [Collection(nameof(ProductCollection))]
    public class ProductTests
    {
        private readonly ProductTestsFixture _productFixture;
        public ProductTests(ProductTestsFixture productFixture)
        {
            _productFixture = productFixture;
        }

        [Fact(DisplayName = "Novo Produto Válido")]
        [Trait("Produto", "Produto Trait Cadastro")]
        public void Product_Created_ReturnTrueAnyProduct()
        {
            //Arrange 
            var productResult = _productFixture.ObterProdutos(50);

            //ACT //Assert
            Assert.True(productResult.Any());
            Assert.NotNull(productResult);
        }

        [Fact(DisplayName = "Novo Produto Válido")]
        [Trait("Produto", "Produto Service Mock Tests Inserir e retornar ID Produto")]
        public async void ProductRepository_CreateProduct_ShouldBeInsertProductAndReturnProductId()
        {
            //ARRANGE
            var productRepo = new Mock<IProductRepository>();
            var productObjetCreate = _productFixture.GenerateObjectInsertProductCommand();
            var createProductHandler = new CreateProductHandler(productRepo.Object);

            //ACT
            var productId = await createProductHandler.Handle(productObjetCreate, new CancellationToken());

            //Assert
            Assert.True(productId >= 0);
            productRepo.Verify(mm => mm.CreateAsync(It.IsAny<ProductModel>()), Times.Once());
        }


        [Fact(DisplayName = "Listar Todos Produto")]
        [Trait("Produto", "Produto Service Mock Tests listar todos os Produtos")]
        public async void ProductRepository_GetAllProduct_ShouldBeListAllProduct()
        {
            //ARRANGE
            var productAll = _productFixture.ObterProdutos(10);
            var productRepoMock = new Mock<IProductRepository>();
            
            productRepoMock.Setup(x => x.GetAllAsync().Result).Returns(productAll);

            var getAllProductCommand = new GetAllProductQueryCommand("");
            var getAllProductHandler = new GetAllProductQueryHandler(productRepoMock.Object);

            //ACT
            var productAllList = await getAllProductHandler.Handle(getAllProductCommand, new CancellationToken());

            //Assert
            Assert.NotNull(productAllList);
            Assert.NotEmpty(productAllList);
            Assert.Equal(productAll.Count(), productAllList.Count());
                        
            productRepoMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);

        }
    }
}
