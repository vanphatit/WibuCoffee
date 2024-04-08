using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WibuCoffee.Model
{
    public class Delivery
    {
        private string materialID;
        private string supplierID;

        public Delivery(string materialID, string supplierID)
        {
            this.materialID = materialID;
            this.supplierID = supplierID;
        }

        public string MaterialID { get => materialID; set => materialID = value; }
        public string SupplierID { get => supplierID; set => supplierID = value; }
    }
}
