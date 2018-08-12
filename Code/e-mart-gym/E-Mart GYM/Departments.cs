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
    public class Departments
    {
        /***********************************************************************
         * The class will contain all the departments of E-Mart
         * ***************************************************************/
        /********************************* Field ******************************************/
        private List<Department> departments = new List<Department>();  //Initsliezing the list

        /*********************************** Constructor **********************************/
        public Departments(List<Department> departments)
        {
            this.departments = departments;
        }
        public Departments() //Defualt Constractor
        {

        }
        /************************************Methods*************************************/
        /************************************get/set*****************************/
        public List<Department> Departmentss
        {
            get { return this.departments; }
            set { this.departments = value; }
        }
        /********************************Add / Remove to/From list***********************************/

        /*Adding a Department to list*/
        public void addDepartment(Department departmentToAdd)
        {
            departments.Add(departmentToAdd);
        }

        /*Removing a Department from the list*/
        public void removeDepartment(Department departmentToRemove)
        {
            departments.Remove(departmentToRemove);
        }
        /*********************************************Other******************************************/
        public string toString()
        {
            string ans = "";
            foreach (Department department in departments)
            {
                ans = ans + department.toString() + "\n";
            }
            return ans;
        }
    }

}
