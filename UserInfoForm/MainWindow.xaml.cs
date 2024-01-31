using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace UserInfoForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            bool validFields = false;
            bool validPasswords = false;
            try
            {
                validFields = ValidateFields(txtName.Text, Int32.Parse(txtAge.Text), txtEmail.Text);
            }
            catch {
                MessageBox.Show("Please provide a valid age number");
            }
            validPasswords = ValidatePassword(password.Password.ToString(), password2.Password.ToString());

            if (validFields && validPasswords) {
                MessageBox.Show("User information successfully submitted!");
            }
        }

        private void UploadFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Text documents (.txt)|*.txt;*.doc;*.docx";
            fileDialog.FilterIndex = 1;
            if (fileDialog.ShowDialog() == true)
            {
                fileName.Content = fileDialog.FileName;
            }
        }

        private void UploadImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog imgDialog = new OpenFileDialog();
            imgDialog.Filter = "Image files|*.bmp;*.jpg;*.png";
            imgDialog.FilterIndex = 1;
            if (imgDialog.ShowDialog() == true) {
                profileImg.Source = new BitmapImage(new Uri(imgDialog.FileName));
            }
        }

        private bool ValidatePassword(String pass, String pass2) {

            if (pass.Length < 1) {
                MessageBox.Show("Please provide a valid password");
                return false;
            }

            if (pass != pass2) {
                MessageBox.Show("Passwords do not match. Please try again.");
                return false;
            }

            return true;

        }

        private bool ValidateFields(String name, int age, String email ) {
            
            // Empty inputs
            if (name.Length == 0) {
                MessageBox.Show("Please provide a valid name");
                return false;
            }

            if (email.Length == 0) {
                MessageBox.Show("Please provide a valid email");
                return false;
            }

            if (age < 1) {
                MessageBox.Show("Please provide a valid age number");
                return false;
            }

            // Proper format
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!match.Success) {
                MessageBox.Show("Please provide a valid email address");
                return false;
            }

            return true;
        }

    }

}

