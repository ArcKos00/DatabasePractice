using DatabaseMigrations;
using DatabaseMigrations.Configs;
using DatabaseMigrations.Repositories;
using DatabaseMigrations.Repositories.Abstractions;
using DatabaseMigrations.Services;
using DatabaseMigrations.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("config.json")
    .Build();

var serviceCollection = new ServiceCollection();
ConfigurationService(serviceCollection, config);
var provider = serviceCollection.BuildServiceProvider();

var app = provider.GetService<Application>();
app!.Start();

void ConfigurationService(ServiceCollection collection, IConfiguration config)
{
    collection.AddOptions<LoggerOption>().Bind(config.GetSection("Logger"));

    var connectionString = config.GetConnectionString("DefaultConnection");
    serviceCollection.AddDbContextFactory<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
    serviceCollection.AddScoped<IDbContextWrapper<ApplicationDbContext>, DbContextWrapper<ApplicationDbContext>>();

    serviceCollection
        .AddLogging(configure => configure.AddConsole())
        .AddTransient<ICategoryRepository, CategoryRepository>()
        .AddTransient<ICustomerRepository, CustomerRepository>()
        .AddTransient<IOrderRepository, OrderRepository>()
        .AddTransient<IOrderDetailsRepository, OrderDetailsRepository>()
        .AddTransient<IPaymentRepository, PaymentRepository>()
        .AddTransient<IProductRepository, ProductRepository>()
        .AddTransient<IShipperRepository, ShipperRepository>()
        .AddTransient<ISupplierRepository, SupplierRepository>()
        .AddTransient<ICategoryService, CategoryService>()
        .AddTransient<ICustomerService, CustomerService>()
        .AddTransient<IOrderService, OrderService>()
        .AddTransient<IOrderDetailService, OrderDetailService>()
        .AddTransient<IPaymentService, PaymentService>()
        .AddTransient<IProductService, ProductService>()
        .AddTransient<IShipperService, ShippersService>()
        .AddTransient<ISupplierService, SupplierService>()
        .AddTransient<Application>();
}