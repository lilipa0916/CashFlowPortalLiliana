using CashFlowPortal.Applicacion.Interfaces.IRepository;
using CashFlowPortal.Applicacion.Interfaces.IServices;
//using JwtSettings = CashFlowPortal.Applicacion.Services.JwtSettings;
//using JwtTokenService = CashFlowPortal.Applicacion.Services.JwtTokenService;
//using TipoGastoService = CashFlowPortal.Applicacion.Services.TipoGastoService;
//using UsuarioService = CashFlowPortal.Applicacion.Services.UsuarioService;
using CashFlowPortal.Applicacion.Interfaces.Repository;
using CashFlowPortal.Applicacion.Interfaces.Services;
using CashFlowPortal.Applicacion.Services;
using CashFlowPortal.Applicacion.Services;
using CashFlowPortal.Applicacion.Validator;
using CashFlowPortal.Infraestructura.Data;
using CashFlowPortal.Infraestructura.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CashFlowPortal.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Habilita los CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularClient",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200")
                              .AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowCredentials(); // si usas cookies
                    });
            });

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
            builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

            var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
            var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                };
            });

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<TipoGastoValidator>();
            //Servicios

            builder.Services.AddScoped<ITipoGastoService, TipoGastoService>();
            builder.Services.AddScoped<IFondoMonetarioService, FondoMonetarioService>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
            builder.Services.AddScoped<IAuthService, AuthService>();

            // Repositorios
            builder.Services.AddScoped<ITipoGastoRepository, TipoGastoRepository>();
            builder.Services.AddScoped<IFondoMonetarioRepository, FondoMonetarioRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IAuthRepository, AuthRepository>();


            // Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "CashFlowPortal API", Version = "v1" });
                var xmlPath = Path.Combine(AppContext.BaseDirectory, "Api.xml");
                c.IncludeXmlComments(xmlPath);
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseCors("AllowAngularClient");

            // Configure the HTTP request pipeline.
            app.UseCors(policy =>
            policy.WithOrigins("https://localhost:5001/")
          .AllowAnyHeader()
          .AllowAnyMethod()
          .AllowCredentials());

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CashFlowPortal API V1");
                c.RoutePrefix = "swagger";
            });


            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseAuthentication();
            app.MapControllers();

            app.Run();
        }
    }
}
