using NoMappingBySample.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoMappingBySample.DALs.Interfaces;

public interface IProductRepository
{
    Task<Product> GetProductByIdAsync(int productId);
    Product GetProductById(int productId);
    Task<List<Product>> GetProductsAsync();
    List<Product> GetProducts();
}