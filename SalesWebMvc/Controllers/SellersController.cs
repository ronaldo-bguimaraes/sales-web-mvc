using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
  public class SellersController : Controller
  {
    private readonly SellerService _sellerService;
    private readonly DepartmentService _departmentService;

    public SellersController(SellerService sellerService, DepartmentService departmentService)
    {
      _sellerService = sellerService;
      _departmentService = departmentService;
    }

    public IActionResult Index()
    {
      var list = _sellerService.FindAll();
      return View(list);
    }
    public IActionResult Create()
    {
      var viewModel = new SellerFormViewModel()
      {
        Departments = _departmentService.FindAll()
      };
      return View(viewModel);
    }
    [HttpPost]
    public IActionResult Create(Seller seller)
    {
      _sellerService.Insert(seller);
      return RedirectToAction("Index");
    }
  }
}