using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WibuCoffee.Model
{
    public class Supplier
    {
        private string id;
        private string name;
        private string address;
        private string phone;

        public Supplier(string iD, string name, string address, string phone)
        {
            id = iD;
            this.name = name;
            this.address = address;
            this.phone = phone;
        }

        public string ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
    }
}
