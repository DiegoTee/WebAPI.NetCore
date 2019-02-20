using SolsticeAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeAPI.BusinessProcess.Interfaces
{
    public interface IApplicationBusinessProcess
    {
        List<Contact> GetAllContacts();
        Contact GetContactById(Guid contactId);
        Contact AddContact(Contact contact);
        Contact GetContactByName(string name);
        List<Contact> GetAllContactByStateCity(string state, string city);
        Contact GetContactByEmailPhone(string email, string phoneNumber);
        void UpdateContact(Contact contact);
        void DeleteContact(Contact contact);
        bool ExistContact(Guid id);
    }
}
