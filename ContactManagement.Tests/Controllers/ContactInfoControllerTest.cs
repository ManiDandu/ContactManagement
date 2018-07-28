using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactManagement.Controllers;
using ContactManagement.Models;
using ContactManagement.Business;

namespace ContactManagement.Tests.Controllers
{
    [TestClass]
    public class ContactInfoControllerTest
    {
        [TestMethod]
        public void AddContact()
        {
            //Create a Mock object here and pass to ContactInfoController. For now just to build the framework I used the original jsonInstance class.
            ContactInfoJsonInstance jsonInstance = new ContactInfoJsonInstance();
            ContactInfoController contactInfoController =  new ContactInfoController(jsonInstance);
            ContactInformation contactInfo = new ContactInformation();
            contactInfo.FirstName = "first1";
            contactInfo.LastName = "last1";
            contactInfo.EMail = "email1";
            contactInfo.PhoneNumber = "phoneNum";
            contactInfo.Status = "Active";
            contactInfoController.AddContact(contactInfo);
            //Logic for test cases
        }
        [TestMethod]
        public void EditContact()
        {
            //Create a Mock object here and pass to ContactInfoController. For now just to build the framework I used the original jsonInstance class.
            ContactInfoJsonInstance jsonInstance = new ContactInfoJsonInstance();
            ContactInfoController contactInfoController = new ContactInfoController(jsonInstance);
            ContactInformation contactInfo = new ContactInformation();
            contactInfo.ContactID = 4;
            contactInfo.FirstName = "first2";
            contactInfo.LastName = "last2";
            contactInfo.EMail = "email2";
            contactInfo.PhoneNumber = "phoneNum2";
            contactInfo.Status = "Active";
            contactInfoController.EditContact(contactInfo);
            //Logic for test cases
        }
        [TestMethod]
        public void DeleteContact()
        {
            //Create a Mock object here and pass to ContactInfoController. For now just to build the framework I used the original jsonInstance class.
            ContactInfoJsonInstance jsonInstance = new ContactInfoJsonInstance();
            ContactInfoController contactInfoController = new ContactInfoController(jsonInstance);
            ContactInformation contactInfo = new ContactInformation();
            contactInfo.ContactID = 2;
            contactInfo.FirstName = "first1";
            contactInfo.LastName = "last1";
            contactInfo.EMail = "email1";
            contactInfo.PhoneNumber = "phoneNum";
            contactInfo.Status = "Active";
            contactInfoController.DeleteContact(contactInfo.ContactID);
            //Logic for test cases
        }
        [TestMethod]
        public void GetContactList()
        {
            //Create a Mock object here and pass to ContactInfoController. For now just to build the framework I used the original jsonInstance class.
            ContactInfoJsonInstance jsonInstance = new ContactInfoJsonInstance();
            ContactInfoController contactInfoController = new ContactInfoController(jsonInstance);
            ContactInformation contactInfo = new ContactInformation();
            contactInfo.ContactID = 2;
            contactInfo.FirstName = "first1";
            contactInfo.LastName = "last1";
            contactInfo.EMail = "email1";
            contactInfo.PhoneNumber = "phoneNum";
            contactInfo.Status = "Active";
            contactInfoController.GetContactList();
            //Logic for the test cases
        }
    }
}
