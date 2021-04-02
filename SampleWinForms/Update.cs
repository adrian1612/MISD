using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleWinForms
{
    public partial class Update : Form
    {
        Person p = new Person();
        public event EventHandler Updated;
        public Update(int ID)
        {
            InitializeComponent();

            p = p.FindPerson(ID);
            textBox1.Text = p.fname;
            textBox2.Text = p.mn;
            textBox3.Text = p.lname;
            textBox4.Text = p.ID.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = MessageBox.Show("Are you sure you want to update?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                p.Update(new Person(p.ID, textBox1.Text,textBox2.Text,textBox3.Text));
                Updated?.Invoke(this, EventArgs.Empty);
                Close();
            }
        }
    }
}
