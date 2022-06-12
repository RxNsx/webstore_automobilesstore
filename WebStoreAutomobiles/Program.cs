using Microsoft.EntityFrameworkCore;
using WebStoreAutomobiles.Models;

var builder = WebApplication.CreateBuilder(args);

//Подключаем файл контекста и базу данных через json 
builder.Services.AddDbContext<WebStoreDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:WebStoreConnection"]);
});

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("pagination",
        "Products/Page{productPage}",
        new { Controller = "Home", action = "Catalog" });
    endpoints.MapDefaultControllerRoute();
});

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//Заполнить таблицу первоначальными данными по автомобилям
SeedProductData.EnsurePopulated(app);
app.Run();
