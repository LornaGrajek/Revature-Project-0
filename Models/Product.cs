namespace Models;
public class Product
{
    public Product() { }
    public Product(string productName, string description, decimal price){
        this.ProductName = productName;
        this.Description = description;
        this.Price = price;
    }
    public int ProductID { get; set; }
    public string? ProductName { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
}