using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend;
using DAL;

namespace BL
{
    public class Product_BL
    {
        IDAL itsDAL;

        public Product_BL(IDAL itsDAL)
        {
            this.itsDAL = itsDAL;
        }

        /********************************************* ADD/REMOVE/EDIT ***********************************************/
            /********************* ADD ********************/
        /*
         * requests itsDAL to add product p after:
         * 1. setting the products inventory ID
         * 2. checking if the departmentID set in product actually exists in database
         * 3. setting the InStock variable 
         */ 
        public void addProduct(Product p)
        {
            try
            {
                setInventoryId(p);//1
                validateDepartmentID(p);//2
                setInStock(p);//3
            }
            catch (Exception e)
            {
                throw e;
            }

            itsDAL.addProduct(p);
        }
            
            /*************** Remove ***************/
        /*
         * requests itsDAL to remove product p from database
         */ 
        public void removeProduct(Product p)
        {
            itsDAL.removeProduct(p);
        }

            /**************** Edit Product *****************/
        /*
         * requests itsDAL to edit product p after:
         * 1. checking if the department ID set in product p exists
         * 2. setting the InStock variable
         */ 
        public void editProduct(Product p)
        {
            try
            {
                validateDepartmentID(p);
                setInStock(p);
            }
            catch (Exception e)
            {
                throw e;

            }
            itsDAL.editProduct(p);
        }

            /************* PRIVATE METHODS *************/
        /*
         * sets the inventory ID of the product to the maximum ID in the product's data base + 1
         */ 
        private void setInventoryId(Product p)
        {
            Products allProducts = itsDAL.getAllProducts();
            int maxID = 0;
            foreach (Product prod in allProducts.Productss)
            {
                if (prod.InventoryID > maxID)
                {
                    maxID = prod.InventoryID;
                }
            }
            p.InventoryID = maxID+1;
        }

        /*
         * throws an exception if the departmentID the product is located at exists
         */ 
        private void validateDepartmentID(Product p)
        {
            Departments allDepartments = itsDAL.getAllDepartments();
            bool found = false;
            foreach (Department dep in allDepartments.Departmentss)
            {
                if (dep.DepartmentID == p.Location)
                {
                    found = true;
                    break;
                }

            }
            if (!found)
            {
                throw new Exception("Adding product failed: Department: " + p.Location + " Not Found");
            }
        }

        /*
         * sets the InStock variable according to the products stockCount
         */ 
        private void setInStock(Product p)
        {
            if (p.StockCount == 0)
            {
                p.INStock = InStock.False;

            }
            else if (p.StockCount <= p.WhenToOrder)
            {
                p.INStock = InStock.NeedToOrder;
            }
            else p.INStock = InStock.True;
        }

        /*************************************** <END> ADD/REMOVE/EDIT <END> **************************************/

        /************************************************ QUERYS ******************************************************/
            /********** STRING QUERY ***********/
        /*
      * will direct the query requested to the correct function in the this.itsDAL interface 
      * and return a list containing the query results:
      * a list of all the products where field equals value
      */
        public List<Product> queryByString(stringFields field, string value ,List<Product> listP=null)
        {
            if (field == stringFields.name || field == stringFields.type || field == stringFields.inventoryID || field == stringFields.location || field == stringFields.inStock)
            {
               
                List<Product> tempPList = itsDAL.productStringQuery(field, value ,listP);
                EmphsizeTopSeller(tempPList);
                return tempPList;
            }
            Console.WriteLine("WRONG SEARCH PARAMETERS");
            return null;
        }

            /********** RANGE QUERY ***********/
        /*
         *will direct the query requested to the correct function in the this.itsDAL interface
         *and return a list containing the query results:
         *all the products in which -> fromValue <= field <= toValue
         */
        public List<Product> queryByRange(rangeFields field, string fromValue, string toValue, List<Product> listP = null)
        {
            if (field == rangeFields.price || field == rangeFields.stockCount || field == rangeFields.whenToOrder)
            {
                List<Product> tempPList = itsDAL.productRangeQuery(field, fromValue, toValue, listP);
                EmphsizeTopSeller(tempPList);
                return tempPList;
            }
            Console.WriteLine("WRONG SEARCH PARAMETERS");
            return null;
        }

        /******************************************* <END> QUERYS <END> **********************************************/

        private void EmphsizeTopSeller(List<Product> listP)
        {
            if ((listP != null)&&(listP.Count!=0))
            {
                int top = listP.ElementAt(0).SoldLastMonth;
                foreach (Product p in listP)
                {
                    if (p.SoldLastMonth==top)
                        p.IsTopSeller=true;
                    else
                        p.IsTopSeller=false;
                }
            }
            else
                return;
        }

        /********************************************** OTHER *********************************************************/
        /*
         * requests, recieves and returns a container holding a list of all products in database
         */ 
        internal Products getAllProducts()
        {
            Products p = itsDAL.getAllProducts();
            p.isTimeToSetSeales();
            return p;    
        }

        internal void clearReceipt(Receipt receipt)
        {
           
            List<ProductSale> pSale = receipt.Data;
            foreach (ProductSale ps in pSale)
            {
                ps.PRODUCT.StockCount += ps.Amount;
                setInStock(ps.PRODUCT);
            }
        }
    }
}
