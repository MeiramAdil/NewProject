using Microsoft.AspNetCore.Identity;

namespace NewProject.Models
{
  public class AppplicationUser : IdentityUser
  {
    public DateTime BirthDateTime { get; set; }
  }
}
