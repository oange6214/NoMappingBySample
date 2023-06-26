using NoMappingBySample.DALs.Interfaces;
using NoMappingBySample.Models;
using System.Collections.Generic;

namespace NoMappingBySample.Services;

public class ProductService : IProductService
{
    private IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<Product> GetProducts()
    {
        return _productRepository.GetProducts();
    }

    public Product GetProductById(int productId)
    {
        return _productRepository.GetProductById(productId);
    }
}