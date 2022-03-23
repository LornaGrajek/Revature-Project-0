namespace UI;

public class EditStore : IMenu
{
    private IBL _bl;
    public EditStore(IBL bl)
    {
        _bl = bl;
    }
    public void Start()
    {
        editStoreMenu:
        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine($"========= {CurrentContext.editStore!.Name} ========");
        Console.ResetColor();
        System.Console.WriteLine("What would you like to do?");
        System.Console.WriteLine("[1] View All Product Inventory");
        System.Console.WriteLine("[2] Edit Product Inventory");
        System.Console.WriteLine("[3] View Order History");
        System.Console.WriteLine("[4] Return to Admin Menu");

        int choice;
        bool parse = Int32.TryParse(Console.ReadLine(), out choice);

        if (parse && choice >= 1 && choice <= 4)
        {
            switch (choice)
            {
                case 1:
                    List<Product> allProducts = _bl.GetAllStoreProducts(CurrentContext.editStore.StoreID);
                    List<Inventory> allInventory = _bl.GetStoreInventory(CurrentContext.editStore.StoreID);
                    var productInventory = allProducts.Zip(allInventory, (p, i) => new {Product = p, Inventory = i});
                    foreach (var (item, index) in productInventory.Select((value, i) => (value, i)))
                    {
                        System.Console.WriteLine($"\n[{index}] {item.Product.ProductName}: {item.Product.Description}\nPrice: ${item.Product.Price}\tQuantity: {item.Inventory.Quantity}");
                    }
                    System.Console.WriteLine("Press Enter to return to menu");
                    
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        goto editStoreMenu;
                    }
                break;

                case 2:
                    MenuFactory.GetMenu("inventory").Start();
                break;

                case 3:
                    System.Console.WriteLine($"All Orders for {CurrentContext.editStore.Name}: ");
                    List<Order> allOrders = _bl.GetAllStoreOrders(CurrentContext.editStore.StoreID);
                    foreach (Order o in allOrders)
                    {
                        System.Console.WriteLine($"Customer ID: {o.CustomerId} Order Number: {o.OrderNumber} Total: {o.Total} Date: {o.OrderDate}");
                    }
                    System.Console.WriteLine("Press Enter to return to Store Menu");
                    enter:
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        goto editStoreMenu;
                    } else {
                        System.Console.WriteLine("Please press enter");
                        goto enter;
                    }

                case 4:
                    MenuFactory.GetMenu("manager").Start();
                break;
            }
        }
    }
}