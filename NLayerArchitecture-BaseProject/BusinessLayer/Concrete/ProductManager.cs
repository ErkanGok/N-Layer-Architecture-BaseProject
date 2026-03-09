using App.Services;
using BusinessLayer.Abstract;
using BusinessLayer.Products.Create;
using BusinessLayer.Products.Update;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitofWorks;
using DtoLayer.ProductDto;
using EntityLayer.Concrete;
using System.Net;

namespace BusinessLayer.Concrete
{
	public class ProductManager(IProductDal _productDal, IUnitofWork unitofWork) : IProductService
	{
		

		public async Task<ServiceResult<CreateProductResponse>> InsertAsync(CreateProductRequest request)
		{
			var product = new Product
			{
				Name = request.Name,
				Price = request.Price,
				Quantity = request.Quantity,
				ProductCategoryID = request.ProductCategoryID
			};

			await _productDal.InsertAsync(product);
			await unitofWork.SaveChangesAsync();
			return ServiceResult<CreateProductResponse>.SuccessAsCreated(new CreateProductResponse(product.ID), $"api/products/{product.ID}");
		}

		public async Task<ServiceResult> DeleteAsync(int id)
		{
			var product = await _productDal.GetByIDAsync(id);

			if (product is null)
			{
				return ServiceResult.Fail("Product Not Found", HttpStatusCode.NotFound);
			}

			await _productDal.DeleteAsync(product);
			await unitofWork.SaveChangesAsync();
			return ServiceResult.Success(HttpStatusCode.NoContent);
		}

		public async Task<ServiceResult<ProductDto?>> GetByIDAsync(int id)
		{
			var products = await _productDal.ProductwithCategoryGetByIDAsync(id);

			if (products is null)
			{
				return ServiceResult<ProductDto?>.Fail("Product Not Found", HttpStatusCode.NotFound);
			}
			var productsAsDto = new ProductDto
			{
				ID = products.ID,
				Name = products.Name,
				Price = products.Price,
				Quantity = products.Quantity,
				CategoryName = products.ProductCategory.Name
			};

			return ServiceResult<ProductDto>.Success(productsAsDto)!;
		}

		public async Task<ServiceResult<List<ProductDto>>> GetListAsync()
		{
			var values = await _productDal.ProductwithCategoryGetListAsync();

			var valuesMap = values.Select(x => new ProductDto
			{
				ID = x.ID,
				Name = x.Name,
				Price = x.Price,
				Quantity = x.Quantity,
				CategoryName = x.ProductCategory.Name
			}).ToList();

			return ServiceResult<List<ProductDto>>.Success(valuesMap);

		}

		public async Task<ServiceResult> UpdateAsync(int id, UpdateProductRequest request)
		{
			var product = await _productDal.GetByIDAsync(id);

			if (product is null)
			{
				return ServiceResult.Fail("Product Not Found", HttpStatusCode.NotFound);
			}

			product.Name = request.Name;
			product.Price = request.Price;
			product.Quantity = request.Quantity;
			product.ProductCategoryID = request.ProductCategoryID;


			await _productDal.UpdateAsync(product);
			await unitofWork.SaveChangesAsync();

			return ServiceResult.Success(HttpStatusCode.NoContent);
		}

		
	}
}
