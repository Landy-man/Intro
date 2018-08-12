using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend;

namespace DAL
{
    public class Employee_LINQ_DAL
    {
        private List<Employee> employees;

        public Employee_LINQ_DAL(Employees employees)
        {
            this.employees = employees.Employeess;
        }

        //adds employee e to database
        public void addEmployee(Employee e)
        {
            employees.Add(e);
        }

        //removes employee e from database after finding it by comparing teudatZehute's
        public void removeEmployee(Employee e)
        {
           foreach(Employee emp in employees)
           {
               if(emp.TeudatZehute == e.TeudatZehute)
               {
                   this.employees.Remove(emp);
                   return;
               }
           }
        }

        //replaces previous employee with Employee e (finds previous by comparing teudatZehute's)
        public void editEmployee(Employee e)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees.ElementAt(i).TeudatZehute == e.TeudatZehute)
                {
                    removeEmployee(employees.ElementAt(i));
                    addEmployee(e);
                    return;
                }
            }
        }

        //returns a list of employees where teudatZehute = p
        internal List<Employee> employeeIDQuery(int p, List<Employee> listE = null)
        {
            if(listE == null)
            {
                listE = employees;
            }

            var id =
                from e in listE
                where e.TeudatZehute == p
                select e;
            return id.ToList<Employee>();
        }

        //returns a list of employees where departmentID = p
        internal List<Employee> employeeDPIDQuery(int p, List<Employee> listE = null)
        {
            if (listE == null)
            {
                listE = employees;
            }

            var DPID =
              from e in listE
              where e.DepartmentID == p
              select e;

            return DPID.ToList<Employee>();
        }

        //returns a list of employees where supervisorID = p
        internal List<Employee> employeeSupervisorIDQuery(int p, List<Employee> listE = null)
        {
            if (listE == null)
            {
                listE = employees;
            }

            var supervisorID =
              from e in listE
              where e.SupervisorID == p
              select e;

            return supervisorID.ToList<Employee>();
        }

        //returns a list of employees where firstName = value
        internal List<Employee> employeeFirstNameQuery(string value, List<Employee> listE = null)
        {
            if (listE == null)
            {
                listE = employees;
            }

            var firstName =
              from e in listE
              where e.FirstName == value
              select e;

            return firstName.ToList<Employee>();
        }

        //returns a list of employees where lastName = value
        internal List<Employee> employeeLastNameQuery(string value, List<Employee> listE = null)
        {
            if (listE == null)
            {
                listE = employees;
            }

            var lastName =
             from e in listE
             where e.LastName == value
             select e;

            return lastName.ToList<Employee>();
        }

        //returns a list of employees where Gender = p
        internal List<Employee> employeeGenderQuery(Gender p, List<Employee> listE = null)
        {
            if (listE == null)
            {
                listE = employees;
            }

            var genders =
             from e in listE
             where e.GendeR == p
             select e;

            return genders.ToList<Employee>();
        }

        //returns a list of employees where p1<=salary<=p2
        internal List<Employee> employeeSalaryQuery(double p1, double p2, List<Employee> listE = null)
        {
            if (listE == null)
            {
                listE = employees;
            }

            var salary =
                from e in listE
                where e.Salary >= p1 && e.Salary <= p2
                select e;
            return salary.ToList<Employee>();
        }
    }
}
