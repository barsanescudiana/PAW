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
using System.Drawing.Printing;

namespace _1045_BarsanescuDiana_Proiect
{
    public partial class ShowTransactions : Form
    {
         public List<Transaction> transactionsList = new List<Transaction>();

        public ShowTransactions()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader("Transactions.txt");
            string linie;
            while ((linie = sr.ReadLine()) != null)
            {
                dataGridView1.Rows.Add(Convert.ToString(linie.Split(' ')[0]), Convert.ToString(linie.Split(' ')[1]),
                    Convert.ToString(linie.Split(' ')[2]), Convert.ToString(linie.Split(' ')[3]),
                    Convert.ToString(linie.Split(' ')[4]), Convert.ToString(linie.Split(' ')[5]),
                    Convert.ToString(linie.Split(' ')[6]), Convert.ToString(linie.Split(' ')[7]));
                dataGridView1.BackgroundColor = Color.Black;
            }

            sr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
