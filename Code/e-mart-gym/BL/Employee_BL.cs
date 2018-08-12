using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Backend;

namespace BL
{
    class Employee_BL
    {
        IDAL itsDAL;
        
        /*
         * constructor
         */ 
        public Employee_BL(IDAL itsDAL)
        {
            this.itsDAL = itsDAL;
        }

        /********************************************** ADD/REMOVE/EDIT ********************************************/
            /**************** ADD **************/
        /*
         * requests itsDAL to add the given employee if:
         * 1. the department ID listed to the employee exists
         * 2. the supervisor ID of the employee exists
         * 3. the employees teudat zehute doesnt exist in the database 
         */ 
        public void addEmployee(Employee employee)
        {
            try
            {
                validateDepartmentID(employee.DepartmentID);//1
                validateSupervisorID(employee.SupervisorID);//2
                validateTeudatZehute(employee.TeudatZehute);//3
            }
            catch (Exception e)
            {
                throw e;
            }
            itsDAL.addEmployee(employee);
        }

            /******** REMOVE ***********/
        /*
         * requests itsDAL to remove employee if:
         * 1. employee doesnt supervise any other employees
         */ 
        public void removeEmployee(Employee employee)
        {
            try
            {
                isSupervisor(employee.TeudatZehute);//1
                itsDAL.removeEmployee(employee);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        /*
         * requests itsDAL to edit employee if:
         * 1. the department ID the employee is set at actually exists
         * 2. the supervisor ID the employee is under actually exists
         */ 
        public void editEmployee(Employee employee)
        {
            try
            {
                validateDepartmentID(employee.DepartmentID);
                validateSupervisorID(employee.SupervisorID);
            }
            catch (Exception e)
            {
                throw e;
            }
            itsDAL.editEmployee(employee);
        }

            /******** PRIVATE METHODS ********/
        /*
         * throws an exception if p exists (the teudat zehute allready exists in the database of employees)
         */ 
        private void validateTeudatZehute(int p)
        {
            Employees emps = itsDAL.getAllEmployees();
            foreach(Employee emp in emps.Employeess)
            {
                if (emp.TeudatZehute == p) throw new Exception("Teudat Zehute Already Exists");
            }
        }

        /*
         * throws an exception if the departmentID doesnt exist in database
         */ 
        private void validateDepartmentID(int departmentID)
        {
            Departments allDepartments = itsDAL.getAllDepartments();
            foreach (Department dep in allDepartments.Departmentss)
            {
                if (dep.DepartmentID == departmentID)
                {
                    return;
                }
            }
            throw new Exception("Adding Employee failed: Department: " + departmentID + " Not Found");
        }

        /*
         * throws exception if the supervisorID doesnt exist in the employee database
         */ 
        private void validateSupervisorID(int supervisorID)
        {
            if (supervisorID == -1) return;//supervisorID=-1 means employee has no supervisor.

            Employees allEmployees = itsDAL.getAllEmployees();
            foreach (Employee employee in allEmployees.Employeess)
            {
                if (employee.TeudatZehute == supervisorID)
                {
                    return;
                }
            }
            throw new Exception("Adding Employee Failed: Supervisor: " + supervisorID + " Not Found");
        }

        /*
         * throws an exception if the employeeID given is set as a supervisor to other employees
         */ 
        private void isSupervisor(int employeeID)
        {
            Employees allEmployees = itsDAL.getAllEmployees();
            foreach (Employee employee in allEmployees.Employeess)
            {
                if (employee.SupervisorID == employeeID)
                {
                    throw new Exception("Deleting Employee Failed: Employee is a Supervisor first manage his staff.");
                }
            }
        }

        /******************************* <END> ADD/EDIT/REMOVE <END> ******************************************/

        /************************************* QUERYS ***************************************/
            
            /********** STRING QUERY **************/
        /*
      * will direct the query requested to the correct function in the this.itsDAL interface 
      * and return a list containing the query results:
      * a list of all the employees where field equals value
      */
        public List<Employee> queryByString(stringFields field, string value, List<Employee> list = null)
        {
            if (field == stringFields.teudatZehute || field == stringFields.firstName || field == stringFields.lastName || field == stringFields.departmentID || field == stringFields.supervisorID || field == stringFields.gender)
            {
                if(list == null)
                return itsDAL.employeeStringQuery(field, value,list);
            }
            Console.WriteLine("WRONG SEARCH PARAMETERS");
            return null;
        }

            /********* RANGE QUERY *********/
        /*
         *will direct the query requested to the correct function in the this.itsDAL interface
         *and return a list containing the query results:
         *all the club members in which -> fromValue <= field <= toValue
         */
        public List<Employee> queryByRange(rangeFields field, string fromValue, string toValue, List<Employee> list = null)
        {
            if (field == rangeFields.salary)
            {
                return itsDAL.employeeRangeQuery(field, fromValue, toValue, list);
            }
            Console.WriteLine("WRONG SEARCH PARAMETERS");
            return null;
        }

        /************************************ <END> QUERYS <END> *******************************************/

        /***************************************** OTHER *****************************************************/
        /*
         * requests, recieves and returns the container of all employees in data base
         */ 
        internal Employees getAllEmployees()
        {
            return itsDAL.getAllEmployees();
        }
    }
}
