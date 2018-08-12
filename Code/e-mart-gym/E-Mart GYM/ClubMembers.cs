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
    public class ClubMembers
    {
        /*
         The class will represent all of the club members in E-Mart
         */
        /*************************************Field****************************************/
        private List<ClubMember> clubMembers = new List<ClubMember>(); //Creating a Empty list of club Members on default

        /******************************Constructor*****************************************/
        public ClubMembers(List<ClubMember> clubMembers)
        {
            this.clubMembers = clubMembers;
        }
        public ClubMembers()
        {

        }
        /**********************************Methods*****************************************/
        /***********************************get/set****************************************/
        public List<ClubMember> ClubMemberss
        {
            get { return this.clubMembers; }
            set { this.clubMembers = value; }
        }

        /*Adding a club member to the list of club members*/
        public void addClubMember(ClubMember clubMemberToAdd)
        {
            clubMembers.Add(clubMemberToAdd);
        }

        /*Removing a club member from the list of club members*/
        public void removeClubMember(ClubMember clubMemberToRemove)
        {
            clubMembers.Remove(clubMemberToRemove);
        }
        /***********************************Other*********************************/
        public string toString()
        {
            string ans = "";
            foreach (ClubMember clubMember in clubMembers)
            {
                ans = ans + clubMember.toString() + "\n";
            }
            return ans;
        }
    }

}
