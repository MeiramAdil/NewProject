using Microsoft.EntityFrameworkCore;
using NewProject;
using NewProject.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var config = builder.Configuration;
string connection = config.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MobileContext>(options => options.UseSqlServer(connection));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var services = app.Services.CreateScope().ServiceProvider;
var context = services.GetRequiredService<MobileContext>();
SampleData.InitializeCategory(context);
SampleData.InitializeProducts(context);

app.Run();
