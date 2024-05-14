using Agenda.Api.Mappers;
using Agenda.Domain.EntitiesAbstractions.EntitiesDto;
using Agenda.Domain.EntitiesAbstractions.EntitiesInputs;
using Agenda.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(IUnitOfWork unitOfWork, ILogger<ContactsController> logger) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        private readonly ContactMapper _contactMapper = new();

        private readonly ILogger<ContactsController> _logger = logger;

        /// <summary>
        /// End-Point responsible for retrieving all stored Contacts.
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(ContactDto), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get(CancellationToken ct)
        {
            try
            {
                var contacts = (await _unitOfWork.Contacts.GetAllAsync(ct)).Select(_contactMapper.ContactToContactDto);
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return BadRequest("Error: Failed to Return All Contacts! Try Again.");
            }
        }

        /// <summary>
        /// End-Point responsible for retrieving a specific Contact in the database using It's GUID.
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(ContactDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
        {
            try
            {
                var contact = _contactMapper.ContactToContactDto((await _unitOfWork.Contacts.FindByIdAsync(id, ct))!);
                return Ok(contact);
            }
            catch
            {
                return NotFound("Contact Not Found!");
            }
        }

        /// <summary>
        /// End-Point responsible for saving a new Contact in the database.
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(ContactDto), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] ContactInput entity, CancellationToken ct)
        {
            try
            {
                var savedEntity = await _unitOfWork.Contacts.SaveAsync(_contactMapper.ContactInputToContact(entity), ct);
                _logger.LogInformation($"Contact Of {savedEntity?.Email} Added To The Database");

                await _unitOfWork.CompleteAsync(ct);

                return Ok(_contactMapper.ContactToContactDto(savedEntity));
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return BadRequest("Error: Contact Not Created! Try Again.");
            }
        }

        /// <summary>
        /// End-Point responsible for updating a Contact in the database using It's Old Model.
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(typeof(ContactDto), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Put([FromBody] ContactInput entity, CancellationToken ct)
        {
            try
            {
                var updatedEntity = await _unitOfWork.Contacts.UpdateAsync(_contactMapper.ContactInputToContact(entity));
                _logger.LogInformation($"Contact Of {updatedEntity?.Email} Updated In The Database");

                await _unitOfWork.CompleteAsync(ct);

                return Ok(_contactMapper.ContactToContactDto(updatedEntity));
            }
            catch
            {
                return BadRequest("Error: Contact Not Updated! Try Again.");
            }
        }

        /// <summary>
        /// End-Point responsible for deleting a Contact in the database using It's GUID.
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(ContactDto), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            try
            {
                var deletedEntity = (await _unitOfWork.Contacts.DeleteAsync(id, ct))!;
                _logger.LogInformation($"Contact Of {deletedEntity?.Email} Deleted From The Database");

                await _unitOfWork.CompleteAsync(ct);

                return Ok(_contactMapper.ContactToContactDto(deletedEntity));
            }
            catch
            {
                return BadRequest("Error: Contact Not Deleted! Try Again.");
            }
        }
    }
}
