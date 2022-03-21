global using Models;
global using StoreDL;
namespace StoreBL;
public interface IBL{
     //-----GET ALL-----------
    List<Customer> GetAllCustomers();
    List<Storefront> GetAllStores();
    List<Product> GetAllProducts();
    List<Product> GetAllStoreProducts(int storeID);
    List<Order> GetAllOrders(int CID);
    List<Inventory> GetAllInventory();
    List<Order> GetAllStoreOrders(int storeID);
    List<Inventory> GetStoreInventory(int storeID);
    //----------ADD SOMETHING-----------
    void AddCustomer(Customer newCustomer);
    void AddLineItem(LineItem newLI, int orderID);
    void AddStore(Storefront storetoAdd);
    void AddProduct(Product productToAdd);
    void AddOrder(Order orderToAdd);
    void AddProductToInventory(int prodID, Inventory inventToAdd);
    void RestockStoreInventory(int storeID, int prodID, int quantity);

    //-----------------------------------------------
    int GetCustomerID(string username);
    int GetProductID(string productname);
    void RemoveProduct(int prodID);
}
