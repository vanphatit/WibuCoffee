using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WibuCoffee.Model
{
    public class Shift
    {
        private string id;
        private SqlDateTime startTime;
        private SqlDateTime endTime;

        public Shift(string iD, SqlDateTime startTime, SqlDateTime endTime)
        {
            id = iD;
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public string ID { get => id; set => id = value; }
        public SqlDateTime StartTime { get => startTime; set => startTime = value; }
        public SqlDateTime EndTime { get => endTime; set => endTime = value; }
    }
}
