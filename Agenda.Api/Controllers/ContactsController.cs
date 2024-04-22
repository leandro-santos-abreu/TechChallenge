using Agenda.Domain.Entities;
using Agenda.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agenda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository contactRepository;

        public ContactsController(IContactRepository ContactRepository)
        {
            this.contactRepository = ContactRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken ct)
        {
            var contacts = await contactRepository.GetAllContacts(ct);
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
        {
            var contact = await contactRepository.GetContactById(id, ct);
            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Contact entity, CancellationToken ct)
        {
            var savedEntity = await contactRepository.SaveContact(entity, ct);
            return Ok(savedEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Contact entity, CancellationToken ct)
        {
            var updatedEntity = await contactRepository.UpdateContactById(id, entity, ct);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var deletedEntity = await contactRepository.DeleteContactById(id, ct);
            return Ok(deletedEntity);
        }
    }
}
