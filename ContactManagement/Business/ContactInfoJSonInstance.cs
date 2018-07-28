using ContactManagement.Interfaces;
using ContactManagement.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ContactManagement.Business
{
    /// <summary>
    /// Implementation for Jsnon repository if Contact Management
    /// </summary>
    public class ContactInfoJsonInstance: IContactInfoInstance
    {
        public void AddContact(ContactInformation contactInformation)
        {
            GenericInstance genericInstance = new GenericInstance();
            try
            {
                string fileName = genericInstance.getFileName();
                if (!genericInstance.IsFileExists(fileName))
                {
                    genericInstance.CreateFileIfNotExists(fileName);
                }
                JObject jsonObj = genericInstance.ReadFromFile(fileName);
                JArray contactInfoArrary = new JArray();
                if (jsonObj != null)

                {
                    contactInfoArrary = jsonObj.GetValue("ContactInformation") as JArray;
                    contactInformation.ContactID = genericInstance.GetMaxID(contactInfoArrary) + 1;
                }
                else
                {
                    contactInformation.ContactID = 1;
                    jsonObj = new JObject();

                }
                var newContactJSonString = JsonConvert.SerializeObject(contactInformation);
                var newContact = JObject.Parse(newContactJSonString);
                contactInfoArrary.Add(newContact);
                
                jsonObj["ContactInformation"] = contactInfoArrary;
                string newJsonResult = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                genericInstance.WriteToFile(fileName, newJsonResult);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteContact(int contactID)
        {
            try
            {
                GenericInstance genericInstance = new GenericInstance();
                string fileName = genericInstance.getFileName();
                JObject jsonObj = genericInstance.ReadFromFile(fileName);
                var contactInfoArrary = jsonObj.GetValue("ContactInformation") as JArray;

                foreach (var contact in contactInfoArrary.Where(obj => obj["ContactID"].Value<int>() == contactID))
                {
                    contact["Status"] = "InActive";

                }

                jsonObj["ContactInformation"] = contactInfoArrary;
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                genericInstance.WriteToFile(fileName, newJsonResult);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditContact(ContactInformation contactInformation)
        {
            try
            {
                GenericInstance genericInstance = new GenericInstance();
                string fileName = genericInstance.getFileName();
                JObject jsonObj = genericInstance.ReadFromFile(fileName);
                var contactInfoArrary = jsonObj.GetValue("ContactInformation") as JArray;
                foreach (var contact in contactInfoArrary.Where(obj => obj["ContactID"].Value<int>() == contactInformation.ContactID))
                {
                    contact["FirstName"] = contactInformation.FirstName;
                    contact["LastName"] = contactInformation.LastName;
                    contact["EMail"] = contactInformation.EMail;
                    contact["PhoneNumber"] = contactInformation.PhoneNumber;
                    contact["Status"] = contactInformation.Status;
                }

                jsonObj["ContactInformation"] = contactInfoArrary;
                string newJsonResult = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                genericInstance.WriteToFile(fileName, newJsonResult);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<ContactInformation> GetContactList()
        {
            try
            {
                GenericInstance genericInstance = new GenericInstance();
                string fileName = genericInstance.getFileName();
                if (!genericInstance.IsFileExists(fileName))
                {
                    genericInstance.CreateFileIfNotExists(fileName);
                }
                JObject jsonObj = genericInstance.ReadFromFile(fileName);
                var local = jsonObj["ContactInformation"];

                if (jsonObj != null)
                {
                    return local.ToObject<List<ContactInformation>>();
                }
                else
                {
                    return new List<ContactInformation>();
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
    
}
