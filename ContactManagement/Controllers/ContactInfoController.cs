using ContactManagement.Business;
using ContactManagement.Interfaces;
using ContactManagement.Models;
using ContactManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactManagement.Controllers
{
    /// <summary>
    /// Controller for Contact Information Management. 
    /// Added Route and the Custom Exception Filter attribute to handle the exceptions.
    /// </summary>
    [RoutePrefix("api/ContactInfo")]
    [CustomExceptionFilter]
    public class ContactInfoController : ApiController
    {
        
        private IContactInfoInstance _instance;
        //Injected the dependency to resolve the repositories
        public ContactInfoController(IContactInfoInstance instance)
        {
            _instance = instance;
        }

        /// <summary>
        /// Method for Add Contact to the System
        /// </summary>
        /// <param name="contactInformation"></param>
        /// <returns></returns>
        [Route("AddContact")]
        [HttpPost]
        public HttpResponseMessage AddContact(ContactInformation contactInformation)
        {
            GenericInstance genericInstance = new GenericInstance();
            string errorMessage = genericInstance.RequiredFieldsValidation(contactInformation);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed, errorMessage);
            }

            this._instance.AddContact(contactInformation);
            return Request.CreateResponse(HttpStatusCode.OK, "Contact Added Successfully!"); ;
        }

        /// <summary>
        /// Method for Inactive a Contact. 
        /// </summary>
        /// <param name="contactID"></param>
        /// <returns></returns>
        [Route("DeleteContact")]
        [HttpPost]
        public HttpResponseMessage DeleteContact([FromBody]int contactID)
        {
            GenericInstance genericInstance = new GenericInstance();
            if (!genericInstance.isValidContact(contactID))
            {
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed, "Contact is not valid.");
            }

            this._instance.DeleteContact(contactID);

            return Request.CreateResponse(HttpStatusCode.OK, "Contact Deleted Successfully!");
        }


        /// <summary>
        /// Method for updating a contact
        /// </summary>
        /// <param name="contactInformation"></param>
        /// <returns></returns>
        [Route("EditContact")]
        [HttpPost]
        public HttpResponseMessage EditContact(ContactInformation contactInformation)
        {

            GenericInstance genericInstance = new GenericInstance();
            if (!genericInstance.isValidContact(contactInformation.ContactID))
            {
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed, "Contact is not valid.");
            }
            string errorMessage = genericInstance.RequiredFieldsValidation(contactInformation);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return Request.CreateResponse(HttpStatusCode.PreconditionFailed, errorMessage);
            }
            this._instance.EditContact(contactInformation);

            return Request.CreateResponse(HttpStatusCode.OK, "Contact Updated Successfully!");



        }

        /// <summary>
        /// Method to get all the contact list
        /// </summary>
        /// <returns></returns>
        [Route("GetContactList")]
        [HttpGet]
        public HttpResponseMessage GetContactList()
        {
            GenericInstance genericInstance = new GenericInstance();
            List<ContactInformation> contactList = this._instance.GetContactList();
            return Request.CreateResponse(HttpStatusCode.OK, contactList);
        }
    }
}



