using AutoMapper;
using DtoLayer.CategoryDto;
using DtoLayer.ProductDto;
using EntityLayer.Concrete;

namespace BusinessLayer.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Product, ProductDto>().ReverseMap();
			CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
		}
	}
}
