using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RepositoryContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),
    options => options.MigrationsAssembly("StoreApp"));
});

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build(); 


app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseRouting();

app.MapControllerRoute(
    name: "defaullt",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
