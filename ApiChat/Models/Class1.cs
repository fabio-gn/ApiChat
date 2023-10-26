using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiChat.Models
{
    public class Person
    {
        static public int count = 0;
        public int Id;
        public string Name { get; set; }
        public string Surname { get; set; }
        static public List<Person> PeopleList { get; set; }  = new List<Person>();
        public Person() {
            //count++;
            //Id = count;
            //PeopleList.Add(this);
        }
        //public Person(string name, string surname)
        //{
        //    count++;
        //    Id = count;
        //    Name= name;
        //    Surname= surname;
        //    PeopleList.Add(this);
            
        //}
    }
}