using Microsoft.EntityFrameworkCore;
using PracticalTaskGNIS.DbCon;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DBConContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConStringGNIS")));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "getCustomerNames",
    pattern: "Meeting/GetCustomerNames",
    defaults: new { controller = "Meeting", action = "GetCustomerNames" }
);

app.Run();
