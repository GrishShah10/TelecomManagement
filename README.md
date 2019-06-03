## TelecomManagement - API Guide

### Overview:
This is an API project to retrieve and manage phone numbers of customers. This project is kept simple with only one entity and fixed data stored into an array.

### Software:
This project is built on:
- Visual Studio 2015
- .NET Framework 4.6
- Web API 5.2
- ASP.NET 4.6
- C#


### Model:
There can be multiple contact numbers for a customer which can be active or not. A model "ContactNumber" has following properties:
- Id – int – Unique id of a contact number record
- PhoneNumber – long – Numeric property for a phone number
- Active – bool – Status of a phone number
- CustomerId – int – Foreign key, linked to a Customer unique id

### Controller:
There is a controller "ContactNumbersController" to handle HTTP requests which is has following responsibilities:
- Return all phone numbers
- Return all phone numbers only for a given customer id
- Activate a particular phone number

### Service:
An interface "IContactNumberService" implemented by another service class which is responsible for processing data for operations defined on above controller.

### Data:
Following fixed data is created and stored in an array of above model inside the above service class:
```
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
```

### Endpoints:
This API has following end points, as implemented on a controller:
- URI: /api/ContactNumbers
	- HTTP Request: GET
	- Method: Get, 
	- Returns all phone numbers.
	- i.e. https://localhost:51304/api/ContactNumbers
- URI: /api/ContactNumbers/id
	- HTTP Request: GET
	- Method: Get
	- Returns all phone numbers for provided customer id.
	- i.e. https://localhost:51304/api/ContactNumbers/1
- URI: /api/ContactNumbers/Activate?PhoneNumber=PhoneNumber
	- HTTP Request: PUT
	- Method: PutActivate
	- Activates given phone number.
	- i.e. https://localhost:51304/api/ContactNumbers/Activate?PhoneNumber=9875246215
