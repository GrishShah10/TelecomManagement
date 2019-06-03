using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TelecomManagement.API.Models;
using TelecomManagement.API.Services;

namespace TelecomManagement.API.Controllers
{
    /// <summary>
    /// Returns and activates contact numbers
    /// </summary>
    public class ContactNumbersController : ApiController
    {
        public IContactNumberService contactNumberService { get; }

        /// <summary>
        /// Constructure initialises interface
        /// </summary>
        public ContactNumbersController()
        {
            contactNumberService = new ContactNumberService();
        }

        /// <summary>
        /// Returns all contact numbers of all customers
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            try
            {
                //Get Data
                var allPhoneNumbers = contactNumberService.GetAllPhoneNumbers();

                //Validate data
                if (allPhoneNumbers == null)
                {
                    //Error - Data could not be found
                    HttpResponseMessage responseMsg = Request.CreateResponse(HttpStatusCode.NotFound, "No records found");
                    return ResponseMessage(responseMsg);
                }

                //Return result
                return Ok(allPhoneNumbers);
            }
            catch (Exception ex)
            {
                //Error - Something went wrong
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Returns contact numbers for provided customer Id only
        /// </summary>
        /// <param name="id">Id of a customer</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            try
            {
                //Get data
                var customerPhoneNumbers = contactNumberService.GetCustomerPhoneNumbers(id);

                //Validate data
                if (customerPhoneNumbers == null)
                {
                    //Error - Data could not be found
                    HttpResponseMessage responseMsg = Request.CreateResponse(HttpStatusCode.NotFound, "Customer could not be found");
                    return ResponseMessage(responseMsg);
                }

                //Return result
                return Ok(customerPhoneNumbers);
            }
            catch (Exception ex)
            {
                //Error - Something went wrong
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Activates provided phone number
        /// </summary>
        /// <param name="PhoneNumber">Phone number to be activated</param>
        /// <returns></returns>
        public IHttpActionResult PutActivate(long phoneNumber)
        {
            try
            {
                //Get data
                var phoneNumberActivated = contactNumberService.ActivatePhoneNumber(phoneNumber);

                //Validate data
                if (!phoneNumberActivated)
                {
                    //Error - Data could not be found
                    HttpResponseMessage responseMsg = Request.CreateResponse(HttpStatusCode.NotFound, "Phone number could not be found");
                    return ResponseMessage(responseMsg);
                }

                //Return result
                return Ok("Phone number activated successfully");
            }
            catch (Exception ex)
            {
                //Error - Something went wrong
                return BadRequest(ex.Message);
            }
        }
    }
}
