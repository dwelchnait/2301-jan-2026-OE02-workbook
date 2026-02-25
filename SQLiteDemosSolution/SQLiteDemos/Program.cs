using System;
using System.Linq;

#region Additional Namespaces
using Microsoft.EntityFrameworkCore;
using SQLiteDemos;
using SQLiteDemos.System.DAL;
using SQLiteDemos.System.Models;
using SQLiteDemos.System.Services;
#endregion

// See https://aka.ms/new-console-template for more information
Console.WriteLine("\n\t\tHello, SQLite World!\n");

//we will need to go to NuGet Packages and include the following
// MicroSoft.EntityFrameworkCore
// MicroSoft.EntityFrameworkCore.Tools
// MicroSoft.EntityFrameworkCore.SQLite

//these packages are add to your project under Dependencies
//this has to be done ONCE for your project

// Force SQLite to use a single database file in the project root.
// Prevents "no such table" errors caused by different working directories
//adjusted path, one needs to know the location of your .exe
//      AppDomain.CurrentDomain.BaseDirectory
//once the .exe location is known, I can combine that location with
//      relative address to reach the desired location of the SQLite file
var dbPath = Path.Combine(
    AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "demo.db");

//var dbPath = Path.Combine(
//    AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "production.db");

//however we need to know the location of your application on the drive
//phyiscal absolute address location
dbPath = Path.GetFullPath(dbPath);

//setup the connection string information into a variable that can be 
//      pass to the AppDbContext class
//This allows for the user developing a front end for an existing system
//      indicate their desired database location

var options = new DbContextOptionsBuilder<AppDBContext>()
    .UseSqlite($"Data Source={dbPath}")
    .Options;


//create an instance of the context class to be used by the program
using AppDBContext context = new AppDBContext(options);

//use Dependency Injection to let service classes to know about context to db connection
//Why This Is Better
//Your class library should NOT know about:
//  SQLite
//  File paths
//  Connection strings

//That is infrastructure.
//using this technique loosely couples your service with a context class
// thus your front end can identify your data stores

//The console app is the "composition root" — it wires everything together.
//Inform the services class about the DB context connection to use
var departmentServices = new DepartmentServices(context);
var personServices = new PersonServices(context);
var projectServices = new ProjectServices(context);


//if you wish to start your application with a clean file on every execution
// use the following
//WARNING: if you alter your entities, add a new entity or remove an entity
//          from your database, you MUST drop your current database and
//          recreate the db SQLite file.
context.Database.EnsureDeleted();

//ensure that your database file exists
// if the database does not exist, then the data is created using the context class
//  mapping; and your database will be empty
// if the database does exist, then no action is taken and the existing data
//  remains to be used by your application
context.Database.EnsureCreated();

Console.WriteLine("\nAdding a record to the database");

//assume you have an input module to gather the department data (prompts, readlines, etc.)
Department department = new Department();
department.Code = "SDEV";
department.DepartmentName = "Software Development";

//send the input data to the database to be persisted
//this will be the functionality of the application (class library)
//What services do I need to used? department services
//How do I reference the department services? departmentServices (via Dependency Injection)
//****** since the services are async/task the calls will need to have an await *******
await departmentServices.Department_Add(department);

department = new Department();
department.Code = "WEBD";
department.DepartmentName = "Web Development";
await departmentServices.Department_Add(department);

department = new Department();
department.Code = "GDEV";
department.DepartmentName = "Game Development";
await departmentServices.Department_Add(department);


//assume you have an input module to gather the person data
await personServices.Person_Add(new Person("Bob G",20,97,1));
await personServices.Person_Add(new Person("Terry B", 52, 47, 1));
await personServices.Person_Add(new Person("Don W", 70, 87, 1));
await personServices.Person_Add(new Person("Terry C", 31, 67, 2));
await personServices.Person_Add(new Person("Don K", 31, 37, 2));
await personServices.Person_Add(new Person("Pat T", 53, 65, 3));
await personServices.Person_Add(new Person("Dan C", 28, 72, 3));

//assume you have an input module to gather the project data

// Object Initializer
// It allows you to:
//      Create an object
//      Set its properties
//      All in one expression
await projectServices.Project_Add(new Project() { Code= "PRJ01", ProjectName = "Basic C# Lessons" });
await projectServices.Project_Add(new Project() { Code="PRJ02", ProjectName = "Unit Testing Lessons" });
await projectServices.Project_Add(new Project() { Code="PRJ03", ProjectName = "Linq, Class Library and Unit Testing Lessons" });
await projectServices.Project_Add(new Project() { Code="PRJ04", ProjectName = "Client Server Putting it together" });
await projectServices.Project_Add(new Project() { Code="PRJ05", ProjectName = "WEB Client Server with Blazor" });


//use Linq to get the data records from the datastore via the context DbSet
List<Person> peopleContents = new List<Person>();
peopleContents = await personServices.Person_GetAll();

//display the current contains of People
foreach( var item in peopleContents)
{
    Console.WriteLine($"ID {item.Id} Name: {item.Name} Age: {item.Age} Mark: {item.Mark} Department: {item.DepartmentId}");
}

//use Linq to get the data records from the datastore via the context DbSet
List<Department> departmentContents = new List<Department>();
departmentContents = await departmentServices.Department_GetAll();

//display the current contains of department
foreach (var item in departmentContents)
{
    Console.WriteLine($"ID {item.Id} Code: {item.Code} Name: {item.DepartmentName}");
}

//use Linq to get the data records from the datastore via the context DbSet
List<Project> projectContents = new List<Project>();
projectContents = await projectServices.Project_GetAll();

//display the current contains of Project
foreach (var item in projectContents)
{
    Console.WriteLine($"ID {item.Id} Code: {item.Code} Name: {item.ProjectName}");
}


