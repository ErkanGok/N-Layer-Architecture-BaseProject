using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ExceptionHandlers;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

			services.AddFluentValidationAutoValidation(); // burası açık olursa asenkron validation çalışmaz, Eğer bunu kaldırırsak Product service'e geçmemiz lazım (3. yol)
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			//Exceptionhandlers eklediğimiz sıra önemli
			services.AddExceptionHandler<CriticalExceptionHandler>();
			services.AddExceptionHandler<GlobalExceptionHandler>();

			return services;
		}
	}
}
