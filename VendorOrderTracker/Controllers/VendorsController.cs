using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VendorOrderTracker.Models;

namespace VendorOrderTracker.Controllers
{
  public class VendorsController : Controller
  {

    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      List<Vendor> allVendors = Vendor.GetAllVendors();
      return View(allVendors);
    }

    [HttpGet("/vendors/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/vendors")]
    public ActionResult Create(string inputName, string inputDescription, string inputAddress)
    {
      Vendor newVendor = new Vendor(inputName, inputDescription, inputAddress);
      return RedirectToAction("Index");
    }

    [HttpGet("/vendors/{vendorId}")]
    public ActionResult Show(int vendorId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor selectedVendor = Vendor.FindVendor(vendorId);
      List<Order> vendorOrders = selectedVendor.Orders;
      model.Add("vendor", selectedVendor);
      model.Add("orders", vendorOrders);
      return View(model);
    }

    [HttpPost("/vendors/{vendorId}/orders")]
    public ActionResult Create(int vendorId, string inputTitle, string inputDescription, string inputPrice, string inputDate)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor selectedVendor = Vendor.FindVendor(vendorId);
      Order newOrder = new Order(inputTitle, inputDescription, inputPrice, inputDate);
      selectedVendor.AddOrder(newOrder);
      List<Order> vendorOrders = selectedVendor.Orders;
      model.Add("vendor", selectedVendor);
      model.Add("orders", vendorOrders);
      return View("Show", model);
    }

    [HttpPost("/vendors/delete")]
    public ActionResult Destroy()
    {
      Vendor.ClearAllVendors();
      return RedirectToAction("Index");
    }

    [HttpPost("/vendors/{vendorId}/orders/delete")]
    public ActionResult Destroy(int vendorId)
    {
      Vendor selectedVendor = Vendor.FindVendor(vendorId);
      selectedVendor.Orders.Clear();
      return RedirectToAction("Show");
    }

    [HttpGet("/vendors/{vendorId}/edit")]
    public ActionResult Edit(int vendorId)
    {
      Vendor selectedVendor = Vendor.FindVendor(vendorId);
      return View(selectedVendor);
    }

    [HttpPost("/vendors/{vendorId}")]
    public ActionResult Patch(int vendorId, string inputName, string inputDescription, string inputAddress)
    {
      Vendor selectedVendor = Vendor.FindVendor(vendorId);
      selectedVendor.Name = inputName;
      selectedVendor.Description = inputDescription;
      selectedVendor.Address = inputAddress;
      return RedirectToAction("Show");
    }

  }
}