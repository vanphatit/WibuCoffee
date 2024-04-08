using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WibuCoffee.Model
{
    public class ExpenseBill
    {
        private string id;
        private string detail;
        private decimal price;
        private DateTime date;

        public ExpenseBill(string iD, string detail, decimal price, DateTime date)
        {
            id = iD;
            this.detail = detail;
            this.price = price;
            this.date = date;
        }

        public string ID { get => id; set => id = value; }
        public string Detail { get => detail; set => detail = value; }
        public decimal Price { get => price; set => price = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}
