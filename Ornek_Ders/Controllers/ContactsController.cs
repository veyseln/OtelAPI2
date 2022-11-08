using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ornek_Ders.Controllers.Models;
using Ornek_Ders.Data;
using Ornek_Ders.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Ornek_Ders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : Controller
    {
        private readonly ContacDbApiContext dbContext;
        public ContactsController(ContacDbApiContext dbContext)
        {
            this.dbContext = dbContext;

        }
        [HttpGet]
        [Route("get")]
        public IActionResult GetContacs()
        {
            
            return Ok(dbContext.Contacts.ToList());

        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> AddContact(AddContactRequest value)
        {
            var contact = new Contact()
            {
                Id = new int(),
                Username = value.Username,
                Password = value.Password,



            };
            await dbContext.Contacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();
            return Ok(contact);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetContact([FromRoute] int id)// Kaça bakmak istiyorsan
        {
            var contact=await dbContext.Contacts.FindAsync(id);
            if (contact==null)
            {
                return NotFound();
            }
            return Ok(contact);
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateContact([FromRoute] int id,UpdateContactRequest updateContactRequest)

        {
            var contact = await dbContext.Contacts.FindAsync(id);
            if (contact !=null)
            {
                contact.Username = updateContactRequest.Username;
                
                contact.Password = updateContactRequest.Password;
               

                await dbContext.SaveChangesAsync();
                return Ok(contact);
                   
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteContact([FromRoute] int id)
        {
            var contact = await dbContext.Contacts.FindAsync(id);
            if (contact != null)
            {
                dbContext.Remove(contact);
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            return NotFound();

        }

    }
   

}

