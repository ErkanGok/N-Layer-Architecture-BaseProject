using App.API.Controllers;
using BusinessLayer.Abstract;
using BusinessLayer.Products.Create;
using BusinessLayer.Products.Update;
using DtoLayer.ProductDto;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	
	public class ProductController(IProductService _productService) : CustomBaseController
	{
		

		[HttpGet("GetListProductwithCategory")]
		public async Task<IActionResult> GetListProductwithCategory()  => CreateActionResult(await _productService.GetListAsync());
		

		[HttpPost("AddProduct")]
		public async Task<IActionResult> AddProduct(CreateProductRequest request) => CreateActionResult(await _productService.InsertAsync(request));
		

		[HttpPut("UpdateProduct")]
		public async Task<IActionResult> UpdateProduct(int id, UpdateProductRequest request) => CreateActionResult(await _productService.UpdateAsync(id, request));
		

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProduct(int id) => CreateActionResult(await _productService.DeleteAsync(id));
		

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIDProduct(int id) => CreateActionResult(await _productService.GetByIDAsync(id));
		
	}
}
