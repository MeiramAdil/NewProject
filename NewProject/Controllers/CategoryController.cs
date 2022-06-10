using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    //Update
    [HttpGet]
    public IActionResult Update(int id)
    {
      if (id != 0)
      {
        var c = _db.Categories.Where(x => x.Id == id).FirstOrDefault();
        return View(c);
      }
      else return NotFound("Похоже этого объекта не существует");
    }
    [HttpPost]
    public string Update(Category c)
    {
      if (c != null)
      {
        _db.Categories.Update(c);
        _db.SaveChanges();
        return $"Update {c.CategoryName}";
      }
      else return "Похоже что то пошло не так";

    }
    //Add
    [HttpGet]
    public IActionResult Add()
    {
      return View();
    }
    public string Add(Category c)
    {
      if (c != null)
      {
        _db.Categories.Add(c);
        _db.SaveChanges();
        return "Category added";
      }
      else return "Похоже что то пошло не так";
    }
    //Delete
    [HttpGet]
    public IActionResult Delete(string id)
    {
      int a = int.Parse(id);
      if (a != 0)
      {
        ViewBag.CategoryId = a;
        return View(a);
      }
      else return NotFound("Похоже этого объекта уже не существует");
    }
    
    [HttpPost]
    public string Delete(int id)
    {
      try
      {
        var category = _db.Categories.Include(x => x.ProductList).FirstOrDefault(x => x.Id == id);
        if (category.ProductList.Count > 0)
        {
          return "Есть ссылки на обьекты";
        }
        _db.Categories.Remove(category);
        _db.SaveChanges();
      }
      catch (Exception e)
      {
        return $"{e.Message}";
      }

      return "Product is deleted";
    }
  }
}
