using BusinessLayer.Abstract;
using DtoLayer.ProductDto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet("GetListProductwithCategory")]
		public async Task<IActionResult> GetListProductwithCategory()
		{
			var values = await _productService.ProductwithCategoryGetListAsync();
			return Ok(values);
		}

		[HttpPost("AddProduct")]
		public async Task<IActionResult> AddProduct(AddProductDto dto)
		{
			await _productService.AddProductAsync(dto);
			return Ok("Ürün Başarıyla Eklendi");
		}

		[HttpPut("UpdateProduct")]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto dto)
		{
			await _productService.UpdateProductAsync(dto);
			return Ok("Ürün Güncellendi");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			await _productService.DeleteAsync(id);
			return Ok("Ürün Silindi");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIDProduct(int id)
		{
			var value = await _productService.ProductwithCategoryGetByIDAsync(id);

			if (value == null)
				return NotFound("Ürün bulunamadı!");

			return Ok(value);
		}
	}
}
