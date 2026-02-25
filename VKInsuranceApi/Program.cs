using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VKInsuranceApi.Automapper;
using VKInsuranceApi.Database;
using VKInsuranceApi.RepositotyDesignPattern.Implementation;
using VKInsuranceApi.RepositotyDesignPattern.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
//JWT AUthentication adding to middleware
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    ValidAudience = builder.Configuration["Jwt:Audience"],
    ValidateLifetime = true,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
});


builder.Services.AddDbContext<WillisDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("WillisDb")));
builder.Services.AddScoped<ILogin, Login>();

var app = builder.Build();

// Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{

    c.SwaggerEndpoint("/swagger/v1/swagger.json", "VKInsurance API V1");
    c.RoutePrefix = "swagger"; // serves at "/swagger"


});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//conventional routing
//app.MapControllerRoute(name: "Default", pattern: "{controller=Home}/{action=Index}/{Id?}");

// Redirect root to Swagger UI
app.MapGet("/", () => Results.Redirect("/"));

app.Run();

