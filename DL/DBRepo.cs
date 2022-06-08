using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
// using Serilog;

namespace StoreDL;
public class DBRepo : IRepo
{
    private string _connectionstring;
    public DBRepo(string connectionstring){
        _connectionstring = connectionstring;
    }
    public void AddCustomer(Customer newCustomer)
    {
        Random rand = new Random();
        int custID = rand.Next(1, 1001);
        Customer.CId = custID;
        int CID = Customer.CId;
        string connectionString = _connectionstring;
        var sqlQuery = "SELECT * FROM Customer";
        using(var connString = new SqlConnection(_connectionstring))
        {
            using(var da = new SqlDataAdapter(sqlQuery, connString))
            {
                var ds = new DataSet();
                da.Fill(ds, "customers");
                DataTable dt = ds.Tables["customers"];
                DataRow newRow = dt.NewRow();
                newRow["CustomerId"] = CID;
                newRow["UserName"] = newCustomer.UserName;
                newRow["PassWord"] = newCustomer.Password;
                dt.Rows.Add(newRow);

                var insertQuery = $"INSERT INTO Customer (CustomerId, UserName, PassWord) VALUES ({CID}, '{newCustomer.UserName}', '{newCustomer.Password}')";
                da.InsertCommand = new SqlCommand(insertQuery, connString);

                da.Update(dt);
            }
        }
    }

    public void AddLineItem(LineItem newLI, int orderID)
    {
        throw new NotImplementedException();
    }

    public void AddOrder(Order orderToAdd)
    {
        throw new NotImplementedException();
    }

    public void AddProduct(Product productToAdd)
    {
        throw new NotImplementedException();
    }

    public void AddProductToInventory(int prodID, Inventory inventToAdd)
    {
        throw new NotImplementedException();
    }

    public void AddStore(Storefront storetoAdd)
    {
        throw new NotImplementedException();
    }

    public List<Customer> GetAllCustomers()
    {
        throw new NotImplementedException();
    }

    public List<Inventory> GetAllInventory()
    {
        throw new NotImplementedException();
    }

    public List<Order> GetAllOrders(int CID)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public List<Order> GetAllStoreOrders(int storeID)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetAllStoreProducts(int storeID)
    {
        throw new NotImplementedException();
    }

    public List<Storefront> GetAllStores()
    {
        List<Storefront> allStores = new List<Storefront>();
        using(SqlConnection connection = new SqlConnection(_connectionstring))
        {
            connection.Open();
            string queryTxt = "SELECT * FROM Storefront";
            using(SqlCommand cmd = new SqlCommand(queryTxt, connection))
            {
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Storefront store = new Storefront();
                        store.StoreID = reader.GetInt32(0);
                        store.Name = reader.GetString(1);
                        store.Address = reader.GetString(2);

                        allStores.Add(store);
                    }
                }
            }
            connection.Close();
        }
        return allStores;
    }

    public int GetCustomerID(string username)
    {
        int CID = Customer.CId;
        Customer currentCustomer = new Customer();
        using SqlConnection connection = new SqlConnection(_connectionstring);
        {
            connection.Open();
            string queryTxt = $"SELECT CustomerId FROM Customer WHERE UserName = '{username}'";
            using(SqlCommand cmd = new SqlCommand(queryTxt, connection))
            {
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CID = reader.GetInt32(0);
                    }
                }
            }
            connection.Close();
        }
        return CID;
    }

    public int GetProductID(string productname)
    {
        throw new NotImplementedException();
    }

    public List<Inventory> GetStoreInventory(int storeID)
    {
        throw new NotImplementedException();
    }

    public void RemoveProduct(int prodID)
    {
        throw new NotImplementedException();
    }

    public void RestockStoreInventory(int storeID, int prodID, int quantity)
    {
        throw new NotImplementedException();
    }
}