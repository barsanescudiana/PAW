using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _1045_BarsanescuDiana_Proiect
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();

        }

        private void calculatorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            Calculator frm = new Calculator();
            frm.ShowDialog();
        }

        private void viewAllRatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rates frm = new Rates();
            frm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            label3.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewEmployees frm = new ViewEmployees();
            frm.ShowDialog();
            

        }
        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.ShowDialog();
        }
    }
}
