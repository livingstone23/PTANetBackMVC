using Microsoft.OpenApi.Models;
using System.Reflection;
using ACD.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(opts =>
{
    opts.SwaggerDoc("v1", new OpenApiInfo { Title = "Alicunde API", Version = "v1" });

    //Enable Annotations
    opts.EnableAnnotations();

    // Configurar la documentación XML
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    opts.IncludeXmlComments(xmlPath);

});


///Extension method to register all the dependencies
builder.Services.AddAutoMapper(typeof(Program));

// Register the infrastructure dependencies
builder.Services.RegisterInfrastureDependencies(builder.Configuration);

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
