namespace UI;

public class MainMenu : IMenu
{
    private IBL _bl;
    public MainMenu(IBL bl)
    {
        _bl = bl;
    }
    public void Start()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Welcome to the UFO Emporium!");
        Console.WriteLine("Home of all your intergalactic needs!");
        Console.ResetColor();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Please Select from the Following: ");
            Console.WriteLine("[1] Log-in \t[2] Sign-Up\t[3] Admin\t[4] Exit");
            int choice;
            bool parse = Int32.TryParse(Console.ReadLine(), out choice);

            if(parse && choice >= 1 && choice <= 4)
            {
                switch (choice)
                {
                    case 1:
                        MenuFactory.GetMenu("login").Start();
                    break;
                    case 2:
                        MenuFactory.GetMenu("signup").Start();
                    break;
                    case 3:
                        MenuFactory.GetMenu("manager").Start();
                    break;
                    case 4:
                        Environment.Exit(4);
                    break;
                    default:
                        System.Console.WriteLine("Please Choose a Valid Option");
                    break;
                }
            } else
            {
                System.Console.WriteLine("Please Choose a Valid Option");
            }
        }
    }
}