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
    public class Transactions
    {
        private List<Transaction> transactions = new List<Transaction>();

        /*********************Constructor************************/
        public Transactions(List<Transaction> transactions)
        {
            this.transactions = transactions;
        }
        public Transactions()
        {

        }
        /**************Methods***********************/
        /********Get/Set************/
        public List<Transaction> Transactionss
        {
            get { return this.transactions; }
            set { this.transactions = value; }
        }
        public void addTransaction(Transaction transactionToAdd)
        {
            transactions.Add(transactionToAdd);
        }
        public void removeTransaction(Transaction transactionToRemove)
        {
            transactions.Remove(transactionToRemove);
        }
        /*************Other***************/
        public string toString()
        {
            string ans = "";
            foreach (Transaction transaction in transactions)
            {
                ans = ans + transaction.toString() + "\n";
            }
            return ans;
        }
    }

}
