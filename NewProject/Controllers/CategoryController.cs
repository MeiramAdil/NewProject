using Microsoft.AspNetCore.Mvc;
using NewProject.Data;
using NewProject.Models;

namespace NewProject.Controllers
{
  public class CategoryController : Controller
  {
    private readonly MobileContext _db;
    public CategoryController(MobileContext context)
    {
      _db = context;
    }
    public IActionResult Index()
    {
      var categories = _db.Categories.ToList();
      return View(categories);
    }
    [HttpGet]
    public IActionResult ProductsByCategory(int id)
    {
      ViewBag.CategoryId = id;
      var products = _db.Products.ToList();
      return View(products);
    }

  }
}
