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

using System.Data.OleDb;

namespace _1045_BarsanescuDiana_Proiect
{
    public partial class ViewEmployees : Form
    {
        string connS;
        public ViewEmployees()
        {
            InitializeComponent();

            connS = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Employees.accdb";
            OleDbConnection connection = new OleDbConnection(connS);
            try
            { if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                DataTable dataT = new DataTable();
                OleDbCommand SelectV = connection.CreateCommand();
                SelectV.CommandType = CommandType.Text;
                SelectV.CommandText = "SELECT * FROM employees;";
                SelectV.ExecuteNonQuery();
                OleDbDataAdapter adapter = new OleDbDataAdapter(SelectV);
                adapter.Fill(dataT);

                foreach (DataRow dr in dataT.Rows)
                {
                    ListViewItem itm = new ListViewItem(dr[0].ToString());
                    itm.SubItems.Add(dr[1].ToString());
                    itm.SubItems.Add(dr[2].ToString());
                    itm.SubItems.Add(dr[3].ToString());
                    itm.SubItems.Add(dr[4].ToString());
                    lvEmployees.Items.Add(itm);
                }
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addNewEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEmployee frm = new AddEmployee();
            frm.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddEmployee frm = new AddEmployee();
            frm.ShowDialog();
        }

        private void deleteEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection(connS);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                DataTable dataT = new DataTable();
                OleDbCommand SelectV;
                foreach (ListViewItem itm in lvEmployees.Items)
                {
                    if (itm.Checked)
                    {
                        //int cod = Convert.ToInt32(itm.Text);
                        SelectV = new OleDbCommand("DELETE FROM employees WHERE ID = " + Convert.ToInt32(itm.Text) + ";", connection);
                        SelectV.ExecuteNonQuery();
                        itm.Remove();
                        lvEmployees.Update();

                        MessageBox.Show("Employee deleted!");

                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            connection.Close();
            refreshListView();
        }

        private void editEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection(connS);
            try
            {
                foreach (ListViewItem itm in lvEmployees.Items)
                {

                        if (itm.Checked)
                        {
                        MessageBox.Show("You chose to edit this employee: " + itm.SubItems[1].Text + " " + itm.SubItems[2].Text);
                        AddEmployee frme = new AddEmployee(itm.Text, itm.SubItems[1].Text, itm.SubItems[2].Text, itm.SubItems[4].Text, itm.SubItems[3].Text);
                        frme.ShowDialog();

                        }
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally {
                refreshListView();
            }
        }

        public void refreshListView()
        {
            lvEmployees.Items.Clear();

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
                SelectV.CommandText = "SELECT * FROM employees;";
                SelectV.ExecuteNonQuery();
                OleDbDataAdapter adapter = new OleDbDataAdapter(SelectV);
                adapter.Fill(dataT);

                foreach (DataRow dr in dataT.Rows)
                {
                    ListViewItem itm = new ListViewItem(dr[0].ToString());
                    itm.SubItems.Add(dr[1].ToString());
                    itm.SubItems.Add(dr[2].ToString());
                    itm.SubItems.Add(dr[3].ToString());
                    itm.SubItems.Add(dr[4].ToString());
                    lvEmployees.Items.Add(itm);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
