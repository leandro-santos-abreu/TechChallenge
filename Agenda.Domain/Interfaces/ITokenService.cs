using Agenda.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Agenda.Domain.Interfaces
{
    public interface ITokenService
    {
        Task<string> Authenticate(User user, CancellationToken ct);
        Task AttachUserToContext(HttpContext httpContext, string token, CancellationToken ct);
    }
}
