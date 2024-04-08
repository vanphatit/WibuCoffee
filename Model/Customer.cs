using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WibuCoffee.Model
{
    public class Customer
    {
        private string id;
        private string name;
        private string phone;
        private int bonusPoint;

        public Customer(string iD, string name, string phone, int bonusPoint)
        {
            id = iD;
            this.name = name;
            this.phone = phone;
            this.bonusPoint = bonusPoint;
        }

        public string ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public int BonusPoint { get => bonusPoint; set => bonusPoint = value; }
    }
}
