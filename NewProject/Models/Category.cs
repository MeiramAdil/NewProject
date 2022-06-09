namespace NewProject.Models
{
  public class Category
  {
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public List<Product>? ProductList { get; set; }
  }
}
