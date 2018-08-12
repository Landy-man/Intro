using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend;

namespace DAL
{
    public class Transaction_LINQ_DAL
    {
        private List<Transaction> transactions;

        //constructor
        public Transaction_LINQ_DAL(Transactions transactions)
        {
            this.transactions = transactions.Transactionss;
        }

        //adds transaction t into the transaction's database
        public void addTransaction(Transaction t)
        {
            transactions.Add(t);
        }

        //replaces the previous transaction with transaction t, finds previous by comparing transactioID's
        public void editTransaction(Transaction t)
        {
            foreach (Transaction transaction in transactions)
            {
                if (transaction.TransactionID == t.TransactionID)
                {
                    removeTransaction(transaction);
                    addTransaction(t);
                    return;
                }
            }
        }

        //removes transaction t from database, locates t by comparing transactionID's
        public void removeTransaction(Transaction t)
        {
            foreach(Transaction trans in transactions)
            {
                if(trans.TransactionID == t.TransactionID)
                {
                    this.transactions.Remove(trans);
                    return;
                }
            }
        }

        //returns a list of transaction's where transactionID = p
        internal List<Transaction> transactionIDQuery(int p)
        {
            var id =
                from t in transactions
                where t.TransactionID == p
                select t;

            return id.ToList<Transaction>();
        }

        //returns a list of transaction's where is_a_return = p
        internal List<Transaction> transactionIsAReturnQuery(bool p)
        {
            var isAReturn =
               from t in transactions
               where t.Is_a_return == p
               select t;

            return isAReturn.ToList<Transaction>();
        }

        //returns a list of transaction's where paymentMethod = paymentMethod
        internal List<Transaction> transactionPaymentMethodQuery(PaymentMethod paymentMethod1)
        {
            var paymentMethod =
              from t in transactions
              where t.PaymentMethod == paymentMethod1
              select t;

            return paymentMethod.ToList<Transaction>();
        }

        ////returns a list of transaction's where dateTime1 <= dateTime <= dateTime2
        internal List<Transaction> transactionDateTimeQuery(DateTime dateTime1, DateTime dateTime2)
        {
            var dateTime =
                from t in transactions
                where t.DateTime >= dateTime1 && t.DateTime <= dateTime2
                select t;
            return dateTime.ToList<Transaction>();
        }
    }
}
