# Animal Shelter API

#### By Jase Seeley

#### Epicodus Week #13 Independent Code Review: Building an API   
* A web API to view adoptable cats and dogs at an animal shelter.

## Technologies Used
* ASP.NET Core
* C#
* Entity Core
* EF Core Migrations
* OpenAPI
* SQL
* MySQLWorkbench
* Swagger
* Swashbuckle

## Description

An Animal Shelter API which utilizes RESTful routing, Swagger documentation, and pagination to display pets available for adoption.

## Setup/Installation Requirements

* Clone this repository to your desktop.

### Add the "***appsettings.json***" file:
1. Open the "***AnimalShelter.Solution***" folder in your code editor.
2. Right click on the "***AnimalShelter***" project folder and select "New File".
3. Enter "***appsettings.json***" in the text box and press "***Enter/Return***".
4. Double click the file to open it in your editor.
5. Copy and paste the code below into the file.
<pre>{  
  "ConnectionStrings": {  
    "DefaultConnection": "Server=localhost;Port=3306;database=jase_seeley;uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"  
  }  
}</pre>
6. Change the "***USERNAME***" and "***PASSWORD***" to match your MySQL information.
7. Save and close the file.

### Building and running the API:
* Make sure that "***dotnet ef***" is installed on your machine.
* Navigate to the "***AnimalShelter***" project directory in your terminal.
* Enter "***dotnet restore***" to install the required packages.
* Enter "***dotnet build***" to build the project.
* Enter "***dotnet ef database update***" to build the database.
* To use the API, enter "***dotnet run***" and visit ***http://localhost:5000/swagger*** in your browser or use ***Postman*** to access the endpoints listed below.
* When finished, press "***CTRL + C***" in your terminal to close out of the API.

## Swagger
* The easiest way to explore the functionality of this API is through ***Swagger***. After executing the "***dotnet run***" command in your terminal, visit ***http://localhost:5000/swagger*** in your browser and click on any of the available routes.
* Upon clicking, a form will drop down. Click the "***Try it out***" button, fill out any applicable fields and click "***Execute***" to submit your request.  

## Pagination
* Pagination is used to break up large amounts of data into smaller, easier to view pages. The default setting for this API is page 1 of the results with a maximum of 10 entries. These settings can be changed by going into ***Filters/PaginationFilter.cs*** and adjusting the ***PageNumber*** and ***PageSize*** properties.
* Alternatively, you may choose to view a different page of the results or view less than 10 entries per page directly through the URL:<ul>  
* To view a different page, add "***?pagenumber=REQUESTED PAGE***" to the end of the GET request:   
Example: ***http://localhost:5000/api/animalshelter/animals?pagenumber=2***   
* To view less than 10 results per page, add "***?pagesize=NUMBER OF RESULTS***" to the end of the GET request:   
Example URL: ***http://localhost:5000/api/animalshelter/animals?pagesize=4***
* These filters may also be combined with "***&***":   
Example URL: ***http://localhost:5000/api/animalshelter/animals?pagenumber=2&pagesize=4***</ul>


## API Endpoints
* Base URL: ***http://localhost:5000***    
*NOTE: If the above URL isn't working, try ***https://localhost:5001***
### **GET:** ***/api/animalshelter/animals***
* By default, this URL provides a full list of all available cats and dogs.
* In addition to or in place of custom pagination, you may utilize the following search queries:   
***type, name, gender, maximumAge, minimumAge***<ul>
* To filter the results, add a ***question mark, the query name, and '='*** to the end of the URL followed by your specific search text:   
Example URL: ***http://localhost:5000/api/animalshelter/animals?type=dog***
* Like pagination, these queries may also be combined with "***&***":   
Example URL: ***http://localhost:5000/api/animalshelter/animals?type=dog&gender=male***   
* To utilize with pagination, simply seperate with additional "***&***":   
Example URL: ***http://localhost:5000/api/animalshelter/animals?pagesize=3&minimumage=2&gender=male***</ul>

### **POST:** ***/api/animalshelter/animals***
* To add a new animal to the database, you will need to make a POST request. Copy and paste the following code into the body of your request:
<pre>{
  "type": "string",
  "name": "string",
  "gender": "string",
  "age": 0
}</pre>
* Change the "***0***" and "***string***" areas to match the animals details and submit your request. If field requirements are met, your new entry will be added to database. If not, an error will be returned stating the issue.

### **GET:** ***/api/animalshelter/animals/{id}***
* To retrieve an individual animal, add the ID number of the requested entry to the end of the URL:  
Example URL: ***http://localhost:5000/api/animalshelter/animals/2***

### **PUT:** ***/api/animalshelter/animals/{id}***
* To edit an animal's information, you will need to make a PUT request. Attach the animals ID number to the end of the URL and change the applicable fields in the body of your request.   
Example URL: ***http://localhost:5000/api/animalshelter/animals/2***   
Example body:
<pre>{
  "animalId": 2,
  "type": "Dog",
  "name": "Sally Sandwichstealer",
  "gender": "Female",
  "age": 2
}</pre>

## **DELETE** ***/api/animalshelter/animals/{id}***
* To delete an animal, attach the animal's ID number to the end of the URL and submit a DELETE request.  
Example URL: ***http://localhost:5000/api/animalshelter/animals/2*** 


## Known Bugs

* No known bugs at this time.

## License

MIT

Copyright (c) 2022 Jase Seeley