using Microsoft.AspNetCore.Mvc;
using SolsticeAPI.BusinessProcess.Interfaces;
using SolsticeAPI.Controllers;
using SolsticeAPI.Model;
using SolsticeAPI.Test.BusinessProcess;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SolsticeAPI.Test.Controllers
{
    public class ApplicationControllerTest
    {
        ApplicationController _applicationController;
        IApplicationBusinessProcess _applicationBusinessProcess;

        public ApplicationControllerTest()
        {
            _applicationBusinessProcess = new ApplicationBusinessProcessFake();
            _applicationController = new ApplicationController(_applicationBusinessProcess);
        }

        [Fact]
        public void GetAllContact_WhenCalled_ReturnsOKResult()
        {
            var result = _applicationController.GetAllContact();

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetAllContact_WhenCalled_ReturnsAllItems()
        {
            var result = _applicationController.GetAllContact().Result as OkObjectResult;

            var items = Assert.IsType<List<Contact>>(result.Value);
            Assert.Single(items);
        }

        [Fact]
        public void AddContact_WhenInvalidObjectPassed_ReturnsBadRequest()
        {
            var missingAddressContact = new Contact() {
                Name = "PartialContact",
                Email = "partialcontact@mail.com",
                PhoneNumber = "11109873462",
                Dob = new DateTime(1965, 12, 1),
            };

            _applicationController.ModelState.AddModelError("Address", "Required");

            var response = _applicationController.AddContact(missingAddressContact);
            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Fact]
        public void AddContact_WhenValidObjectPassed_ReturnOk()
        {
            var validContact = new Contact()
            {
                Name = "ValidContact",
                Address = new Address()
                {
                    AddressLine = "123 Valid St.",
                    City = new City()
                    {
                        Name = "Valid City",
                        State = new State()
                        {
                            Name = "Valid State"
                        }
                    }
                },
                Company = new Company()
                {
                    Name = "Valid Company"
                },
            };

            var response = _applicationController.AddContact(validContact);

            Assert.IsType<CreatedAtActionResult>(response);
        }

        [Fact]
        public void AddContact_WhenValidObjectPassed_Inserted()
        {
            var validContact = new Contact()
            {
                Name = "ValidContact",
                Address = new Address()
                {
                    AddressLine = "123 Valid St.",
                    City = new City()
                    {
                        Name = "Valid City",
                        State = new State()
                        {
                            Name = "Valid State"
                        }
                    }
                },
                Company = new Company()
                {
                    Name = "Valid Company"
                },
            };

            var response = _applicationController.AddContact(validContact) as CreatedAtActionResult;
            var contact = response.Value as Contact;

            Assert.IsType<Contact>(contact);
            Assert.Equal("ValidContact", contact.Name);
        }
    }
}
