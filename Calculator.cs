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
using System.Xml;

namespace _1045_BarsanescuDiana_Proiect
{
    
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        public Calculator(string val)
        {
            InitializeComponent();
            if(Convert.ToDouble(val) > 0)
                tbValue.Text = val;
        }

        public Calculator(string val, string cur, string rateV)
        {
            InitializeComponent();
            tbDate.Text = DateTime.Now.ToString();
            if (Convert.ToDouble(val) > 0)
                tbValue.Text = val;
            if (Convert.ToDouble(rateV) > 0)
                tbRate.Text = rateV;
            if (cur != "")
                cbCurrency.Text = cur;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("nbrfxrates.xml");
            string str = sr.ReadToEnd();
            sr.Close();

            XmlReader reader = XmlReader.Create(new StringReader(str));
            while (reader.Read())
            {
                if (reader.Name == "PublishingDate" && reader.NodeType == XmlNodeType.Element)
                {
                    reader.Read();
                    tbDate.Text = reader.Value;
                }
                if (reader.Name == "Rate" && reader.NodeType == XmlNodeType.Element)
                {
                    string atribut = reader["currency"];
                    if (atribut == cbCurrency.Text)
                    {
                        reader.Read();
                        tbRate.Text = reader.Value;
                    }
                }
            }
        }        

        private void button4_Click(object sender, EventArgs e)
        {

            if (cbCurrency.Text == "")
                errorProvider1.SetError(cbCurrency, "Please choose currency!");
            else
                if (tbValue.Text == "")
                errorProvider1.SetError(tbValue, "Please insert value!");
                else
                try
                {
                    tbFinal.Text = (Convert.ToDouble(tbValue.Text) / Convert.ToDouble(tbRate.Text)).ToString("N2");
                    lbFinal.Text = cbCurrency.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception: " + ex.Message);
                }
                finally
                {
                    errorProvider1.Clear();
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            Add frm = new Add(tbValue.Text, cbCurrency.Text, tbRate.Text);
            frm.ShowDialog();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            tbValue.Text = vScrollBar1.Value.ToString();
        }

        private void tbValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                vScrollBar1.Value = Convert.ToInt32(tbValue.Text);
            }
            catch
            {
                vScrollBar1.Value = 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbDate.Clear();
            cbCurrency.Text = "";
            tbRate.Clear();
            tbValue.Clear();
            tbFinal.Clear();
            lbFinal.Text = "";
        }

        private void tbValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void darkBlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkSlateGray;
            tbDate.BackColor = Color.DarkSlateGray;

        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            tbDate.BackColor = Color.Black;
        }

        private void greyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Gray;
            tbDate.BackColor = Color.Gray;
        }

    }
}
