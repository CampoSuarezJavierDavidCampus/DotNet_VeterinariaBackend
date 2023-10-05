namespace Models.Dtos;
public class CartItemDto{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string UserName { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public string ProductDescription { get; set; } = null!;
    public string ProductImageURL { get; set; } = null!;
    public decimal Price { get; set; }
    public decimal TotalPrice { get; set; }
    public int Qty { get; set; }
}