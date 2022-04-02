# Animal Shelter API

#### By Jase Seeley

#### A web API to view adoptable cats and dogs at an animal shelter.

## Technologies Used
* C#
* ASP.NET Core
* Entity Core
* EF Core Migrations
* SQL
* MySQLWorkbench
* Swagger
* Swashbuckle

## Description



## Setup/Installation Requirements

* Clone this repository to your desktop.

### Add the "appsettings.json" file:
1. Open the "AnimalShelter.Solution" folder in your code editor.
2. Right click on the "AnimalShelter" project folder and select "New File".
3. Enter "appsettings.json" in the text box and press "Enter/Return".
4. Double click the file to open it in your editor.
5. Copy and paste the code below into the file.
<pre>{  
  "ConnectionStrings": {  
    "DefaultConnection": "Server=localhost;Port=3306;database=jase_seeley;uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"  
  }  
}</pre>
6. Change the "USERNAME" and "PASSWORD" to match your MySQL information.
7. Save and close the file.

### Building and running the application:
* Make sure that "dotnet ef" is installed on your machine.
* Navigate to the "Pierres" project directory in your terminal.
* Enter "dotnet restore" to install the required packages.
* Enter "dotnet build" to build the project.
* Enter "dotnet ef database update" to build the database.
* To use the application, enter "dotnet run" and visit "http://localhost:5000/" in your browser.
* When finished, press "CTRL + C" in your terminal to close the application.

## Known Bugs

* No known bugs at this time.

## License

MIT

Copyright (c) 2022 Jase Seeley  