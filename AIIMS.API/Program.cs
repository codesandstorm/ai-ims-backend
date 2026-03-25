using AIIMS.Application.Auth;
using AIIMS.Application.Services;
using AIIMS.Infrastructure.Auth;
using AIIMS.Infrastructure.Data;
using AIIMS.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// =============================
// CONTROLLERS
// =============================
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// =============================
// DATABASE
// =============================
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection") ??
    builder.Configuration["ConnectionStrings__DefaultConnection"];

if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("❌ DATABASE CONNECTION STRING MISSING");
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// =============================
// SERVICES
// =============================
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();

// =============================
// 🔥 JWT CONFIG (SAFE VERSION)
// =============================
var jwtKey =
    builder.Configuration["Jwt:Key"] ??
    builder.Configuration["Jwt__Key"];

var issuer =
    builder.Configuration["Jwt:Issuer"] ??
    builder.Configuration["Jwt__Issuer"];

var audience =
    builder.Configuration["Jwt:Audience"] ??
    builder.Configuration["Jwt__Audience"];

// 🔥 DEBUG LOG (IMPORTANT)
Console.WriteLine("JWT KEY: " + (jwtKey ?? "NULL"));
Console.WriteLine("ISSUER: " + (issuer ?? "NULL"));
Console.WriteLine("AUDIENCE: " + (audience ?? "NULL"));

// 🔥 HARD FAIL WITH CLEAR ERROR
if (string.IsNullOrEmpty(jwtKey))
{
    throw new Exception("❌ JWT KEY NOT FOUND IN ENV VARIABLES");
}

var key = Encoding.UTF8.GetBytes(jwtKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = issuer,
        ValidAudience = audience,

        IssuerSigningKey = new SymmetricSecurityKey(key),
        ClockSkew = TimeSpan.Zero
    };
});

// =============================
// APP BUILD
// =============================
var app = builder.Build();

// =============================
// MIDDLEWARE
// =============================
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();