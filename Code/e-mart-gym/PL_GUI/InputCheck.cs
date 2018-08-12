using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend;
using BL;

namespace PL_GUI
{

    public class InputCheck
    {
        public static void isInt(string abc, string field)
        {
            try
            {
                int tmp = Convert.ToInt32(abc);
            }
            catch (FormatException)
            {
                throw new Exception("The" + field + "Must Be A Number ");
            }
        }

        public static void isDouble(string abc,string field)
        {
            try
            {
                double tmp = Convert.ToDouble(abc);
            }
            catch (FormatException)
            {
                throw new Exception("The" + field + "Must Be A Number ");
            }
        }

        public static void isType(string abc)
        {
            if (abc != "Electronics" && abc != "Food" && abc != "Fashion" && abc != "HomeAndGarden")
            {
                try
                {
                    Backend.Type tmp = (Backend.Type)Enum.Parse(typeof(Backend.Type), abc);
                }
                catch (ArgumentException)
                {
                    throw new Exception("The Type of Produce doesnt exist.at all");
                }
            }
        }

        public static void isPaymentMethod(string abc)
        {
            try
            {
                PaymentMethod tmp = (PaymentMethod)Enum.Parse(typeof(PaymentMethod), abc);
            }
            catch (ArgumentException)
            {
                throw new Exception("The Payment method You Entered Doesnt exist.");
            }
        }

        public static void isGender(string abc)
        {
            try
            {
                Gender tmp = (Gender)Enum.Parse(typeof(Gender), abc);
            }
            catch (ArgumentException)
            {
                throw new Exception("The gender must be writen 'Male' or 'Female' only. ");
            }
        }

        public static void isinStock(string abc)
        {
            try
            {
                InStock tmp = (InStock)Enum.Parse(typeof(InStock), abc);
            }
            catch (ArgumentException)
            {
                throw new Exception("The in stock You Entered Doesnt exist.");
            }
        }

        public static void isDateTime(string abc)
        {
            try
            {
                DateTime tmp = Convert.ToDateTime(abc);
            }
            catch (FormatException)
            {
                throw new Exception("Your date of birth is illigel");
            }
        }

    } 
}
