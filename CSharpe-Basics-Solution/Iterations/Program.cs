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
   
}
static void ForIteration()
{

}
static void ForEachIteration()
{

}
