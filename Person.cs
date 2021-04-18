using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Listbox
{
    public class Person
    {
        public static List<Person> Existing = new List<Person>();

        string name;
        public string Name 
        { 
            get { return name; }
            set 
            { 
                if (value.Length > 2) { name = value; }
                else { throw new ArgumentException("Name must have at least 2 letters."); }
            }
        }

        string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value.Length > 2) { lastName = value; }
                else { throw new ArgumentException("Last name must have at least 2 letters."); }
            }
        }
        DateTime birthDate;
        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                if (value < DateTime.Now) { birthDate = value; }
                else { throw new ArgumentException("Birth date can't be in the future."); }
            }
        }
        public string BirthDateFormated
        {
            get { return BirthDate.ToString("yyyy/MM/dd"); }
        }
        public string personalIdentificationNumber;
        public string PersonalIdentificationNumber
        {
            get { return personalIdentificationNumber; }
            set
            {
                Regex reg = new Regex(@"^(?<date>\d{6})\/\d{3,4}");

                if (reg.IsMatch(value) && (value.Length == 11 || value.Length == 10)) //here i could verify value by checking for more rules but this is for now fair enought
                { personalIdentificationNumber = value; }
                else { throw new ArgumentException("Atempt to assign invalid value to personal identification number."); }
            }
        }

        public Person(string aName, string aLastName, DateTime aBirthDate, string aPersonalIdentificationNumber)
        {
            Name = aName;
            LastName = aLastName;
            BirthDate = aBirthDate;
            PersonalIdentificationNumber = aPersonalIdentificationNumber;
            Existing.Add(this);
        }

        public static void AddTestPersons()
        {
            Person subject1 = new Person("Franta", "Fusekle", new DateTime(1968, 12, 24), "681224/485");
            Person subject2 = new Person("Agnes", "Hammeln", new DateTime(1985, 7, 8), "855708/474"); //all women haves at PIN YY(MM+50)DD...
            Person subject3 = new Person("Geghanush", "Padsham", new DateTime(2001, 8, 27), "015827/485");
        }
    }
}
