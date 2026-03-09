using App.Services;
using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Products.Create;
using BusinessLayer.Products.Update;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitofWorks;
using DtoLayer.ProductDto;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BusinessLayer.Concrete
{
	public class ProductManager(IProductDal _productDal, IUnitofWork unitofWork, IMapper mapper) : IProductService
	{
		public async Task<ServiceResult<CreateProductResponse>> InsertAsync(CreateProductRequest request)
		{
			var anyProduct = await _productDal.Where(x => x.Name == request.Name).AnyAsync();

			if (anyProduct)
			{
				return ServiceResult<CreateProductResponse>.Fail("Ürün İsmi Veritabanında Bulunmaktadır.", HttpStatusCode.BadRequest);
			}

			var product = new Product
			{
				Name = request.Name,
				Price = request.Price,
				Quantity = request.Quantity,
				ProductCategoryID = request.ProductCategoryID
			};

			await _productDal.AddAsync(product);
			await unitofWork.SaveChangesAsync();
			return ServiceResult<CreateProductResponse>.SuccessAsCreated(new CreateProductResponse(product.ID), $"api/products/{product.ID}");
		}

		public async Task<ServiceResult> DeleteAsync(int id)
		{
			var product = await _productDal.GetByIdAsync(id);

			if (product is null)
			{
				return ServiceResult.Fail("Product Not Found", HttpStatusCode.NotFound);
			}

			_productDal.Delete(product);
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
			var productsMap = mapper.Map<ProductDto>(products);
			#region Manuel Mapping
			//var productsAsDto = new ProductDto
			//{
			//	ID = products.ID,
			//	Name = products.Name,
			//	Price = products.Price,
			//	Quantity = products.Quantity,
			//	CategoryName = products.ProductCategory.Name
			//};
			#endregion


			return ServiceResult<ProductDto>.Success(productsMap)!;
		}

		public async Task<ServiceResult<List<ProductDto>>> GetListAsync()
		{
			var products = await _productDal.ProductwithCategoryGetListAsync();
			var productsMap = mapper.Map<List<ProductDto>>(products);
			#region Manuel Map
			//var valuesMap = values.Select(x => new ProductDto
			//{
			//	ID = x.ID,
			//	Name = x.Name,
			//	Price = x.Price,
			//	Quantity = x.Quantity,
			//	CategoryName = x.ProductCategory.Name
			//}).ToList();
			#endregion

			return ServiceResult<List<ProductDto>>.Success(productsMap);

		}

		public async Task<ServiceResult> UpdateAsync(int id, UpdateProductRequest request)
		{
			var product = await _productDal.GetByIdAsync(id);

			if (product is null)
			{
				return ServiceResult.Fail("Product Not Found", HttpStatusCode.NotFound);
			}

			product.Name = request.Name;
			product.Price = request.Price;
			product.Quantity = request.Quantity;
			product.ProductCategoryID = request.ProductCategoryID;


			_productDal.Update(product);
			await unitofWork.SaveChangesAsync();

			return ServiceResult.Success(HttpStatusCode.NoContent);
		}

		
	}
}
