using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend;

namespace DAL
{
    public class Department_LINQ_DAL
    {
        private List<Department> departments;

        public Department_LINQ_DAL(Departments departments)
        {
            this.departments = departments.Departmentss;
        }

        //adds department d to database
        public void addDepartment(Department d)
        {
            departments.Add(d);
        }

        //removes department d from database after find it by comparing departmentID's
        public void removeDepartment(Department d)
        {
            foreach(Department dp in departments)
            {
                if(dp.DepartmentID == d.DepartmentID)
                {
                    this.departments.Remove(dp);
                    return;
                }
            }
        }

        //replacing previous department in database with d (finds previous by comparing departmentID's)
        public void editDepartment(Department d)
        {

            for (int i = 0; i < departments.Count; i++)
            {
                if (departments.ElementAt(i).DepartmentID == d.DepartmentID)
                {
                    removeDepartment(departments.ElementAt(i));
                    addDepartment(d);
                    return;
                }
            }


        }

        //returns a list of departments where name = value
        internal List<Department> departmentNameQuery(string value)
        {
            var names =
                from d in departments
                where d.Name == value
                select d;
            return names.ToList<Department>();
        }

        //returns a list of departments where departmentID = p
        internal List<Department> departmentIDQuery(int p)
        {
            var ids =
               from d in departments
               where d.DepartmentID == p
               select d;

            return ids.ToList<Department>();
        }
    }
}
