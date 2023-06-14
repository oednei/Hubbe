using Hubbe.Services.Restaurant.Data.Context;
using Hubbe.Services.Restaurant.Repositories.Interface;
using Hubbe.Services.Restaurant.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string strConnection = builder.Configuration.GetConnectionString("DefatulConnection");

builder.Services.AddDbContext<DataContext>(option => 
{
    option.UseSqlServer(strConnection);
});

builder.Services.AddScoped<IReservationRepository, ReservartionRepository>();
builder.Services.AddScoped<ITableRepository, TableRepository>();

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
