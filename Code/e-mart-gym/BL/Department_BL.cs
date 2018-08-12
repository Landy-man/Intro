using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend;
using DAL;

namespace BL
{
    public class Department_BL
    {

        private IDAL itsDAL;

        public Department_BL(IDAL dal)
        {
            this.itsDAL = dal;
        }

        /****************************************** ADD/REMOVE/EDIT **********************************************/
            /*************** Add Department ****************/
        /*
         * sends the given department d to be added after:
         * 1. setting the department ID
         */ 
        public void addDepartment(Department d)
        {
            setDepartmentID(d);//1
            itsDAL.addDepartment(d);
        }

         /******************* Remove Department ***********************/
        /*
         * sends a request to remove the given department d from database if:
         * 1.no products are listed to belong the department d
         */ 
        public void removeDepartment(Department d)
        {
            try { AssignedProducts(d); }
            catch (Exception e) { throw e; }
            itsDAL.removeDepartment(d);
        }

        /***************** Edit Department ********************/
        /*
         * requests itsDAL to edit the department
         */ 
        public void editDepartment(Department d)
        {
            itsDAL.editDepartment(d);
        }
            /************** PRIVATE METHODS ******************/
        /*
         * throws an exception if there are products listed to be contained in the given department d
         */ 
        private void AssignedProducts(Department d)
        {
            Products allProducts = itsDAL.getAllProducts();
            foreach (Product prod in allProducts.Productss)
            {
                if (prod.Location == d.DepartmentID)
                {
                    throw new Exception("You are tring to remove a department that have assigned products to, please clear all products from the department first ");
                }

            }
        }
        /*
         * sets the department id to the given department d to the max department id in the database + 1
         */ 
        private void setDepartmentID(Department d)
        {
            Departments allDepartments = itsDAL.getAllDepartments();
            int maxID = 0;
            foreach (Department dep in allDepartments.Departmentss)
            {
                if (dep.DepartmentID > maxID)
                {
                    maxID = dep.DepartmentID;
                }
            }
            d.DepartmentID = maxID+1;
        }

        /************************************* QUERYS *******************************************/
            /******* STRING QUERY ********/
        /*
       * will direct the query requested to the correct function in the this.itsDAL interface 
       * and return a list containing the query results:
       * all departments where field equals value
       */ 
        public List<Department> queryByString(stringFields field, string value)
        {
            if (field == stringFields.departmentID || field == stringFields.name)
            {
                return itsDAL.departmentStringQuery(field, value);
            }
            Console.WriteLine("WRONG SEARCH PARAMETERS");
            return null;
        }

        /*********************************** <END> QUERYS <END> *************************************************/
        
        /************************************* OTHER ************************************************/
        /*
         * requests, recieves and returns all the Departments in the database
         */ 
        public Departments getAllDepartments()
        {
            return itsDAL.getAllDepartments();
        }

    }
}
