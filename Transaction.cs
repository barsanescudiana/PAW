using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1045_BarsanescuDiana_Proiect
{
    public class Transaction: ICloneable, IComparable
    {
        public DateTime transactionDate { get; set; }
        public int transactionNo { get; set; }
        public string idEmployee { get; set; }
        public string payerName { get; set; }
        public float valueRON { get; set; }
        public float currencyRate { get; set; }
        public string currency { get; set; }

        public Transaction()
        {
            transactionDate = Convert.ToDateTime(null);
            transactionNo = 0;
            idEmployee = "" ;
            payerName = "";
            valueRON = 0;
            currencyRate = 0;
            currency = "";

        }

        public Transaction(DateTime td, int tn, string p, string ie, float vr, string c, float vc)
        {
            transactionDate = td;
            transactionNo = tn;
            idEmployee = ie;
            payerName = p;
            valueRON = vr;
            currencyRate = vc;
            currency = c;
        }

        public Transaction(string ie, DateTime dt)
        {
            transactionDate = dt;
            idEmployee = ie;
            transactionNo = 0;
            payerName = "";
            valueRON = 0;
            currencyRate = 0;
            currency = "";
        }

        public Transaction(string c, float vc)
        {
            currency = c;
            currencyRate = vc;
            transactionNo = 0;
            idEmployee = "";
            payerName = "";
            valueRON = 0;
            transactionDate = Convert.ToDateTime(null);
        }

        public override string ToString()
        {
            return "Employee: " + idEmployee + Environment.NewLine + "Transaction no. " + transactionNo + 
                ", made by " + payerName + " had the initial value of " + valueRON + 
                " RON. Final value of the transaction is " + finalValue().ToString("N2") + " " + currency + ".";
        }

        public object Clone()
        {
            transactionNo++;
            return this.MemberwiseClone();
        }

        public int CompareTo(object obj)
        {
            Transaction a = (Transaction)obj;
            if (this.idEmployee == a.idEmployee)
                return DateTime.Compare(this.transactionDate, a.transactionDate);
            else
                if (this.valueRON > a.valueRON)
                return 1;
            else
                return 0;

        }
        public double finalValue()
        {
            if (this.valueRON > 0 && this.currencyRate != 0)
            {
                if (currency == "HUF" || currency == "JPY" || currency == "KRW")
                    return (valueRON / currencyRate) / 100;
                else
                    return (valueRON / currencyRate);
            }
            else
                return 0;
        }
        public static bool operator <(Transaction t1, Transaction t2)
        {
            if (t1.valueRON < t2.valueRON)
                return true;
            else return false;
        }

        public static bool operator >(Transaction t1, Transaction t2)
        {
            if (t1.valueRON < t2.valueRON)
                return true;
            else return false;
        }
    }
}
