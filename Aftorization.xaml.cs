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

namespace bred
{
    public partial class Aftorization : Window
    {
        public Aftorization()
        {
            InitializeComponent();
        }

        public bool IsUser;
        public bool IsSignIn;

        private void SignIn_click(object sender, RoutedEventArgs e)
        {
            if(loginTextBox.Text == "User" && passwordTextBox.Text == "123")
            {
                IsUser = true;
                IsSignIn = true;
                Close();
            }
            else if(loginTextBox.Text == "Admin" && passwordTextBox.Text == "abc")
            {
                IsUser = false;
                IsSignIn = true;
                Close();
            }
        }
    }
}
