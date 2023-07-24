var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllerRoute(
    name: "defaullt",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
