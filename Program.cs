using AISAutoForms.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AISAutoForms.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddControllersWithViews();                 //Bryan
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(connectionString)); 
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
// Bryan: Configures ASP.NET Core Identity for user authentication and authorization, using
//        IdentityUser for users and IdentityRole for roles, and sets it to use Entity Framework Core
//        for data storage. It also adds the default Identity UI and token providers for features
//        like password reset and email confirmation.
builder.Services.AddIdentity<IdentityUser, IdentityRole>()  // Bryan: added this for Identity role
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI()                                         // Bryan: added this for Identity role
    .AddDefaultTokenProviders();                            // Bryan: added this for Identity role
//builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

// Bryan: We are creating a scope here to call the DbSeeder method
using (var scope = app.Services.CreateScope())
{
    await DbSeeder.SeedRolesAndAdminAsync(scope.ServiceProvider);
}

app.Run();
