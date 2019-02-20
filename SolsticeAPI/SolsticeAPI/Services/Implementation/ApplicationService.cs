using Microsoft.EntityFrameworkCore;
using SolsticeAPI.Data;
using SolsticeAPI.Model;
using SolsticeAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SolsticeAPI.Services
{
    public class ApplicationService : IApplicationService
    {
        public void AddContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void DeleteContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetAllContactByStateCity(string state, string city)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetAllContacts()
        {
            throw new NotImplementedException();
        }

        public Contact GetContactByEmailPhone(string email, int phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Contact GetContactByName(string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
