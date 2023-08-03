using Microsoft.EntityFrameworkCore;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RepositoryContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),
    options => options.MigrationsAssembly("StoreApp"));
});

var app = builder.Build();


app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseRouting();

app.MapControllerRoute(
    name: "defaullt",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
