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
    public partial class Add : Form
    {
        Person p = new Person();
        public event EventHandler Added;
        public Add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            var dialog = MessageBox.Show("Confirm Add person", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                p.Insert(new Person(textBox1.Text, textBox2.Text, textBox3.Text));
                Added?.Invoke(this, EventArgs.Empty);
                Close();
            }
        }
    }
}
