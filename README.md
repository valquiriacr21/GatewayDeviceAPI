# GatewayDeviceAPI
## Readme file with installation guides.

### Creating Database
-You must create a new database in SQL Server with the name:
#### 'GatewayDeviceAPIMusalaSoft' or the name of your choice

### Recongif your appsettings.json
-Go to the file "appsettings.json to configure the local data server" in visual studio.
-Review the “DefaultConnection” configuration and in Server put the name of your local server and in DataBase the name of the database that you just created. In my case it is:
#### “GatewayDeviceAPIMusalaSoft”.

### Delete elements in the migrations folder
-If there are elements in the migrations folder, they must be deleted.
-Then they must do the migrations again, for this they must go to tools or tools / NuGet Package Management / Package Manager Console.
 
### Migrations Adding
-In the console after “PM>” write: 
#### 'Add-Migration InitialCreate'
-When PM comes out again> write:
#### 'Update-DataBase'
Then go to the Microsoft SQL Management Studio

### Open the SQL file to Insert Data:
#### '3. Musala Soft Insert into tables.sql'
that is in the API project inside the SQL folder: .
Where it says USE in the code for the name of the database that you connected to the project, in my case it is 	the name that you read suggested: 
#### 'GatewayDeviceAPIMusalaSoft' and you execute it.
Then you go to the solution in visual studio and run the project.
