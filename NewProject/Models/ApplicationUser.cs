
using Microsoft.AspNetCore.Identity;

namespace NewProject.Models
{
  public class ApplicationUser : IdentityUser
  {
    public DateTime BirthDateTime { get; set; }
  }
}
