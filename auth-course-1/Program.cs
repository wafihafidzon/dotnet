using Courses.Application.Services;
using Courses.Domain.Interfaces;
using Courses.Infrastrutre.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICoursetRepository, CourseRepository>();
builder.Services.AddSingleton<IStudentRepository, StudentRepository>();

builder.Services.AddScoped<StudentAuthService>();
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<StudentService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
