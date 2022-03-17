namespace UI;

public class StoreMenu : IMenu
{
    private IBL _bl;
    public StoreMenu(IBL bL){
        _bl = bL;
    }
    public void Start()
    {
        StoreFront store = new StoreFront();
        Random rand = new Random();
        int orderID = rand.Next(1, 500);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Welcome to {store.name}! What Would you like to do?");
        Console.ResetColor();
        Console.WriteLine("[1] View products and place an order");
        Console.WriteLine("[2] Return to Main Menu");
    }
}
