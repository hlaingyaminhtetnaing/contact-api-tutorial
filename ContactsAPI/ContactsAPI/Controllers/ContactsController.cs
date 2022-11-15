using ContactsAPI.Data;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactAPIDbContext _dbContext;

        public ContactsController(ContactAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _dbContext.Contacts.ToListAsync());
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult> GetbyId([FromRoute]Guid id)
        {
            var contact = await _dbContext.Contacts.FindAsync(id);
            if(contact != null)
            {
                return Ok(contact);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> AddContact(ContactRequest contactRequest)
        {
            var contact = new Contact()
            {
                Id=Guid.NewGuid(),
                FullName=contactRequest.FullName,
                Email=contactRequest.Email,
                Phone=contactRequest.Phone,
                Address=contactRequest.Address,                
            };
            await _dbContext.Contacts.AddAsync(contact);
            await _dbContext.SaveChangesAsync();
            return Ok(contact);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult> UpdateContact([FromRoute]Guid id,ContactRequest contactRequest)
        {
           var contact =await _dbContext.Contacts.FindAsync(id);
            if(contact != null)
            {
                contact.FullName = contactRequest.FullName;
                contact.Email = contactRequest.Email;
                contact.Phone = contactRequest.Phone;
                contact.Address = contactRequest.Address;
                await _dbContext.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult> DeleteContact([FromRoute] Guid id)
        {
            var contact = await _dbContext.Contacts.FindAsync(id);
            if(contact != null)
            {
                _dbContext.Contacts.Remove(contact);
                await _dbContext.SaveChangesAsync();
                return Ok("Successful deleted");
            }
            return NotFound();
        }
    }
}
