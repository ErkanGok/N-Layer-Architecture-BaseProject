namespace BusinessLayer.Products.Create;

	public record CreateProductRequest(string Name, int Price,int Quantity, int? ProductCategoryID);
	
	
