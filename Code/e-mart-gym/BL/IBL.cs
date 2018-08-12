using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend;
using DAL;

namespace BL
{
    /*
     * BUISNES LAYER INTERFACE
     */ 
    public interface IBL
    {
        void add(object obj);
        void remove(object obj);
        void edit(object obj);
        void saveDataToFile();
        bool doesFileExist();
        void loadDataFromFile();
        User isUserAdmin(User user);
        User isUserOk(User user);
        void clearReceipt(Receipt receipt);
        Transactions getAllTransaction();
        Employees getAllEmployees();
        ClubMembers getAllClubMembers();
        Products getAllProducts();
        Departments getAllDepartments();
        Users getAllUsers();
        List<object> queryByRange(Classes clas, rangeFields field, string fromValue, string ToValue,List<object> list=null);
        List<object> queryByString(Classes clas, stringFields field, string value,List<object> list=null);

    
    }
}
