using CustomerAPI.Data;
using CustomerAPI.Interface;
using CustomerAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
// crud operation in sql memory instead of store in database using usein memory database
//builder.Services.AddDbContext<CustomerDBContext>(options => options.UseInMemoryDatabase("CustomerDb"));

// Using below line u can connect any database like use sql use post sql oracle etc.
//If you try to migrage database using CORD way use Add-Migration "Initial Migration" and Update-database command in nuget console
builder.Services.AddDbContext<CustomerDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerConnectionString")));
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
