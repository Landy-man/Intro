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
    public class Receipt
    {
        private List<ProductSale> data = new List<ProductSale>();

        /*************************Methods*************************/
        public Receipt(List<ProductSale> data)
        {
            this.data = data;
        }
        public Receipt(Receipt r)
        {
            this.data = r.data;
        }
        public Receipt()
        {

        }
        /****************Get/Set**********/
        public List<ProductSale> Data
        {
            get { return this.data; }
            set { this.data = value; }
        }
        /*************************/
        public void addProductSale(ProductSale sale)
        {
            minimize(sale);
        }

        public void removeProductSale(ProductSale sale)
        {

            data.Remove(sale);
        }
      

        /**********************Minimizing the list*************************/
        public void minimize(ProductSale sale)
        {
            bool found = false;
            if (this.data == null || this.data.Count == 0)
                data.Add(sale);
            else
            {
                for (int i = 0; i < data.Count && !found; i++)
                    if (data.ElementAt(i).ProductID == sale.ProductID)
                    {
                        data.ElementAt(i).Amount += sale.Amount;
                        found = true;
                    }
                if (!found)
                    data.Add(sale);
            }
        }
        /**************  *****************/
        public string toString()
        {
            string ans = "";
            foreach (ProductSale p in data)
            {
                ans = ans + p.toString() + " \n";
            }
            return ans;
        }
    }
}
