using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Project.Application.Interfaces;
using Project.Infrastructure.Data;
using Project.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(Options =>
    Options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));



// MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.Load("Project.Application"))
);

// Repositórios
builder.Services.AddScoped<IUserRepository, UserRepository>();








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

app.Run();
