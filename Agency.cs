using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1045_BarsanescuDiana_Proiect
{
    public abstract class Agency: ICloneable, IComparable, IMovable
    {
        public string name;
        public int id = 1045;
        public string address;

        List<Employee> employeeList;

        public Agency()
        {
            name = "";
            id = 1045;
            address = "";
        }
        public Agency(int id, string name, string address, List<Employee> list)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            employeeList = list;
        }

        public override string ToString()
        {
            return "Agency: " + name + ", ID: " + id + ", address: " + address + ".";
        }

        public object Clone()
        {
            this.id++;
            return this.MemberwiseClone();
        }

        public int CompareTo(object obj)
        {
            Agency a = (Agency)obj;
            if (this.id != a.id)
                return String.Compare(this.name, a.name);
            else
                return 0;
        }
        public Agency this[int index]
        {
            get
            {
                if (employeeList != null && index >= 0 && index < employeeList.Count)
                    return employeeList[index];
                else
                    return null;
            }
        }

       public void Move(string s)
        {
            address = s;
        }
    }
}
