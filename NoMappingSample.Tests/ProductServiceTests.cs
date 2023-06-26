//using NoMappingBySample.DALs.Interfaces;

using Moq;
using NoMappingBySample.DALs;
using NoMappingBySample.DALs.Interfaces;
using NoMappingBySample.Models;
using NoMappingBySample.Services;

namespace NoMappingSample.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public void GetProducts_ReturnsProductsFromRepository()
        {
            // 建立模擬的 Repository
            var repositoryMock = new Mock<IProductRepository>();


            // 預期的回傳結果
            var expectedProducts = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 10 },
                new Product { Id = 2, Name = "Product 2", Price = 20 }
            };


            // 設定模擬 Repository 的行為
            repositoryMock
                .Setup(repo => repo.GetProducts())
                .Returns(expectedProducts);


            // 建立被測試的 ProductService，並傳入模擬的 Repository
            var productService = new ProductService(repositoryMock.Object);


            // 執行被測試的方法
            var actualProducts = productService.GetProducts();


            // 斷言結果是否符合預期
            Assert.Equal(expectedProducts, actualProducts);
        }

        [Fact]
        public void GetProductById_ReturnsProductFromRepository()
        {
            var repositoryMock = new Mock<IProductRepository>();

            var expectedProducts = new Product { Id = 2, Name = "Product 1", Price = 10 };

            repositoryMock
                .Setup(repo => repo.GetProductById(1))
                .Returns(expectedProducts);

            var productService = new ProductService(repositoryMock.Object);

            var actualProduct = productService.GetProductById(1);

            Assert.Equal(expectedProducts, actualProduct);
        }
    }
}