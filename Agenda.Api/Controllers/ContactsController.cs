using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(IRepository<Contact> contactRepository) : ControllerBase
    {
        private readonly IRepository<Contact> contactRepository = contactRepository;

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken ct)
        {
            var contacts = await contactRepository.GetAllAsync(ct);
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
        {
            var contact = await contactRepository.FindByIdAsync(id, ct);
            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Contact entity, CancellationToken ct)
        {
            var savedEntity = await contactRepository.SaveAsync(entity, ct);
            return Ok(savedEntity);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Contact entity, CancellationToken ct)
        {
            var updatedEntity = await contactRepository.UpdateAsync(entity, ct);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var deletedEntity = await contactRepository.DeleteAsync(id, ct);
            return Ok(deletedEntity);
        }
    }
}
