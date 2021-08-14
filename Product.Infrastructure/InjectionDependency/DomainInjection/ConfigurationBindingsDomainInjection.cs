using Product.Core.Repository;
using Product.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Product.Infrastructure.Context;
using Product.Application.Command.Product.Create;
using MediatR;

namespace Product.Infrastructure.InjectionDependency.DomainInjection
{
    public class ConfigurationBindingsDomainInjection
    {
        public static void RegisterBindings(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddDbContext<ProductDbContext>(opt => opt.UseInMemoryDatabase("Database"));
            services.AddMediatR(typeof(CreateProductCommand));
        }
    }
}
