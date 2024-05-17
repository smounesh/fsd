using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PizzaHut.Contexts;
using PizzaHut.Interfaces;
using PizzaHut.Models;
using PizzaHut.Repositories;
using PizzaHut.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });

    // Define the JWT bearer token scheme
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header
    };

    // Add the JWT bearer token scheme to the Swagger document
    c.AddSecurityDefinition("Bearer", securityScheme);

    // Add the JWT bearer token authentication requirement to the Swagger document
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});



#region contexts
builder.Services.AddDbContext<PizzaHutContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
);
#endregion

#region repositories
builder.Services.AddScoped<IReposiroty<int, Employee>, EmployeeRepository>();
builder.Services.AddScoped<IReposiroty<int, User>, UserRepository>();
builder.Services.AddScoped<IReposiroty<int, Pizza>, PizzaRepository>();
builder.Services.AddScoped<IReposiroty<int, Order>, OrderRepository>();
#endregion

#region services
builder.Services.AddScoped<IEmployeeService, EmployeeBasicService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPizzaService, PizzaService>();
builder.Services.AddScoped<IOrderService, OrderService>();
#endregion


#region JWT
// Add JWT Authentication Middleware - This code will intercept HTTP request and validate the JWT.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    opt => {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(builder.Configuration.GetSection("JWT:Secret").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    }
  );
# endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name v1");
        c.RoutePrefix = "swagger"; 
        c.DefaultModelsExpandDepth(-1);
        c.DisplayRequestDuration();
    });

}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
