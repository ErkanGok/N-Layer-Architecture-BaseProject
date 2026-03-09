using BusinessLayer.Products.Create;
using DataAccessLayer.Abstract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ProductCategories.Create
{
	public class CreateProductCategoryRequestValidator : AbstractValidator<CreateProductCategoryRequest>
	{
		private readonly IProductCategoryDal _productCategorydal;


		public CreateProductCategoryRequestValidator(IProductCategoryDal productCategoryDal)
		{
			_productCategorydal = productCategoryDal;
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Kategori İsmi Gereklidir.")
				.Length(3, 10).WithMessage("Kategori İsmi 3 ile 10 Karakter Arasında Olmalıdır.");

			
		}
	}
}
