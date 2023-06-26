using Microsoft.Extensions.DependencyInjection;
using NoMappingBySample.DALs;
using NoMappingBySample.DALs.Interfaces;
using NoMappingBySample.Services;
using NoMappingBySample.ViewModels;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace NoMappingBySample;


public partial class App : Application
{
    private readonly IServiceProvider _serviceProvider;

    public App()
    {

        IServiceCollection serviceCollection = new ServiceCollection();

        serviceCollection.AddSingleton<IDbConnection>(provider =>
        {
            string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SampleDb;Integrated Security=True;Connect Timeout=30;";

            IDbConnection connection = new SqlConnection(connString);
            return connection;
        });

        serviceCollection.AddScoped<IProductRepository, ProductRepository>();

        serviceCollection.AddScoped<IProductService, ProductService>();

        serviceCollection.AddScoped<ProductViewModel>();

        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        MainWindow mainWindow = new();
        mainWindow.DataContext = _serviceProvider.GetRequiredService<ProductViewModel>();
        mainWindow.Show();
    }
}
