namespace StoreBL;

public class UFOBL : IBL
{
    private IRepo _dl;
    public UFOBL(IRepo repo){
        _dl = repo;
    }
    public void AddCustomer(Customer newCustomer)
    {
        _dl.AddCustomer(newCustomer);
    }

    public void AddLineItem(LineItem newLI, int orderID)
    {
        _dl.AddLineItem(newLI, orderID);
    }

    public void AddOrder(Order orderToAdd)
    {
        _dl.AddOrder(orderToAdd);
    }

    public void AddProduct(Product productToAdd)
    {
        _dl.AddProduct(productToAdd);
    }

    public void AddProductToInventory(int prodID, Inventory inventToAdd)
    {
        _dl.AddProductToInventory(prodID, inventToAdd);
    }

    public void AddStore(Storefront storetoAdd)
    {
        _dl.AddStore(storetoAdd);
    }

    public List<Customer> GetAllCustomers()
    {
        return _dl.GetAllCustomers();
    }

    public List<Inventory> GetAllInventory()
    {
        return _dl.GetAllInventory();
    }

    public List<Order> GetAllOrders(int CID)
    {
        return _dl.GetAllOrders(CID);
    }

    public List<Product> GetAllProducts()
    {
        return _dl.GetAllProducts();
    }

    public List<Order> GetAllStoreOrders(int storeID)
    {
        return _dl.GetAllStoreOrders(storeID);
    }

    public List<Product> GetAllStoreProducts(int storeID)
    {
        return _dl.GetAllStoreProducts(storeID);
    }

    public List<Storefront> GetAllStores()
    {
        return _dl.GetAllStores();
    }

    public int GetCustomerID(string username)
    {
        return _dl.GetCustomerID(username);
    }

    public int GetProductID(string productname)
    {
        return _dl.GetProductID(productname);
    }

    public List<Inventory> GetStoreInventory(int storeID)
    {
        return _dl.GetStoreInventory(storeID);
    }

    public void RemoveProduct(int prodID)
    {
        _dl.RemoveProduct(prodID);
    }

    public void RestockStoreInventory(int storeID, int prodID, int quantity)
    {
        _dl.RestockStoreInventory(storeID, prodID, quantity);
    }
}