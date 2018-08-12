using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Collections.ObjectModel;

namespace Backend
{
    [XmlRoot("E-Mart"), Serializable]
    public class Products
    {
        /*******************************Field************************************/
        private List<Product> products = new List<Product>();
        private DateTime isTheMonth = DateTime.Today;

        /*********************Constructor************************/
        public Products(List<Product> products)
        {
            this.products = products;
        }
        public Products()
        {

        }
        /**************Methods***********************/
        /*****Get/Set***********/
        public List<Product> Productss
        {
            get { return this.products; }
            set { this.products = value; }
        }

        public DateTime IsTheMonth
        {
            get { return this.isTheMonth; }
            set { this.isTheMonth = value; }
        }



        /**********************************************************/
        /*Adding removing and editing products in the list*/
        public void addProduct(Product productToAdd)
        {
            products.Add(productToAdd);
        }
        public void removeProduct(Product productToRemove)
        {
            products.Remove(productToRemove);
        }

        public void editProduct(Product p)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products.ElementAt(i).InventoryID == p.InventoryID)
                {
                    removeProduct(products.ElementAt(i));
                    addProduct(p);
                    return;
                }
            }
        }

        public bool isTheMonthChanged()
        {
            DateTime today = DateTime.Today;
            return this.isTheMonth.Month != today.Month;
        }

        public void isTimeToSetSeales()
        {
            if (!isTheMonthChanged()) { return; }
            else
            {
                foreach (Product p in products)
                {
                    p.SoldLastMonth = p.SoldThisMonth;
                    p.SoldThisMonth = 0;
                }
                this.isTheMonth = DateTime.Today;
            }
        }

        /*************Other***************/
        public string toString()
        {
            string ans = "";
            foreach (Product product in products)
            {
                ans = ans + product.toString() + "\n";
            }
            return ans;
        }


    }

}
