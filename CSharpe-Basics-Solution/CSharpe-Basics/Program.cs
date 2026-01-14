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


