// See https://aka.ms/new-console-template for more information
Console.WriteLine("Over and over and over again!");

//typical menu loop


string choice = "";

//post-test iteration
//will execute the coding block at least once
//after each execution of the coding block the
//  iteration condition is evaluated
//if true, do the iteration again
//if false, exit the iteration

//post-test loop (done at the end of the loop)
//do-until loops
//the do-until structure is use for an unknown number of iterations
do
{
    choice = GetChoice();
    switch (choice.ToLower())
    {
        case "a":
            {
                WhileIteration();
                break; //this is not unstructured code, it is  part of the switch structure
            }
        case "b":
            {
                ForIteration();
                break;
            }
        case "c":
            {
                ForEachIteration();
                break;
            }
        case "x":
            {
                Console.WriteLine($"\nThank you. Come again.");
                break;
            }
        default:
            {
                Console.WriteLine($"\nYour choice of >{choice}< is invalid");
                break;
            }
    }
} while (choice.ToUpper() != "X");

static string GetChoice()
{
    string choice = ""; 
    Console.WriteLine("\nChoose pre-test iteration example");
    Console.WriteLine("a: While (unknown iteration times)");
    Console.WriteLine("b: For (exact loop iteration)");
    Console.WriteLine("c: Foreach (great for collections)");
    Console.WriteLine("x: exit");
    Console.Write("Enter your choice:\t");

    choice = Console.ReadLine();

    return choice;
}

static void  WhileIteration()
{
    //a temporary starting point for a method with no precessing code is
    //  often called a "method stub"
    //IF your method stub returns a value, then put in a return statement
    //  with an acceptable return value

    //collect a set of numbers and display the total
    string inputValue = "";
    int total = 0;
    int num = 0;
    int numberOfValues = 0;

    //pre-test iteration, the loop condition is done before the coding block is executed
    //the iteration continues as long as the condition is true
    //the "while" iteration is used when the number of iterations is unknown

    Console.Write("\nEnter a positive integer value or a negative value to exit:\t");
    inputValue = Console.ReadLine();
    num = int.Parse(inputValue); //assume value data

    while (num >= 0) //consider using positive oriented condition code
    {
        //total = total + num;
        total += num;
        //numberOfValues = numberOfValues + 1;
        //numberOfValues += 1;
        numberOfValues++; //increment value by 1

        Console.Write("\nEnter a positive integer value or a negative value to exit:\t");
        inputValue = Console.ReadLine();
        num = int.Parse(inputValue); //assume value data
    }

    Console.WriteLine($"\n\tThe sum of the {numberOfValues} digits entered is {total}");
}
static void ForIteration()
{
    string inputValue = "";
    int total = 0;
    int num = 0;
    int numberOfValues = 0;

    Console.Write("\nEnter the number of iterations to perform:\t");
    inputValue = Console.ReadLine();
    numberOfValues = int.Parse(inputValue); //assume value data

    //pre-test iteration, the loop condition is done before the coding block is executed
    //the iteration continues as long as the condition is true
    //the "for" iteration is used when the number of iterations is known
    //syntax  for(int loopcounter = value; termination condition; increment/decrement)
    //           { coding block }

    for(int counter = 0; counter < numberOfValues; counter++)
    {
        Console.Write("\nEnter a integer value:\t");
        inputValue = Console.ReadLine();
        num = int.Parse(inputValue); //assume value data

        total += num;
    }

    Console.WriteLine($"\n\tThe sum of the {numberOfValues} digits entered is {total}");
}
static void ForEachIteration()
{
    //collect: a set of numbers and display the total
    string inputValue = "";
    int total = 0;
    int[] numberOfValues = new int[] { 1, 2, 3, 4, 5 }; //array
    int numberOfCollectionItems = 0;

    //pre-test iteration, the loop condition is done before the coding block is executed
    //the iteration starts with the first item in your collection, continues processing
    //  the next item on the next iteration, and continues until the last item is processed
    //if there is no items in the collection, no iteration is done
    //syntax  foreach(collectiondatatype collectionitemidentifier in collectionname)
    //           { coding block }
    //typically you may see the datatype var used as the collectiondatatype

    foreach (int num in numberOfValues)
    {
        //note: no input request, data is already within a stored collection
        total += num;
        numberOfCollectionItems++;
    }

    Console.WriteLine($"\n\tThe sum of the {numberOfCollectionItems} collection digits is {total}");
}
