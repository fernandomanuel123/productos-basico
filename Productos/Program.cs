using FluentValidation.AspNetCore;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Productos.Repository.Implementation;
using Productos.Service;
using Productos.Service.Implementation;
using Microsoft.AspNetCore.Builder;


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => {
    options.AddPolicy("Todos",
        builder => builder.WithOrigins("*").WithHeaders("*").WithMethods("*"));
});


// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(c =>
    c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));


builder.Services.AddTransient<IProductoRepository, ProductoRepository>();
builder.Services.AddTransient<IProductoService, ProductoService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API de productos",
        Description = "Esta API genera un CRUD de productos",
        Contact = new OpenApiContact
        {
            Name = "Fernando Murgueytio",
            Url = new Uri("https://github.com/fernandomanuel123")
        }
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "part2 v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("Todos");

app.Run();
