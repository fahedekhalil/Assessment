using AutoMapper;
using CustomerOrderServiceAPI.Data;
using CustomerOrderServiceAPI.Middleware;
using CustomerOrderServiceAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("CustomerOrderDb"));
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerOrderService, CustomerOrderService>();
builder.Services.AddScoped<ITenantProvider, TenantProvider>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "");
        c.RoutePrefix = string.Empty;
    });
}

app.UseRouting();
app.UseMiddleware<TenantMiddleware>();
app.MapControllers();

app.Run();