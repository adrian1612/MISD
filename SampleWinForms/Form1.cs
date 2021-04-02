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
    public partial class Form1 : Form
    {
        Person p = new Person();

        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData(string Search = "")
        {
            dataGridView1.DataSource = p.ListPerson(Search);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadData(textBox1.Text);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmAdd = new Add();
            frmAdd.Added += FrmAdd_Added;
            frmAdd.ShowDialog();
        }

        private void FrmAdd_Added(object sender, EventArgs e)
        {
            LoadData();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if (r.Selected)
                {
                    var frmUpdate = new Update((int)r.Cells[0].Value);
                    frmUpdate.Updated += FrmUpdate_Updated;
                    frmUpdate.ShowDialog();
                }
            }
        }

        private void FrmUpdate_Updated(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
