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
using System.Windows.Shapes;
using System.Collections;


namespace Collection
{
    /// <summary>
    /// Interaction logic for Exercise2.xaml
    /// </summary>
    public partial class Exercise2 : Window
    {
        public Exercise2()
        {
            InitializeComponent();
        }

        private void click_buttonTest(object sender, RoutedEventArgs e)
        {
            AddressBook addressBook = new AddressBook();
            addressBook.test();
        }

    }


    public class AddressBook : IComparer<Person>
    {
        SortedDictionary<int, Person> addressBook = new SortedDictionary<int, Person>();

        public int Compare(Person a, Person b)
        {
            return 0;
        }

        public void test()
        {
            addressBook.Add(1, new Person("Jan", "Kowalski", "Wadowice", "Mickiewicza", 12, 34100));
            addressBook.Add(2, new Person("Adam", "Nowak", "Warszawa", "Kosciuszki", 10, 12345));
            addressBook.Add(3, new Person("Marcin", "Iksinski", "Krakow", "Polna", 43, 98765));
         
            foreach (KeyValuePair<int, Person> person in addressBook)
            {
                Console.WriteLine(person);
            }

        }

    }



    public class Person
    {
        private string
            first_name,
            last_name,
            city,
            street;
        private int
            postCode,
            houseNumber;

        public Person(string first_name, string last_name, string city, string street, int postCode, int houseNumber)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.city = city;
            this.street = street;
            this.postCode = postCode;
            this.houseNumber = houseNumber;
        }
    }

    
}
