using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Extensions
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<Context>(options =>
			{
				var connectionStrings = configuration.GetSection(ConnectionStringOption.Key).Get<ConnectionStringOption>();

				options.UseSqlServer(connectionStrings!.SqlServer, sqlServerOptionsAction =>
				{
					sqlServerOptionsAction.MigrationsAssembly(typeof(RepositoryAssembly).Assembly.FullName);
				});
			});
			services.AddScoped<IProductService, ProductManager>();
			services.AddScoped<IProductCategoryService, ProductCategoryManager>();
			services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
			return services;
		}
	}
}
