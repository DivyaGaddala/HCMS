using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PRJ2.API.Data;
using PRJ2.API.Mappings;
using PRJ2.API.Repositories;
using PRJ2.API.Repositories.SQLPatientsRepository;
using System.Text;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<PatientsMappingProfile>();
    cfg.AddProfile<DoctorMappingProfile>();
    cfg.AddProfile<DepartmentMappingProfile>();
    cfg.AddProfile<ApointmetMappingProfile>();
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<HCMSDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("HCMSconnection"));
});
builder.Services.AddDbContext<HCMSAuthenticationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("HCMSAuthConnection"),
        sqlOptions =>
            sqlOptions.MigrationsHistoryTable("__EFMigrationsHistory_Auth"));
});
builder.Services
    .AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<HCMSAuthenticationDbContext>();

builder.Services.AddScoped<IPatientsRepository, SQLRepositoryBase>();
builder.Services.AddScoped<IDoctoRRepository, SQLDoctorRepository>();
builder.Services.AddScoped<IDepartmentRepository, SQLDepartmentRepository>();
builder.Services.AddScoped<IAppointmentRepository, SQLAppointmentRepository>();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.ParameterLocation.Header,
        Description = "Enter your JWT token"
    });

    options.AddSecurityRequirement(document =>
    {
        return new Microsoft.OpenApi.OpenApiSecurityRequirement
        {
            [new Microsoft.OpenApi.OpenApiSecuritySchemeReference("Bearer", document)] = new List<string>()
        };
    });

});


var app = builder.Build();

// Configure the HTTP request pipeline.builder.Services.AddEndpointsApiExplorer();


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
