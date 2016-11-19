using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLibrary
{
    interface IPerson
    {
        string ShowCountry();
    }

    public class IndianPerson : IPerson
    {
        string IPerson.ShowCountry()
        {
            return "I am Indian Person";
        }
    }

    class USPerson : IPerson
    {
        public string ShowCountry()
        {
            return "I am US Person";
        }
    }

    class PersonSupplyer
    {
        public static IPerson ReturnPerson(String country)
        {
            if (country == "INDIA")
                return new IndianPerson();
            else if (country == "US")
                return new USPerson();
            else
                return null;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            IPerson objPerson = PersonSupplyer.ReturnPerson("INDIA");

            objPerson.ShowCountry();
            Console.ReadLine();
        }
    }
}