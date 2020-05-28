using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace _1045_BarsanescuDiana_Proiect
{
    public partial class UserControl1 : UserControl
    {
        string connS;
        public UserControl1()
        {
            InitializeComponent();
            connS = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Users.accdb";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection(connS);
            OleDbCommand comanda = new OleDbCommand("SELECT COUNT(*) FROM Users WHERE username='"
                + tbUser.Text + "' AND password='" + tbPassword.Text + "'", connection);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                    int credentialsCheck = Convert.ToInt32(comanda.ExecuteScalar());

                    if (credentialsCheck != 0)
                    {
                        MessageBox.Show("Log in successfull!");
                        Add frm = new Add();
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Username and password do not match!");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
                Login.ActiveForm.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection(connS);
            OleDbCommand comanda = new OleDbCommand("SELECT COUNT(*) FROM Users WHERE username='"
                + tbUser.Text + "' AND password='" + tbPassword.Text + "'", connection);
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                    int credentialsCheck = Convert.ToInt32(comanda.ExecuteScalar());

                    if (credentialsCheck != 0)
                    {
                        MessageBox.Show("Log in successfull!");
                        ShowTransactions frm = new ShowTransactions();
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Username and password do not match!");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
                Login.ActiveForm.Close();
            }
        }
    }
}
