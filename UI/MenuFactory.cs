namespace UI;

public static class MenuFactory
{
    public static IMenu GetMenu(string menuString)
    {
        menuString = menuString.ToLower();
        string connectionstring = File.ReadAllText("connectionstring.txt");
        IRepo repo = new DBRepo(connectionstring);
        IBL bl = new UFOBL(repo);

        switch(menuString)
        {
            case "main":
                return new MainMenu(bl);

            case "signup":
                return new SignUp(bl);
            
            case "login":
                return new LoginMenu(bl);

            case "customer":
                return new CustomerMenu(bl);
            
            case "store":
                return new StoreSelectionMenu(bl);

            case "shop":
                return new ShopMenu(bl);

            case "manager":
                return new ManagerMenu(bl);
            
            case "edit":
                return new EditStore(bl);

            case "inventory":
                return new EditInventory(bl);

            default:
                return new MainMenu(bl);
        }
    }
}