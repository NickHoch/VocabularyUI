
using MahApps.Metro.Controls;
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
using VocabularyUI.UserControls;

namespace VocabularyClient
{
    public partial class MainWindow : MetroWindow
    {
        private SignIn signIn = null;
        public MainWindow()
        {
            InitializeComponent();
            signIn = new SignIn();
            contentControl.Content = signIn;
            signIn.AddHandler(SignIn.SignUpClick, new RoutedEventHandler(SignUpButton));
            signIn.AddHandler(SignIn.LoginClick, new RoutedEventHandler(LoginButton));
        }

        private void SignUpButton(object sender, RoutedEventArgs e)
        {
            var signUp = new SignUp();
            contentControl.Content = signUp;
            e.Handled = true;
            signUp.AddHandler(SignUp.ContinueClick, new RoutedEventHandler(ContinueButton));
            signUp.AddHandler(SignUp.CancelClick, new RoutedEventHandler(CancelButton));
        }

        private void LoginButton(object sender, RoutedEventArgs e)
        {
            //this.Close();
        }

        private void ContinueButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
            signIn = new SignIn();
            contentControl.Content = signIn;
            signIn.AddHandler(SignIn.SignUpClick, new RoutedEventHandler(SignUpButton));
            signIn.AddHandler(SignIn.LoginClick, new RoutedEventHandler(LoginButton));
        }

        private void ExitButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
