using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitofWorks;
using DtoLayer.ProductDto;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class ProductManager(IProductDal productDal, IUnitofWork unitofWork) : IProductService
	{
		private readonly IProductDal _productDal = productDal;

		public async Task AddProductAsync(AddProductDto addProductDto)
		{
			var product = new Product
			{
				Name = addProductDto.Name,
				Price = addProductDto.Price,
				Quantity = addProductDto.Quantity,
				ProductCategoryID = addProductDto.ProductCategoryID
			};

			await _productDal.InsertAsync(product);
			await unitofWork.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var value = await _productDal.GetByIDAsync(id);

			if (value != null)
			{
				await _productDal.DeleteAsync(value);
				await unitofWork.SaveChangesAsync();
			}
		}

		public async Task<GetListProductDto> ProductwithCategoryGetByIDAsync(int id)
		{
			var value = await _productDal.ProductwithCategoryGetByIDAsync(id);

			if (value == null)
				return null;

			return new GetListProductDto
			{
				ID = value.ID,
				Name = value.Name,
				Price = value.Price,
				Quantity = value.Quantity,
				CategoryName = value.ProductCategory.Name
			};
		}

		public async Task<List<GetListProductDto>> ProductwithCategoryGetListAsync()
		{
			var values = await _productDal.ProductwithCategoryGetListAsync();

			return values.Select(x => new GetListProductDto
			{
				ID = x.ID,
				Name = x.Name,
				Price = x.Price,
				Quantity = x.Quantity,
				CategoryName = x.ProductCategory.Name
			}).ToList();
		}

		public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
		{
			var product = new Product
			{
				ID = updateProductDto.ID,
				Name = updateProductDto.Name,
				Price = updateProductDto.Price,
				Quantity = updateProductDto.Quantity,
				ProductCategoryID = updateProductDto.ProductCategoryID
			};

			await _productDal.UpdateAsync(product);
			await unitofWork.SaveChangesAsync();
		}
	}
}
