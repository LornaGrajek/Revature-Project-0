namespace Models;
public class Storefront
{
    public Storefront()
    {
        this.Products = new List<Inventory>();
    }

    public Storefront(string name, string address){
        this.Name = name;
        this.Address = address;
        this.Products = new List<Inventory>();
    }
    public int StoreID { get; set; }
    public string? Address { get; set; }
    public string? Name { get; set; }
    public List<Inventory>? Products { get; set; }
    public List<Order>? Orders { get; set; }
}