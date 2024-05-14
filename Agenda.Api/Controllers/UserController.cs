using Agenda.Api.Mappers;
using Agenda.Domain.Entities;
using Agenda.Domain.EntitiesAbstractions.EntitiesDto;
using Agenda.Domain.EntitiesAbstractions.EntitiesInputs;
using Agenda.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Agenda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUnitOfWork unitOfWork, ILogger<UserController> logger) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        private readonly UserMapper _userMapper = new();

        private readonly ILogger<UserController> _logger = logger;

        /// <summary>
        /// End-Point responsible for retrieving all stored Users.
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(400)]
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

        /// <summary>
        /// End-Point responsible for retrieving a specific User in the database using It's GUID.
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(404)]
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

        /// <summary>
        /// End-Point responsible for saveing a new User in the database.
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] UserInput entity, CancellationToken ct)
        {
            try
            {
                var savedEntity = await _unitOfWork.Users.SaveAsync(_userMapper.UserInputToUser(entity), ct);
                _logger.LogInformation($"User {entity?.UserName} Added To The Database");

                await _unitOfWork.CompleteAsync(ct);
                return Ok(savedEntity);
            }
            catch
            {
                return BadRequest("Error: User Not Created! Try Again.");
            }
        }

        /// <summary>
        /// End-Point responsible for updating a specific User in the database using It's old model.
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Put([FromBody] User entity, CancellationToken ct)
        {
            try
            {
                var updatedEntity = await _unitOfWork.Users.UpdateAsync(entity);
                _logger.LogInformation($"User {updatedEntity?.UserName} Updated In The Database");

                await _unitOfWork.CompleteAsync(ct);
                return Ok(_userMapper.UserToUserDto(updatedEntity));
            }
            catch
            {
                return BadRequest("Error: User Not Updated! Try Again.");
            }
        }

        /// <summary>
        /// End-Point responsible for deleting a specific User in the database using It's GUID.
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            try
            {
                var deletedEntity = (await _unitOfWork.Users.DeleteAsync(id, ct))!;
                _logger.LogInformation($"User {deletedEntity?.UserName} Deleted From The Database");

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
