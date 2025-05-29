
using CashFlowPortal.Applicacion.Interfaces;
using CashFlowPortal.Infraestructura.Auth;
using CashFlowPortal.Infraestructura.Persistencia;
using CashFlowPortal.Infraestructura.Services;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace CashFlowPortal.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
            builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

            var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
            var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);

            builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };
                });


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

            app.UseAuthentication();
            app.MapControllers();

            app.Run();
        }
    }
}
