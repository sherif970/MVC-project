using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<entities>(OptionsBuilder =>
{
    OptionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=master;Integrated Security=True");
});
builder.Services.AddIdentity<applicationuser, IdentityRole>(Options =>
{
    Options.Password.RequireUppercase = false;
    Options.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<entities>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
