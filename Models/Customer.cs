global using CustomException;
global using System.Text.RegularExpressions;
namespace Models;
public class Customer
{
    public Customer()
    {
        this.Orders = new List<Order>();
    }
    public Customer(string username, string password)
    {
        this.UserName = username;
        this.Password = password;
        this.Orders = new List<Order>();
    }
    public static int CId { get; set; }
    private string? _UserName;
    public string? UserName {
        get => _UserName;
        set{
            Regex pattern = new Regex("[A-Za-z0-9]");
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InputInvalidException("Name cannot be empty");
            } else if (!pattern.IsMatch(value)){
                throw new InputInvalidException("Username can only have alphanumeric characters and numbers");
            } else {
                this._UserName = value;
            }
        }
    }
    private string? _password;
    public string? Password {
        get => _password; 
        set{
            Regex pattern = new Regex("[A-Za-z0-9]");
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InputInvalidException("Password cannot be empty");
            } else if (!pattern.IsMatch(value)){
                throw new InputInvalidException("Password can only have alphanumeric characters and numbers");
            } else {
                this._password = value;
            }
        } 
        }
    public List<Order> Orders { get; set; }
    public void ToDataRow(ref DataRow row)
    {
        // row["CustomerId"] = this.CustomerId;
        // row["StoreId"] = this.StoreId;
        // row["Total"] = this.Total;
        // row["OrderDate"] = this.OrderDate;
    }
}