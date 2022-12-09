using smartcollecttv.api.Data.Context;
using smartcollecttv.api.Data.Implementation;
using smartcollecttv.api.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<DbContext>(x => 
{
    return new DbContext(
        builder.Configuration["AzureCosmosConnectionString"]!,
        builder.Configuration["AzureCosmosDbName"]!,
        builder.Configuration["CollectionPointContainer"]!,
        builder.Configuration["DrivertContainer"]!,
        builder.Configuration["IotSensortContainer"]!,
        builder.Configuration["RoutestContainer"]!,
        builder.Configuration["VehicleContainer"]!);
});

builder.Services.AddScoped<ICollectionPointRepository, CollectionPointRepository>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IIotSensorRepository, IotSensorRepository>();
builder.Services.AddScoped<IRouteRepository, RouteRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
