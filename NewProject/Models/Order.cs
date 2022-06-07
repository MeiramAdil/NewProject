namespace NewProject.Models
{
  public class Order
  {
    public int OrderId { get; set; }
    public string User { get; set; }
    public string Addres { get; set; }
    public string ContactPhone { get; set; }
    public int ProductId { get; set; }
    public Product product { get; set; }
  }
}
