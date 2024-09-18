using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.OData.Edm;
using PersonEntity.Models;  // Adjust to match your actual namespace


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add OData services to the container
builder.Services.AddControllers().AddOData(options =>
{
    // Enable OData features like Select, Filter, OrderBy, etc.
    options.Select().Filter().OrderBy().Expand().Count();

    // Add OData route components with the EDM model (Entity Data Model)
    options.AddRouteComponents("odata", GetEdmModel());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();   // This enables routing in your application

app.UseAuthorization();

// Add OData and MVC routing
app.MapControllers();  // This is required for OData and MVC controllers

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();  // Ensure controllers are mapped
});

app.Run();

// Function to configure the OData EDM model
IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<Person>("People");  // 'People' is the OData EntitySet for the Person entity
    return builder.GetEdmModel();
}

builder.Services.ConfigureControllersWithViews(setup =>
{
    setup.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Weather Forecasts",
        Version = "v1"
    });
});