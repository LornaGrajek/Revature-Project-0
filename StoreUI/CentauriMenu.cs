namespace UI;

public class CentauriMenu : IMenu
{
    private IBL _bl;
    public CentauriMenu(IBL bL)
    {
        _bl = bL;
    }
    public void Start()
    {
        Random rand = new Random();
        int orderID = rand.Next(1, 500);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Welcome to Proxima B! What Would you like to do?");
        Console.ResetColor();
        Console.WriteLine("[1] View products and place an order");
        Console.WriteLine("[2] Return to Main Menu");
        string response = Console.ReadLine();
        switch (response)
        {
            case "1":
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("\nPlease select from the following products: \n");
                    DateTime date = DateTime.Now;
                    Storefront centarui = CurrentContext.currentStore;
                    int storeID = CurrentContext.currentStore.StoreID;
                    List<Product> allProducts = _bl.GetAllCentauriProducts();

                    for (int i = 0; i < allProducts.Count; i++)
                    {
                        Console.WriteLine($"\n[{i}] {allProducts[i].ProductName}: \n{allProducts[i].Description}\nPrice:\t${allProducts[i].Price}");
                    }

                    int input = int.Parse(Console.ReadLine());
                    Product selectedprod = new Product();
                    selectedprod = allProducts[input];
                    Console.WriteLine($"How many {selectedprod.ProductName} would you like to buy?");
                    int input2 = int.Parse(Console.ReadLine());
                    int prodID = selectedprod.ProductID;
                    LineItem newLI = new LineItem(selectedprod, input2, orderID, selectedprod.ProductID);

                    if(CurrentContext.lineItems == null)
                    {
                        CurrentContext.lineItems = new List<LineItem>();
                    }
                    CurrentContext.lineItems.Add(newLI);
                    decimal currTotal = CurrentContext.CalculateTotal();
                    // int orderTotal = int.Parse(CurrentContext.Cart.LineItems.Sum());
                    if(CurrentContext.Cart == null)
                    {
                        
                        Order newOrder = new Order(Customer.CId, orderID, CurrentContext.currentStore.StoreID, date, currTotal);

                        CurrentContext.Cart = newOrder;
                    }
                    else if(CurrentContext.Cart != null)
                    {
                        CurrentContext.Cart.Total += currTotal;
                    }
                    else
                    {}
                    Console.WriteLine("Keep Shopping or Place Order?");
                    Console.WriteLine("[1] Keep Shopping!\t[2] Place Order");
                    int shopInput = Int32.Parse(Console.ReadLine());
                    
                    if (shopInput == 1)
                    {

                    } 
                    else
                    {
                        _bl.AddOrder(CurrentContext.Cart);
                        foreach (LineItem item in CurrentContext.lineItems)
                        {
                            _bl.AddLineItem(item, orderID);
                        }
                        System.Console.WriteLine("Thank you for placing your order! You can find your order details in your customer account.");
                        Order clearCart = new Order();
                        CurrentContext.Cart = clearCart;
                        exit = true;
                    }
                }
                MenuFactory.GetMenu("customer").Start();
            break;
            case "2":
                MenuFactory.GetMenu("customer").Start();
            break;
            default:
                MenuFactory.GetMenu("store").Start();
            break;
        }
    }
}