using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.OleDb;
using System.IO;
using System.Security.Cryptography;

namespace _1045_BarsanescuDiana_Proiect
{
    public partial class AddEmployee : Form
    {
        int maxID;
        string fn, ln, a;
        string connS;
        public AddEmployee()
        {
            InitializeComponent();
            connS = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Employees.accdb";
            button2.Visible = false;
            OleDbConnection conn = new OleDbConnection(connS);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT MAX(ID) FROM employees", conn);
            maxID = Convert.ToInt32(cmd.ExecuteScalar());
            tbID.Text = Convert.ToString(maxID + 10);
            tbID.Enabled = false;
            conn.Close();
        }

        public AddEmployee(string id, string fn, string ln, string age, string date)
        {
            InitializeComponent();
            button1.Visible = false;
            tbID.Text = id;
            tbID.Enabled = false;
            //dtpE.Enabled = false;
            //dtpE.Visible = false;
            this.fn = tbF.Text; 
            tbF.Text = fn;
            this.ln = ln;
            tbL.Text = ln;
            a = age;
            cbAge.Text = age;
            dtpE.Value = Convert.ToDateTime(date);
            //dtpE.Text = date;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbID.Text == "")
                errorProvider1.SetError(tbID, "Pleaste insert ID!");
            else
                if (tbF.Text == "")
                errorProvider1.SetError(tbF, "Insert your first name!");
            else
                if (tbL.Text == "")
                errorProvider1.SetError(tbL, "Insert your last name!");
            else
                if (cbAge.Text == "")
                errorProvider1.SetError(cbAge, "Please choose your age!");
            else
                try
                {
                    OleDbConnection connection = new OleDbConnection(connS);
                    connection.Open();
                    OleDbCommand comanda = new OleDbCommand();
                    comanda.Connection = connection;

                    comanda.CommandText = "INSERT INTO employees VALUES(?,?,?,?,?)"; 
                    comanda.Parameters.Add("ID", OleDbType.Integer).Value = Convert.ToInt32(tbID.Text);
                    comanda.Parameters.Add("First name", OleDbType.Char, 30).Value = tbF.Text;
                    comanda.Parameters.Add("Last name", OleDbType.Char, 50).Value = tbL.Text;
                    comanda.Parameters.Add("Employment date", OleDbType.DBDate).Value = dtpE.Value;
                    comanda.Parameters.Add("Age", OleDbType.Integer).Value = Convert.ToInt32(cbAge.Text);

                    comanda.ExecuteNonQuery();

                    MessageBox.Show("Employee has been added!");

                    this.Close();
                    ViewEmployees frm = new ViewEmployees();
                    frm.Show();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Exception: " + ex.Message);
                }
            
        }

        private void tbID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;

        }

        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
                e.Handled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            connS = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Employees.accdb";
            OleDbConnection connection1 = new OleDbConnection(connS);

            if (tbF.Text == "")
                errorProvider1.SetError(tbF, "Insert your first name!");
            else
                if (tbL.Text == "")
                errorProvider1.SetError(tbL, "Insert your last name!");
            else
                if (cbAge.Text == "")
                errorProvider1.SetError(cbAge, "Please choose your age!");
            else

                try
            {
                    connection1.Open();
                    OleDbCommand comanda = new OleDbCommand();
                    comanda.Connection = connection1;
                    OleDbCommand selectCommand = new OleDbCommand("SELECT FirstName FROM  employees WHERE ID=" + tbID.Text + ";",connection1);
                    OleDbDataReader reader = selectCommand.ExecuteReader();
                    while(reader.Read())
                    fn = reader[0].ToString();

                    comanda.CommandText = "UPDATE employees SET FirstName = '"+ tbF.Text +"' WHERE ID=" +tbID.Text+"";
                    comanda.ExecuteNonQuery();

                    comanda.CommandText = "UPDATE employees SET LastName = '" + tbL.Text + "' WHERE ID=" + tbID.Text + "";
                    comanda.ExecuteNonQuery();

                    comanda.CommandText = "UPDATE employees SET Age = '" + cbAge.Text + "' WHERE ID=" + tbID.Text + "";
                    comanda.ExecuteNonQuery();

                    comanda.CommandText = "UPDATE employees SET EmploymentDate = '" + dtpE.Value + "' WHERE ID=" + tbID.Text + "";
                    comanda.ExecuteNonQuery();

                    StreamReader sr = new StreamReader("Transactions.txt");
                    string linie;
                    MessageBox.Show(fn);

                    while ((linie = sr.ReadLine()) != null)
                    {
                        //MessageBox.Show(linie.Split(' ')[1]);
                        if ((linie.Split(' ')[1]) == fn)
                            linie = linie.Replace(linie.Split(' ')[1], fn);
                    }
                    sr.Close();
                    this.Close();
                    ViewEmployees.ActiveForm.Refresh();
                    connection1.Close();
                    reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }

        }
    }
}
