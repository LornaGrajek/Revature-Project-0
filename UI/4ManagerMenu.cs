namespace UI;
public class ManagerMenu : IMenu
{
    private IBL _bl;
    public ManagerMenu(IBL bl)
    {
        _bl = bl;
    }
    public void Start()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n=============================");
        Console.ResetColor();
        Console.WriteLine("Admin Mode Initalized");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("=============================");
        Console.ResetColor();
        storeMenu:
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("[1] Add a New Location");
        Console.WriteLine("[2] View/Edit locations");
        Console.WriteLine("[3] Return to main menu");
        
        int choice;
        bool parse = Int32.TryParse(Console.ReadLine(), out choice);

        if (parse && choice >= 1 && choice <= 3)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nStore Name: ");
                    string? name = Console.ReadLine();
                    Console.WriteLine("\nStore Address: ");
                    string? address = Console.ReadLine();
                    Storefront newStore = new Storefront(name!, address!);
                    _bl.AddStore(newStore);
                    System.Console.WriteLine("Store Added!");
                    goto storeMenu;

                case 2:
                    Console.WriteLine("Select a store to see more information: ");
                    List<Storefront> allStores = _bl.GetAllStores();
                    for (int i = 0; i < allStores.Count; i++)
                    {
                        Console.WriteLine($"\n[{i}] {allStores[i].Name} located on {allStores[i].Address}");
                    }
                    
                    parse = Int32.TryParse(Console.ReadLine(), out choice);
                    CurrentContext.editStore = allStores[choice - 1];
                    
                    MenuFactory.GetMenu("edit").Start();
                break;
                case 3:
                    MenuFactory.GetMenu("main").Start();
                break;
            }
            
        }

    }
}