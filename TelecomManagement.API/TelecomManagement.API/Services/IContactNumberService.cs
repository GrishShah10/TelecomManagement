using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelecomManagement.API.Services
{
    public interface IContactNumberService
    {
        /// <summary>
        /// Returns all contact numbers of all customers
        /// </summary>
        /// <returns></returns>
        IEnumerable<long> GetAllPhoneNumbers();

        /// <summary>
        /// Returns contact numbers for provided customer Id only
        /// </summary>
        /// <param name="customerId">Id of a customer</param>
        /// <returns></returns>
        IEnumerable<long> GetCustomerPhoneNumbers(int customerId);

        /// <summary>
        /// Activates provided phone number
        /// </summary>
        /// <param name="phoneNumber">Phone number to be activated</param>
        /// <returns></returns>
        bool ActivatePhoneNumber(long phoneNumber);
    }
}