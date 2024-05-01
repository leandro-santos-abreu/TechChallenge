using Agenda.Api.Mappers;
using Agenda.Domain.EntitiesAbstractions.EntitiesInputs;
using Microsoft.AspNetCore.Mvc;
using Agenda.Domain.Interfaces;

namespace Agenda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(IUnitOfWork unitOfWork, ITokenService tokenService) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        private readonly ITokenService _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        private readonly UserMapper _userMapper = new();

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserInput entity, CancellationToken ct)
        {
            try
            {
                var token = await _tokenService.Authenticate(_userMapper.UserInputToUser(entity), ct);

                if (string.IsNullOrEmpty(token))
                    return Unauthorized();

                return Ok(token);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
