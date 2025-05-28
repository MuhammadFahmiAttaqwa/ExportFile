using ExportFile;
using ExportFile.Repository;
using ExportFile.Repository.Impl;
using ExportFile.Service;
using ExportFile.Service.Impl;
using Rotativa.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IExportFile, ExportFileImpl>();

builder.Services.AddSingleton<ConnectionSql>();

builder.Services.AddSingleton<IDataRepository, DataRepository>();

var app = builder.Build();
var env = app.Services.GetRequiredService<IWebHostEnvironment>();
Rotativa.AspNetCore.RotativaConfiguration.Setup(env.WebRootPath, "Rotativa");


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
