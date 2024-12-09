using API_Best_Practice.Models;
using API_Best_Practice.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddScoped<BookService>();
builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost:6379")); // Redis bağlantı adresinizi buraya ekleyin
builder.Services.AddScoped<RedisCacheService>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
