using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend;

namespace DAL
{
    public class Product_LINQ_DAL
    {
        public List<Product> products;

        //constructor
        public Product_LINQ_DAL(Products products)
        {
            this.products = products.Productss;
        }

        //adds product p to database
        public void addProduct(Product p)
        {
            this.products.Add(p);
        }

        //removes product p from products data base, product p is find by comparing productID's
        public void removeProduct(Product p)
        {
            foreach(Product prod in products)
            {
                if(prod.InventoryID == p.InventoryID)
                {
                    this.products.Remove(prod);
                    return;
                }
            }
        }

        //product p replaces his previos version in the products database, found by comparing productID's
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

        //returns a list of products where InventoryID == p1
        internal List<Product> productInventoryIDQuery(int p1,List<Product> listP=null)
        {
            if(listP == null)
            {
                listP = products;
            }

            var inventoryID =
                from p in listP
                where p.InventoryID == p1
                orderby p.SoldLastMonth descending
                select p;

            return inventoryID.ToList<Product>();
        }

        //returns a list of products where Location = p1
        internal List<Product> productLocationQuery(int p1, List<Product> listP = null)
        {
            if (listP == null)
            {
                listP = products;
            }

            var location =
                 from p in listP
                 where p.Location == p1
                 orderby p.SoldLastMonth descending
                 select p;

            return location.ToList<Product>();
        }

        //returns a list of products where where name = value
        internal List<Product> productNameQuery(string value, List<Product> listP = null)
        {
            if (listP == null)
            {
                listP = products;
            }

            var name =
                 from p in listP
                 where p.Name == value
                 orderby p.SoldLastMonth descending
                 select p;

            return name.ToList<Product>();
        }

        //returns a list of products where type = type1
        internal List<Product> productTypeQuery(Backend.Type type1, List<Product> listP = null)
        {
            if (listP == null)
            {
                listP = products;
            }

            var type =
                from p in listP
                where p.Type == type1
                orderby p.SoldLastMonth descending
                select p;

            return type.ToList<Product>();
        }

        //returns a list of products where inStock = inStock1
        internal List<Product> productInStockQuery(InStock inStock1, List<Product> listP = null)
        {
            if (listP == null)
            {
                listP = products;
            }

            if(inStock1 == InStock.NeedToOrder)
            {
                var inStock =
                from p in listP
                where (p.INStock == inStock1 || p.INStock == InStock.False)
                orderby p.SoldLastMonth descending
                select p;

                return inStock.ToList<Product>();
            }
            else if(inStock1 == InStock.True)
            {
                var inStock =
              from p in listP
              where (p.INStock == inStock1 || p.INStock == InStock.NeedToOrder)
              orderby p.SoldLastMonth descending
              select p;

                return inStock.ToList<Product>();
            }
            var inStock2 =
                from p in listP
                where p.INStock == inStock1
                orderby p.SoldLastMonth descending
                select p;

            return inStock2.ToList<Product>();
        }

        //returns a list of products where p1<=Price<=p2
        internal List<Product> productPriceQuery(double p1, double p2, List<Product> listP = null)
        {
            if (listP == null)
            {
                listP = products;
            }

            var price =
                from p in listP
                where p.Price >= p1 && p.Price <= p2
                orderby p.SoldLastMonth descending
                select p;

            return price.ToList<Product>();
        }

        //returns a list of products where p1<=stockCount<=p2
        internal List<Product> productStockCountQuery(int p1, int p2, List<Product> listP = null)
        {
            if (listP == null)
            {
                listP = products;
            }

            var stockCount =
                from p in listP
                where p.StockCount >= p1 && p.StockCount <= p2
                orderby p.SoldLastMonth descending
                select p;

            return stockCount.ToList<Product>();
        }

        //returns a list of products where p1<=WhenToOrder<=p2
        internal List<Product> productWhenToOrderQuery(int p1, int p2, List<Product> listP = null)
        {
            if (listP == null)
            {
                listP = products;
            }

            var whenToOrder =
               from p in listP
               where p.WhenToOrder >= p1 && p.WhenToOrder <= p2
               orderby p.SoldLastMonth descending
               select p;

            return whenToOrder.ToList<Product>();
        }
    }
}
