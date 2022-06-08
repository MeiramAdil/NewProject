
using NewProject.Data;
using NewProject.Models;

namespace NewProject
{
  public static class SampleData
  {
    public static void InitializeProducts(MobileContext context)
    {
      if (!context.Products.Any())
      {
        context.Products.AddRange(
            new Product
            {
              Name = "Iphone 11",
              Description = " Company: Apple",
              Price = 600,
              CategoryId = 1
            },
            new Product
            {
              Name = "S2",
              Description = "Company: Samsunng",
              Price = 700,
              CategoryId = 1
            },
            new Product
            {
              Name = "Война и мир",
              Description = "Автор: Лев Толстой",
              Price = 50,
              CategoryId = 2
            },
            new Product
            {
              Name = "Абай жолы",
              Description = "Автор: Мұхтар Әуезов",
              Price = 100,
              CategoryId = 2
            },
            new Product
            {
              Name = "A31",
              Description = "Company: Xiaomi",
              Price = 400,
              CategoryId = 1
            }
            );
        context.SaveChanges();
      }
     
    }
    public static void InitializeCategory(MobileContext context)
    {
      if (!context.Categories.Any())
      {
        context.Categories.AddRange(
          new Category
          {
            CategoryName = "Phone"
          },
          new Category
          {
            CategoryName = "Book"
          });
        context.SaveChanges();
      }
    }
  }
}

