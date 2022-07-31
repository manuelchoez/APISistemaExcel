using SistemaExcel.Applicacion.Services;
using SistemaExcel.Applicacion.Services.Interfaces;
using SistemaExcel.Dominio.Repository;
using SistemaExcel.Infraestructura.Data;
using Serilog;
using SistemaExcel.Infraestructura.Log;
using SistemaExcel.Applicacion.Mapper.Interfaces;
using SistemaExcel.Applicacion.Mapper;
using SistemaExcel.Infraestructura.Token;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
.MinimumLevel.Debug()
.WriteTo.MongoDB("mongodb+srv://user_db:user_db_mch@cluster0.h3vyc.mongodb.net/infodb", "logdata", Serilog.Events.LogEventLevel.Warning)
.CreateLogger();

//builder.Host.UseSerilog((hostContext, services, configuration) => {
//    configuration = new SerilogHelper(hostContext.Configuration).SerilogConfigure();    
//});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});
// Add services to the container.
builder.Services.AddSingleton(Log.Logger);
builder.Services.AddScoped<IDataOneService, DataOneService>();
builder.Services.AddScoped<IDataOneRepository, DataOneRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IToken, Token>();
builder.Services.AddScoped<IMapear, Mapeo>();
builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseSerilog();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();    
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
