using SpiceNRice.Client;
using SpiceNRice;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders()
    .AddRoles<IdentityRole>()
    //(options => options.SignIn.RequireConfirmedAccount = false)
    
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton(x =>
new PaypalClient(
    builder.Configuration["PayPalOptions:ClientId"],
    builder.Configuration["PayPalOptions:ClientSecret"],
    builder.Configuration["PayPalOptions:Mode"]
    ));

builder.Services.AddScoped<CartDetail>();
builder.Services.AddScoped<ShoppingCart>();

builder.Services.AddTransient<IHomeRepository, HomeRepository>();
builder.Services.AddTransient<ICartRepository, CartRepository>();
builder.Services.AddTransient<IUserOrderRepository, UserOrderRepository>();

builder.Services.AddCoreAdmin();

var app = builder.Build();
// Uncomment it when you run the project first time, It will registered an admin
//using (var scope = app.Services.CreateScope())
//{
  //  await DbSeeder.SeedDefaultData(scope.ServiceProvider);
//}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.UseCoreAdminCustomUrl("MyAdmin");

app.Run();