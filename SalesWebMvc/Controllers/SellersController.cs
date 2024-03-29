﻿using Microsoft.AspNetCore.Mvc;
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
    [ValidateAntiForgeryToken]
    public IActionResult Create(Seller seller)
    {
      _sellerService.Insert(seller);
      return RedirectToAction("Index");
    }
    public IActionResult Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }
      var seller = _sellerService.FindById(id.Value);
      if (seller == null)
      {
        return NotFound();
      }
      return View(seller);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
      _sellerService.Remove(id);
      return RedirectToAction("Index");
    }
  }
}