using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Listbox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public MainWindow()
        {
            InitializeComponent();
            Person.AddTestPersons();
            Persons.DataContext = Person.Existing;
        }

        private void Persons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastName"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BirthDateFormated"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PersonalIdentificationNumber"));
            DataContext = Person.Existing[Persons.SelectedIndex];
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = Person.Existing[Persons.SelectedIndex];
        }
    }
}
