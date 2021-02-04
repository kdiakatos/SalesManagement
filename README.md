## A. What the application does 

This application allows its users to perform the following: 

 1. Create/Edit/Delete Sellers
 2. Create/Edit/Delete Sales
 


## B. Architecture Solution 

The architectural design follows the 3-Layer architecture. A short description about the three layers follows: 

  ### 1. Data Access Layer
	  It is a class library project that implements this layer, which is responsible for storing and 
      retrieving data to a persistent database.  
  ### 2. Business Layer
      It is a class library project that implements this layer, which operates as the “middleman” 
     between the data access layer and the presentation layer. 
  ### 3. Presentation Layer  
      It is the front end layer in the 3-tier system and consists of the user interface. 


## C. Technologies/Frameworks used 

The solution is built using the following technologies/frameworks: 

C# .NET (Core) 5 Web Application MVC

SQL Server

EF Core

Automapper


## D. Project Setup 

To set up the database, you should do the following: 

In the file appsettings.json (SalesManagement.Web project), fill in your connection string to the SQL Server instance of your desire 

Set as start-up project the SalesManagement.Web 

In Visual Studio 2019, go Tools -> NuGet Package Manager -> Package Manager 

Set Default Project, SalesManagement.DataLayer and type the following command:  

**update-database**
