using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using WebApplication1.Services;
using WebApplication1.Validators;
using FluentValidation;
using WebApplication1.EndPoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IService, Service>();
//builder.Services.AddValidatorsFromAssemblyContaining<WarehouseProductValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.RegisterWarehouseEndpoint();

app.Run();