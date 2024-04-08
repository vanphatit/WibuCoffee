using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WibuCoffee.Model
{
    public class Bill
    {
        private string id;
        private DateTime dateTime;
        private string tableID;
        private string customerID;
        private string categoryID;
        private string empID;
        private decimal receiptMoney;

        public Bill(string iD, DateTime dateTime, string tableID, string customerID, string categoryID, string empID, decimal receiptMoney)
        {
            id = iD;
            this.dateTime = dateTime;
            this.tableID = tableID;
            this.customerID = customerID;
            this.categoryID = categoryID;
            this.empID = empID;
            this.receiptMoney = receiptMoney;
        }

        public string ID { get => id; set => id = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public string TableID { get => tableID; set => tableID = value; }
        public string CustomerID { get => customerID; set => customerID = value; }
        public string CategoryID { get => categoryID; set => categoryID = value; }
        public string EmpID { get => empID; set => empID = value; }
        public decimal ReceiptMoney { get => receiptMoney; set => receiptMoney = value; }
    }
}
