using Microsoft.AspNetCore.Mvc;

namespace NewProject.Controllers
{
  public class ProductController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
