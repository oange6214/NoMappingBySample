using NoMappingBySample.Models;
using NoMappingBySample.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace NoMappingBySample.ViewModels;

public class ProductViewModel : INotifyPropertyChanged
{
    private readonly IProductService _productService;
    private Product _selectedProduct = null!;

    public ObservableCollection<Product> Products { get; }

    public Product SelectedProduct
    {
        get { return _selectedProduct; }
        set
        {
            _selectedProduct = value;
            OnPropertyChanged(nameof(SelectedProduct));
        }
    }

    public ProductViewModel(IProductService productService)
    {
        _productService = productService;
        Products = new ObservableCollection<Product>();
        LoadProducts();
    }

    public void LoadProducts()
    {
        List<Product> products = _productService.GetProducts();
        foreach (Product product in products)
        {
            Products.Add(product);
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
