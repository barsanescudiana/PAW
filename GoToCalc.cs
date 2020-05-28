using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace _1045_BarsanescuDiana_Proiect
{
    public partial class GoToCalc : UserControl
    {
        string c, v, r;
        public GoToCalc()
        {
            InitializeComponent();
        }


        public GoToCalc(string value, string currency, string rate)
        {
            InitializeComponent();
            v = value;
            c = currency;
            r = rate;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Calculator frm;
            if (r == "" && c == "" && r == "")
                frm = new Calculator();
            else
                frm = new Calculator(v, c, r);
            frm.ShowDialog();
        }

        private void GoToCalc_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.Teal;
        }
    }
}
