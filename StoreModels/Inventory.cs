namespace Models;

public class Inventory 
{
    public Inventory(){ }
    public Inventory(int storeId, int quantity, int prodID){
        this.StoreId = storeId;
        this.Quantity = quantity;
        this.ProductID = prodID;
    }
    public int InventoryID { get; set; }
    public int StoreId { get; set; }
    public int Quantity { get; set; }
    public int ProductID { get; set; }
    public Product Item { get; set; }
}