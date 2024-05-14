using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Agenda.Domain.Interfaces.Caches;

namespace Agenda.Api.Authentication
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenCache _tokenCache;

        public TokenService(IConfiguration configuration, IUnitOfWork unitOfWork, ITokenCache tokenCache)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _tokenCache = tokenCache ?? throw new ArgumentNullException(nameof(tokenCache)); ;
        }

        public async Task<string> Authenticate(User requestedUser, CancellationToken ct)
        {
            try
            {
                User validUser = await _unitOfWork.Users.FindByUserNameAsync(requestedUser.UserName, ct);

                if (validUser == null || !VerifyPassword(requestedUser.Password, validUser.Password))
                    return string.Empty;

                var token = await _tokenCache.GetOrCreateAsync(validUser.UserName, async() => await CreateToken(validUser), TimeSpan.FromMinutes(_configuration.GetValue<int>("Cache:CacheServiceDefaultExpirationTime")!));
                return token;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task AttachUserToContext(HttpContext httpContext, string token, CancellationToken ct)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretJWT")!);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ClockSkew = TimeSpan.Zero
                }, out var validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;

                if (!string.IsNullOrEmpty(userId))
                {
                    httpContext.Items["User"] = await _unitOfWork.Users.FindByIdAsync(Guid.Parse(userId), ct);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private Task<string> CreateToken(User validUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretJWT")!);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim("Id", validUser.Id.ToString()),
                        new Claim(ClaimTypes.Name, validUser.UserName),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Task.FromResult(tokenHandler.WriteToken(token));

        }
        private static bool VerifyPassword(string providedPassword, string hashedPassword)
        {
            return System.Web.Helpers.Crypto.VerifyHashedPassword(hashedPassword, providedPassword);
        }
    }
}
