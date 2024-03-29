using SistemaExcel.Applicacion.Services;
using SistemaExcel.Applicacion.Services.Interfaces;
using SistemaExcel.Dominio.Repository;
using SistemaExcel.Infraestructura.Data;
using Serilog;
using SistemaExcel.Infraestructura.Log;
using SistemaExcel.Applicacion.Mapper.Interfaces;
using SistemaExcel.Applicacion.Mapper;
using SistemaExcel.Infraestructura.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:audienceToken"],
        ValidIssuer = builder.Configuration["Jwt:issuerToken"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:secretKey"]))
    };    
});

// Add services to the container.
builder.Services.AddSingleton(Log.Logger);
builder.Services.AddScoped<IDataOneService, DataOneService>();
builder.Services.AddScoped<IDataOneRepository, DataOneRepository>();
builder.Services.AddScoped<IDataTwoService, DataTwoService>();
builder.Services.AddScoped<IDataTwoRepository, DataTwoRepository>();
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

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
