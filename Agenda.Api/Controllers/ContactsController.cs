using Agenda.Api.Mappers;
using Agenda.Domain.Entities;
using Agenda.Domain.EntitiesAbstractions.EntitiesDto;
using Agenda.Domain.EntitiesAbstractions.EntitiesInputs;
using Agenda.Domain.Interfaces;
using Agenda.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        private readonly ContactMapper _contactMapper = new();

        [HttpGet]
        [Authorize]
        [Produces(typeof(IEnumerable<ContactDto>))]
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

        [HttpGet("{id}")]
        [Authorize]
        [Produces(typeof(ContactDto))]
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

        [HttpPost]
        [Authorize]
        [Produces(typeof(ContactDto))]
        public async Task<IActionResult> Post([FromBody] ContactInput entity, CancellationToken ct)
        {
            try
            {
                var savedEntity = await _unitOfWork.Contacts.SaveAsync(_contactMapper.ContactInputToContact(entity), ct);
                await _unitOfWork.CompleteAsync(ct);

                return Ok(_contactMapper.ContactToContactDto(savedEntity));
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return BadRequest("Error: Contact Not Created! Try Again.");
            }
        }

        [HttpPut]
        [Authorize]
        [Produces(typeof(ContactDto))]
        public async Task<IActionResult> Put([FromBody] ContactInput entity, CancellationToken ct)
        {
            try
            {
                var updatedEntity = await _unitOfWork.Contacts.UpdateAsync(_contactMapper.ContactInputToContact(entity));
                await _unitOfWork.CompleteAsync(ct);

                return Ok(_contactMapper.ContactToContactDto(updatedEntity));
            }
            catch
            {
                return BadRequest("Error: Contact Not Updated! Try Again.");
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        [Produces(typeof(ContactDto))]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            try
            {
                var deletedEntity = (await _unitOfWork.Contacts.DeleteAsync(id, ct))!;
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
