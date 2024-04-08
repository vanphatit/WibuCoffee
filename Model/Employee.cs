using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WibuCoffee.Model
{
    public class Employee
    {
        private string id;
        private string name;
        private SqlDateTime birthdate;
        private string address;
        private string phone;
        private SqlDateTime recruitmentDate;
        private string jobID;
        private int penaltyPoint;
        private int bonusPoint;
        private int numberOfShifts;

        public Employee(string iD, string name, SqlDateTime birthdate, string address, string phone, SqlDateTime recruitmentDate, string jobID, int penaltyPoint, int bonusPoint, int numberOfShifts)
        {
            id = iD;
            this.name = name;
            this.birthdate = birthdate;
            this.address = address;
            this.phone = phone;
            this.recruitmentDate = recruitmentDate;
            this.jobID = jobID;
            this.penaltyPoint = penaltyPoint;
            this.bonusPoint = bonusPoint;
            this.numberOfShifts = numberOfShifts;
        }

        public string ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public SqlDateTime Birthdate { get => birthdate; set => birthdate = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public SqlDateTime RecruitmentDate { get => recruitmentDate; set => recruitmentDate = value; }
        public string JobID { get => jobID; set => jobID = value; }
        public int PenaltyPoint { get => penaltyPoint; set => penaltyPoint = value; }
        public int BonusPoint { get => bonusPoint; set => bonusPoint = value; }
        public int NumberOfShifts { get => numberOfShifts; set => numberOfShifts = value; }

    }
}
