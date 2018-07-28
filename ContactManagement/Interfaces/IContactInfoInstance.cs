using ContactManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManagement.Interfaces
{
    /// <summary>
    /// Interface for the Contact Information Repository
    /// </summary>
    public interface IContactInfoInstance
    {
 
        void AddContact(ContactInformation contactInfo);
        void EditContact(ContactInformation contactInfo);
        List<ContactInformation> GetContactList();
        void DeleteContact(int contactID);
    }
}