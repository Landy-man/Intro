using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Backend
{
    [XmlRoot("E-Mart"), Serializable]
    public class Employees
    {
        /********************************Field************************************/
        private List<Employee> employees = new List<Employee>();

        /*********************Constructor************************/
        public Employees(List<Employee> employees)
        {
            this.employees = employees;
        }
        public Employees()
        {

        }
        /**************Methods***********************/
        /*********Get/Set*****************/
        public List<Employee> Employeess
        {
            get { return this.employees; }
            set { this.employees = value; }
        }

        /*******************************************************************************************/
        /*Adding and removing an employee from the list of employees*/
        public void addEmployee(Employee employeeToAdd)
        {
            employees.Add(employeeToAdd);
        }


        public void removeEmployee(Employee employeeToRemove)
        {
            employees.Remove(employeeToRemove);
        }
        /*************Other***************/
        public string toString()
        {
            string ans = "";
            foreach (Employee employee in employees)
            {
                ans = ans + employee.toString() + "\n";
            }
            return ans;
        }
    }

}
