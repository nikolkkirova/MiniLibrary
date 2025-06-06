using Microsoft.EntityFrameworkCore;
using MiniLibrary.Data;
using Microsoft.AspNetCore.Identity;    
using MiniLibrary.Models;

var builder = WebApplication.CreateBuilder(args);

// Добавяме DbContext-а и връзката към SQL Server
builder.Services.AddDbContext<MiniLibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MiniLibraryContext") ?? throw new InvalidOperationException("Connection string 'MiniLibraryContext' not found.")));

// Add services to the container.
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<MiniLibraryContext>();

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline. 
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();
app.MapDefaultControllerRoute();
app.Run();
