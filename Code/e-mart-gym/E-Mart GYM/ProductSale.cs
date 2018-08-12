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
    public class ProductSale
    {
        /************************
         * 
         * This class will represent a singal product sale at a certin moment
         * 
         * ***************************/
        /**********************Fields****************************/
        private string name;
        private int productID;
        private double price;
        private int amount;
        private Product prod;

        /***************************************Methods***************************************/
        /********************Constructor*****************************/
        public ProductSale(int productID, double price, int amount)
        {
            this.productID = productID;
            this.price = price;
            this.amount = amount;
        }
        public ProductSale()
        {

        }
        /*The constractor will get a product and will save its ID and the price in the buying time*/
        public ProductSale(Product product, int amount)
        {
            if (amount > product.StockCount)
                throw new Exception("Can`t but more than we have in stock");
            this.productID = product.InventoryID;
            this.price = product.Price;
            this.amount = amount;
            this.name = product.Name;
            this.prod = product;
        }

        public ProductSale(string productID, string price)
        {
            try
            {
                this.productID = Convert.ToInt32(productID);
                if (this.productID < 0) throw new Exception("Products ID Must Be Bigger Or Equal To 0.");
            }
            catch (FormatException)
            {
                throw new Exception("The Product ID Must Be A Number.");
            }
            catch (OverflowException)
            {
                throw new Exception("The Product ID is Either To Small Or To Big.");
            }
            try
            {
                this.price = Convert.ToDouble(price);
                if (this.price < 0) throw new Exception("Price Cannot Be Less Then 0.");
            }
            catch (FormatException)
            {
                throw new Exception("The Price Must Be A Number.");
            }
            catch (OverflowException)
            {
                throw new Exception("The Price is Either To Small Or To Big.");
            }
        }
        /************get/set*************/
        public int ProductID
        {
            get { return this.productID; }
            set { this.productID = value; }
        }

        public double Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public int Amount
        {
            get { return this.amount; }
            set { this.amount = value; }

        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public Product PRODUCT
        {
            get { return this.prod; }
            set { this.prod = value; }
        }

        /***************Other***************/
        public string toString()
        {
            return "product ID: " + productID.ToString() + " Product Name: " + name + " Amount: " + amount + " price: " + price.ToString();
        }

    }
}
