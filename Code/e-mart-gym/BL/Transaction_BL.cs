using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Backend;

namespace BL
{
    public class Transaction_BL
    {
        IDAL itsDAL;

        public Transaction_BL(IDAL dal)
        {
            this.itsDAL = dal;
        }

        /*********************************************** ADD/REMOVE/EDIT ***************************************************/
            /************ ADD **************/
        /*
         * requests itDAL to add transaction after:
         * 1. checking if receipt in transaction is correct
         * 2. sets the transaction's transactionID 
         */
        public void addTransaction(Transaction transaction)
        {
            try
            {
                isReceiptValid(transaction.Receipt, true);//1
            }
            catch(Exception e)
            {
                throw e;
            }
            setTransactionID(transaction);//2
            itsDAL.addTransaction(transaction);
        }
            /****** REMOVE *******/
        /*
         * requests itsDAL to remove transaction from database after:
         * 1. removing all records of this specific transaction
         */
        public void removeTransaction(Transaction transaction)
        {
            removeTransactionfromrecord(transaction);//1
            itsDAL.removeTransaction(transaction);
        }

            /**** EDIT *****/
        /*
         * requests itsDAL to edit the transaction in database after:
         * 1. checking if the receipt listed in the transaction is correct
         */
        public void editTransaction(Transaction transaction)
        {
            try
            {
                isReceiptValid(transaction.Receipt , false);//1
            }
            catch (Exception e)
            {
                throw e;
            }
            itsDAL.editTransaction(transaction);
        }

            /*************** PRIVATE METHOD ****************/
        /*
         * checkPrice = true -> throws an exception if the receipt r contains an incorrect productID or price
         * checkPrice = false -> throws an exception if the receipt r contains an incorrect productID
         */
        private void isReceiptValid(Receipt r,bool checkPrice)
        {
            Products products = itsDAL.getAllProducts();

            for (int i = 0; i < r.Data.Count; i++)
            {
                bool found = false;

                foreach (Product product in products.Productss)
                {
                    if (product.InventoryID == r.Data.ElementAt(i).ProductID )
                    {
                        if(checkPrice)
                        {
                            if(product.Price == r.Data.ElementAt(i).Price)
                            {
                                 found = true;
                                 break;
                            }
                        }
                        else
                        {
                            found = true;
                            break;
                        }
                    }
                }
                if (!found) throw new Exception("Recipt Invalid Product: " + r.Data.ElementAt(i).ProductID + " Was Not Found Or Price Is Incorrect");
            }
        }

        /*
         * sets the transactionID to the max value existing in the transaction data base +1
         */
        private void setTransactionID(Transaction transaction)
        {
            Transactions allTransactions = itsDAL.getAllTransactions();
            int maxID = 0;
            foreach (Transaction trans in allTransactions.Transactionss)
            {
                if (trans.TransactionID > maxID)
                {
                    maxID = trans.TransactionID;
                }
            }
            transaction.TransactionID = maxID+1;
        }

        /*
         * removes all records of this transaction in the clubMember's transaction history fields
         */
        private void removeTransactionfromrecord(Transaction transaction)
        {
            ClubMembers allClubMembers = itsDAL.getAllClubMembers();
            foreach (ClubMember club in allClubMembers.ClubMemberss)
            {
                foreach (int i in club.TransactionHistory)
                {
                    if (transaction.TransactionID == i)
                    {
                        club.removeTransactionHostory(i);
                        return;
                    }
                }
            }
        }

        /****************************** <END> ADD/REMOVE/EDIT <END> ***********************************/

        /**************************************** QUERYS ************************************************/

            /******** STRING QUERY *********/
        /*
      * will direct the query requested to the correct function in the this.itsDAL interface 
      * and return a list containing the query results:
      * a list of all the transactions where field equals value
      */
        public List<Transaction> queryByString(stringFields field, string value)
        {
            if (field == stringFields.transactionID || field == stringFields.is_A_Return || field == stringFields.paymentMethod)
            {
                return itsDAL.transactionStringQuery(field, value);
            }
            Console.WriteLine("WRONG SEARCH PARAMETERS");
            return null;
        }

            /********* RANGE QUERY **********/
        /*
         *will direct the query requested to the correct function in the this.itsDAL interface
         *and return a list containing the query results:
         *all the transactions in which -> fromValue <= field <= toValue
         */
        public List<Transaction> queryByRange(rangeFields field, string fromValue, string toValue)
        {
            if (field == rangeFields.dateTime)
            {
                return itsDAL.transactionRangeQuery(field, fromValue, toValue);
            }
            Console.WriteLine("WRONG SEARCH PARAMETERS");
            return null;
        }

        /********************* <END> QUERYS <END> ********************************/

        /***************************** OTHER *******************************/
        /*
         * requests,recieves and returns a container containing a list of all transactions
         */
        internal Transactions getAllTransaction()
        {
            return itsDAL.getAllTransactions();
        }

       
    }
}
