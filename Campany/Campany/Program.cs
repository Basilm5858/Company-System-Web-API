using System.Text;
using Campany.Data;
using Campany.Mapper;
using Campany.Models;
using Campany.Repos.Implementation;
using Campany.Repos.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(
    x => x.AddProfile<MappingProfile>());

builder.Services.AddDbContext<My_AppContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("conn")
    ));

builder.Services.AddScoped<IApplicationUser, ApplicationUserCustomRepo>();
builder.Services.AddScoped<IDepartment, DepartmentCustomRepo>();
builder.Services.AddScoped<IEmployeeProject, EmployeeProjectCustomRepo>();
builder.Services.AddScoped<IEmployee, EmployeeCustomRepo>();
builder.Services.AddScoped<IProject, ProjectCustomRepo>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]));
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(opt =>
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Iss"],

        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Aud"],

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = key
    });

var app = builder.Build();

app.UseCors("AllowFrontend");


// Configure the HTTP request pipeline.
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
