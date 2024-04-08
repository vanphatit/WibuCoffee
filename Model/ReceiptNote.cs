using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WibuCoffee.Model
{
    public class ReceiptNote
    {
        private string id;
        private DateTime date;
        private decimal price;
        private string supplierID;
        private string empID;

        public ReceiptNote(string iD, DateTime date, decimal price, string supplierID, string empID)
        {
            id = iD;
            this.date = date;
            this.price = price;
            this.supplierID = supplierID;
            this.empID = empID;
        }

        public string ID { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public decimal Price { get => price; set => price = value; }
        public string SupplierID { get => supplierID; set => supplierID = value; }
        public string EmpID { get => empID; set => empID = value; }
    }
}
