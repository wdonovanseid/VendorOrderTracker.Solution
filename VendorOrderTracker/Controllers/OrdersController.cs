using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VendorOrderTracker.Models;

namespace VendorOrderTracker.Controllers
{
  public class OrdersController : Controller
  {

    [HttpGet("/vendors/{vendorId}/orders/new")]
    public ActionResult New(int vendorId)
    {
      Vendor vendor = Vendor.FindVendor(vendorId);
      return View(vendor);
    }

    [HttpGet("/vendors/{vendorId}/orders/{orderId}")]
    public ActionResult Show(int vendorId, int orderId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor vendor = Vendor.FindVendor(vendorId);
      Order order = Order.FindOrder(orderId);
      model.Add("vendor", vendor);
      model.Add("order", order);
      return View(model);
    }

    [HttpGet("/vendors/{vendorId}/orders/{orderId}/edit")]
    public ActionResult Edit(int vendorId, int orderId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor vendor = Vendor.FindVendor(vendorId);
      Order order = Order.FindOrder(orderId);
      model.Add("vendor", vendor);
      model.Add("order", order);
      return View(model);
    }

    [HttpPost("/vendors/{vendorId}/orders/{orderId}")]
    public ActionResult Patch(int vendorId, int orderId, string inputTitle, string inputDescription, string inputPrice, string inputDate)
    {
      Vendor selectedVendor = Vendor.FindVendor(vendorId);
      Order selectedOrder = selectedVendor.FindOrderInVendor(orderId);
      selectedOrder.Title = inputTitle;
      selectedOrder.Description = inputDescription;
      selectedOrder.Price = inputPrice;
      selectedOrder.Date = inputDate;
      return RedirectToAction("Show");
    }
  }
}