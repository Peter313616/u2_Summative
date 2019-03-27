using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _313616_Contacts
{
    class Contact
    {
        private string firstName;
        private string lastName;
        private int yearBorn;
        private int monthBorn;
        private int dayBorn;
        private string email;

        public Contact(string fN, string lN, int yB, int mB, int dB, string eA)
        {
            firstName = fN;
            lastName = lN;
            yearBorn = yB;
            monthBorn = mB;
            dayBorn = dB;
            email = eA;
        }

        public string[] readFromFile()
        {
            System.IO.StreamReader streamReader = new System.IO.StreamReader("contact.txt");
            string[] contactArray = streamReader.ReadLine().Split(',');
            streamReader.Close();
            return contactArray;
        }

        public void getAge()
        {
            DateTime birthDay = new DateTime(yearBorn, monthBorn, dayBorn);
            DateTime currentDay = new DateTime();
            currentDay = DateTime.Today;
            TimeSpan Age = currentDay.Subtract(birthDay);
            //MessageBox.Show(Age.ToString());
            int.TryParse(Age.ToString(), out int tempAge);
            MessageBox.Show((Age.Days / 365).ToString(), "Your age is");
        }
        
        public void writeToFile()
        {
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter("contact.txt");
            streamWriter.WriteLine(firstName + "," + lastName + "," +
                yearBorn + "," + monthBorn + "," + dayBorn + "," +
                email);
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}
