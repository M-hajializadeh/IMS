using IMS.Plugin.DataStore;
using IMS.Plugin.SQLDataStore;
using IMS.UseCases.DataStorePluginInterfaces;
using IMS.UseCases.DataStoreUseCase.Category;
using IMS.UseCases.DataStoreUseCase.ProductsInCategory;
using IMS.UseCases.DataStoreUseCase.ProductUseCase;
using IMS.UseCases.DataStoreUseCase.Transactions;
using IMS.WebApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

#region Get Connection
var AccountconnectionString = builder.Configuration.GetConnectionString("AccountDbContextConnection");
var AppDefualtconnectionString = builder.Configuration.GetConnectionString("DefualtConnection");

builder.Services.AddDbContext<AccountDbContext>(options =>
    options.UseSqlServer(AccountconnectionString));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AccountDbContext>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(AppDefualtconnectionString);   
});
#endregion

#region Auth Policy
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", p => p.RequireClaim("Position", "Admin"));
    options.AddPolicy("WorkerOnly", p => p.RequireClaim("Position", "Worker"));
});
#endregion

#region DI

//DI for Storage in memory
//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<ITransactionRepository,TransactionRepository>();

//DI for sql server storage
builder.Services.AddScoped<ICategoryRepository, IMS.Plugin.SQLDataStore.Repositories.CategoryRepository>();
builder.Services.AddScoped<IProductRepository, IMS.Plugin.SQLDataStore.Repositories.ProductRepository>();
builder.Services.AddScoped<ITransactionRepository, IMS.Plugin.SQLDataStore.Repositories.TransactionRepository>();

//DI for use case
builder.Services.AddTransient<IViewCategoryUseCase, ViewCategoryUseCase>();
builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
builder.Services.AddTransient<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();   
builder.Services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();
builder.Services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
builder.Services.AddTransient<IProductUseCase, ProductUseCase>();
builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();
builder.Services.AddTransient<IGetProductUseCase, GetProductUseCase>();
builder.Services.AddTransient<IEditProductUseCase, EditProductUseCase>();
builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
builder.Services.AddTransient<IGetProductsInCategoryUseCase, GetProductsInCategoryUseCase>();
builder.Services.AddTransient<ICheckOutProductUseCase, CheckOutProductUseCase>();
builder.Services.AddTransient<IRecordTransactionUseCase, RecordTransactionUseCase>();
builder.Services.AddTransient<IGetTodayTransactionUseCase, GetTodayTransactionUseCase>();
builder.Services.AddTransient<IGetTransactionsUseCase, GetTransactionsUseCase>();
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
