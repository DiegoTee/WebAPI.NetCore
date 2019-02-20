using SolsticeAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SolsticeAPI.Services.Interfaces
{
    public interface IApplicationService
    {
        void AddContact(Contact contact);
        Contact GetContactByName(string name);
        List<Contact> GetAllContactByStateCity(string state, string city);
        Contact GetContactByEmailPhone(string email, int phoneNumber);
        void UpdateContact(Contact contact);
        void DeleteContact(Contact contact);
        List<Contact> GetAllContacts();
    }
}
