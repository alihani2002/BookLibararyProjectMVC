using BookLibarary.Data_Context;
using BookLibarary.Helpers;
using BookLibarary.Models;
using BookLibarary.Repos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DB_Context>(options =>
{ options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]); });
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddScoped<ICategoryRepos,CategoryRepos>();
builder.Services.AddScoped<IBookRepos, BookRepos>();

//fluint validation
builder.Services.AddValidatorsFromAssembly(typeof(Book).Assembly);

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

DbIntializer.Seed(app);

app.Run();
