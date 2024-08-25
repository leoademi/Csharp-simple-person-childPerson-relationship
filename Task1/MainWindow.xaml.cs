using Microsoft.EntityFrameworkCore;
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
using Task1.Models;

namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApplicationDbContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();

        }

        private async void OnPersonClick(object sender, RoutedEventArgs e)
        {
            string identificationNumber = IdentificationNumberTextBox.Text;

            var existingPerson = await _context.Persons
                .Include(p => p.Child)
                .Include(p => p.HealthInsuranceDocument)
                .FirstOrDefaultAsync(p => p.IdentificationNumber == identificationNumber);

            if (existingPerson != null)
            {
                FirstNameTextBox.Text = existingPerson.FirstName;
                LastNameTextBox.Text = existingPerson.LastName;
                CityTextBox.Text = existingPerson.City;
                EmailTextBox.Text = existingPerson.Email;

                if (existingPerson.Child != null && existingPerson.Child.HealthInsuranceDocument != null)
                {
                    var healthInsurance = existingPerson.Child.HealthInsuranceDocument;
                    AccidentDatePicker.SelectedDate = healthInsurance.DateOfAccident;
                    DocumentIdentificationNumberTextBox.Text = healthInsurance.DocumentIdentificationNumber;
                    DoctorNameTextBox.Text = healthInsurance.DoctorName;
                    BodilyInjuriesTextBox.Text = healthInsurance.BodilyInjuries;
                }
            }
            else
            {
                MessageBox.Show("Person not found. Please enter new details.");
            }
        }


        private async void OnPersonSave(object sender, RoutedEventArgs e)
        {
            string identificationNumber = IdentificationNumberTextBox.Text;
            var existingPerson = await _context.Persons
                .Include(p => p.Child)
                .Include(p => p.HealthInsuranceDocument)
                .FirstOrDefaultAsync(p => p.IdentificationNumber == identificationNumber);

            if (existingPerson == null)
            {
                var newPerson = new Person
                {
                    IdentificationNumber = identificationNumber,
                    FirstName = FirstNameTextBox.Text,
                    LastName = LastNameTextBox.Text,
                    City = CityTextBox.Text,
                    Email = EmailTextBox.Text,
                };

                if (AccidentDatePicker.SelectedDate.HasValue && !string.IsNullOrEmpty(DocumentIdentificationNumberTextBox.Text))
                {
                    var childPerson = new ChildPerson
                    {
                        IdentificationNumber = identificationNumber + "-C",
                        FirstName = "Child of " + FirstNameTextBox.Text,
                        LastName = LastNameTextBox.Text,
                        City = CityTextBox.Text,
                        Email = EmailTextBox.Text,
                        Parent = newPerson,
                        HealthInsuranceDocument = new HealthInsuranceDocument
                        {
                            DateOfAccident = AccidentDatePicker.SelectedDate.Value,
                            DocumentIdentificationNumber = DocumentIdentificationNumberTextBox.Text,
                            DoctorName = DoctorNameTextBox.Text,
                            BodilyInjuries = BodilyInjuriesTextBox.Text
                        }
                    };
                    newPerson.Child = childPerson;
                }

              
                _context.Persons.Add(newPerson);
            }
            else
            {
                existingPerson.FirstName = FirstNameTextBox.Text;
                existingPerson.LastName = LastNameTextBox.Text;
                existingPerson.City = CityTextBox.Text;
                existingPerson.Email = EmailTextBox.Text;

                if (existingPerson.Child != null && existingPerson.Child.HealthInsuranceDocument != null)
                {
                    var healthInsurance = existingPerson.Child.HealthInsuranceDocument;
                    healthInsurance.DateOfAccident = AccidentDatePicker.SelectedDate.Value;
                    healthInsurance.DocumentIdentificationNumber = DocumentIdentificationNumberTextBox.Text;
                    healthInsurance.DoctorName = DoctorNameTextBox.Text;
                    healthInsurance.BodilyInjuries = BodilyInjuriesTextBox.Text;
                }
            }

            await _context.SaveChangesAsync();
            MessageBox.Show("Person saved successfully.");
        }
    }
}
