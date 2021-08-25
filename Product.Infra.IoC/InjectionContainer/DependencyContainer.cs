using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Command.Product.Create;
using Product.Core.Repository;
using Product.Infrastructure.Context;
using Product.Infrastructure.Persistence.Repositories;

namespace Product.Infra.IoC.InjectionContainer
{
    public class DependencyContainer
    {
        public static void RegisterService(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddDbContext<ProductDbContext>(opt => opt.UseInMemoryDatabase("Database"));
            services.AddMediatR(typeof(CreateProductCommand));
        }
    }
}
