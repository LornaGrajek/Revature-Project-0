namespace UI;
public class EditInventory : IMenu
{
    private IBL _bl;
    public EditInventory(IBL bl)
    {
        _bl = bl;
    }
    public void Start()
    {
        Menu:
        System.Console.WriteLine("[1] Add New Product \n[2] Replenish Inventory\n [3] View Inventory\t[4] Store Menu\n[5] Manager Menu\n [6] Main Menu");

        int choice;
        bool parse = Int32.TryParse(Console.ReadLine(), out choice);
        List<Product> allProducts = _bl.GetAllStoreProducts(CurrentContext.editStore!.StoreID);
        List<Inventory> allInventory = _bl.GetStoreInventory(CurrentContext.editStore.StoreID);
        var prodInventory = allProducts.Zip(allInventory, (p, i) => new {Product = p, Inventory = i});

        if (parse && choice >= 1 && choice <= 6)
        {
            switch(choice)
            {
                case 1:
                    newProduct:
                    System.Console.WriteLine("Product Name: ");
                    string? name = Console.ReadLine();
                    System.Console.WriteLine("Product Description: ");
                    string? describe = Console.ReadLine();
                    System.Console.WriteLine("Price: ");
                    string? sPrice = Console.ReadLine();
                    decimal price;
                    bool priceParse = Decimal.TryParse(sPrice, out price);
                    System.Console.WriteLine("Quantity: ");
                    string? sQuantity = Console.ReadLine();
                    int quantity;
                    bool quantParse = Int32.TryParse(sQuantity, out quantity);
                    
                    if (priceParse && quantParse && price > 0 && quantity > 0)
                    {
                        Product newProd = new Product(name!, describe!, price);
                        _bl.AddProduct(newProd);
                        int productID = _bl.GetProductID(newProd.ProductName!);
                        Inventory newInvent = new Inventory(CurrentContext.editStore!.StoreID, quantity, productID);
                        _bl.AddProductToInventory(productID, newInvent);
                        System.Console.WriteLine($"{newProd.ProductName} has been added!");
                    } else {
                        System.Console.WriteLine("Please input a valid number");
                        goto newProduct;
                    }
                    goto Menu;

                case 2:
                    System.Console.WriteLine("Select which item you would like to restock by using product ID: ");
                    foreach (var (item, index) in prodInventory.Select((value, i) => (value, i)))
                    {
                        System.Console.WriteLine($"\n[{item.Product.ProductID}] {item.Product.ProductName}: {item.Product.Description}\nPrice: ${item.Product.Price}\tQuantity: {item.Inventory.Quantity}");
                    }
                    int selectedProduct;
                    bool prodParse = Int32.TryParse(Console.ReadLine(), out selectedProduct);
                    System.Console.WriteLine("Quantity to restock: ");
                    int selectedQuantity;
                    bool numParse = Int32.TryParse(Console.ReadLine(), out selectedQuantity);
                    if (prodParse && numParse && selectedProduct <= allProducts.Count && selectedQuantity > 0)
                    {
                        _bl.RestockStoreInventory(CurrentContext.editStore.StoreID, selectedProduct, selectedQuantity);
                    }
                    goto Menu;

                case 3:                   
                    foreach (var (item, index) in prodInventory.Select((value, i) => (value, i)))
                    {
                        System.Console.WriteLine($"\n[{item.Product.ProductID}] {item.Product.ProductName}: {item.Product.Description}\nPrice: ${item.Product.Price}\tQuantity: {item.Inventory.Quantity}");
                    }
                goto Menu;
                
                case 4:
                    MenuFactory.GetMenu("edit").Start();
                break;

                case 5:
                    MenuFactory.GetMenu("manager").Start();
                break;

                case 6:
                    MenuFactory.GetMenu("main").Start();
                break;
            }
        }

    }
}