using Administration.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Plugins.DataStore.SQL;
using UseCases.CategoriesUseCases;
using UseCases.DataStorePluginInterfaces;
using UseCases.ProductUseCases;
using UseCases.UseCaseInterfaces;
using Microsoft.AspNetCore.Identity;
using System.Configuration;
using Microsoft.Extensions.Options;
using UseCases.Transactions;
using Administration.Services;
using Administration;
using StackExchange.Redis;
using Administration.Areas.Identity.Data;





var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();




builder.Configuration.AddJsonFile("appsettings.json");


builder.Services.AddDbContext<MarketContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 26)));
});
builder.Services.AddDbContext<AccountContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 26)));
});


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AccountContext>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", p => p.RequireClaim("Position", "Admin"));
    options.AddPolicy("CashierOnly", p => p.RequireClaim( "Position", "Cashier"));
});

builder.Services.AddIdentityCore<IdentityUser>(opt => 
{

})
.AddEntityFrameworkStores<AccountContext>()
.AddSignInManager<SignInManager<IdentityUser>>();

builder.Services.AddSingleton<IConnectionMultiplexer>(c => {
    var options = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"));
    return ConnectionMultiplexer.Connect(options);
});

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();    


builder.Services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
builder.Services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();
builder.Services.AddTransient<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();
builder.Services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
builder.Services.AddTransient<IViewProductsUseCase, ViewProductsUseCase>();
builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();
builder.Services.AddTransient<IEditProductUseCase, EditProductUseCase>();
builder.Services.AddTransient<IGetProductByIdUseCase, GetProductByIdUseCase>();
builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
builder.Services.AddTransient<IViewProductsByCategoryId, ViewProductsByCategoryId>();
builder.Services.AddTransient<ISellProductUseCase, SellProductUseCase>();
builder.Services.AddTransient<IRecordTransactionUseCase, RecordTransactionUseCase>();
builder.Services.AddTransient<IGetTodayTransactionUseCase, GetTodayTransactionUseCase>();
builder.Services.AddTransient<IGetTransactionsUseCase, GetTransactionsUseCase>();
builder.Services.AddScoped<PointsService>();
builder.Services.AddScoped<ApplicationUser>();





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
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();


app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
var context = app.Services.GetRequiredService<MarketContext>();
var IdentityContext = app.Services.GetRequiredService<AccountContext>();
var userManager = app.Services.GetRequiredService<UserManager<IdentityUser>>();
var logger = app.Services.GetRequiredService<ILogger<Program>>();
try
{
     await context.Database.MigrateAsync();
    await IdentityContext.Database.MigrateAsync();
    await AccountContextSeed.SeedUsersAsync(userManager);
}
catch (Exception ex)
{
    
    logger.LogError(ex, "An error occured during migration");
}

app.Run();
