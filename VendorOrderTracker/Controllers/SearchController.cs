using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VendorOrderTracker.Models;

namespace VendorOrderTracker.Controllers
{
  public class SearchController : Controller
  {

    [HttpGet("/search")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet("/search/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/search")]
    public ActionResult Create(string inputVendorName)
    {
      List<Vendor> matchingVendors = new List<Vendor>{};
      List<Vendor> allVendors = Vendor.GetAllVendors();
      foreach (Vendor vendor in allVendors)
      {
        if (vendor.Name.ToUpper().Contains(inputVendorName.ToUpper()))
        {
          matchingVendors.Add(vendor);
        }
      }
      return View("Index", matchingVendors);
    }

  }
}