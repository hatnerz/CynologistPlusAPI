using Microsoft.EntityFrameworkCore;
using WebAPI.DataBase;
using WebAPI.DI;
using WebAPI.Helpers;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container (services dependency injection).
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IHashService, HashService>();
builder.Services.AddScoped<IDbControlService, DbControlService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IDogService, DogService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<ITrainingCenterService, TrainingCenterService>();
builder.Services.AddSingleton<ConfigurationHelper>();
builder.Services.AddScoped<IManagerService, ManagerService>();

// Configuring Entity Framework context
builder.Services.AddDbContext<CynologistPlusContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("default")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// TODO: Configure CORS later during deployment
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

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

app.UseCors("AllowAll");

app.Run();
