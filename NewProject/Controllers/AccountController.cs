using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewProject.Models;
using NewProject.ViewModels;

namespace NewProject.Controllers
{
  public class AccountController : Controller
  {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
      _userManager = userManager;
      _signInManager = signInManager;
    }
    [HttpGet]
    public IActionResult Register()
    {
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterView model)
    {
      if (ModelState.IsValid)
      {
        ApplicationUser user = new ApplicationUser { Email = model.Email, UserName = model.Email, BirthDateTime = model.Year };
        // добавляем пользователя
        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
          // установка куки
          await _signInManager.SignInAsync(user, false);
          return RedirectToAction("Index", "Home");
        }
        else
        {
          foreach (var error in result.Errors)
          {
            ModelState.AddModelError(string.Empty, error.Description);
          }
        }
      }
      return View(model);
    }
  }
}
