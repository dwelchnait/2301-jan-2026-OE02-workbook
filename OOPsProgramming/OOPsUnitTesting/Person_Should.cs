
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
    }
}
