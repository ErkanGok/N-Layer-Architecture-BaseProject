using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using DataAccessLayer.UnitofWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer.Extensions
{
	public static class RepositoryExtensions
	{
		public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<Context>(options =>
			{
				var connectionStrings = configuration.GetSection(ConnectionStringOption.Key).Get<ConnectionStringOption>();

				options.UseSqlServer(connectionStrings!.SqlServer, sqlServerOptionsAction =>
				{
					sqlServerOptionsAction.MigrationsAssembly(typeof(RepositoryAssembly).Assembly.FullName);
				});
			});
			services.AddScoped<IProductDal, EfProductDal>();			
			services.AddScoped<IProductCategoryDal, EfProductCategoryDal>();			
			services.AddScoped<IUnitofWork, UnitofWork>();			
			services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
			return services;
		}
	}
}
