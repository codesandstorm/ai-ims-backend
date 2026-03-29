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
// 🔥 FORCE DATABASE CONNECTION (FIXED)
// =============================
builder.Services.AddDbContext<AppDbContext>(options =>
{
    // Kill any Railway override
    Environment.SetEnvironmentVariable("DATABASE_URL", null);

    // Get correct connection string
    var connectionString =
        builder.Configuration.GetConnectionString("DefaultConnection")
        ?? Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

    Console.WriteLine("========== DATABASE DEBUG ==========");
    Console.WriteLine($"DB CONNECTION USED: {connectionString}");
    Console.WriteLine("====================================");

    options.UseNpgsql(connectionString);
});

// =============================
// SERVICES
// =============================
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();

// =============================
// JWT CONFIG
// =============================
var jwtKey = builder.Configuration["Jwt:Key"]
             ?? Environment.GetEnvironmentVariable("Jwt__Key")
             ?? "THIS_IS_A_SUPER_SECURE_AIIMS_JWT_SECRET_KEY_2026";

var issuer = builder.Configuration["Jwt:Issuer"]
             ?? Environment.GetEnvironmentVariable("Jwt__Issuer")
             ?? "AIIMS";

var audience = builder.Configuration["Jwt:Audience"]
               ?? Environment.GetEnvironmentVariable("Jwt__Audience")
               ?? "AIIMS_USERS";

Console.WriteLine("========== JWT DEBUG ==========");
Console.WriteLine($"JWT KEY: {jwtKey}");
Console.WriteLine($"ISSUER: {issuer}");
Console.WriteLine($"AUDIENCE: {audience}");
Console.WriteLine("================================");

var key = Encoding.UTF8.GetBytes(jwtKey);

// =============================
// AUTH
// =============================
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
// APP
// =============================
var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();