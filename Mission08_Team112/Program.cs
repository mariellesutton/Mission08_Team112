using Microsoft.EntityFrameworkCore;
using Mission08_Team112.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the SQLite Database Context
builder.Services.AddDbContext<TaskContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TaskConnection")));

// Register the Repository for Dependency Injection (Repository Pattern)
builder.Services.AddScoped<ITaskRepository, EFTaskRepository>();

var app = builder.Build();

// Ensure database is created and seed categories if empty (Home, School, Work, Church)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TaskContext>();
    db.Database.EnsureCreated();
    if (!db.Categories.Any())
    {
        db.Categories.AddRange(
            new Category { CategoryName = "Home" },
            new Category { CategoryName = "School" },
            new Category { CategoryName = "Work" },
            new Category { CategoryName = "Church" });
        db.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Task}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
