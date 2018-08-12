using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Backend
{
    public enum InStock { True, NeedToOrder, False };
    public enum Type {Electronics, Food, Fashion, HomeAndGarden };
    [XmlRoot("E-Mart"), Serializable]
    public class Product
    {
        private string name;
        private Type type;
        private int inventoryID;
        private int location;
        private InStock inStock;
        private int stockCount; 
        private double price;
        private int whenToOrder; //this field will help to determen the in stock field.
        private int soldThisMonth=0;
        private int soldLastMonth=0;
        private bool isTopSeller = false;

        /**********************Methods*************************/
        /****************Constructur********************/
        public Product(string name, string type, int inventoryID, int location, InStock inStock, int stockCount, double price, int minToOrder)
        {
            this.name = name;
            this.inventoryID = inventoryID;
            this.location = location;
            this.inStock = inStock;
            this.price = price;
            this.type = (Type)Enum.Parse(typeof(Type), type);
            this.stockCount = stockCount;
            this.whenToOrder = minToOrder;
        }

        /*Copy Constractor*/
        public Product(Product p) 
        {
            this.name = p.Name;
            this.inventoryID = p.InventoryID;
            this.location = p.Location;
            this.inStock = p.INStock;
            this.price = p.Price;
            this.type = p.Type;
            this.stockCount = p.StockCount;
            this.whenToOrder = p.WhenToOrder;
        }

        /*String constractor which will check that the format given by user is in the right format*/
        public Product(string name, string type, string location, string stockCount, string price, string whenToOrder)
        {
            if (name.Length < 1) throw new Exception("Invalid Product Name, Must Have Atleast One Character");
            this.name = name;

            try
            {
                this.type = (Type)Enum.Parse(typeof(Type), type);
            }
            catch (ArgumentException)
            {
                throw new Exception("The Type of Produce doesnt exist.");
            }
            try
            {
                this.location = Convert.ToInt32(location);
            }
            catch (FormatException)
            {
                throw new Exception("The Location Must Be A Number.");
            }
            catch (OverflowException)
            {
                throw new Exception("The Location is Either To Small Or To Big");
            }

            try
            {
                this.stockCount = Convert.ToInt32(stockCount);
                if (this.stockCount < 0) throw new Exception("The Stock Count Must Be Bigger Or Equal To 0.");
            }
            catch (FormatException)
            {
                throw new Exception("The Stock Count Must Be A Number.");
            }
            catch (OverflowException)
            {
                throw new Exception("The Stock Count is Either To Small Or To Big.");
            }
            try
            {
                this.whenToOrder = Convert.ToInt32(whenToOrder);
                if (this.whenToOrder < 0)
                    throw new Exception("The minimun number of items on which you need to order must be bigger than 0.");
            }
            catch (FormatException)
            {
                throw new Exception("The minimum numbers to order Must Be A Number.");
            }
            catch (OverflowException)
            {
                throw new Exception("The amount from which to place  is Either To Small Or To Big.");
            }


            try
            {
                double tempPrice = Convert.ToDouble(price);
                if (tempPrice > 0) this.Price = tempPrice;
                else throw new Exception("The Price Must Be Above 0.");
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


        public Product()
        {

        }
        /********************getter/setter*********************/
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int InventoryID
        {
            get { return this.inventoryID; }
            set { this.inventoryID = value; }
        }

        public int Location
        {
            get { return this.location; }
            set { this.location = value; }
        }

        public InStock INStock
        {
            get { return this.inStock; }
            set { this.inStock = value; }
        }

        public int StockCount
        {
            get { return this.stockCount; }
            set { this.stockCount = value; }
        }

        public double Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
        public Type Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        public int WhenToOrder
        {
            get { return this.whenToOrder; }
            set { this.whenToOrder = value; }
        }

        public bool IsTopSeller
        {
            get { return this.isTopSeller; }
            set { this.isTopSeller = value; }
        }

        public int SoldLastMonth
        {
            get { return this.soldLastMonth; }
            set { this.soldLastMonth = value; }
        }

        public int SoldThisMonth
        {
            get { return this.soldThisMonth; }
            set { this.soldThisMonth = value; }
        }

        /*******************Other************************/
        public string toString()
        {
            return "Product Name: " + name +
                   " Type: " + type.ToString() +
                   " Inventory ID: " + inventoryID.ToString() +
                   " Location: " + location.ToString() +
                   " In stock?: " + inStock.ToString() +
                   " Stock count: " + stockCount.ToString() +
                   " Price " + price.ToString() +
                    " Minimun numbers in which to order:  " + whenToOrder.ToString();
        }
    }
}
