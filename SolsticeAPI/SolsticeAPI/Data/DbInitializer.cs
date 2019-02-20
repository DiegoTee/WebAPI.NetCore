using SolsticeAPI.Model;
using System;
using System.Linq;

namespace SolsticeAPI.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            context.Database.EnsureCreated();

            if (context.Contacts.Any())
                return;

            var state = new State { Name = "Buenos Aires" };
            context.States.Add(state);
            context.SaveChanges();
            var city = new City { Name = "Capital Federal", State = state };
            context.Cities.Add(city);
            context.SaveChanges();
            var address = new Address { AddressLine = "2209 San Martin", City = city };
            context.Addresses.Add(address);
            context.SaveChanges();
            var company = new Company { Name = "Solstice" };
            context.Companies.Add(company);
            context.SaveChanges();
            var contact = new Contact
            {
                Name = "ContactOne",
                Email = "contactone@mail.com",
                PhoneNumber = "2341539053",
                Dob = new DateTime(1980, 1, 29),
                Address = address,
                Company = company,
                ProfileImage = ""
            };
            context.Contacts.Add(contact);
            context.SaveChanges();
        }
    }
}
