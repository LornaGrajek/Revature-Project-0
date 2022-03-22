namespace UI;
public class StoreSelectionMenu : IMenu
{
    private IBL _bl;
    public StoreSelectionMenu(IBL bl)
    {
        _bl = bl;
    }
    public void Start()
    {
        Console.WriteLine("Choose your preferred location: ");
        List<Storefront> allStores = _bl.GetAllStores();
        for (int i = 0; i < allStores.Count; i++)
        {
            Console.WriteLine($"\n[{i + 1}] {allStores[i].Name} located on {allStores[i].Address}");
        }

        string? input = Console.ReadLine();
        int selection;
        bool parse = Int32.TryParse(input, out selection);
        
        if (parse && selection < allStores.Count)
        {
            CurrentContext.currentStore = allStores[selection];
            MenuFactory.GetMenu("shop").Start();
        }
    }
}