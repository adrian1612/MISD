using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISDGit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Worlds");
            Console.ReadLine();
        }

        public class Person
        {
            public string Name { get; set; }
            public int Age { get { return DateTime.Now.Subtract(Birthday).Days / 365; } }
            public DateTime Birthday { get; set; }
            public Person()
            {

            }

            public Person(string _Name, DateTime _Birthday)
            {
                Name = _Name;
                Birthday = _Birthday;
            }


        }
    }
}
