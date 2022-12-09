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
        builder.Configuration["collectionPointContainer"]!);
});

builder.Services.AddScoped<ICollectionPointRepository, CollectionPointRepository>();

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
