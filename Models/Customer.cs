namespace Models;
public class Customer
{
    public Customer()
    {
        this.Orders = new List<Order>();
    }
    public Customer(string username, string password)
    {
        this.UserName = username;
        this.Password = password;
        this.Orders = new List<Order>();
    }
    public static int CId { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public List<Order> Orders { get; set; }
    public void ToDataRow(ref DataRow row)
    {
        // row["CustomerId"] = this.CustomerId;
        // row["StoreId"] = this.StoreId;
        // row["Total"] = this.Total;
        // row["OrderDate"] = this.OrderDate;
    }
}