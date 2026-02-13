using System;
using System.Linq;

#region Additional Namespaces
using Microsoft.EntityFrameworkCore;
using SQLiteDemos.System;
using SQLiteDemos;
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

//if you wish to start your application with a clean file on every execution
// use the following
//context.Database.EnsureDeleted();

//ensure that your database file exists
// if the database does not exist, then the data is created using the context class
//  mapping; and your database will be empty
// if the database does exist, then no action is taken and the existing data
//  remains to be used by your application
context.Database.EnsureCreated();

Console.WriteLine("\nAdding a record to the database");

Person person = new Person("bob",20,97);

//stage the data in memory to the DbSet collection
context.People.Add(person);

//persist the data from memory to the database
context.SaveChanges();

//use Linq to get the data records from the datastore via the context DbSet
List<Person> datastoreContents = new List<Person>();
datastoreContents = context.People.OrderBy(p => p.Name).ToList();

//display the current contains of People
foreach( var item in datastoreContents)
{
    Console.WriteLine($"ID {item.Id} Name: {item.Name} Age: {item.Age} Mark: {item.Mark}");
}



