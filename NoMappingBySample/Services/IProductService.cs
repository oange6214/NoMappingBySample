using NoMappingBySample.Models;
using System.Collections.Generic;

namespace NoMappingBySample.Services;

public interface IProductService
{
    List<Product> GetProducts();
    Product GetProductById(int productId);
}
