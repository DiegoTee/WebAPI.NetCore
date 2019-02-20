using SolsticeAPI.BusinessProcess.Interfaces;
using SolsticeAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SolsticeAPI.Test.BusinessProcess
{
    public class ApplicationBusinessProcessFake : IApplicationBusinessProcess
    {
        private readonly List<Contact> _contacts;

        public ApplicationBusinessProcessFake()
        {
            Guid id = new Guid();

            _contacts = new List<Contact>()
            {
                new Contact() {
                    ID = id ,
                    Name = "ContactTest",
                    Email = "contacttest@mail.com",
                    PhoneNumber = "55564562341",
                    Dob = new DateTime(1965, 12, 1),
                    Address = new Address () {
                        ID = id,
                        AddressLine = "123 Fake St.",
                        City = new City () {
                            ID = id,
                            Name = "Fake City",
                            State = new State () {
                                ID = id,
                                Name = "Fake State"
                            }
                        }
                    },
                    Company = new Company() {
                        ID = id,
                        Name = "Fake Company"
                    },
                    ProfileImage = "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"
                }
            };
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts;
        }

        public Contact GetContactById(Guid contactId)
        {
            return _contacts.FirstOrDefault(c => c.ID == contactId);
        }

        public Contact AddContact(Contact contact)
        {
            contact.ID = new Guid();
            _contacts.Add(contact);

            return contact;
        }

        public void UpdateContact(Contact newContact)
        {
            var oldContact = GetContactById(newContact.ID);

            if (oldContact != null)
            {
                _contacts.Remove(oldContact);
                _contacts.Add(newContact);
            }
        }

        public void DeleteContact(Contact contact)
        {
            var contactInserted = GetContactById(contact.ID);

            if(contactInserted != null)
                _contacts.Remove(contactInserted);
        }

        public bool ExistContact(Guid contactId)
        {
            return _contacts.Any(c => c.ID == contactId);
        }

        public List<Contact> GetAllContactByStateCity(string state, string city)
        {
            throw new NotImplementedException();
        }

        public Contact GetContactByEmailPhone(string email, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Contact GetContactByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
