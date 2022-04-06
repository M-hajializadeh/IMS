using IMS.Plugin.DataStore;
using IMS.UseCases.DataStorePluginInterfaces;
using IMS.UseCases.DataStoreUseCase;
using IMS.UseCases.DataStoreUseCase.Category;
using IMS.UseCases.DataStoreUseCase.ProductsInCategory;
using IMS.UseCases.DataStoreUseCase.ProductUseCase;
using IMS.UseCases.DataStoreUseCase.Transactions;
using IMS.WebApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

//DI for Storage
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ITransactionRepository,TransactionRepository>();
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
