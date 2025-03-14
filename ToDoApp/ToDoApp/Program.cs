using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ToDoApp.Models;
using ToDoApp.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDutyRepository, DutyRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();

builder.Services.AddScoped<IPriorityRepository, PriorityRepository>();


builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication().AddCookie();
builder.Services.AddDbContext<ToDoAppDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoAppDbContextConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ToDoAppDbContext>();
    //context.Database.EnsureCreated();
    DbInitializer.Seed(context);
}
app.Run();
