using Microsoft.EntityFrameworkCore;
using SolsticeAPI.BusinessProcess.Interfaces;
using SolsticeAPI.Data;
using SolsticeAPI.Model;
using SolsticeAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeAPI.BusinessProcess.Implementation
{
    public class ApplicationBusinessProcess : IApplicationBusinessProcess
    {
        private readonly ApplicationContext _context;
        private readonly IFileService _fileService;

        public ApplicationBusinessProcess(
            ApplicationContext context,
            IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }


        public List<Contact> GetAllContacts()
        {
            var contacts = _context.Contacts
                .Include(c => c.Company)
                .Include(c => c.Address)
                    .ThenInclude(a => a.City)
                        .ThenInclude(ci => ci.State);

            return contacts.ToList();
        }

        public Contact GetContactById(Guid contactId)
        {
            return _context.Contacts
                .Include(c => c.Company)
                .Include(c => c.Address)
                    .ThenInclude(a => a.City)
                        .ThenInclude(ci => ci.State)
                .SingleOrDefault(c => c.ID == contactId);
        }

        public Contact AddContact(Contact contact)
        {
            Contact item = null;

            if(GetContactByName(contact.Name) == null)
            {
                _fileService.SaveImage(contact.ProfileImage, contact.Name);
                item = _context.Add(contact).Entity;
                _context.SaveChanges();
            }

            return item;
        }

        public Contact GetContactByName(string name)
        {
            return _context.Contacts
                .Where(c => c.Name == name)
                .Include(c => c.Company)
                .Include(c => c.Address)
                    .ThenInclude(a => a.City)
                        .ThenInclude(ci => ci.State)
                .SingleOrDefault();
        }

        public List<Contact> GetAllContactByStateCity(string state, string city)
        {
            var contacts = _context.Contacts
                .Include(c => c.Company)
                .Include(c => c.Address)
                    .ThenInclude(a => a.City)
                        .ThenInclude(ci => ci.State)
                .Where(c => c.Address.City.Name == city
                        || c.Address.City.State.Name == state);

            return contacts.ToList();
        }

        public Contact GetContactByEmailPhone(string email, string phoneNumber)
        {
            return _context.Contacts
                .Include(c => c.Company)
                .Include(c => c.Address)
                    .ThenInclude(a => a.City)
                        .ThenInclude(ci => ci.State)
                .SingleOrDefault(c => c.PhoneNumber == phoneNumber
                        || c.Email == email);
        }

        public void UpdateContact(Contact contact)
        {
            _context.Update(contact);
            _context.SaveChanges();
        }

        public void DeleteContact(Contact contact)
        {
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
        }

        public bool ExistContact(Guid contactId)
        {
            return _context.Contacts.Any(c => c.ID == contactId);
        }
    }
}
