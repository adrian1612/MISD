using System;
using System.Collections.Generic;

namespace SampleWinForms
{
    public interface IPerson
    {
        string fname { get; set; }
        int ID { get; set; }
        string lname { get; set; }
        string mn { get; set; }

        event EventHandler Inserted;
        event EventHandler Updated;

        Person FindPerson(int ID);
        void Insert(Person p);
        List<Person> ListPerson(string Search = "");
        void Update(Person p);
    }
}