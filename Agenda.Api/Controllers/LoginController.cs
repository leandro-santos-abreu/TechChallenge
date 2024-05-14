using Agenda.Api.Mappers;
using Agenda.Domain.EntitiesAbstractions.EntitiesInputs;
using Microsoft.AspNetCore.Mvc;
using Agenda.Domain.Interfaces;
using Agenda.Domain.EntitiesAbstractions.EntitiesDto;

namespace Agenda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(ITokenService tokenService, ILogger<LoginController> logger) : ControllerBase
    {
        private readonly ITokenService _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        private readonly UserMapper _userMapper = new();

        private readonly ILogger<LoginController> _logger = logger;

        /// <summary>
        /// End-Point responsible for allowing users to login and obtain a unique Token to allow application use.
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        public async Task<IActionResult> Login([FromBody] UserInput entity, CancellationToken ct)
        {
            try
            {
                var token = await _tokenService.Authenticate(_userMapper.UserInputToUser(entity), ct);

                if (string.IsNullOrEmpty(token))
                    return Unauthorized();

                _logger.LogInformation($"Token {token} Created For User {entity.UserName}");
                return Ok(token);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
