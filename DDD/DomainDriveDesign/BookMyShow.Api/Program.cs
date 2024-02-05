using BookMyShow.Application.Contracts;
using BookMyShow.Application.Services;
using BookMyShow.Infrastructure.Context;
using BookMyShow.Infrastructure.Contracts;
using BookMyShow.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DatabaseContext>();
builder.Services.AddScoped<ITicketApplicationService, TicketApplicationService>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
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
