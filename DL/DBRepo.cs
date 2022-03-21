namespace StoreDL;

public class DBRepo : IRepo
{
    private string _connectionString;
    public DBRepo(string connectionString){
        _connectionString = connectionString;
    }
    public void AddCustomer(Customer newCustomer)
    {
        throw new NotImplementedException();
    }

    public void AddLineItem(LineItem newLI, int orderID)
    {
        throw new NotImplementedException();
    }

    public void AddOrder(Order orderToAdd)
    {
        throw new NotImplementedException();
    }

    public void AddProduct(Product productToAdd)
    {
        throw new NotImplementedException();
    }

    public void AddProductToInventory(int prodID, Inventory inventToAdd)
    {
        throw new NotImplementedException();
    }

    public void AddStore(Storefront storetoAdd)
    {
        throw new NotImplementedException();
    }

    public List<Customer> GetAllCustomers()
    {
        throw new NotImplementedException();
    }

    public List<Inventory> GetAllInventory()
    {
        throw new NotImplementedException();
    }

    public List<Order> GetAllOrders(int CID)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public List<Order> GetAllStoreOrders(int storeID)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetAllStoreProducts(int storeID)
    {
        throw new NotImplementedException();
    }

    public List<Storefront> GetAllStores()
    {
        throw new NotImplementedException();
    }

    public int GetCustomerID(string username)
    {
        throw new NotImplementedException();
    }

    public int GetProductID(string productname)
    {
        throw new NotImplementedException();
    }

    public List<Inventory> GetStoreInventory(int storeID)
    {
        throw new NotImplementedException();
    }

    public void RemoveProduct(int prodID)
    {
        throw new NotImplementedException();
    }

    public void RestockStoreInventory(int storeID, int prodID, int quantity)
    {
        throw new NotImplementedException();
    }
}