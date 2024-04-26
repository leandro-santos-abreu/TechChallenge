using Agenda.Api.Mappers;
using Agenda.Domain.Entities;
using Agenda.Domain.Inputs;
using Agenda.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(IRepository<Contact> contactRepository) : ControllerBase
    {
        private readonly IRepository<Contact> contactRepository = contactRepository;
        private readonly ContactMapper _contactMapper = new();

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get(CancellationToken ct)
        {
            var contacts = await contactRepository.GetAllAsync(ct);
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
        {
            var contact = await contactRepository.FindByIdAsync(id, ct);
            return Ok(contact);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] ContactInput entity, CancellationToken ct)
        {
            var savedEntity = await contactRepository.SaveAsync(_contactMapper.ContactInputToContact(entity), ct);
            return Ok(savedEntity);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] Contact entity, CancellationToken ct)
        {
            var updatedEntity = await contactRepository.UpdateAsync(entity);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var deletedEntity = await contactRepository.DeleteAsync(id, ct);
            return Ok(deletedEntity);
        }
    }
}
