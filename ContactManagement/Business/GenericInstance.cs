using ContactManagement.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ContactManagement.Business
{
    public class GenericInstance
    {
        public bool WriteToFile(string fileName, string jsonContent)
        {
            try
            {
                File.WriteAllText(fileName, jsonContent);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public JObject ReadFromFile(string fileName)
        {
            try
            {
                string jsonString = File.ReadAllText(fileName);
                if (!string.IsNullOrEmpty(jsonString))
                {
                    return (JObject.Parse(jsonString));
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string getFileName()
        {
            try
            {
                //return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"ContactInfo.json");
                string jsonDirectory = ConfigurationManager.AppSettings["JsonDirectory"].ToString();
                return jsonDirectory + "ContactInfo.json";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsFileExists(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return false;
            }
            return true;
        }

        public void CreateFileIfNotExists(string fileName)
        {
            string directoryName = Path.GetDirectoryName(fileName);
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
            }
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();

            }
        }


        public bool isValidContact(int contactID)
        {
            if (contactID <= 0)
            {
                return false;
            }
            string fileName = getFileName();
            JObject jsonObj = ReadFromFile(fileName);
            var contactInfoArrary = jsonObj.GetValue("ContactInformation") as JArray;

            if (contactInfoArrary.FirstOrDefault(obj => obj["ContactID"].Value<int>() == contactID) != null)
            {
                return true;
            }
            return false;
        }

        public string RequiredFieldsValidation(ContactInformation contactInfo)
        {
            if (contactInfo == null)
            {
                return "Invalid Contact Information";
            }
            string errorMessage = string.Empty;
            if (contactInfo.FirstName == null)
            {
                errorMessage = errorMessage + "Please provide First Name. ";
            }
            if (contactInfo.LastName == null)
            {
                errorMessage = errorMessage + "Please provide Last Name. ";
            }
            if (contactInfo.EMail == null)
            {
                errorMessage = errorMessage + "Please provide EMail. ";
            }
            if (contactInfo.PhoneNumber == null)
            {
                errorMessage = errorMessage + "Please provide Phone Number. ";
            }
            if (contactInfo.Status == null)
            {
                errorMessage = errorMessage + "Please provide Status. ";
            }
            return errorMessage;
        }

        public int GetMaxID(JArray contactInfoArrary)
        {
            JToken lastItem = contactInfoArrary.LastOrDefault<JToken>();
            return lastItem["ContactID"].Value<int>();
        }
    }
}
