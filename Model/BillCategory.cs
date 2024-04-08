using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WibuCoffee.Model
{
    public class BillCategory
    {
        private string id;
        private string name;
        private decimal discount;

        public BillCategory(string iD, string name, decimal discount)
        {
            id = iD;
            this.name = name;
            this.discount = discount;
        }

        public string ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public decimal Discount { get => discount; set => discount = value; }
    }
}
