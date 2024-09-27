using StudentCourse.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddScoped<StudentServices>();
    builder.Services.AddScoped<CourseServices>();
    builder.Services.AddControllers();

}

var app = builder.Build();
{
    app.MapControllers();
}

app.Run();

