using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SteamCloneApp.Business;
using SteamCloneApp.DataAccess;
using SteamCloneApp.DataAccess.Repositories.EntityFramework.Contexts;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/auth/login";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        option.AccessDeniedPath = "/";
        option.ReturnUrlParameter = "";
    });


builder.Services.LoadBusiness();
builder.Services.LoadDataAccess(builder.Configuration);

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

app.UseAuthentication();

app.UseAuthorization();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope())
{
    scope?.ServiceProvider.GetRequiredService<SteamCloneContext>().Database.Migrate();
}

app.Run();
