using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace E_Mart_GYM
{
    [XmlRoot("E-Mart"), Serializable]
    public class CreditCard
    {

        /***********************Fields*****************************/
        private Int64 creditcardnum;
        private DateTime expiery;
        private string threeDig;
        /****************************Constractor*******************************/
        public CreditCard() { }

        public CreditCard(CreditCard c)
        {
            this.creditcardnum = c.creditcardnum;
            this.expiery = c.expiery;
            this.threeDig = c.threeDig;
        }

        public CreditCard(string crc,string expierymonth,string expieryears, string threeDig)
        {
            if (threeDig.Length==3)
                {
                    try
                    {
                        Convert.ToInt32(threeDig);
                        this.threeDig = threeDig;
                    }
                    catch (Exception )
                    {
                        throw new Exception("You are reqiuerd to give you back 3 digits");
                    }
                }
                else
                    throw new Exception("You are reqiuerd to give you back 3 digits");
            

            try{
                DateTime exp = new DateTime(Convert.ToInt32(expieryears),Convert.ToInt32(expierymonth),1);
                this.Expiery=exp;
            }catch (Exception )
            {
                throw new Exception("Invalid expiery date please try again");
            }

            if (crc.Length==16){
                try{
                    
                    this.creditcardnum = Convert.ToInt64(crc);;
                }catch(Exception)
                {
                    throw new Exception("Your card number must contain only numbers");
                }
            }
            else{
                throw new Exception("Your credit ,ust contain 16 digits");
            }
        
        }
        /******************************Methods*********************************************/
        public DateTime Expiery
        { 
            get { return this.expiery; }
            set { this.expiery = value; }
        }
        public Int64 CreditCardd 
        {
            get { return this.creditcardnum; }
            set { this.creditcardnum = value; }
        }
        public string ThreeDig 
        {
            get { return this.threeDig; }
            set { this.threeDig = value; }
        }


        /*******************************ToString****************************************/
        public string toString()
        {
            return "CreditCard number: " + creditcardnum + " Expiery Date: " + Expiery.Month + "/" + Expiery.Year + " 3 Digit pin: " + ThreeDig;
        }
    }
}
