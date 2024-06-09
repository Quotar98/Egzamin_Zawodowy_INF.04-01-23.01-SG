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

namespace Desktopowa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string generatePassword = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void GeneratePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            int length = int.Parse(lengthTextBox.Text);
            bool useletters = lettersCheckBox.IsChecked ?? false;
            bool useDigits = digitsCheckBox.IsChecked ?? false;
            bool useSpecialChars = specialCharsCheckBox.IsChecked ?? false;

            generatePassword = GeneratePassword(length, useletters, useDigits, useSpecialChars);
            MessageBox.Show(generatePassword);
        }
        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            string position = ((ComboBoxItem)positionComboBox.SelectedItem).Content.ToString();
            MessageBox.Show($"Dane pracownika: {firstName} {lastName} {position} Hasło: {generatePassword}");
        }

        private string GeneratePassword(int length, bool useLetters, bool useDigits, bool useSpecialChars)
        {
            const string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digits = "0123456789";
            const string specialChars = "!@#$%^&*()_+-=";

            StringBuilder password = new StringBuilder();
            Random random = new Random();

            if (useLetters)
            {
                password.Append(letters[random.Next(letters.Length)]);
            }
            if (useDigits)
            {
                password.Append(digits[random.Next(digits.Length)]);
            }
            if (useSpecialChars)
            {
                password.Append(specialChars[random.Next(specialChars.Length)]);
            }

            for (int i = password.Length; i < length; i++) {
                string validChars = letters;

                if(useLetters)
                {
                    validChars += letters;
                }
                if (useDigits)
                {
                    validChars += digits;
                }
                if (useSpecialChars)
                {
                    validChars += specialChars;
                }

                password.Append(validChars[random.Next(validChars.Length)]);
            }
            return new string(password.ToString().ToCharArray());
        }
    }
}
