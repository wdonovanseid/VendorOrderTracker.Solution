using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorOrderTracker.Models;
using System.Collections.Generic;
using System;

namespace VendorOrderTracker.Tests
{
  [TestClass]
  public class VendorTest : IDisposable
  {

    public void Dispose()
    {
      Vendor.ClearAllVendors();
    }

    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      Vendor newVendor = new Vendor("test name", "test descrip", "test address");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      Vendor newVendor = new Vendor("test name", "test descrip", "test address");

      //Act
      string result = newVendor.Name;

      //Assert
      Assert.AreEqual("test name", result);
    }

    [TestMethod]
    public void   GetId_ReturnsCategoryId_Int()
    {
      //Arrange
      Vendor newVendor = new Vendor("test name", "test descrip", "test address");

      //Act
      int result = newVendor.Id;

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllVendorObjects_VendorList()
    {
      //Arrange
      Vendor newVendor1 = new Vendor("test name", "test descrip", "test address");
      Vendor newVendor2 = new Vendor("test name", "test descrip", "test address");
      List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };

      //Act
      List<Vendor> result = Vendor.GetAllVendors();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectVendor_Vendor()
    {
      //Arrange
      Vendor newVendor1 = new Vendor("test name", "test descrip", "test address");
      Vendor newVendor2 = new Vendor("test name", "test descrip", "test address");

      //Act
      Vendor result = Vendor.FindVendor(2);

      //Assert
      Assert.AreEqual(newVendor2, result);
    }

    [TestMethod]
    public void AddOrder_AssociatesOrderWithVendor_OrderList()
    {
      //Arrange
      Order newOrder = new Order("test title", "test descrip", "test price", "test date");
      List<Order> newList = new List<Order> { newOrder };
      Vendor newVendor = new Vendor("test name", "test descrip", "test address");
      newVendor.AddOrder(newOrder);

      //Act
      List<Order> result = newVendor.Orders;

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
  }
}