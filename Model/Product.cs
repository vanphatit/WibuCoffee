using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WibuCoffee.Model
{
    public class Product
    {
        private string id;
        private string name;
        private string categoryID;
        private decimal price;
        private string status;

        public Product(string iD, string name, string categoryID, decimal price, string status)
        {
            id = iD;
            this.name = name;
            this.categoryID = categoryID;
            this.price = price;
            this.status = status;
        }

        public string ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string CategoryID { get => categoryID; set => categoryID = value; }
        public decimal Price { get => price; set => price = value; }
        public string Status { get => status; set => status = value; }
    }
}
