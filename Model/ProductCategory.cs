using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WibuCoffee.Model
{
    public class ProductCategory
    {
        private string id;
        private string name;

        public ProductCategory(string iD, string name)
        {
            id = iD;
            this.name = name;
        }

        public string ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
