namespace UI;

public class SignUp : IMenu
{
    private IBL _bl;
    public SignUp(IBL bl)
    {
        _bl = bl;
    }
    public void Start()
    {
        createNewUser:
        Console.WriteLine("Greetings! Please Choose a Username:");
        string? username = Console.ReadLine();
        Console.WriteLine("Please enter a password: ");
        string? password = Console.ReadLine();
        
        try{
            Customer newCustomer = new Customer(username ?? "", password ?? "");
            _bl.AddCustomer(newCustomer);
            Console.WriteLine($"Thank you {newCustomer.UserName} for creating an account.");
            CurrentContext.currentCustomer = newCustomer;
            int custID = _bl.GetCustomerID(username ?? "");
            Customer.CId = custID;
        } catch (InputInvalidException ex){
            System.Console.WriteLine(ex.Message);
            goto createNewUser;
        }
        MenuFactory.GetMenu("customer").Start();
    }
}