namespace UI;
public class ShopMenu : IMenu
{
    private IBL _bl;
    public ShopMenu(IBL bl)
    {
        _bl = bl;
    }
    public void Start()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Welcome to {CurrentContext.currentStore!.Name}! What Would you like to do?");
        Console.ResetColor();
        Console.WriteLine("[1] View products and place an order");
        Console.WriteLine("[2] Return to Main Menu");
        string? input = Console.ReadLine();
        int choice;
        bool parse = Int32.TryParse(input, out choice);
        Random rand = new Random();
        int orderID = rand.Next(1, 500);
        DateTime date = DateTime.Now;
        int storeID = CurrentContext.currentStore.StoreID;
        List<Product> allProducts = _bl.GetAllStoreProducts(storeID);

        if (parse && choice >= 1 && choice <= 2)
        {
            switch (choice)
            {
                case 1:
                    bool exit = false;
                    while (!exit)
                    {
                        Console.WriteLine("\nPlease select from the following products: \n");
                        keepShopping:
                        for (int i = 0; i < allProducts.Count; i++)
                        {
                            Console.WriteLine($"\n[{i}] {allProducts[i].ProductName}: \n{allProducts[i].Description}\nPrice:\t${allProducts[i].Price}");
                        }

                        parse = Int32.TryParse(Console.ReadLine(), out choice);
                        Product selectedProduct = new Product();
                        selectedProduct = allProducts[choice];

                        System.Console.WriteLine($"How many {selectedProduct.ProductName} would you like to buy?");
                        int quantity;
                        parse = Int32.TryParse(Console.ReadLine(), out quantity);

                        LineItem currentLI = new LineItem(selectedProduct, quantity, orderID, selectedProduct.ProductID);
                        if (CurrentContext.lineItems == null)
                        {
                            CurrentContext.lineItems = new List<LineItem>();
                        }
                        CurrentContext.lineItems.Add(currentLI);
                        decimal currentTotal = CurrentContext.CalculateTotal();

                        if (CurrentContext.Cart == null)
                        {
                            Order newOrder = new Order(Customer.CId, orderID, storeID, date, currentTotal);
                            CurrentContext.Cart = newOrder;
                        } else
                        {
                            CurrentContext.Cart.Total += currentTotal;
                        }
                        Console.WriteLine("Keep Shopping or Place Order?");
                        Console.WriteLine("[1] Keep Shopping!\t[2] Place Order");
                        parse = Int32.TryParse(Console.ReadLine(), out choice);

                        if (parse && choice <=2 && choice >= 1)
                        {
                            switch (choice)
                            {
                                case 1:
                                    goto keepShopping;
                                case 2:
                                    _bl.AddOrder(CurrentContext.Cart);
                                    System.Console.WriteLine("Thank you for your order!\tYou ordered: ");
                                    foreach (LineItem item in CurrentContext.lineItems)
                                    {
                                        _bl.AddLineItem(currentLI, orderID);
                                        System.Console.WriteLine($"\n{item.Quantity}\n{item.Item!.ProductName}");
                                    }
                                    System.Console.WriteLine($"Your order total is ${currentTotal}");
                                    exit = true;
                                break;
                                default:
                                    MenuFactory.GetMenu("store").Start();
                                break;
                            }
                        }
                    }
                break;
                case 2:
                    MenuFactory.GetMenu("store").Start();
                break;
                default:
                    MenuFactory.GetMenu("store").Start();
                break;
            }
        }

    }
}