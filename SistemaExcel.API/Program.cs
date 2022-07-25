using SistemaExcel.Applicacion.Services;
using SistemaExcel.Applicacion.Services.Interfaces;
using SistemaExcel.Dominio.Repository;
using SistemaExcel.Infraestructura.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddScoped<IDataOneService, DataOneService>();
builder.Services.AddScoped<IDataOneRepository, DataOneRepository>();
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
