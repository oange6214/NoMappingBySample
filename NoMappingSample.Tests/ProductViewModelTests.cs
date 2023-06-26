using Moq;
using NoMappingBySample.Models;
using NoMappingBySample.Services;
using NoMappingBySample.ViewModels;

namespace NoMappingSample.Tests;

public class ProductViewModelTests
{
    [Fact]
    public void LoadProducts_AddsProductsToCollection()
    {
        var productServiceMock = new Mock<IProductService>();

        var expectedProducts = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 10 },
                new Product { Id = 2, Name = "Product 2", Price = 20 }
            };

        productServiceMock
            .Setup(p => p.GetProducts())
            .Returns(expectedProducts);


        var viewModel = new ProductViewModel(productServiceMock.Object);


        Assert.Equal(expectedProducts, viewModel.Products);
    }

    [Fact]
    public void SelectedProduct_PropertyChangedEventRaised()
    {
        // 建立模擬的 ProductService
        var productServiceMock = new Mock<IProductService>();

        var expectedProducts = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 10 },
                new Product { Id = 2, Name = "Product 2", Price = 20 }
            };

        productServiceMock
            .Setup(p => p.GetProducts())
            .Returns(expectedProducts);


        // 建立 ProductViewModel，並傳入模擬的 ProductService
        var viewModel = new ProductViewModel(productServiceMock.Object);


        // 模擬 PropertyChanged 事件的處理程序
        var eventRaised = false;
        viewModel.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == nameof(viewModel.SelectedProduct))
            {
                eventRaised = true;
            }
        };


        // 更新 SelectedProduct 屬性
        viewModel.SelectedProduct = new Product { Id = 1, Name = "Product 1", Price = 10 };


        // 斷言事件是否被觸發
        Assert.True(eventRaised);
    }
}
