using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend;
using DAL;

namespace BL
{
    class ClubMember_BL
    {
        IDAL itsDAL;

        public ClubMember_BL(IDAL itsDAL)
        {
            this.itsDAL = itsDAL;
        }

        /******************************************* ADD / REMOVE / EDIT *****************************************/
            /*********************** ADD *********************/
        /*
         * in order to add a club member:
         * 1. the club members teudat zehute must be unique, cannot add a club member if the teudat zehute exists in data base
         * 2. the club members ID will be set on run time.
         */
        public void addClubMember(ClubMember clubMember)
        {
            try
            {
                checkExsitindID(clubMember);//1
                setClubMemberID(clubMember);//2
            }
            catch (Exception e)
            {
                throw e;
            }
            itsDAL.addClubMember(clubMember);
        }

            /********************* REMOVE ************************/
        /*
         * calls for clubMembers removal
         */ 
        public void removeClubMember(ClubMember clubMember)
        {
            itsDAL.removeClubMember(clubMember);
        }

            /***************************** EDIT ***************************/
        /*
         * editing a club member:
         * 1. checks if the transactions listed in the clubMember exist
         */ 
        public void editClubMember(ClubMember clubMember)
        {
            try
            {
                doTransactionsExist(clubMember);//1
            }
            catch (Exception e)
            {
                throw e;
            }
            itsDAL.editClubMember(clubMember);
        }

            /***************** PRIVATE FUNCTIONS *********************/
        /*
         * throws exception if the transactions listed in the clubMember actually exist
         */ 
        private void doTransactionsExist(ClubMember clubMember)
        {
            Transactions transactions = itsDAL.getAllTransactions();
            for (int i = 0; i < clubMember.TransactionHistory.Count; i++)
            {
                bool found = false;

                foreach (Transaction transaction in transactions.Transactionss)
                {
                    if (transaction.TransactionID == clubMember.TransactionHistory.ElementAt(i))
                    {
                        found = true;
                        break;
                    }
                }
                if (!found) throw new Exception("The Transaction History Is Incorrectr Transaction: " + clubMember.TransactionHistory.ElementAt(i) + " Was Not Found");
            }
        }

        /*
         * throws an exception if the clubMembers teudat zehute allready exists in the database
         */ 
        private void checkExsitindID(ClubMember clubMember)
        {
            ClubMembers allClubmembers = itsDAL.getAllClubMembers();
            foreach (ClubMember club in allClubmembers.ClubMemberss)
            {
                if (clubMember.TeudatZehute == club.TeudatZehute)
                    throw new Exception("ID is already in use.");
            }
        }

        /*
         * sets the clubMember's ID to the maximum ID existing in the data base + 1
         */ 
        private void setClubMemberID(ClubMember clubMember)
        {
            ClubMembers allClubMembers = itsDAL.getAllClubMembers();
            int maxID = 0;
            foreach (ClubMember club in allClubMembers.ClubMemberss)
            {
                if (club.MemberID > maxID)
                {
                    maxID = club.MemberID;
                }
            }
            clubMember.MemberID = maxID+1;
        }

        /********************************************* <END> ADD/REMOVE/EDIT <END> ****************************************************/
        
        /*********************************************************** QUERYS **************************************************************/
            /********* STRING QUERY ***********/
        /*
         * will direct the query requested to the correct function in the this.itsDAL interface 
         * and return a list containing the query results:
         * all the club members where field equals value
         */ 
        public List<ClubMember> queryByString(stringFields field, string value)
        {
            if (field == stringFields.firstName || field == stringFields.lastName || field == stringFields.memberID || field == stringFields.teudatZehute || field == stringFields.gender)
            {
                return itsDAL.ClubMemberStringQuery(field, value);
            }
            Console.WriteLine("WORNG SEARCH PARAMETERS");
            return null;
        }
            /************ RANGE QUERY ****************/
        /*
         *will direct the query requested to the correct function in the this.itsDAL interface
         *and return a list containing the query results:
         *all club members in which -> fromValue <= filed <= toValue
         */ 
        public List<ClubMember> queryByRange(rangeFields field, string fromValue, string toValue)
        {
            if (field == rangeFields.date_of_birth)
            {
                return itsDAL.clubMemberRangeQuery(field, fromValue, toValue);
            }
            Console.WriteLine("WRONG SEARCH PARAMETERS");
            return null;
        }

        /********************************** <END> QUERYS <END> ************************************************/
        
        /***************************************** OTHER ************************************************/
        /*
         * calls, recieves and then returns the full club member list from the database
         */ 
        internal ClubMembers getAllClubMembers()
        {
            return itsDAL.getAllClubMembers();
        }
    }
}
