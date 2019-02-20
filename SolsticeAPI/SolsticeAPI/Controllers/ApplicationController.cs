using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using SolsticeAPI.BusinessProcess.Interfaces;
using SolsticeAPI.Data;
using SolsticeAPI.Dtos;
using SolsticeAPI.Model;
using SolsticeAPI.Services.Interfaces;

namespace SolsticeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationBusinessProcess _applicationBusinessProcess;

        public ApplicationController(IApplicationBusinessProcess applicationBusinessProcess)
        {
            _applicationBusinessProcess = applicationBusinessProcess;
        }

        // To test DbContext is working
        [HttpGet]
        public ActionResult<List<Contact>> GetAllContact()
        {
            var contacts = _applicationBusinessProcess.GetAllContacts();

            if (contacts.Any())
                return Ok(contacts);
            else
                return NotFound();
        }


        [HttpPost]
        public ActionResult AddContact(Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var item = _applicationBusinessProcess.AddContact(contact);

            if (item != null)
                return CreatedAtAction(nameof(GetContactById), new { id = item.ID }, item);
            else
                return Ok($"Contact with name '{contact.Name}' already exists");
        }

        [HttpGet("{name}")]
        public ActionResult<Contact> GetContactByName(string name)
        {
            var contact = _applicationBusinessProcess.GetContactByName(name);

            if (contact != null)
                return Ok(contact);
            else
                return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> GetContactById(Guid id)
        {
            var contact = _applicationBusinessProcess.GetContactById(id);

            if (contact != null)
                return Ok(contact);
            else
                return NotFound();
        }

        [HttpGet("GetByStateCity")]
        public ActionResult<IList<Contact>> GetAllContactByStateCity(ContactDto contact)
        {
            if (ModelState.IsValid)
            {
                var contacts = _applicationBusinessProcess.GetAllContactByStateCity(contact.State, contact.Name);

                if (contacts.Any())
                    return Ok(contacts);
                else
                    return NotFound();
            }
            else
                return BadRequest(ModelState);
        }

        [HttpGet("GetByEmailPhone")]
        public ActionResult<Contact> GetContactByEmailPhone(ContactDto contact)
        {
            if (ModelState.IsValid)
            {
                var contactReturn = _applicationBusinessProcess.GetContactByEmailPhone(contact.Email, contact.PhoneNumber);

                if (contactReturn != null)
                    return Ok(contactReturn);
                else
                    return NotFound();
            }
            else
                return BadRequest(ModelState);
        }

        [HttpPut]
        public ActionResult UpdateContact(Contact contact)
        {
            if (!_applicationBusinessProcess.ExistContact(contact.ID))
                return NotFound();

            _applicationBusinessProcess.UpdateContact(contact);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteContact(Guid id)
        {
            var contact = _applicationBusinessProcess.GetContactById(id);
            if(contact == null)
                return NotFound();

            _applicationBusinessProcess.DeleteContact(contact);
            return Ok();
        }
    }
}