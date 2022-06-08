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
      var products = _db.Products;
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
      var p = _db.Products.Where(x => x.Id == id).FirstOrDefault();
      return View(p);
    }
    [HttpPost]
    public string Update(Product p)
    {
      var prod = _db.Products.Where(x => x.Id == p.Id).FirstOrDefault();
      prod = p;
      //if (prod != null)
      //{
      //  _db.Products.Update(prod);
      //}
      _db.SaveChanges();
      return $"Update {prod.Name}";
    }
    //Add
    [HttpGet]
    public IActionResult Add()
    {
      return View();
    }
    public string Add(Product p)
    {
      _db.Products.Add(p);
      _db.SaveChanges();
      return "Product added";
    }
  }
}
