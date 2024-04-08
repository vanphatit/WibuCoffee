using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WibuCoffee.Model
{
    public class BillInfo
    {
        private string billID;
        private string productID;
        private int quantity;

        public BillInfo(string billID, string productID, int quantity)
        {
            this.billID = billID;
            this.productID = productID;
            this.quantity = quantity;
        }

        public string BillID { get => billID; set => billID = value; }
        public string ProductID { get => productID; set => productID = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
