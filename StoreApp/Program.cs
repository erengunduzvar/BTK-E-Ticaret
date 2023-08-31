using StoreApp.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//Service Extension
builder.Services.ConfigureDbContext(builder.Configuration);
//Service Extension
builder.Services.ConfigureSession();
//Service Extension
builder.Services.ConfigureRepositoryRegistration();
//Service Extension
builder.Services.ConfigureServiceRegistration();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name:"Admin",
        areaName:"Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();
});

//ApplicationExtension
app.ConfigureAndCheckMigration();


app.Run();
