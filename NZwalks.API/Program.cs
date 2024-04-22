using Microsoft.EntityFrameworkCore;
using NZwalks.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NZWalksDbcontext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksConnectionString")));
builder.Services.AddDbContext<NZWalksDbcontext>(options => { var connectionString = builder.Configuration.GetConnectionString("NZWalksConnectionString"); options.UseSqlServer(connectionString, sqlServerOptions => { sqlServerOptions.MigrationsAssembly(typeof(NZWalksDbcontext).Assembly.FullName); }); });


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
