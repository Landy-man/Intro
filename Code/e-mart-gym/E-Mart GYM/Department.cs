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
    public class Department
    {
        /***************************************Fields*******************************************/
        private string name;
        private int departmentID;
        /**************************************Methods*******************************************/
        /************************************Constructor****************************************/
        public Department(string name) //The constractor will check that the user didn`t entered an empty string
        {
            if (name.Length < 1) throw new Exception("Invalid Name, Must Contain Atleast One Character");
            this.name = name;
        }

        public Department(Department d) //Copy Constractor
        {
            this.name = d.Name;
            this.departmentID = d.DepartmentID;
        }
        //public Department(string name, string departmentID)
        //{
        //    this.name = name;
        //    try
        //    {
        //        this.departmentID = Convert.ToInt32(departmentID);
        //    }
        //    catch (FormatException)
        //    {
        //        throw new Exception("The Department ID Must Be A Number. [Location: Product.counstructor]");
        //    }
        //    catch (OverflowException)
        //    {
        //        throw new Exception("The Department ID is Either To Small Or To Big [Location: Product.counstructor]");
        //    }

        //}

        public Department() //Default Constractor
        {

        }
        /*****************Getters/Setters*********************/
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int DepartmentID
        {
            get { return this.departmentID; }
            set { this.departmentID = value; }
        }

        /*************************Other********************/
        public string toString()
        {
            return "Department Name: " + name +
                   " Department ID: " + departmentID.ToString();
        }
    }
}
