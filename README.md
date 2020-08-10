# Person Database

A .NET Core Web API Project that offers users the features to add a person with details such as name, address, update or delete them, etc.

## Dependencies

.NET Core 3.1

## Developer notes

**API**  
Start the server: Run commands `cd PersonDatabase.API` (navigate to the PersonDatabase.API folder), `dotnet restore` followed by `dotnet run` or `dotnet watch run` (to watch changes).  
The server will start on http://localhost:5000 and https://localhost:5001  

**Routes**  
GET /api/persons  
GET /api/persons/{id} e.g. 1  
POST /api/persons  
PUT /api/persons/1  
DELETE /api/persons/1  

GET /api/persons/{personId}/addresses Get all addresses for a person  
GET /api/persons/101/addresses/{id} Get address by id  
POST /api/persons/101/addresses Create multiple addresses for a person  
PUT /api/persons/101/addresses/100  
DELETE /api/persons/101/addresses/100  
