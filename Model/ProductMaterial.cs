using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WibuCoffee.Model
{
    public class ProductMaterial
    {
        private string productID;
        private string materialID;
        private int quantity;

        public ProductMaterial(string productID, string materialID, int quantity)
        {
            this.productID = productID;
            this.materialID = materialID;
            this.quantity = quantity;
        }

        public string ProductID { get => productID; set => productID = value; }
        public string MaterialID { get => materialID; set => materialID = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
