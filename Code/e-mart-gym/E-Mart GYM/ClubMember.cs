using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using E_Mart_GYM;

namespace Backend
{
    [XmlRoot("E-Mart"), Serializable]
    /*
     * The class will create an object of a club member with all the relevent data
    */
    public class ClubMember
    {
        /***************************************Fields**************************************************/
        private int memberID;
        private int teudatZehute;
        private string firstName;
        private string lastName;
        private List<int> transactionHistory = new List<int>();////?
        private Gender gender;
        private DateTime date_of_birth;
        private CreditCard creditCard = null;

        /************************************************Methods*********************************************/
        /************counstructor****************/
        public ClubMember() { } // Default constractor

        public ClubMember(int memberID, int teudatZehute, string firstName, string lastName, List<int> transactionHistory, string geender, DateTime date_of_birth)
        {
            this.memberID = memberID;
            this.teudatZehute = teudatZehute;
            this.firstName = firstName;
            this.lastName = lastName;
            this.transactionHistory = transactionHistory;
            this.date_of_birth = date_of_birth;
            this.gender = (Gender)Enum.Parse(typeof(Gender), geender);
        }

        public ClubMember(ClubMember clubmember) //Copy constractor, Will provid a deep copy of a Club Member
        {
            this.memberID = clubmember.memberID;
            this.teudatZehute = clubmember.teudatZehute;
            this.firstName = clubmember.firstName;
            this.lastName = clubmember.lastName;
            this.transactionHistory = clubmember.transactionHistory;
            this.date_of_birth = clubmember.date_of_birth;
            this.gender = clubmember.gender;
        }

        public ClubMember(string teudatZehute, string firstName, string lastName, string geender, string date_of_birth)
        {
            /*
             * This constractor will get importent fileds of a club member and will check if the values are valid;
             * if not it will throw an exeption to user indicating the wrong input
             * */
            if (firstName.Length < 1) throw new Exception("Invalid First Name, Must Have Atleast One Character");
            if (lastName.Length < 1) throw new Exception("Invalid Last Name, Must Have Atleast One Character");
            this.firstName = firstName;
            this.lastName = lastName;

            try
            {
                this.teudatZehute = Convert.ToInt32(teudatZehute);
                if (this.teudatZehute <= 0) throw new Exception("InValid ID.");
            }
            catch (FormatException)
            {
                throw new Exception("The Teudat Zehute Must Be A Number.");
            }
            catch (OverflowException)
            {
                throw new Exception("The Teudat Zehute is Either To Small Or To Big.");
            }
            try
            {
                this.gender = (Gender)Enum.Parse(typeof(Gender), geender);
            }
            catch (ArgumentException)
            {
                throw new Exception("The Gender You Entered Doesnt exist.");
            }
            try
            {
                this.date_of_birth = Convert.ToDateTime(date_of_birth);
            }
            catch (FormatException)
            {
                throw new Exception("Your date of birth must be in the following order.");
            }


        }

        /****************get / set******************/
        public int MemberID 
        {
            get { return this.memberID; }
            set { this.memberID = value; }
        }
        public int TeudatZehute
        {
            get { return this.teudatZehute; }
            set { this.teudatZehute = value; }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public Gender Gender
        {
            get { return this.gender; }
        }

        public DateTime Date_of_birth
        {
            get { return this.date_of_birth; }
            set { this.date_of_birth = value; }
        }

        public CreditCard CreditCard
        {
            get { return this.creditCard; }
            set { this.creditCard = value; }

        }

        public List<int> TransactionHistory
        {
            get { return this.transactionHistory; }
            set { this.transactionHistory = value; }
        }

        //The function will add a transaction to the club members Transaction history
        public void addTransactionToHistory(int toAdd) 
        {
            transactionHistory.Add(toAdd);
        }

        //The function will remove a transaction to the club members Transaction history
        public void removeTransactionHostory(int toRemove)
        {
            transactionHistory.Remove(toRemove);
        }

        //The function will return all of the TransactionID of the current Club Member
        public string getAllTransactionsFromHistory()
        {
            string ans = "";
            foreach (int s in transactionHistory)
            {
                ans = ans + s + "\n";
            }
            return ans;
        }

        public void addCreditCard(string crc,string expierymonth,string expieryears, string threeDig){
            try
            {
                this.creditCard = new CreditCard(crc, expierymonth, expieryears, threeDig);
            }
            catch (Exception e)
            {
                
                throw e;
            }
        }


        public void addCreditCard(CreditCard c)
        {
            this.CreditCard = c;
        }

        public void removeCreditCard()
        {
            this.creditCard = null;
        }

        /*********************Other************************/
        public string toString()
        {
            return "Member Id: " + memberID.ToString() +
                    " Teudat Zehute: " + teudatZehute.ToString() +
                    " Full Name: " + firstName + " " + lastName +
                    " Transaction History : " + getAllTransactionsFromHistory() +
                    " Gender: " + gender.ToString() +
                    " Date Of Birth: " + date_of_birth.ToString("d");
        }

    }
}
