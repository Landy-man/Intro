using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Backend
{

    public enum PaymentMethod { Cash, Credit, Check };
    [XmlRoot("E-Mart"), Serializable]
    public class Transaction
    {
        private int transactionID;
        private DateTime dateTime;
        private Boolean is_a_return;
        private Receipt receipt;
        private PaymentMethod paymentMethod;
        private Int64 crcNum = 0;

        public Transaction(int transactionID, DateTime dateTime, Boolean is_a_return, Receipt receipt, string paymentsMethod)
        {
            this.transactionID = transactionID;
            this.dateTime = dateTime;
            this.is_a_return = is_a_return;
            this.receipt = receipt;
            paymentMethod = (PaymentMethod)Enum.Parse(typeof(PaymentMethod), paymentsMethod);
        }

        public Transaction()
        {

        }

        public Transaction(Transaction t)
        {
            this.transactionID = t.transactionID;
            this.dateTime = t.dateTime;
            this.is_a_return = t.is_a_return;
            this.receipt = t.receipt;
            this.paymentMethod = t.paymentMethod;
        }

        public Transaction(Receipt receipt, string paymentsMethod)
        {
            this.dateTime = DateTime.Now;
            this.is_a_return = false;
            this.receipt = receipt;

            try
            {
                this.paymentMethod = (PaymentMethod)Enum.Parse(typeof(PaymentMethod), paymentsMethod);
            }
            catch (ArgumentException)
            {
                throw new Exception("The Payment method You Entered Doesnt exist.");
            }

        }
        /***********************get/set*********************/
        public int TransactionID
        {
            get { return this.transactionID; }
            set { this.transactionID = value; }
        }

        public DateTime DateTime
        {
            get { return this.dateTime; }
            set { this.dateTime = value; }
        }

        public bool Is_a_return
        {
            get { return this.is_a_return; }
            set { this.is_a_return = value; }
        }
        public PaymentMethod PaymentMethod
        {
            get { return this.paymentMethod; }
            set { this.paymentMethod = value; }
        }
        public Receipt Receipt
        {
            get { return this.receipt; }
            set { this.receipt = value; }
        }

        public Int64 CrcNum
        {
            get { return this.crcNum; }
            set { this.crcNum = value; }
        }
        /*****************Other**********************/
        public string toString()
        {
            return "transaction ID: " + transactionID.ToString() +
                    " date time: " + dateTime.ToString() +
                    " a return type? " + is_a_return + "\n"+
                    "receipt: "+"\n" + receipt.toString() +  
                    "payment method: " + paymentMethod.ToString();
        }
    }
}
