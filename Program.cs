using crowdfarming.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
// db connection from appsettings.json
 builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
 ,
 sqlServerOptionsAction: sqlOptions =>
 {
     sqlOptions.EnableRetryOnFailure(
         maxRetryCount: 5,
         maxRetryDelay: TimeSpan.FromSeconds(30),
         errorNumbersToAdd: null);
 }));
 
// builder.Services.AddDbContext<DatabaseContext>(options =>
//     options.UseSqlServer(
//         Configuration.GetConnectionString("DefaultConnection"),
//         sqlServerOptionsAction: sqlOptions =>
//         {
//             sqlOptions.EnableRetryOnFailure(
//                 maxRetryCount: 5, 
//                 maxRetryDelay: TimeSpan.FromSeconds(30), 
//                 errorNumbersToAdd: null);
//         }));


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DatabaseContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
