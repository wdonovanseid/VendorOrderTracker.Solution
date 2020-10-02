using System.Collections.Generic;

namespace VendorOrderTracker.Models
{
  public class Vendor
  {
    
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public List<Order> Orders { get; set; }
    public int Id { get; }

    private static List<Vendor> _instances = new List<Vendor> {};

    public Vendor(string inputName, string inputDescription, string inputAddress)
    {
      Name = inputName;
      Description = inputDescription;
      Address = inputAddress;
      Orders = new List<Order> {};
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static void ClearAllVendors()
    {
      _instances.Clear();
    }

    public static List<Vendor> GetAllVendors()
    {
      return _instances;
    }

    public static Vendor FindVendor(int searchId)
    {
      return _instances[searchId-1];
    }

    public void AddOrder(Order order)
    {
      Orders.Add(order);
    }

  }
}