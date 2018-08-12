using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Backend
{
    public enum Gender { Male, Female };
    [XmlRoot("E-Mart"), Serializable]
    public class Employee
    {
        /*******************Fields******************/
        private int teudatZehute;
        private string firstName;
        private string lastName;
        private int departmentID;
        private double salary;
        private Gender gender; 
        private int supervisorID;

        /******************************Methods********************/
        /*********Constructors*************/
        public Employee(int teudatZehute, string firstName, string lastName, int departmentID, double salary, string geender, int supervisorID)
        {
            this.teudatZehute = teudatZehute;
            this.firstName = firstName;
            this.lastName = lastName;
            this.departmentID = departmentID;
            this.salary = salary;
            this.supervisorID = supervisorID;
            this.gender = (Gender)Enum.Parse(typeof(Gender), geender);
        }

        public Employee(Employee e)
        {
            this.teudatZehute = e.teudatZehute;
            this.firstName = e.FirstName;
            this.lastName = e.LastName;
            this.departmentID = e.DepartmentID;
            this.salary = e.Salary;
            this.supervisorID = e.SupervisorID;
            this.gender = e.GendeR;
        }

        public Employee(string teudatZehute, string firstName, string lastName, string departmentID, string salary, string supervisorID, string gender)
        {
            if (firstName.Length < 1) throw new Exception("Invalid First Name, Must Have Atleast One Character");
            if (lastName.Length < 1) throw new Exception("Invalid Last Name, Must Have Atleast One Character");
            this.firstName = firstName;
            this.lastName = lastName;

            try
            {
                this.teudatZehute = Convert.ToInt32(teudatZehute);
                if (this.teudatZehute <= 0) throw new Exception("InValid ID Must Be Larger Then 0");
            }
            catch (FormatException)
            {
                throw new Exception("The Teudat Zehute Must Be A Number.");
            }
            catch (OverflowException)
            {
                throw new Exception("The Teudat Zehute is Either To Small Or To Big.");
            }

            try
            {
                this.departmentID = Convert.ToInt32(departmentID);
            }
            catch (FormatException)
            {
                throw new Exception("The Department ID Must Be A Number.");
            }
            catch (OverflowException)
            {
                throw new Exception("The Department ID is Either To Small Or To Big");
            }

            try
            {
                this.supervisorID = Convert.ToInt32(supervisorID);
                if (this.supervisorID < -1) throw new Exception("Supervisor ID Must Be Bigger Then 0, If You Are A Manager Enter '-1'");
            }
            catch (FormatException)
            {
                throw new Exception("The Department ID Must Be A Number.");
            }
            catch (OverflowException)
            {
                throw new Exception("The Department ID is Either To Small Or To Big.");
            }

            try
            {
                this.gender = (Gender)Enum.Parse(typeof(Gender), gender);
            }
            catch (ArgumentException)
            {
                throw new Exception("The Gender You Entered Doesnt exist.");
            }

            try
            {
                double tempSalary = Convert.ToDouble(salary);
                if (tempSalary >= 0) this.Salary = tempSalary;
                else throw new Exception("The Salary Must Be A Posative Number.");
            }
            catch (FormatException)
            {
                throw new Exception("The Salary Must Be A Number.");
            }
            catch (OverflowException)
            {
                throw new Exception("The Salary is Either To Small Or To Big.");
            }
        }

        public Employee()
        {

        }
        /**************getter / setter******************/

        public int TeudatZehute
        {
            get { return this.teudatZehute; }

            set { this.teudatZehute = value; }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public int DepartmentID
        {
            get { return this.departmentID; }
            set { this.departmentID = value; }
        }

        public double Salary
        {
            get { return this.salary; }
            set { this.salary = value; }
        }
        public Gender GendeR
        {
            get { return this.gender; }
            set { this.gender = value; }
        }
        public String Gender
        {
            get { return gender.ToString(); }
        }

        public int SupervisorID
        {
            get { return this.supervisorID; }
            set { this.supervisorID = value; }
        }

        /****************************Other***************************/
        public string toString()
        {
            return "Employees ID: " + teudatZehute.ToString() +
                    " Full Name: " + firstName + " " + lastName +
                    " department ID: " + departmentID.ToString() +
                    " Salary: " + salary.ToString() +
                    " Gender: " + gender.ToString() +
                    " Supervisor ID: " + supervisorID.ToString();
        }
    }
}
