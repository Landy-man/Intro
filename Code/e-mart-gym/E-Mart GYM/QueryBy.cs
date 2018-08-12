using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    /*
     
     The class will creat a Enum which will help us make the querys more efficeant
     it will sort all queryable fileds into in range and diract search
     */
    public enum Classes { Product, Employee, Transaction, ClubMember, User, Department }
    public enum rangeFields { price, salary, stockCount, whenToOrder, date_of_birth, dateTime };
    public enum stringFields { paymentMethod, inventoryID, name, type, inStock, firstName, lastName, userName, memberID, location, teudatZehute, departmentID, supervisorID, transactionID, is_A_Return, gender }
    class QueryBy
    {
    }
}
