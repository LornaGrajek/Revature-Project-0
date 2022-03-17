global using System.Data;
namespace Models;
public class Order
{
    public Order()
    {
        this.LineItems = new List<LineItem>();
    }
    public Order(int customerId, int orderId, int storeId, DateTime orderdate, int total){
        this.CustomerId = customerId;
        this.OrderNumber = orderId;
        this.StoreId = storeId;
        this.OrderDate = orderdate;
        this.Total = total;
        this.LineItems = new List<LineItem>();
    }
    public DateTime OrderDate { get; set; }
    public int CustomerId { get; set; }
    public int OrderNumber { get; set; }
    public int StoreId { get; set; }
    public List<LineItem> LineItems { get; set; }
    public decimal Total { get; set; }
    public void ToDataRow(ref DataRow row)
    {
        row["OrderId"] = this.OrderNumber;
        row["CustomerId"] = this.CustomerId;
        row["StoreId"] = this.StoreId;
        row["Total"] = this.Total;
        row["OrderDate"] = this.OrderDate;
    }
}