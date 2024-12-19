using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SegundoProyectoAvanzada.Forms;
using SegundoProyectoAvanzada.Infrastructure.Data;
using SegundoProyectoAvanzada.Infrastructure.Data.Repository;
using SegundoProyectoAvanzada.Services;

namespace SegundoProyectoAvanzada
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();


            var services = new ServiceCollection();

            services.AddSingleton(configuration);

            services.AddTransient<IProductsRepository, ProductsRepository>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IEmployeesRepository, EmployeesRepository>();
            services.AddScoped<IShippersRepository, ShippersRepository>();
            services.AddTransient<ICategoriesRepository, CategoriesRepository>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<IOrdersRepository, OrdersRepository>();
            services.AddTransient<ISuppliersServices, SuppliersServices>();
            services.AddTransient<IProductsServices, ProductsServices>();
            services.AddTransient<ICategoriesServices, CategoriesServices>();
            services.AddTransient<IOrdersServices,OrdersServices>();

            services.AddDbContext<NorthwindDbContexts>(options =>
    
            options.UseSqlServer(configuration.GetConnectionString("NorthwindConnection")));


            services.AddTransient<ProductsForm>();
            services.AddTransient<OrdersForm>();
            services.AddTransient<CategoriesForm>();
            services.AddTransient<SuplidorForm>();
            services.AddTransient<Crear_Categories>();
            services.AddTransient<Crear_Products>();
            services.AddTransient<Crear_Suppliers>();
            services.AddTransient<Crear_Ordenes>();
            services.AddTransient<MenuInicio>();



            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            var provider = services.BuildServiceProvider();

            var ProductsForm = provider.GetService<MenuInicio>();


            Application.Run(ProductsForm);

          
        }
    }
}