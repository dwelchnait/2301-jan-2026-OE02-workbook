using Microsoft.EntityFrameworkCore;
using SQLiteDemos;
using System;
using System.Linq;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("\n\t\tHello, SQLite World!\n");

//create an instance of the context class to be used by the program
using AppDBContext context = new AppDBContext();

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



