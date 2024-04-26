using Agenda.Api.Authentication;
using Agenda.Api.Mappers;
using Agenda.Domain.Entities;
using Agenda.Domain.Inputs;
using Agenda.Domain.Interfaces;
using Agenda.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Agenda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUnitOfWork unitOfWork, ITokenService tokenService) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        private readonly ITokenService _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        private readonly UserMapper _userMapper = new();

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get(CancellationToken ct)
        {
            var users = await _unitOfWork.Users.GetAllAsync(ct);
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
        {
            var User = await _unitOfWork.Users.FindByIdAsync(id, ct);
            return Ok(User);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] UserInput entity, CancellationToken ct)
        {
            var savedEntity = await _unitOfWork.Users.SaveAsync(_userMapper.UserInputToUser(entity), ct);
            await _unitOfWork.CompleteAsync(ct);
            return Ok(savedEntity);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserInput entity, CancellationToken ct)
        {
            var token = await _tokenService.Authenticate(_userMapper.UserInputToUser(entity), ct);

            if (string.IsNullOrEmpty(token))
                return Unauthorized();

            return Ok(token);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] User entity, CancellationToken ct)
        {
            var updatedEntity = await _unitOfWork.Users.UpdateAsync(entity);
            await _unitOfWork.CompleteAsync(ct);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var deletedEntity = await _unitOfWork.Users.DeleteAsync(id, ct);
            await _unitOfWork.CompleteAsync(ct);
            return Ok(deletedEntity);
        }
    }
}
