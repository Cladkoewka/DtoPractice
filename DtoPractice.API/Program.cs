using DtoPractice.Application.Services;
using DtoPractice.Application.Services.Mapping;
using DtoPractice.Application.Services.Mapping.AutoMapper;
using DtoPractice.Application.Services.Mapping.Mapster;
using DtoPractice.Infrastructure;
using DtoPractice.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

services.AddScoped<IProductRepository, ProductRepository>();


services.AddScoped<IProductService, ProductService>();

//services.AddScoped<IProductMapper, ProductMapperManual>();
//services.AddScoped<IProductMapper, ProductMapperMapster>();

services.AddAutoMapper(typeof(ProductProfile));

services.AddScoped<IProductMapper, ProductMapperAutoMapper>();

services.AddControllers();

services.AddEndpointsApiExplorer();  
services.AddSwaggerGen(c =>  
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DtoPractice API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "DtoPractice API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.MapControllers();


app.Run();