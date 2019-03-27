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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Contact contact = new Contact("place holder", "place holder", 0,0,0,"place holder");
        public MainWindow()
        {
            InitializeComponent();
            Contact contactTemp = new Contact("temp", "temp", 0, 0, 0, "temp");
            string[] ContactInfo = contactTemp.readFromFile();
            txtFirstName.Text = ContactInfo[0];
            txtLastName.Text = ContactInfo[1];
            int.TryParse(ContactInfo[2], out int year);
            txtBirthYear.Text = year.ToString();
            int.TryParse(ContactInfo[3], out int month);
            txtBirthMonth.Text = month.ToString();
            int.TryParse(ContactInfo[4], out int day);
            txtBirthDay.Text = day.ToString();
            txtEmail.Text = ContactInfo[5];
        }

        private void btnShowAge_Click(object sender, RoutedEventArgs e) 
        {
            int.TryParse(txtBirthYear.Text, out int Year);
            int.TryParse(txtBirthMonth.Text, out int Month);
            int.TryParse(txtBirthDay.Text, out int Day);
            Contact contactCurrent = new Contact(txtFirstName.Text, txtLastName.Text, Year, Month, Day, txtEmail.Text);
            contactCurrent.getAge();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            int.TryParse(txtBirthYear.Text, out int birthYear);
            int.TryParse(txtBirthMonth.Text, out int birthMonth);
            int.TryParse(txtBirthDay.Text, out int birthDay);
            Contact contactClose = new Contact(txtFirstName.Text, txtLastName.Text, 
                birthYear, birthMonth, birthDay, txtEmail.Text);
           // string[] dzhsg = contact.read
            contactClose.writeToFile();
        }
    }
}
