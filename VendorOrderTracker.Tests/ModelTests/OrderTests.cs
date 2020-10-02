using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VendorOrderTracker.Models;
using System;

namespace VendorOrderTracker.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {

    public void Dispose()
    {
      Order.ClearAllOrders();
    }

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order("test title", "test descrip", "test price", "test date");
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      //Arrange
      Order newOrder = new Order("test title", "test descrip", "test price", "test date");

      //Act
      string result = newOrder.Description;

      //Assert
      Assert.AreEqual("test descrip", result);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      //Arrange
      Order newOrder = new Order("test title", "test descrip", "test price", "test date");

      //Act
      string updatedDescription = "bread";
      newOrder.Description = updatedDescription;
      string result = newOrder.Description;

      //Assert
      Assert.AreEqual(updatedDescription, result);
    }

    [TestMethod]
    public void GetAllOrders_ReturnsEmptyList_OrderList()
    {
      // Arrange
      List<Order> newList = new List<Order> { };

      // Act
      List<Order> result = Order.GetAllOrders();

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAllOrders_ReturnsOrders_OrderList()
    {
      //Arrange
      Order newOrder1 = new Order("test title", "test descrip", "test price", "test date");
      Order newOrder2 = new Order("test title", "test descrip", "test price", "test date");
      List<Order> newList = new List<Order> { newOrder1, newOrder2 };

      //Act
      List<Order> result = Order.GetAllOrders();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_OrdersInstantiateWithAnIdAndGetterReturns_Int()
    {
      //Arrange
      Order newOrder = new Order("test title", "test descrip", "test price", "test date");

      //Act
      int result = newOrder.Id;

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void FindOrder_ReturnsCorrectOrder_Order()
    {
      //Arrange
      Order newOrder1 = new Order("test title", "test descrip", "test price", "test date");
      Order newOrder2 = new Order("asdf", "fdsa", "aaff", "ffaa");

      //Act
      Order result = Order.FindOrder(2);

      //Assert
      Assert.AreEqual(newOrder2, result);
    }
  }
}