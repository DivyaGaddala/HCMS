using Microsoft.EntityFrameworkCore;
using PRJ2.API.Data;
using PRJ2.API.Mappings;
using PRJ2.API.Repositories;
using PRJ2.API.Repositories.SQLPatientsRepository;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<PatientsMappingProfile>();
    cfg.AddProfile<DoctorMappingProfile>();
    cfg.AddProfile<DepartmentMappingProfile>();
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<HCMSDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("HCMSconnection"));
});
builder.Services.AddScoped<IPatientsRepository, SQLRepositoryBase>();
builder.Services.AddScoped<IDoctoRRepository, SQLDoctorRepository>();
builder.Services.AddScoped<IDepartmentRepository, SQLDepartmentRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.builder.Services.AddEndpointsApiExplorer();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
