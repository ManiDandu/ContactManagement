using ContactManagement.Interfaces;
using ContactManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManagement.Business
{
    public class ContactInfoSQLInstance : IContactInfoInstance
    {
        public void AddContact(ContactInformation contactInformation)
        {
            throw new NotImplementedException();
        }

        public void DeleteContact(int contactID)
        {
            throw new NotImplementedException();
        }

        public void EditContact(ContactInformation contactInformation)
        {
            throw new NotImplementedException();
        }

        public List<ContactInformation> GetContactList()
        {
            throw new NotImplementedException();
        }

    }
}