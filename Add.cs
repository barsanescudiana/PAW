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
using System.Drawing.Printing;
using System.Data.OleDb;

namespace _1045_BarsanescuDiana_Proiect
{
    public partial class Add : Form
    {
        //List<string> CollectionCurrencies = new List<string> { "EUR", "GBP", "USD", "XAU" };
        int _currentChar;
        private readonly List<Transaction> listT = new List<Transaction>();
        string connS;
        int codMax;

        public Add()
        {
            InitializeComponent();
            cbEmployee.Text = "";
            _currentChar = 0;
            gbCard.Visible = false;
            tbNo.Text = Convert.ToString(getMaxValue());
            tbNo.Enabled = false;
            //sr.Close();
            connS = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Employees.accdb";
            try
            {
                OleDbConnection connection = new OleDbConnection(connS);
                connection.Open();
                DataSet ds = new DataSet("Employees.accdb");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Add(string val, string cur, string rVal)
        {
            InitializeComponent();
            cbEmployee.Text = "";
            if (Convert.ToDouble(val) > 0)
                tbValueRON.Text = val;
            if (cur != "")
                cbCurrency.Text = cur;
            tbRateCurrency.Text = rVal;
            tbNo.Text = Convert.ToString(getMaxValue());
            tbNo.Enabled = false;
            //sr.Close();
        }
        public Add(string v)
        {
            InitializeComponent();
            cbEmployee.Text = "";
            if (Convert.ToDouble(v) > 0)
            {
                tbValueRON.Text = v;
            }
            tbNo.Text = Convert.ToString(getMaxValue());
            tbNo.Enabled = false;
            //sr.Close();
        }

        public Add(string cur, string rate)
        {
            InitializeComponent();
            cbCurrency.Text = cur;
            tbRateCurrency.Text = rate;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                hScrollBar1.Value = Convert.ToInt32(tbValueRON.Text);
            }
            catch
            {
                hScrollBar1.Value = 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\diana\OneDrive\Desktop\PAW_Proiect\1045_BarsanescuDiana_Proiect\bin\Debug\Transactions.txt";
            if (dateTimePicker1.Value == Convert.ToDateTime(null))
                errorProvider1.SetError(dateTimePicker1, "Please choose date!");
            else
                if (tbNo.Text == "")
                errorProvider1.SetError(tbNo, "Please insert transaction number!");
            else
                if (tbPayer.Text == "")
                errorProvider1.SetError(tbPayer, "Please insert payer name!");
            else
                if (cbEmployee.Text == "")
                errorProvider1.SetError(cbEmployee, "Please insert employee ID!");
            else
                if (tbValueRON.Text == "")
                errorProvider1.SetError(tbValueRON, "Please insert value!");
            else
                if (cbCurrency.Text == "")
                errorProvider1.SetError(cbCurrency, "Please choose currency!");
            else
                try
                {
                    DateTime date = dateTimePicker1.Value;
                    int tNo = Convert.ToInt32(tbNo.Text);
                    string idE = cbEmployee.Text, idP = tbPayer.Text, currency = cbCurrency.Text;
                    float vRON = (float)Convert.ToDouble(tbValueRON.Text), vRate = (float)Convert.ToDouble(tbRateCurrency.Text);
                    Transaction t = new Transaction(date, tNo, idP, idE, vRON, currency, vRate);
                    listT.Add(t);
                    if (!File.Exists(path))
                    {
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine(tNo + " " + idE + " " + idP + " " + date + " " + vRON + " " + t.finalValue().ToString("N2") + " " + currency);
                        }
                    }
                    else
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.WriteLine(tNo + " " + idE + " " + idP + " " + date + " " + vRON + " " + t.finalValue().ToString("N2") + " " + currency);
                        }
                    MessageBox.Show(t.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception: " + ex.Message);
                }
                finally
                {
                    cbEmployee.Text = "";
                    tbNo.Clear();
                    tbPayer.Clear();
                    tbValueRON.Clear();
                    cbCurrency.Text = "";
                    tbRateCurrency.Clear();
                    tbAddress.Clear();
                    tbCNP.Clear();
                    cbPayment.Text = "";
                    if (gbCard.Visible == true)
                        gbCard.Visible = false;
                    errorProvider1.Clear();
                }
        }

        private void cbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("nbrfxrates.xml");
            string str = sr.ReadToEnd();
            sr.Close();

            XmlReader reader = XmlReader.Create(new StringReader(str));
            while (reader.Read())
            {

                if (reader.Name == "Rate" && reader.NodeType == XmlNodeType.Element)
                {
                    string atribut = reader["currency"];
                    if (atribut == cbCurrency.Text && (cbCurrency.Text == "HUF" || cbCurrency.Text == "JPY" || cbCurrency.Text == "KRW"))
                    {
                        reader.Read();
                        tbRateCurrency.Text = Convert.ToString(Convert.ToDouble(reader.Value) / 100);
                    }
                    else
                        if (atribut == cbCurrency.Text)
                    {
                        reader.Read();
                        tbRateCurrency.Text = reader.Value;

                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowTransactions frm = new ShowTransactions();
            frm.ShowDialog();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            tbValueRON.Text = hScrollBar1.Value.ToString();
        }

        private void tbValueRON_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbNo_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbNo.Text.Trim()))
            {
                errorProvider1.SetError(tbNo, "Insert transaction number!");
            }
            else
            {
                errorProvider1.SetError(tbNo, string.Empty);
            }
            errorProvider1.Clear();
        }

        private void tbPayer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbEmployee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value == Convert.ToDateTime(null))
                errorProvider1.SetError(dateTimePicker1, "Please choose date!");
            else
            if (tbNo.Text == "")
                errorProvider1.SetError(tbNo, "Please insert transaction number!");
            else
            if (cbEmployee.Text == "")
                errorProvider1.SetError(cbEmployee, "Please insert employee ID!");
            else
            if (tbValueRON.Text == "")
                errorProvider1.SetError(tbValueRON, "Please insert value!");
            else
            if (cbCurrency.Text == "")
                errorProvider1.SetError(cbCurrency, "Please choose currency!");
            else
            if (tbPayer.Text == "")
                errorProvider1.SetError(tbPayer, "Please insert payer name!");
            else
                if (tbCNP.Text == "")
                errorProvider1.SetError(tbCNP, "Please write your CNP!");
            else
                if (tbAddress.Text == "")
                errorProvider1.SetError(tbAddress, "Please write your address!");
            else
                if (cbPayment.Text == "")
                errorProvider1.SetError(cbPayment, "Please choose payment method!");
            else
            try
            {
                    if (gbCard.Visible == true)
                    {
                        if (tbCard.Text == "")
                            errorProvider1.SetError(tbCard, "Please insert card number!");
                        else
                            if (cbMonth.Text == "")
                            errorProvider1.SetError(cbMonth, "Please choose expiration month!");
                        else
                            if (cbYear.Text == "")
                            errorProvider1.SetError(cbYear, "Please choose expiration year!");
                        else
                            if (tbCvv.Text == "")
                            errorProvider1.SetError(tbCvv, "Please write your CVV!");

                    }
                        printDialog1.Document = printDocument1;
                    if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                        printDocument1.Print();

            } catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    tbNo.Text = Convert.ToString(getMaxValue());
                    tbNo.Enabled = false;
                    cbEmployee.Text = "";
                    tbValueRON.Clear();
                    cbCurrency.Text = "";
                    tbRateCurrency.Clear();
                    tbPayer.Clear();
                    tbCNP.Clear();
                    tbAddress.Clear();
                    cbPayment.Text = "";
                    if(gbCard.Visible == true)
                    {
                        gbCard.Visible = false;
                    }
                    errorProvider1.Clear();
                }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("GTWalsheimProRegular", 12);
            Font font2 = new Font("GTWalsheimProRegular", 12, FontStyle.Bold);

            var pageSettings = printDocument1.DefaultPageSettings;
            var intPrintAreaHeight = pageSettings.PaperSize.Height - pageSettings.Margins.Top - pageSettings.Margins.Bottom;
            var intPrintAreaWidth = pageSettings.PaperSize.Width - pageSettings.Margins.Left - pageSettings.Margins.Right;
            var marginLeft = pageSettings.Margins.Left;
            var marginTop = pageSettings.Margins.Top + 50;
            var marginBottom = pageSettings.Margins.Bottom;
            if (printDocument1.DefaultPageSettings.Landscape)
            {
                var intTemp = intPrintAreaHeight;
                intPrintAreaHeight = intPrintAreaWidth;
                intPrintAreaWidth = intTemp;
            }

            RectangleF rectPrintingAreat = new RectangleF(marginLeft + 250, marginTop - 50, 300, 200);
            RectangleF rectPrintingArea = new RectangleF(marginLeft, marginTop, 300, 200);
            RectangleF rectPrintingArea2 = new RectangleF(500, marginTop, 300, 200);
            RectangleF rectPrintingAreat2 = new RectangleF(marginLeft + 250, marginTop + 200, 300, 200);
            RectangleF rectPrintingArea3 = new RectangleF(marginLeft, marginTop + 250, 700, 200);
            RectangleF rectPrintingArea5 = new RectangleF(marginLeft, marginTop + 325, 700, 300);
            StringFormat fmt = new StringFormat(StringFormatFlags.LineLimit);

            int intLinesFilled;
            int intCharsFitted;

            string titlu = tbPayer.Text + "'s transaction";
            string text = "Date: " + dateTimePicker1.Text + "\nTransaction number: " + tbNo.Text + "\nEmployee name: " + cbEmployee.Text + "\nValue in RON: " + tbValueRON.Text + "\nCurrency: " + cbCurrency.Text + "\nCurrency rate: " + tbRateCurrency.Text + "\nFinal value: " + (Convert.ToDouble(tbValueRON.Text)/Convert.ToDouble(tbRateCurrency.Text)).ToString("N2") + " " + cbCurrency.Text;
            string text2 = "Exchange agency: Exchange Now, City: Bucharest, Romania, Address: Union Square 1045";

            string titlu2 = tbPayer.Text + "'s information";
            //string cardDetails = tbCard.Text;
            string textPayer = "CNP: " + tbCNP.Text + "\nAddress: " + tbAddress.Text + "\nPayment method: " + cbPayment.Text;
            if (cbPayment.Text == "Card")
            {
                string textPayment = "Card number: XXXX-XXXX-XXXX-" + tbCard.Text.Substring(tbCard.Text.Length - 4) + "     Expiration Date: " + tbExp.Text + "     CVV: ***";
                e.Graphics.MeasureString(text.Substring(_currentChar), font, new SizeF(intPrintAreaWidth, intPrintAreaHeight), fmt, out intCharsFitted, out intLinesFilled);

                e.Graphics.DrawString(titlu.Substring(_currentChar), font2, Brushes.Black, rectPrintingAreat, fmt);
                e.Graphics.DrawString(text.Substring(_currentChar), font, Brushes.Black, rectPrintingArea, fmt);
                e.Graphics.DrawString(text2.Substring(_currentChar), font2, Brushes.Teal, rectPrintingArea2, fmt);
                e.Graphics.DrawString(titlu2.Substring(_currentChar), font2, Brushes.Black, rectPrintingAreat2, fmt);
                e.Graphics.DrawString(textPayer.Substring(_currentChar), font, Brushes.Black, rectPrintingArea3, fmt);
                e.Graphics.DrawString(textPayment.Substring(_currentChar), font, Brushes.Black, rectPrintingArea5, fmt);
            }
            else
            {
                e.Graphics.MeasureString(text.Substring(_currentChar), font, new SizeF(intPrintAreaWidth, intPrintAreaHeight), fmt, out intCharsFitted, out intLinesFilled);

                e.Graphics.DrawString(titlu.Substring(_currentChar), font2, Brushes.Black, rectPrintingAreat, fmt);
                e.Graphics.DrawString(text.Substring(_currentChar), font, Brushes.Black, rectPrintingArea, fmt);
                e.Graphics.DrawString(text2.Substring(_currentChar), font2, Brushes.Teal, rectPrintingArea2, fmt);
                e.Graphics.DrawString(titlu2.Substring(_currentChar), font2, Brushes.Black, rectPrintingAreat2, fmt);
                e.Graphics.DrawString(textPayer.Substring(_currentChar), font, Brushes.Black, rectPrintingArea3, fmt);
            }


            _currentChar += intCharsFitted;


            if (_currentChar < text.Length)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
                _currentChar = 0;
            }

        }

        private void cbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPayment.Text == "Card")
            {
                gbCard.Visible = true;
            }
            else
                gbCard.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbExp.Text == "")
            {
                tbExp.Text += cbMonth.Text;
                tbExp.Text += "/";
            }
            else
            {
                tbExp.Clear();
                tbExp.Text += cbMonth.Text;
                tbExp.Text += "/";
            }
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMonth.Text != "")
                tbExp.Text += cbYear.Text.Substring(cbYear.Text.Length - 2);
            else
                MessageBox.Show("Please select the month first!");
        }

        private void tbCNP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbCvv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Calculator frm = new Calculator();
            if (tbValueRON.Text != "")
            {
                frm = new Calculator(tbValueRON.Text);
                if (cbCurrency.Text != "")
                    frm = new Calculator(tbValueRON.Text, cbCurrency.Text, tbRateCurrency.Text);
            }
            frm.ShowDialog();
        }

        private void Add_Load(object sender, EventArgs e)
        {
            connS = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Employees.accdb";
            OleDbConnection connection = new OleDbConnection(connS);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                DataTable dataT = new DataTable();
                OleDbCommand SelectV = connection.CreateCommand();
                SelectV.CommandType = CommandType.Text;
                SelectV.CommandText = "SELECT FirstName FROM employees;";
                SelectV.ExecuteNonQuery();
                OleDbDataAdapter adapter = new OleDbDataAdapter(SelectV);
                adapter.Fill(dataT);

                foreach (DataRow dr in dataT.Rows)
                {
                    cbEmployee.Items.Add(dr[0].ToString());
                }
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void uc1_Click(object sender, EventArgs e)
        {
            Calculator frm = new Calculator();
            if (tbValueRON.Text != "")
            {
                frm = new Calculator(tbValueRON.Text);
                if (cbCurrency.Text != "")
                    frm = new Calculator(tbValueRON.Text, cbCurrency.Text, tbRateCurrency.Text);
            }
            frm.ShowDialog();
        }

        public int getMaxValue()
        {
            int max = 0;
            StreamReader sr = new StreamReader("Transactions.txt");
            string linie = sr.ReadLine();
            while (linie != null)
            {
                int codMax = Convert.ToInt32(linie.Split(' ')[0]);
                linie = sr.ReadLine();
                max = codMax + 1;
            }
            sr.Close();
            return max;

        }
    }
    
}
