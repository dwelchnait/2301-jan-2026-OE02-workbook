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

List<Person> workers = new List<Person>();

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
    Console.WriteLine($"The youngs workers collection by increasing age and descending wage is; {item.ToString()}");
}