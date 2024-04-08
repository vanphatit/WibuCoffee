using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WibuCoffee.Model
{
    public class Material
    {
        private string id;
        private string name;
        private string status;

        public Material(string iD, string name, string status)
        {
            id = iD;
            this.name = name;
            this.status = status;
        }

        public string ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
    }
}
