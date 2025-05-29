using CashFlowPortal.Applicacion.Interfaces.IRepository;
using CashFlowPortal.Applicacion.Interfaces.IServices;
using CashFlowPortal.Applicacion.Interfaces.Repository;
using CashFlowPortal.Applicacion.Interfaces.Services;
using CashFlowPortal.Applicacion.Mappings;
using CashFlowPortal.Applicacion.Services;
using CashFlowPortal.Applicacion.Validator;
using CashFlowPortal.Infraestructura.Data;
using CashFlowPortal.Infraestructura.Repositories;
using CashFlowPortal.Web.Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();



builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<TipoGastoValidator>();

//Servicios
builder.Services.AddScoped<ITipoGastoService, TipoGastoService>();
builder.Services.AddScoped<IFondoMonetarioService, FondoMonetarioService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

//Repositorios
builder.Services.AddScoped<ITipoGastoRepository, TipoGastoRepository>();
builder.Services.AddScoped<IFondoMonetarioRepository, FondoMonetarioRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
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




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
