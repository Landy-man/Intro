using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend;

namespace DAL
{
    public class ClubMember_LINQ_DAL
    {
        private List<ClubMember> clubMembers;

        public ClubMember_LINQ_DAL(ClubMembers clubMembers)
        {
            this.clubMembers = clubMembers.ClubMemberss;
        }

        //adds club member to databese
        public void addClubMember(ClubMember c)
        {
            clubMembers.Add(c);
        }

        //replaces previous club member (one with the same memberID) with clubMbmer c
        public void editClubMember(ClubMember c)
        {
            foreach (ClubMember member in clubMembers)
            {
                if (member.MemberID == c.MemberID)
                {
                    removeClubMember(member);
                    addClubMember(c);
                    return;
                }
            }
        }

        //removes club member c from database (finds him by checking memberID's)
        public void removeClubMember(ClubMember c)
        {
            foreach(ClubMember clubM in clubMembers)
            {
                if(clubM.MemberID == c.MemberID)
                {
                    this.clubMembers.Remove(clubM);
                    return;
                }
            }
        }


        //returns a list of clubMember's where: dateTime1<=dateOfBirth<=dateTime2
        internal List<ClubMember> clubMemberDateOfBirthQuery(DateTime dateTime1, DateTime dateTime2)
        {
            var dateTime =
                 from p in clubMembers
                 where p.Date_of_birth >= dateTime1 && p.Date_of_birth <= dateTime2
                 select p;

            return dateTime.ToList<ClubMember>();
        }

        //returns a list of clubMember's where the memberID = p
        internal List<ClubMember> clubMemberIDQuery(int p)
        {
            var ID =
                from c in clubMembers
                where c.MemberID == p
                select c;
            return ID.ToList<ClubMember>();
        }

        //returns a list of clubMember's where teudatZehute = p
        internal List<ClubMember> clubMemberTeudatZehuteQuery(int p)
        {
            var TeudatZehute =
               from c in clubMembers
               where c.TeudatZehute == p
               select c;

            return TeudatZehute.ToList<ClubMember>();
        }

        //returns a list of clubMembers where first name = value
        internal List<ClubMember> clubMemberFirstNameQuery(string value)
        {
            var FirstName =
               from c in clubMembers
               where c.FirstName == value
               select c;

            return FirstName.ToList<ClubMember>();
        }

        //returns a list of clubMembers where last name = value
        internal List<ClubMember> clubMemberLastNameQuery(string value)
        {
            var LastName =
               from c in clubMembers
               where c.LastName == value
               select c;

            return LastName.ToList<ClubMember>();
        }

        //returns a list of clubMembers where Gender = gender
        internal List<ClubMember> clubMemberGenderQuery(Gender gender)
        {
            var genders =
                from c in clubMembers
                where c.Gender == gender
                select c;
            return genders.ToList<ClubMember>();
        }
    }
}
