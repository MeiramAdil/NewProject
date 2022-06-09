using Microsoft.AspNetCore.Mvc;
using NewProject.Data;
using NewProject.Models;

namespace NewProject.Controllers
{
  public class ProductController : Controller
  {
    private readonly MobileContext _db;

    public ProductController(MobileContext context)
    {
      _db = context;
    }
    public IActionResult Index()
    {
      var products = _db.Products.ToList();
      return View(products);
    }

    //Buy
    [HttpGet]
    public IActionResult Buy(int id)
    {
      ViewBag.ProductId = id;
      return View();
    }
    [HttpPost]
    public string Buy(Order o)
    {
      _db.Orders.Add(o);
      _db.SaveChanges();
      return $"Thanks for purchasing {o.User}";
    }

    //Update
    [HttpGet]
    public IActionResult Update(int id)
    {
      if (id != 0)
      {
        var p = _db.Products.Where(x => x.Id == id).FirstOrDefault();
        return View(p);
      }
      else return NotFound("Похоже этого объекта не существует");
    }
    [HttpPost]
    public string Update(Product p)
    {
      if (p != null)
      {
        _db.Products.Update(p);
        _db.SaveChanges();
        return $"Update {p.Name}";
      }
      else return "Похоже что то пошло не так";

    }
    //Add
    [HttpGet]
    public IActionResult Add()
    {
      return View();
    }
    public string Add(Product p)
    {
      if (p != null)
      {
        _db.Products.Add(p);
        _db.SaveChanges();
        return "Product added";
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
        ViewBag.ProductId = a;
        return View(a);
      }
      else return NotFound("Похоже этого объекта уже не существует");
    }
    [HttpPost]
    public string Delete(int id)
    {
      _db.Products.Remove(_db.Products.Where(x => x.Id == id).FirstOrDefault());
      _db.SaveChanges();
      return "Product is deleted";
    }
  }
}
