using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISDGit
{
    class Program
    {
        static void Main(string[] args)
        {
            dbcontrol s = new dbcontrol();

            foreach (DataRow r in s.Query("select * from tbl_sample where id = @id", p => p.Add("@id", 1)).Rows)
            {
                Console.WriteLine("Firstname: {0}\nMiddlename: {1}\nLastname: {2}", r[1], r[2], r[3]);
            }
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

            public void FillPerson()
            {
                Console.Write("Enter your name: ");
                Name = Console.ReadLine();
                Console.Write("Enter your birthday: ");
                Birthday = Convert.ToDateTime(Console.ReadLine());
                Console.Clear();
            }

        }
    }
}
