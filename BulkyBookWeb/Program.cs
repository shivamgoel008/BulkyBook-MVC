

using BulkyBookWeb.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// as we created this dependecy injection so there is no need of creating object of class
builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));


var app = builder.Build();

// Configure the HTTP request pipeline.
// pipeline specifies how application should respond to a web request when your application receives a request from the browser 
// order of pipeline is important 
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

// map the different pattern that we have for MVC 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
