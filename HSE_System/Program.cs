using Microsoft.EntityFrameworkCore;
using HSE.Web.Infrastructure.Data;
using HSE.Web.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("HseDb"));
builder.Services.AddScoped<IHseService, HseService>();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
