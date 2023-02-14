using Microsoft.EntityFrameworkCore;
using TaskTestWebApi.Commons.Mappings;
using TaskTestWebApi.Data;
using TaskTestWebApi.Data.Repositories;
using TaskTestWebApi.Models;
using TaskTestWebApi.Utility.Parser;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("postgresDB"));
});

builder.Services.AddAutoMapper(typeof(MappingProfiler));
builder.Services.AddTransient<IParser, CsvParser>();
builder.Services.AddScoped<IValueRepository, ValueRepository>();
builder.Services.AddScoped<IRepository<Result>, ResultRepository>();

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

    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
