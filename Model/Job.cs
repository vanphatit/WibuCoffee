using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WibuCoffee.Model
{
    public class Job
    {
        private string id;
        private string jobDetail;
        private decimal salary;

        public Job(string iD, string jobDetail, decimal salary)
        {
            id = iD;
            this.jobDetail = jobDetail;
            this.salary = salary;
        }

        public string ID { get => id; set => id = value; }
        public string JobDetail { get => jobDetail; set => jobDetail = value; }
        public decimal Salary { get => salary; set => salary = value; }
    }
}
