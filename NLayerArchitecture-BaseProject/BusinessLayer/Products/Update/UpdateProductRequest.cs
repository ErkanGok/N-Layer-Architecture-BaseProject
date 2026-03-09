namespace BusinessLayer.Products.Update;

public record UpdateProductRequest(string Name, int Price, int Quantity, int? ProductCategoryID);

