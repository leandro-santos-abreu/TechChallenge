using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Api.Middlewares
{
    public class AuthenticationMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;
        public async Task Invoke(HttpContext httpContext, ITokenService tokenService)
        {
            var token = httpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                await AttachUserToContext(httpContext, tokenService, token);

            await _next(httpContext);
        }

        private static async Task AttachUserToContext(HttpContext httpContext, ITokenService _tokenService, string? token)
        {
            await _tokenService.AttachUserToContext(httpContext, token, CancellationToken.None);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}
