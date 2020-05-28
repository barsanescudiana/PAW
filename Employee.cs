using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1045_BarsanescuDiana_Proiect
{

    public class Employee: Agency
    {
        public int idE = 0;
        private new string name { get; set; }

        private int transactionsNo { get; set; }

        private int[] transactions;

        public Employee():base()
        {
            name = "";
            transactionsNo = 0;
            transactions = null;
            base.name = "";
            base.id = 0;
            base.address = "";


        }

        public Employee(string n, int i) : base()
        {
            name = n;
            idE = i;
        }

        public Employee( string n, int tn, int[] t, int ia, string na, string adr, List<Employee> e): base(ia, na, adr, e)
        {
            
            name = n;
            transactionsNo = tn;
            transactions = new int[tn];
            for (int index = 0; index < t.Length; index++)
                transactions[index] = t[index];
        }

        //public Employee(string n, int tn) : base()
        //{
        //    name = n;
        //    transactionsNo++;
        //    int[] addTransactions = new int[TransactionsNo];
        //    for (int i = 0; i < addTransactions.Length; i++)
        //    {
        //        addTransactions[i] = transactions[i];
        //    }
        //    addTransactions[addTransactions.Length - 1] = tn;
        //    transactions = new int[addTransactions.Length];
        //    transactions = addTransactions;
        //    base.name = "";
        //    base.id = 0;
        //    base.address = "";
        //}

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value != "") this.name = value;
            }
        }

        public int TransactionsNo
        {
            get { return this.transactionsNo; }
            set
            {
                if (value > 0) this.transactionsNo = value;
            }
        }

        public override string ToString()
        {
            return "Employee: " + name + ", ID: " + id + " from " + base.ToString();
        }

        public static Employee operator +(Employee a, int t)
        {
            int[] newTransactions = new int[a.transactions.Length + 1];
            for (int i = 0; i < a.transactions.Length; i++)
            {
                newTransactions[i] = a.transactions[i];
            }
            newTransactions[newTransactions.Length - 1] = t;
            a.transactions = newTransactions;
            a.transactionsNo++;
            return a;
        }

        public void writeToFile()
        {
            StreamWriter sw = File.AppendText("Employees.txt");
            sw.WriteLine(name+":"+idE);
            sw.Close();

        }


    }


}
