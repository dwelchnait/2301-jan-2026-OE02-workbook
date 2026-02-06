// See https://aka.ms/new-console-template for more information

#region Aditional Namespaces
using LearningObjects;
#endregion
Console.WriteLine("\n\tWorld of Exploration on Collections\n\n");

//create a collection in C#
//a collection could be any structure that holds more than on occurance of an item
//  a one time

//array[] will hold a fixed number items
//List<T> will an unknown number of items
//          <T> indicates the datatype of the items being held

List<Person> workers = new List<Person>();   //this will create an empty list

//create an instance of your class
Person person = new Person("Don", 70, 101500.00m);

//to on the collection use the .Add(instance of <T>)
workers.Add(person);

//shorten the statement by doing the new inside the Add
workers.Add(new Person("Pat", 32, 45789.00m));
workers.Add(new Person("Evan", 32, 77777.00m));
workers.Add(new Person("Terry", 20, 56678.00m));
workers.Add(new Person("Sam", 60, 89900.00m));

Console.WriteLine($"\nTotal number of workers is {workers.Count}");

//foreach loop will process your collection from the 1st item to the last item
//foreach is a While loop struction (pre-test loop)
//item only exists as long as the foreach is executing
foreach(var item in workers)
{
    Console.WriteLine($"The item in the collection is; {item.ToString()}");
}
Console.WriteLine("\n----------------------------\n");


// --- STEP 1: Filter (Where) -------------------------------
// the common form of a predicate
//  instanceplacehoder => instanceplaceholder operator value
//worker is an instance of a class. Accessing a property in the class uses the dot operator followed
//      by a property, a public data memeber or a method
//what is returned from the .Where() are instances of the workers collection that pass
//      the predicate condition
//the datatype var is set during run time and will not change
//Linq will return either a IEnumerable or IQueryable dataset
//Within C# programming the dataset will probably be IEnumerable
var oldWorkers = workers.Where(x => x.Age > 50);
foreach (var item in oldWorkers)
{
    Console.WriteLine($"The item in the old workers collection is; {item.ToString()}");
}

Console.WriteLine("\n----------------------------\n");
//one could write a loop to check each worker and display a line for each work passing a condition statement
foreach (var item in workers)
{
    if (item.Age > 50)
        Console.WriteLine($"The old worker in the collection is; {item.ToString()}");
}

Console.WriteLine("\n----------------------------\n");


// --- STEP 2: Order  -------------------------------
//OrderBy(predicate) is ascending, use on first ordering field
//OrderByDescending(predicate) is descending, use on first ordering field
//ThenBy(predcate) is ascending, use for second, third, .... ordering field
//ThenByDescending(predicate) is descending, use for second, third, .... ordering field

//var YoungWorkers = workers.Where(x => x.Age < 51);
//var sortedYoungWorkers = YoungWorkers.OrderBy(x => x.Age);

//combine these statements into one

// the workers collection is past into .Where
//.Where returna a resulting collection
//.Where collection is past into .OrderBy
//.OrderBy returns a resulting collection
//.OrderBY collection is assigned to sortedYoungWorkers

var sortedYoungWorkers = workers.Where(x => x.Age < 51).OrderBy(x => x.Age);


foreach (var item in sortedYoungWorkers)
{
    Console.WriteLine($"The youngs workers collection by increasing age is; {item.ToString()}");
}

Console.WriteLine("\n----------------------------\n");
//what if I have a second field to sort on
//use the appropriate ThenBy

var ageByWageYoungWorkers = workers.Where(x => x.Age < 51)     //filter
                                    .OrderBy(x => x.Age)       //first ordering field, ascending
                                    .ThenByDescending(x => x.Wage); //nth ordering field, descending

foreach (var item in ageByWageYoungWorkers)
{
    Console.WriteLine($"The young workers collection by increasing age and descending wage is; {item.ToString()}");
}


Console.WriteLine("\n----------------------------\n");
// --- STEP 3: Finding items in a Collection  -------------------------------

//Using the .Where(...) to locate an item
//Where(  ) returns a collection. That collection maybe empty, one record, or more many records
//see Where examples above

//What if you just wish to know if an item is in the collection?
//You does not need to want a returned collection
//The are two boolean filter commands for searching your collection: Any or All
//Any(predicate) will return true if any instance in your collection matching the predicate : return is a boolean
//All(predicate) will return true if all instances in your collection matches the predicate : return is a boolean

//These are very useful in decision making (if(... ) statement)
if (workers.All(x => x.Age < 65))
{
    // all instances match the condition within the predicate
    Console.WriteLine($"\nThe workers all need to pay into CPP.");
}
else
{
    // at least one instances does not match the condition within the predicate
    Console.WriteLine($"\nSome workers do not need to pay into CPP.");
}

if (workers.Any(x => x.Age > 65))
{
    // at least one instances matches the condition within the predicate
    Console.WriteLine($"\nAt least one worker do not need to pay into CPP.");
}
else
{
    // no instances match the condition within the predicate
    Console.WriteLine($"\nThe workers all need to pay into CPP. No old people.");
}

//What if you wish to locate an instance in your collection by a unique key value (pkey)
//These solution will possible return an instance or null
//possible solutions:
// You can use Where(...)
// You can also use collection methods such as Find(..), FindAll(...), FindLast(...), FindIndex (...)
// You could also use a Linq method such as First<> or FirstOrDefault

Person foundThem = workers.Find(x => x.Age > 39 &&  x.Age < 60);

if (foundThem != null)
    Console.WriteLine($"\nFound {foundThem.Name} is of age {foundThem.Age}.");
else
    Console.WriteLine($"\nNo workers in that age bracket.");

//CANNOT use Linq method with collection methods
//OrderBy is a Linq method
//Find is a collection method
//Person OrderfoundThem = workers.OrderBy(x => x.Age).Find(x => x.Age > 19 &&  x.Age < 60);

//if (OrderfoundThem != null)
//    Console.WriteLine($"\nFound {OrderfoundThem.Name} is of age {OrderfoundThem.Age}.");
//else
//    Console.WriteLine($"\nNo workers in that age bracket.");

Person LinqfoundThem = workers.FirstOrDefault(x => x.Age > 19 &&  x.Age < 50);

if (LinqfoundThem != null)
    Console.WriteLine($"\nFound {LinqfoundThem.Name} is of age {LinqfoundThem.Age}.");
else
    Console.WriteLine($"\nNo workers in that age bracket.");

Person OrderLinqfoundThem = workers.OrderBy(x => x.Age)
                                    .FirstOrDefault(x => x.Age > 19 &&  x.Age < 50);

if (LinqfoundThem != null)
    Console.WriteLine($"\nFound {OrderLinqfoundThem.Name} is of age {OrderLinqfoundThem.Age}.");
else
    Console.WriteLine($"\nNo workers in that age bracket.");