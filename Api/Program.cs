using Api.Extensions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//* Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllers();

//*Api Extensions
builder.Services.AddApiServices();
builder.Services.ConfigureRateLimiting();
builder.Services.ConfigureVersioning();
builder.Services.ConfigureCors();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//*DbContext Configuration
builder.Services.AddDbContext<ApiContext>(opts =>{
    string connection = builder.Configuration.GetConnectionString("ConnectionWindows") ?? throw new Exception("Fatal Error: cannot connect to database");

    opts.UseMySql(connection,ServerVersion.AutoDetect(connection));
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

//*Api Extensions
app.UseRateLimiter();
app.UseCors("CorsPolicy");
app.UseApiVersioning();

app.MapControllers();

app.Run();
