using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelecomManagement.API.Models;

namespace TelecomManagement.API.Services
{
    public class ContactNumberService : IContactNumberService
    {
        /// <summary>
        /// Storing data in an array only for the purpose of this test project 
        /// </summary>
        ContactNumber[] contactNumbers = new ContactNumber[]
        {
            new ContactNumber { Id = 1, PhoneNumber = 1234567890, Active = true, CustomerId = 1},
            new ContactNumber { Id = 2, PhoneNumber = 1235489705, Active = true, CustomerId = 1},
            new ContactNumber { Id = 3, PhoneNumber = 5487963315, Active = false, CustomerId = 1},
            new ContactNumber { Id = 4, PhoneNumber = 1254863245, Active = false, CustomerId = 3},
            new ContactNumber { Id = 5, PhoneNumber = 3697458745, Active = true, CustomerId = 4},
            new ContactNumber { Id = 6, PhoneNumber = 2478965478, Active = true, CustomerId = 5},
            new ContactNumber { Id = 7, PhoneNumber = 8975463158, Active = false, CustomerId = 6},
            new ContactNumber { Id = 8, PhoneNumber = 9875246215, Active = false, CustomerId = 6},
            new ContactNumber { Id = 9, PhoneNumber = 2548976522, Active = true, CustomerId = 7},
            new ContactNumber { Id = 10, PhoneNumber = 9856478912, Active = true, CustomerId = 8},
        };

        /// <summary>
        /// Returns all contact numbers of all customers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<long> GetAllPhoneNumbers()
        {
            //Validate data
            if (contactNumbers != null)
            {
                //Get data
                var phoneNumbers = contactNumbers.Select(cn => cn.PhoneNumber);

                //Return result
                return phoneNumbers;
            }

            //Records not found, return null
            return null;
        }

        /// <summary>
        /// Returns contact numbers for provided customer Id only
        /// </summary>
        /// <param name="customerId">Id of a customer</param>
        /// <returns></returns>
        public IEnumerable<long> GetCustomerPhoneNumbers(int customerId)
        {
            //Validate data
            if (contactNumbers != null)
            {
                //Get data
                var phoneNumbers = contactNumbers.Where(cn => cn.CustomerId == customerId).Select(cn => cn.PhoneNumber);

                //Validate data
                if (phoneNumbers != null && phoneNumbers.Count() > 0)
                {
                    //Return result
                    return phoneNumbers;
                }
            }

            //Records not found, return null
            return null;
        }

        /// <summary>
        /// Activates provided phone number
        /// </summary>
        /// <param name="phoneNumber">Phone number to be activated</param>
        /// <returns></returns>
        public bool ActivatePhoneNumber(long phoneNumber)
        {
            //Validate data
            if (contactNumbers != null)
            {
                //Update data
                var phoneNumbers = contactNumbers.Where(cn => cn.PhoneNumber == phoneNumber)
                    .Select(cn => { cn.Active = true; return cn; });

                //Validate data
                if (phoneNumbers != null && phoneNumbers.Count() > 0)
                {
                    //Record found and updated successfully, return success
                    return true;
                }
            }

            //Records not found to be updated, return failure
            return false;
        }
    }
}