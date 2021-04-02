using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWinForms
{
    public class Person
    {
        dbcontrol s = new dbcontrol();

        public event EventHandler Updated;
        public event EventHandler Inserted;

        public int ID { get; set; }
        public string fname { get; set; }
        public string mn { get; set; }
        public string lname { get; set; }

        public Person()
        {

        }

        public Person(DataRow r)
        {
            ID = (int)r[0];
            fname = r[1].ToString();
            mn = r[2].ToString();
            lname = r[3].ToString();
        }

        public Person(int ID, string fname, string mn, string lname)
        {
            this.ID = ID;
            this.fname = fname;
            this.mn = mn;
            this.lname = lname;
        }
        public Person(string fname, string mn, string lname)
        {
            this.fname = fname;
            this.mn = mn;
            this.lname = lname;
        }

        public void Insert(Person p)
        {
            s.Insert("tbl_sample", f =>
            {
                f.Add("fname", p.fname);
                f.Add("mn", p.mn);
                f.Add("lname", p.lname);
            });
            Inserted?.Invoke(this, EventArgs.Empty);
        }

        public Person FindPerson(int ID)
        {
            var p = new Person();
            s.Query("select * from tbl_sample where ID = @ID", f => f.Add("@ID", ID)).AsEnumerable().ToList().ForEach(r =>
            {
                p = new Person(r);
            });
            return p;
        }

        public void Update(Person p)
        {
            s.Update("tbl_sample", p.ID, f =>
            {
                f.Add("fname", p.fname);
                f.Add("mn", p.mn);
                f.Add("lname", p.lname);
            });
            Updated?.Invoke(this, EventArgs.Empty);
        }

        public List<Person> ListPerson(string Search = "")
        {
            var list = new List<Person>();
            s.Query("select * from tbl_sample where fname like @search or mn like @search or lname like @search", p => p.Add("@search", $"%{Search}%")).AsEnumerable().ToList().ForEach(r =>
            {
                list.Add(new Person(r));
            });
            return list;
        }
    }
}
