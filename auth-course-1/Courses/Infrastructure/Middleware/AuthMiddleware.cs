using Microsoft.AspNetCore.Http;
using Courses.Application.Services;
using System.Threading.Tasks;

public class AuthMiddleware
{
  private readonly RequestDelegate _next;
  private readonly StudentAuthService _authService;

  public AuthMiddleware(RequestDelegate next, StudentAuthService authService)
  {
    _next = next;
    _authService = authService;
  }

  public async Task Invoke(HttpContext context)
  {
    if (context.Request.Headers.ContainsKey("Authorization"))
    {
      var token = context.Request.Headers["Authorization"].ToString();
      var student = _authService.ValidateToken(token);
      if (student != null)
      {
        context.Items["Student"] = student;
      }
      else
      {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("Invalid Token");
        return;
      }
    }

    await _next(context);
  }
}
