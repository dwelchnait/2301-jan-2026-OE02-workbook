// See https://aka.ms/new-console-template for more information
//this is a top-level statement console application
//the Main() entry point to the application is implied

//this is an output statement to display to
//  your console screen.
//syntax:  static-classname.methodname(argument)
Console.WriteLine("Hello, World!"); //method call statement

//variables
//C# is a strongly-typed language
//once a variable has been declare for a specific
//  datatype, that variable WILL be ONLY that datatype
//a variable with a specified datatype, is resolved at compile time
//variable names must be unique

//Special: var variable
//          this obtains its datatype when it is first
//          encounter in your program according to the
//          datatype of the using value.
//          HOWEVER, once determined, it CAN NOT BE ALTERED
//          var is resolved at run time

//syntax: datatype variablename [= value];
//        datatype variablename [, variable2name, ...];

//default for numeric is 0

int rawGrade;
int assignmentWeight, maxGrade;
double weightedMark = 0.0;

//decimal literals need to be identified by having an m suffix at the end
//  of the value
//decimal weightedMark = 0.0m;


//Strings and Characters
// strings is a set of characters: datatype string
// character is a single character: datatype char

// string literals are encased in double quotes ("")
// char literals are encased in single quotes ('')
string courseID;

//class variables
//DateTime which holds both a date and the time
//.Today has a date of today and a time portion of 00:00:00am
//.Now has a date of today and a time portion of hh:mm:ss am/pm
DateTime theDate = DateTime.Today;

//calculate the weighted mark for an assessment in a course
//inputs: mark weight, maximum grade, raw grade, courseid
//process:
//  input values
//  calculate weighted mark
//  output a message with the weighted mark

//input values
// reading command is Console.ReadLine();
// all input come in as a string
// To convert to a specific datatype, investigate if the datatype
//      has a .Parse() method

string inputValue;

// prompt, read, store (may need to parse the incoming value)
//prompt: .Write() this method will NOT proceed to the need line
Console.Write("Enter the course id:\t");
inputValue = Console.ReadLine();
courseID = inputValue;

Console.Write("Enter the course mark weight:\t");
inputValue = Console.ReadLine();
assignmentWeight = int.Parse(inputValue);

Console.Write("Enter the maximum grade value:\t");
inputValue = Console.ReadLine();
maxGrade = int.Parse(inputValue);

Console.Write("Enter the your received grade value:\t");
inputValue = Console.ReadLine();
rawGrade = int.Parse(inputValue);

//Calculation
//all standard rules of math apply in this language

//the result of your calculation is dependent on your
//  variable data type
//problem here is the calculation variables are integers
//          therefore the calculation uses the rules of integer arth.

//Solutions:
//a) change the datatype of your variables
//      may cause problems elsewhere in your code, REMEMBER to retest your program

//b) if one of the variables' datatype is different then others
//      and allows for increased numeric representation (ie integer to double)
//      then C# will attempt to do the calculation at the greater
//      numeric representation
// rawGrade is a double (increased numeric representation)

//c) use a type-cast on your field(s)
//      a type-cast is a temporary internal changing of how to handle
//      the variable's data

weightedMark = rawGrade / (double)maxGrade * assignmentWeight;

//output
//string concatenation : numerics

//use the concatenation operator: +
Console.WriteLine("\nYour mark in " + courseID +
                    " is " + Math.Round(weightedMark,1));

// index replacement string creation
Console.WriteLine("\nYour mark in {0} is {1:##0.0}", courseID, weightedMark);

//string interpolation (preferred)
Console.WriteLine($"\nYour mark in {courseID} is {weightedMark.ToString("#,##0.00")}");

//if your console app does not stop and remain visible
// try using the following to keep the window open
//Console.ReadKey();
