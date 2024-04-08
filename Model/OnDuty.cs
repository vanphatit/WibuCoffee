using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WibuCoffee.Model
{
    public class OnDuty
    {
        private string empID;
        private string shiftID;
        private SqlDateTime date;

        public OnDuty(string empID, string shiftID, SqlDateTime date)
        {
            this.empID = empID;
            this.shiftID = shiftID;
            this.date = date;
        }

        public string EmpID { get => empID; set => empID = value; }
        public string ShiftID { get => shiftID; set => shiftID = value; }
        public SqlDateTime Date { get => date; set => date = value; }
    }
}
