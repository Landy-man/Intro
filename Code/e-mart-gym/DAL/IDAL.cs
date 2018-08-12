using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend;

namespace DAL
{
    /*
     * DATA LAYER INTERFACE
     */
    public interface IDAL
    {
        void addProduct(Product p);
        void removeProduct(Product p);
        void editProduct(Product p);
        void addDepartment(Department d);
        void removeDepartment(Department d);
        void editDepartment(Department d);
        void addUser(User p);
        void removeUser(User p);
        void editUser(User p);
        void addEmployee(Employee e);
        void removeEmployee(Employee e);
        void editEmployee(Employee e);
        void addClubMember(ClubMember c);
        void editClubMember(ClubMember c);
        void removeClubMember(ClubMember c);
        void addTransaction(Transaction t);
        void editTransaction(Transaction t);
        void removeTransaction(Transaction t);
        Products getAllProducts();
        Departments getAllDepartments();
        ClubMembers getAllClubMembers();
        Transactions getAllTransactions();
        Employees getAllEmployees();
        Users getAllUsers();

        List<Employee> employeeStringQuery(stringFields field, string value,List<Employee> listE=null);

        List<Employee> employeeRangeQuery(rangeFields field, string fromValue, string toValue, List<Employee> listE = null);

        List<Product> productStringQuery(stringFields field, string value, List<Product> listE = null);

        List<Product> productRangeQuery(rangeFields field, string fromValue, string toValue, List<Product> listE = null);

        List<Transaction> transactionStringQuery(stringFields field, string value);

        List<Transaction> transactionRangeQuery(rangeFields field, string fromValue, string toValue);

        List<User> userStringQuery(stringFields field, string value);

        List<ClubMember> clubMemberRangeQuery(rangeFields field, string fromValue, string toValue);

        List<ClubMember> ClubMemberStringQuery(stringFields field, string value);

        List<Department> departmentStringQuery(stringFields field, string value);

        void saveDataToFile();

        void loadDataFromFile();

        bool doesFileExist();

       // User getAdmin();

        void enitializeLinqDal();

        User isUserOk(User user);

        User isUserAdmin(User user);
    }
}
