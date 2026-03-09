using App.Services;
using BusinessLayer.Abstract;
using BusinessLayer.ProductCategories.Create;
using BusinessLayer.ProductCategories.Update;
using BusinessLayer.Products.Update;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitofWorks;
using DtoLayer.CategoryDto;
using DtoLayer.ProductDto;
using EntityLayer.Concrete;
using System.Net;

namespace BusinessLayer.Concrete
{
	public class ProductCategoryManager(IProductCategoryDal _productCategoryDal, IUnitofWork unitofWork) : IProductCategoryService
	{	

		public async Task<ServiceResult> DeleteAsync(int id)
		{
			var productCategory = await _productCategoryDal.GetByIDAsync(id);

			if (productCategory is null)
			{
				return ServiceResult.Fail("Product Not Found", HttpStatusCode.NotFound);
			}

			await _productCategoryDal.DeleteAsync(productCategory);
			await unitofWork.SaveChangesAsync();
			return ServiceResult.Success(HttpStatusCode.NoContent);
		}

		public async Task<ServiceResult<GetListCategoryDto?>> GetByIDAsync(int id)
		{
			var products = await _productCategoryDal.GetByIDAsync(id);

			if (products is null)
			{
				return ServiceResult<GetListCategoryDto?>.Fail("Product Not Found", HttpStatusCode.NotFound);
			}
			var productsAsDto = new GetListCategoryDto
			{
				ID = products.ID,
				Name = products.Name,				
			};

			return ServiceResult<GetListCategoryDto>.Success(productsAsDto)!;
		}

		public async Task<ServiceResult<List<GetListCategoryDto>>> GetListAsync()
		{
			var values = await _productCategoryDal.GetListAsync(); ;

			var valuesMap = values.Select(x => new GetListCategoryDto
			{
				ID = x.ID,
				Name = x.Name			
			}).ToList();

			return ServiceResult<List<GetListCategoryDto>>.Success(valuesMap);
		}

		public async Task<ServiceResult<CreateProductCategoryResponse>> InsertAsync(CreateProductCategoryRequest request)
		{
			var productCategory = new ProductCategory
			{
				Name = request.Name				
			};
			await _productCategoryDal.InsertAsync(productCategory);
			await unitofWork.SaveChangesAsync();
			return ServiceResult<CreateProductCategoryResponse>.SuccessAsCreated(new CreateProductCategoryResponse(productCategory.ID), $"api/products/{productCategory.ID}");
		}

		public async Task<ServiceResult> UpdateAsync(int id, UpdateProductCategoryRequest request)
		{
			var productCategory = await _productCategoryDal.GetByIDAsync(id);

			if (productCategory is null)
			{
				return ServiceResult.Fail("Product Category Not Found", HttpStatusCode.NotFound);
			}

			productCategory.Name = request.Name;

			await _productCategoryDal.UpdateAsync(productCategory);
			await unitofWork.SaveChangesAsync();

			return ServiceResult.Success(HttpStatusCode.NoContent);
		}
	}
}
