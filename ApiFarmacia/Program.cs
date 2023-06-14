using ApiFarmacia.Autentication;
using ApiFarmacia.Services;
using Infra;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);

builder.Services.AddAuthentication(configureOptions:AuthenticationOptions =>
{
    x.DefaultAuthenticationScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeSchema = JwtBearerDefaults.AuthenticationScheme;
});


// Add services to the container.

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddTransient<TokenService>(); // Sempre criar um novo
/*builder.Services.AddTransient<TokenService>(); // Transação
builder.Services.AddTransient<TokenService>(); // Singleton -> 1 por App!*/

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
