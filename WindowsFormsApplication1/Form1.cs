using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> YourDestiny = new List<string> { "Magkaka anak ka ng aso", "Magkaka asawa ka ng baog", "Magiging mayaman ka", "Ikaw ang pagasa ng bayan", "Ikaw lang ang sakalam" };

        private void button1_Click(object sender, EventArgs e)
        {
            Message m = new Message($"{textBox1.Text} {YourDestiny[new Random().Next(0, YourDestiny.Count)]}");
            m.Show();
        }
    }
}
