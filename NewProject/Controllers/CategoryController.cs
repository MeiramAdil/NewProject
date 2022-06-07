using Microsoft.AspNetCore.Mvc;
using NewProject.Data;

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
  }
}
