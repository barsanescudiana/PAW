using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace _1045_BarsanescuDiana_Proiect
{
    public class Currency
    {
            private double value { get; set; }
            private string name { get; set; }

            public Currency()
            {
                value = 0;
                name = "";
            }
            public Currency(double val, string d)
            {
                value = val;
                name = d;
            }

            public Currency(string d)
            {
                name = d;
                StreamReader sr = new StreamReader("nbrfxrates.xml");
                string str = sr.ReadToEnd();
                sr.Close();

                XmlReader reader = XmlReader.Create(new StringReader(str));
                while (reader.Read())
                {

                    if (reader.Name == "Rate" && reader.NodeType == XmlNodeType.Element)
                    {
                        string atribut = reader["currency"];
                        if (atribut == d)
                        {
                            reader.Read();
                            value = Convert.ToDouble(reader.Value);
                        }
                    }
                }
            }

            public string Name
            {
                get { return name; }
                set
                {
                    if (value != "") name = value;
                }
            }

            public double Value
            {
                get { return value; }
                set
                {
                    if (value != 0 && value > 0) _ = value;
                }
            }


            public override string ToString()
            {
                return ("Currency: " + this.name + ", buying value: " + this.value + ", selling value: " + this.value + ".");
            }
        public static bool operator <(Currency t1, Currency t2)
        {
            if (t1.value < t2.value)
                return true;
            else return false;
        }

        public static bool operator >(Currency t1, Currency t2)
        {
            if (t1.value < t2.value)
                return true;
            else return false;
        }


    }


}


