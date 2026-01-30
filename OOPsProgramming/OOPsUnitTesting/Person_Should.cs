
using Microsoft.VisualStudio.TestPlatform.Common.DataCollection;
using System;
using System.Collections.Generic;
using System.Text;

#region Additional Namespaces
using LearningObjects;
#endregion

namespace OOPsUnitTesting
{
    public class Person_Should
    {
        #region Using Valid Data
        //the type [Fact] says to run the test once
        //[Fact] is called an annotation
        //ANY unit test MUST have an annotation in front
        //  of the unit test method to be recognized as an unit test
        [Fact]
        public void Successfully_Create_Default_Instance_With_Valid_Data()
        {
            //Arrange
            //optionally
            //this area of your unit test is used to
            //  create test data needed to complete the test

            //Act
            //optionally
            //this area of your unit test would represent the
            //  line of code in any program that will be executed
            Person sut = new Person();

            //Assert
            //this area of your unit test checks the expected result
            //  of your unit test
            //is the test result as expected????
            Assert.Equal("Unknown", sut.Name);
            Assert.Equal(0,sut.Age);
            Assert.Equal(0.00m,sut.Wage);
        }
        [Fact]
        public void Successfully_Create_Greedy_Instance_With_Valid_Data_Including_Wage()
        {
            //Arrange

            //Act
            Person sut = new Person("  Don  ",70,55990.02m);

            //Assert
            Assert.Equal("Don", sut.Name);
            Assert.Equal(70, sut.Age);
            Assert.Equal(55990.02m, sut.Wage);
        }
        [Fact]
        public void Successfully_Create_Greedy_Instance_With_Valid_Data_Without_Wage()
        {
            //Arrange

            //Act
            Person sut = new Person("  Don  ", 70);

            //Assert
            Assert.Equal("Don", sut.Name);
            Assert.Equal(70, sut.Age);
            Assert.Equal(0.00m, sut.Wage);
        }
        [Fact]
        public void Successfully_Alter_Name_Via_Property()
        {
            //Arrange
            //this area of your unit test is used to
            //  create test data needed to complete the test
            //we need an instance to be able to call the property of the instance
            Person sut = new Person("Don", 70);

            //Act
            sut.Name = "    Terry   ";

            //Assert
            Assert.Equal("Terry", sut.Name);
            //optional
            //did changing the name, change any other data in the instance by accident
            Assert.Equal(70, sut.Age);
            Assert.Equal(0.00m, sut.Wage);
        }
        [Fact]
        public void Successfully_Alter_Age_Via_Property()
        {
            //Arrange
            Person sut = new Person("Don", 70);

            //Act
            sut.Age = 55;

            //Assert
            Assert.Equal(55, sut.Age);
            //optional
            //did changing the age, change any other data in the instance by accident
            Assert.Equal(0.00m, sut.Wage);
            Assert.Equal("Don", sut.Name);
        }
        [Fact]
        public void Successfully_Alter_Wage_Via_ChangeWage()
        {
            //Arrange
            Person sut = new Person("Don", 70);

            //Act
            sut.ChangeWage(101456.99m);
            //Assert
            Assert.Equal(101456.99m, sut.Wage);
            //optional
            //did changing the age, change any other data in the instance by accident
            //Assert.Equal(70, sut.Age);
            //Assert.Equal("Don", sut.Name);
        }
        #endregion

        #region Testing with Invalid data
        //how many invalid values could one have for the string Name
        // null, empty string, just blanks in the string

        //Is there a way to have one unit test, execute n possible different
        //  actions?
        //YES: use the [Theory] annotation
        //the Theory annotation executes as if it were a loop
        //after the annotation include the value(s) for each iteration of the theory
        //      using the annotation [InlineData(....)] where .... is your value(s)
        //[Theory]
        //[InlineData(null,70,14.00)]
        //[InlineData("", 70, 14.00)]
        //[InlineData("   ", 70, 14.00)]
        //public void  Fail_To_Create_Instance_For_Invalid_Name(string name, int age, decimal wage)
        //{
        //    //IF your method is part of a Theory test which contains iteration value(s)
        //    //  you MUST include as part of the header, a parameter list,
        //    //  a parameter for each value(s) in your InlineData

        //    //Arrange

        //    //Act

        //    //Assert
        //    //when code throw asserts, the preferred method is to include
        //    //    the Act as part of the Assert test
        //    //pattern:  Assert.Throws<T>(.....); where ..... represents your Act
        //    //syntax of the Act: () => the code to execute
        //    Assert.Throws<ArgumentNullException>(() => new Person(name, age, wage));
        //}

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Fail_To_Create_Instance_For_Invalid_Name(string name)
        {
            //IF your method is part of a Theory test which contains iteration value(s)
            //  you MUST include as part of the header, a parameter list,
            //  a parameter for each value(s) in your InlineData

            //Arrange

            //Act

            //Assert
            //when code throw asserts, the preferred method is to include
            //    the Act as part of the Assert test
            //pattern:  Assert.Throws<T>(.....); where ..... represents your Act
            //syntax of the Act: () => the code to execute
            Assert.Throws<ArgumentNullException>(() => new Person(name, 70, 14.00m));
        }
        #endregion
    }
}
