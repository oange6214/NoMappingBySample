using NoMappingBySample.DALs.Entities;
using NoMappingBySample.Models;
using System.Collections.Generic;
using Dapper;
using System.Data;
using NoMappingBySample.DALs.Interfaces;
using System.Threading.Tasks;

namespace NoMappingBySample.DALs;

public class ProductRepository : IProductRepository
{
    private readonly IDbConnection _connection;

    public ProductRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public Product GetProductById(int productId)
    {
        // 參數
        string query = "SELECT * FROM Products WHERE id = @ProductId";
        var parameters = new { ProductId = productId };

        // 操作
        ProductData productData = _connection.QueryFirstOrDefault<ProductData>(query, parameters);

        // 轉換後返回
        return MapProductDataToProduct(productData);
    }

    public async Task<Product> GetProductByIdAsync(int productId)
    {
        string query = "SELECT * FROM Products WHERE id = @ProductId";
        var parameters = new { ProductId = productId };

        ProductData productData = await _connection.QueryFirstOrDefaultAsync<ProductData>(query, parameters);

        return MapProductDataToProduct(productData);
    }

    public List<Product> GetProducts()
    {
        // 參數
        string query = "SELECT * FROM Products";

        // 操作
        List<ProductData> productDataList = _connection.Query<ProductData>(query).AsList();

        // 轉換後返回
        List<Product> productList = new();

        foreach (ProductData productData in productDataList)
        {
            Product product = MapProductDataToProduct(productData);
            productList.Add(product);
        }

        return productList;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        string query = "SELECT * FROM Products";

        List<ProductData> productDataList = (await _connection.QueryAsync<ProductData>(query)).AsList();

        List<Product> productList = new List<Product>();

        foreach (ProductData productData in productDataList)
        {
            Product product = MapProductDataToProduct(productData);
            productList.Add(product);
        }

        return productList;
    }

    private Product MapProductDataToProduct(ProductData productData)
    {
        if (productData == null)
            return null!;

        Product product = new()
        {
            Id = productData.Id,
            Name = productData.Name,
            Price = productData.Price,
            // 其他屬性的映射...
        };

        return product;
    }
}