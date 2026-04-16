using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MinhaLojaAPI.Data;
using MinhaLojaAPI.Extensions;
using MinhaLojaAPI.Repositories;
using MinhaLojaAPI.Services;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddScoped<ICategoryRespository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services
	.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		var signingKey = builder.Configuration["Jwt:Secret"];
		var issuer = builder.Configuration["Jwt:Issuer"];
		var audience = builder.Configuration["Jwt:Audience"];
		var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey!));

		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateIssuerSigningKey = true,

			ValidIssuer = issuer,
			ValidAudience = audience,
			IssuerSigningKey = securityKey
		};
	});

builder.Services.AddAuthorization();

builder.Services.AddSqlite<AppDbContext>("Data Source=MinhaLoja.db");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
	app.ApplyMigrations();
}

app.MapScalarApiReference();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
