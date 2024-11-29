using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TaskManager.Contracts;
using TaskManager.Data.Implementation;
using TaskManager.Endpoints;
using TaskManager.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
         options.UseInMemoryDatabase("ApplicationDb"));

builder.Services.AddScoped<ITodoService, TodoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

TodoEndpoints.Map(app);

app.Run();


