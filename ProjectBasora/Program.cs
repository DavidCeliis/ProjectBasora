using ProjectBasora.Data;
using ProjectBasora.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = true;
})
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddAuthorization(
    options =>
    {
        options.AddPolicy("IsReader", policy =>
        {
            policy.RequireClaim("reader");
        });
        options.AddPolicy("IsLoaner", policy =>
        {
            policy.RequireClaim("loaner");
        });
        options.AddPolicy("IsUser", policy =>
        {
            policy.RequireClaim("user");
        });
        //Admins
        options.AddPolicy("IsTechnic", policy =>
        {
            policy.RequireClaim("technic");
        });
        options.AddPolicy("IsSuperUser", policy =>
        {
            policy.RequireClaim("superuser");
        });
        options.AddPolicy("IsOwner", policy =>
        {
            policy.RequireClaim("owner");
        });
    });
//builder.Services.AddRazorPages(options => {
//    options.Conventions.AuthorizeAreaFolder("Admin", "/", "IsOwner" + "IsTechnic" + "IsSuperUser");
//    options.Conventions.AuthorizeAreaFolder("SuperUser", "/", "IsSuperUser" + "IsOwner");
//    options.Conventions.AuthorizeAreaFolder("Owner", "/", "IsOwner");

//}
//);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
