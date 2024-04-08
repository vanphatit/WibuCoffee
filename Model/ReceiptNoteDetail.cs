using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WibuCoffee.Model
{
    public class ReceiptNoteDetail
    {
        private string rNoteID;
        private string materialID;
        private int quantity;
        private decimal unitPrice;

        public ReceiptNoteDetail(string rNoteID, string materialID, int quantity, decimal unitPrice)
        {
            this.rNoteID = rNoteID;
            this.materialID = materialID;
            this.quantity = quantity;
            this.unitPrice = unitPrice;
        }

        public string RNoteID { get => rNoteID; set => rNoteID = value; }
        public string MaterialID { get => materialID; set => materialID = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public decimal UnitPrice { get => unitPrice; set => unitPrice = value; }
    }
}
