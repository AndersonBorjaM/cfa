using Domain.Config;
using Domain.Repositories;
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using Repository.Database;
using Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
//builder.Services.AddScoped<IPhoneRepository, ClientService>();

builder.Services.AddDbContext<ApplicationContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationConnection")));


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
