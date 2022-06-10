using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewProject.Models;

namespace NewProject.Controllers
{
  public class CityController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
    public IActionResult Create()
    {
      List<User> users = new()
      {
        new User { id = 1, Name = "Adil", Age = 22 },
        new User { id = 2, Name = "Adilbek", Age = 222 },
        new User { id = 3, Name = "Adil", Age = 10 }
      };
      ViewBag.Users = new SelectList(users, "id", "Name");
      return View();
      //return Content($"{name} - {population} - {discript}");
    }
  }
}
