using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;


namespace LearningObjects
{
  
    public class Person
    {
        //data member

        private string _Name;
        private int _Age;
      
        //properties

        public string Name
        {
            //accessor (getter)
            //returns the string associated with this property
            get { return _Name; }

            //mutator (setter)
            //the incoming data value is accessed within the property
            //  using the keyword: value
            //the incoming value to the instance's property  will be stored
            //  in the data member _Name.

            //it is within the set that the validation of the data
            //  is done to determine if the data is acceptable
            //if all processing of the string is done via the property
            //  it will ensure that good data is within the associated string
            set 
            { 
                //validate that the Name cannot be null, empty or just blank characters
               if (string.IsNullOrWhiteSpace(value))
               {
                    //classes do not output directly to the program user
                    //classes throw Exceptions that are handled by the program and displayed to the 
                    //  human user
                    //there are many types of exceptions within C#
                    // general catchall exception: Exception
                    // specific exceptions:
                    //      ArgumentNullException (used when missing a value)
                    //      ArgumentException ( used when the value supplied is incorrect)
                    throw new ArgumentNullException("Name", "Name cannot be empty or just blanks");
               }
               else
               {
                    //has an actual character(s) in the value
                    // "    don welch     "
                    //it is a very good practice to remove leading and trailing spaces on strings
                    //  so that only the required and important characters are stored.
                    //to do this sanitization use .Trim()
                    //this does not remove embedded blanks:  "don welch"
                    _Name = value.Trim();
               }
            }
        }

        //auto implemented property version of Name
        //public string Name { get; set; }

        ///<summary>
        ///Property: Age
        ///validation: the value must be 0 or greater
        ///datatype: int
        ///</summary>
        ///

        public int Age
        {
            get { return _Age; }
            set
            {
                if (value < 0) //int.IsNegative(value)
                //{
                    // a throw cause execution to stop and exit the property or method
                    throw new ArgumentException($"The age {value} is invalid. Age must be 0 or greater.", "Age");
                //}
                //else
                //{
                _Age = value;
                //}
            }
        } //eop end of property

        //create an auto implemented property for Wage data
        //the o/s will create the storage area for saving the data within the class instance (object)
        //therefore no data member is required for this property

        //one option on the setter is to make it private
        //if private:
        //  changes to this data will ONLY be done via a constructor or a method
        //  one will NOT be able to directly change the data via the property
        //  the ONLY code that could change Wage is code that exists within the Person class
        //  DO NOT make your getter private

        //if your validation is NOT in the property, EVERY time you alter the data
        //  you NEED to consider if validation is required.
        //if validation is required, that validation MUST be placed in your code
        //  WHEREVER the alternation is done
        public decimal Wage { get; private set; }

        //methods
        //  constructor

        //constructor ensure that when an class instance (object) is created, the contents
        //  of the object will be as "expected" (in a known state)

        //your class does not technically need a coded constructor
        //if you code a constructor for your class you are responsible for coding ALL constructors for the class
        //if you do not code a constructor then the system will assign the software datatype defaults
        //  to your variables (data members/auto-implemented properties)

        //syntax: accesslevel constructorname([list of parameters]) { .... }
        //NOTE: NO return datatype
        //      the constructorname MUST be the class name

        //Default
        //simulates the "system defaults"
        //no parameters are submitted
        public Person()
        {
            //if there is no code within this constructor, the actions for setting
            //  your internal fields will be using the system defaults for the datatype

            //optionally!!!!!
            // you could assign values to your initial fields within this constructor typically
            //      using literal values
            //Why?
            // your internal fields may have validation attached to the data for the field
            // this validation is usually within the property
            // you would wish to have valid data values for your internal fields

            //BEST PRACTICE: always wherever possible save and access your instance data
            //                  via the properties, specially, when the property contains validation
            Name = "Unknown";

            //Age and Wage
            //the default values is 0 (fine)
            //HOWEVER, if you wish you could code the initial value
            Age = 0;
            Wage = 0.00m; //m is need as the literal needs to be a decimal literal NOT double literal
        }

        //Greedy
        //this is the constructor typically used to assign values to a instance at the time of
        //    creation
        //the list of parameters normal include ALL data members AND auto implemented properties
        //the list of parameters may or may not contain default parameter values
        //if you have assigned default parameter values then those parameters MUST be at the end of
        //  the parameter list
        //in this example wage is a default parameter (it has an assigned value if the value
        //  is not included on the coded constructor in the user program
        public Person(string name, int age, decimal wage = 0.00m)
        {

            Name = name;
            Age = age;

            //if wage was NOT on the new statement then the value of the parameter
            //  defaults to 0.00
            //if wage was supplied on the new statement then the supplied value is the
            //  contents of the parameter

            //one could add validation to the constructor, especially if the property has
            //  a private set OR 
            //  the property is an auto-implemented property that has restrictions
            //example: Wage
            //         must be 0 or greater
            if (wage < 0)
                throw new ArgumentException($"The wage {wage} is invalid. Wage must be 0 or greater.","Wage");
                //throw new ArgumentOutOfRangeException("Wage", $"The wage {wage} is invalid. Wage must be 0 or greater.");
            //here, if the throw happen, execution would proceed to the end of the constructor
            //  and NOT set Wage
            //AND
            //the instance would NOT be created
            Wage=wage;
        }


        // behaviour (aka method)

        //syntax of a general method
        // accesslevel [override] returndatatype methodname ([list of parameters])
        // {
        //     coding block
        //  }

        // realize that to use a method or any item within your instance you must have the instance
        //  if you have the instance then you have the data within the instance ALREADY
        //  THEREFORE, if the data is within the instance you DO NOT need to pass the data into your method

        public decimal CalculateBonus(decimal yearsofservice)
        {
            //Notice: Wage is not passed in, as it is already known within the instance
            // yearsofservice is NOT stored within the instance THERFORE it MUST be a parameter
            return Wage * yearsofservice / 100;
        }

        //we would like to dump the data within the instance to "somewhere"
        public override string ToString()
        {
            //each instance has a ToString() method as part of its construction
            //you can overide the default coding of the supplied method
            //to use your own code, create the method with the special keyword "override"
            //in this example the delimiter for the value will be a ; due to the fact
            //  I wish to use a comma , in the Wage display
            return $"{Name};{Age};{Wage.ToString("#,##0.00")}";
        }

        //this method will allow the alteration of the Wage data
        //if the setter on Wage was NOT private then this method would NOT be needed
        public void ChangeWage(decimal newwage)
        {
            //is there required validation: YES
            //is the validation in the property: NO (we have an auto-implemented property)
            //THEREFORE you WILL need to REPEAT the validation in this method
            if (newwage < 0)
                throw new ArgumentException($"The wage {newwage} is invalid. Wage must be 0 or greater.", "Wage");
            Wage = newwage;
        }
    }
}
