using Agenda.Api.Mappers;
using Agenda.Domain.Entities;
using Agenda.Domain.EntitiesAbstractions.EntitiesInputs;
using Agenda.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Agenda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        private readonly UserMapper _userMapper = new();

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get(CancellationToken ct)
        {
            try
            {
                var users = await _unitOfWork.Users.GetAllAsync(ct);
                return Ok(users.Select(_userMapper.UserToUserDto));
            }
            catch
            {
                return BadRequest("Error: Failed to Return All Users! Try Again.");
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
        {
            try
            {
                var user = _userMapper.UserToUserDto((await _unitOfWork.Users.FindByIdAsync(id, ct))!);
                return Ok(user);
            }
            catch
            {
                return NotFound("User Not Found!");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] UserInput entity, CancellationToken ct)
        {
            try
            {
                var savedEntity = await _unitOfWork.Users.SaveAsync(_userMapper.UserInputToUser(entity), ct);
                await _unitOfWork.CompleteAsync(ct);
                return Ok(savedEntity);
            }
            catch
            {
                return BadRequest("Error: User Not Created! Try Again.");
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] User entity, CancellationToken ct)
        {
            try
            {
                var updatedEntity = await _unitOfWork.Users.UpdateAsync(entity);
                await _unitOfWork.CompleteAsync(ct);
                return Ok(_userMapper.UserToUserDto(updatedEntity));
            }
            catch
            {
                return BadRequest("Error: User Not Updated! Try Again.");
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            try
            {
                var deletedEntity = (await _unitOfWork.Users.DeleteAsync(id, ct))!;
                await _unitOfWork.CompleteAsync(ct);
                return Ok(_userMapper.UserToUserDto(deletedEntity));
            }
            catch
            {
                return BadRequest("Error: User Not Deleted! Try Again.");
            }
        }
    }
}
