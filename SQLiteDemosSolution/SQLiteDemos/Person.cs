using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace SQLiteDemos
{
    public class Person
    {
        //Id is the "pkey" of the entity that will be SQLite datastore
        //this will be a generated field by SQLite
        public int Id { get; private set; } 
        public string? Name { get; set; }
        public int Age { get; set; }
        public int Mark { get; set; }
        public Person() { }
        public Person(string name,  int age, int mark)
        {
           
            Name=name;
            Age=age;
            Mark=mark;
        }
    }
}
